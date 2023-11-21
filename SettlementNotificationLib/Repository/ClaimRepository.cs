using DataProj.DataContext;
using DataProj.Domain;
using System;
//using SettlementNotificationLib.Domain;

namespace SettlementNotificationLib.Repository
{
	public class ClaimRepository
	{
		private readonly ApplicationDbContext context;

		public ClaimRepository()
		{
			context = new ApplicationDbContext();
		}

		public async Task AddClaimAsync(List<Claim> claims)
		{
			foreach(var claim in claims)
			{
                await context.Claims.AddAsync(claim);
            }

			await context.SaveChangesAsync();
		}



	}
}

