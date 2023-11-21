using System;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Lib.DTO;
using System.Text;
using Util;
using industrydmspush;

namespace Lib
{
	public class NibssService<TRequest, TResponse> 
	{
        private readonly HttpClient _httpClient;

        public NibssService()
        {
            _httpClient = new HttpClient();

            _httpClient.DefaultRequestHeaders.Add("Authorization", Constants.Base64Enconding());
            _httpClient.DefaultRequestHeaders.Add("SIGNATURE", Constants.SignatureSHA());
            _httpClient.DefaultRequestHeaders.Add("SIGNATURE_METH", "SHA256");
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            _httpClient.DefaultRequestHeaders.Add("Accept", "text/plain");
            

        }

        public async Task<ResponseDTO<TResponse>> SendRequestAsync(RequestDTO<TRequest> requestDTO)
        {
            try
            {
                var httpRequestMessage = new HttpRequestMessage();

                httpRequestMessage.RequestUri = new Uri(requestDTO.Url);
                //httpRequestMessage.Headers.Add("Content-Type", "text/plain");


                if (requestDTO.Data != null)
                {
                    
                    string text = JsonConvert.SerializeObject(requestDTO.Data);
                    Console.WriteLine(text);
                    //Encrypt data
                    string encryptedText = Encryption.encrypt(text, Constants.aeskey, Constants.ivspec);
                    
                    httpRequestMessage.Content = new StringContent(encryptedText, Encoding.UTF8, "text/plain");

                }

                HttpResponseMessage httpResponseMessage = null;

                switch (requestDTO.ApiType)
                {
                    case ApiType.POST:
                        httpRequestMessage.Method = HttpMethod.Post;
                        break;
                    case ApiType.PUT:
                        httpRequestMessage.Method = HttpMethod.Put;
                        break;
                    case ApiType.DELETE:
                        httpRequestMessage.Method = HttpMethod.Delete;
                        break;
                    default:
                        httpRequestMessage.Method = HttpMethod.Get;
                        break;
                }



                httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage);

                switch (httpResponseMessage.StatusCode)
                {
                    case System.Net.HttpStatusCode.PreconditionFailed:
                        return new ResponseDTO<TResponse>
                        {
                            Message = "Precondition Failed",
                            StatusCode = (int)httpResponseMessage.StatusCode,
                            Data = default(TResponse)
                        };

                    case System.Net.HttpStatusCode.BadRequest:
                        var apiContent = await httpResponseMessage.Content.ReadAsStringAsync();
                        string decryptedContent = Encryption.decrypt(apiContent, Constants.aeskey, Constants.ivspec);

                        Console.WriteLine(decryptedContent);

                        var responseDTO = new ResponseDTO<TResponse>
                        { 
                            Message = "Bad Request",
                            StatusCode = (int)httpResponseMessage.StatusCode,
                            Data = JsonConvert.DeserializeObject<TResponse>(decryptedContent)
                        };
                        return responseDTO;


                    case System.Net.HttpStatusCode.OK:

                        var apiContent2 = await httpResponseMessage.Content.ReadAsStringAsync();
                        string decryptedContent2 = Encryption.decrypt(apiContent2, Constants.aeskey, Constants.ivspec);
                        var data = JsonConvert.DeserializeObject<TResponse>(decryptedContent2);
                        Console.WriteLine(data);
                        return new ResponseDTO<TResponse>
                        {
                            IsSuccess = true,
                            Message = "Success",
                            StatusCode = (int)httpResponseMessage.StatusCode,
                            //Data = new List<object>()
                            Data = data
                        };

                    default:
                        var apiContent1 = await httpResponseMessage.Content.ReadAsStringAsync();

                        string decryptedContent1 = Encryption.decrypt(apiContent1, Constants.aeskey, Constants.ivspec);

                        Console.WriteLine(decryptedContent1);

                        var responseDTO1 = new ResponseDTO<TResponse>
                        {
                            Message = "",
                            StatusCode = (int)httpResponseMessage.StatusCode,
                            Data = JsonConvert.DeserializeObject<TResponse>(decryptedContent1)
                        };

                        return responseDTO1;
                }
            }

            catch (Exception ex)
            {
                var dto = new ResponseDTO<TResponse>
                {
                    Message = ex.Message,
                    

                };

                return dto;
            }
            finally
            {
                _httpClient.Dispose();
            }

        }
    }
}


