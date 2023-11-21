using System.Xml;
using Lib;
using Lib.DTO;
using Microsoft.EntityFrameworkCore;
//using SettlementNotificationLib.Domain;
using SettlementNotificationLib.DTO;
using Util;
using SettlementNotificationLib;
using SettlementNotificationLib.Repository;
using Newtonsoft.Json;
using DataProj.Domain;
using DataProj.DataContext;

namespace SettlementNotificationLib;
public class SettlementNotification
{
    public async Task<ResponseDTO<SettlementNotificationResponseDTO>> SettlementNotify()
    {

        SettlementNotificationRequestDTO settlement = new SettlementNotificationRequestDTO()
        {
            StartDate = new DateTime(2023, 10, 19, 14, 0, 0),
            //StartDate = DateTime.Now.AddDays(-1),
            //EndDate = DateTime.Now.AddHours(-10),
            EndDate = new DateTime(2023, 10, 19, 16, 50, 0),
            IncludeFetchedDisputes = 1,
            IncludeAllStatus = 1,
            RequestId = "124785478579",
            PageNumber = 1

        };


        RequestDTO<SettlementNotificationRequestDTO> request = new RequestDTO<SettlementNotificationRequestDTO>()
        {
            ApiType = Util.ApiType.POST,
            Data = settlement,
            Url = Constants.baseAddress + "authserv_idrs/secured/api/v1/disputed/unsettled"
        };

        NibssService<SettlementNotificationRequestDTO, SettlementNotificationResponseDTO> nibssService = new NibssService<SettlementNotificationRequestDTO, SettlementNotificationResponseDTO>();

        var response = await nibssService.SendRequestAsync(request);

        //var jsonString = response.Data + "";

        //var jsondata = JsonConvert.DeserializeObject<SettlementNotificationResponseDTO>(jsonString);

        //IEnumerable<DataResponseData> dataResponses = jsondata.Data;

        var dataResponses = response.Data.Data;

        List<Claim> claimDataList = new List<Claim>();

        foreach (var dataResponse in dataResponses)
        {
             var claimsData = new Claim()
            {
                Acqrrn = dataResponse.AcquirerRRN,
                Status = dataResponse.Status,
                Stan = dataResponse.STAN,
                Amount = dataResponse.Amount,
                Arn = dataResponse.ARN,
                Dateoftransaction = dataResponse.DateOfTransaction,
                Disputeticketid = dataResponse.DisputeTicketId,
                Transactionamount = dataResponse.TransactionAmount,
                Processoridtransactionid = dataResponse.ProcessorIDTransactionID,
                Disputetype = dataResponse.DisputeType
            };

            claimDataList.Add(claimsData);
        }

        try
        {
            // Add the entity (claimsData) to the database context
            await new ClaimRepository().AddClaimAsync(claimDataList);

            Console.WriteLine("Data inserted successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);
        }

        // Get TransactionID and Save to a file
        GetTransactionID();
        
        return response;
    }

    private static void GetTransactionID()
    {
        using (var applicationDbContext = new ApplicationDbContext())
        {
            var data = applicationDbContext.Claims
                                            .Select(item => item.Processoridtransactionid); //.ToList();

            var prefix = "UPSL-";

            var modifiedData = data.Select(item => item.Substring(prefix.Length)).ToList();


            SaveTransactionIDToFile(Util.Constants.transactiondatapath, modifiedData);                        

        }
    }

    private static void SaveTransactionIDToFile(string filePath, List<string> data)
    {
        File.WriteAllText(filePath, string.Join(Environment.NewLine, data));
    }
}

