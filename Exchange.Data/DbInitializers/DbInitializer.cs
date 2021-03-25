using System.Collections.Generic;
using System.Threading.Tasks;
using Exchange.Data.Contexts;
using Exchange.Domain.Entity;
using Exchange.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Exchange.Data.DbInitializers
{
    public class DbInitializer
    {

        public static async Task Initialize(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            await CreateAdmin(context, userManager);
            await CreateCurrencies(context);

            await context.SaveChangesAsync();
        }

        private static async Task CreateAdmin(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            if (!await context.Users.AnyAsync(x => x.UserName == "Admin"))
            {
                var user = new ApplicationUser {Email = "Admin@user.com", UserName = "Admin@user.com"};
                await userManager.CreateAsync(user, "1qaz!QAZ");
            }
        }

        private static async Task CreateCurrencies(ApplicationDbContext context)
        {
            //USD, EUR, BRL, GBP, and AUD
            var currencyList = new List<Currency>
            {
                new Currency("USD", "US dollar","US"),
                new Currency("EUR", "Euro","EU"),
                new Currency("BRL", "Brazilian real","BR"),
                new Currency("GBP", "Pound sterling","GB"),
                new Currency("AUD", "Australian dollar","AU")

            };

            foreach (var currency in currencyList)
            {
                if (!await context.Set<Currency>().AnyAsync(x => x.Code == currency.Code))
                {
                    await context.AddAsync(currency);
                }
            }

            
        }


    }
}