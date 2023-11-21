using DataProj.DataContext;
using DataProj.Domain;
using Lib;
using Lib.DTO;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SettlementStatusLib.DTO;
using Util;

namespace SettlementStatusLib;
public class SettlementStatus
{

    
    public async Task<ResponseDTO<SettlementStatusResponseDTO>> SettlementStats()
    {
        
        List<Claim> recordsWithStatus01 = new List<Claim>();

        using (ApplicationDbContext dbContext = new ApplicationDbContext())
        {
            recordsWithStatus01 = await dbContext.Claims
              .Where(claim => claim.Status == Util.Constants.EnumToStringStatus(Util.Status.Settled))
              .ToListAsync();
        }


            if (recordsWithStatus01.Any())
            {
                // Prepare the request only if there are records with status "01"
                var settlement = CreateSettlementRequest(recordsWithStatus01);

                RequestDTO<SettlementStatusRequestDTO> request = new RequestDTO<SettlementStatusRequestDTO>()
                {
                    ApiType = Util.ApiType.POST,
                    Data = settlement,
                    Url = Constants.baseAddress + "authserv_idrs/secured/api/v1/disputed/status"
                };

                NibssService<SettlementStatusRequestDTO, SettlementStatusResponseDTO> nibssService = new NibssService<SettlementStatusRequestDTO, SettlementStatusResponseDTO>();

            var response = await nibssService.SendRequestAsync(request);

            return response;

        }
        else
        {
            Console.WriteLine("No records found!");
            return new ResponseDTO<SettlementStatusResponseDTO>();
        }
        
    }


    private SettlementStatusRequestDTO CreateSettlementRequest(List<Claim> claims)
    {
        var request = new SettlementStatusRequestDTO
        {
            RequestId = "234567890123",
            Data = claims.Select(claim => new DataRequestDTO
            {
                Status = claim.Status,
                DisputeSettlementDate = DateTime.Now.AddHours(-4),
                DisputeTicketID = claim.Disputeticketid
            }).ToList()
        };

        return request;
    }
}

