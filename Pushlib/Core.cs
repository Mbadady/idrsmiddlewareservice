using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib;
using Lib.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Pushlib;
//using Pushlib.Data;
using Pushlib.DTO;
using repocore;
//using Pushlib.Domain;
using Util;
using static Org.BouncyCastle.Bcpg.Attr.ImageAttrib;


namespace Pushlib
{
    public class Core
    {

        

        public static async Task<ResponseDTO<PushResponseDTO>> Push()
        { 

            var requestDTO = new Repo();

            var pushRequest = requestDTO.GetTransactions(DateTime.Parse("2023-02-01"));

            
            PushRequestDTO pushRequestDTO = new PushRequestDTO()
            { 
                Transactions = pushRequest,
            };


             RequestDTO<PushRequestDTO> request = new RequestDTO<PushRequestDTO>()
            {
                ApiType = Util.ApiType.POST,
                Data = pushRequestDTO,
                Url = Constants.baseAddress + "authserv_idrs/secured/api/v1/transaction"
            };


            NibssService<PushRequestDTO, PushResponseDTO> nibssService = new NibssService<PushRequestDTO, PushResponseDTO>();

           var response =  await nibssService.SendRequestAsync(request);

            //var jsonStringResponse = response.Data + "";

            //var settlementResponse = JsonConvert.DeserializeObject<PushResponseDTO>(jsonStringResponse);

            return response;
        }

    }
}

