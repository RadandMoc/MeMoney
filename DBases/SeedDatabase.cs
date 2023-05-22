using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace MeMoney.DBases
{
    
        public static class SeedDatabase
        {
            public static void Initialize(IServiceProvider serviceProvider)
            {
            using (var context = new MyDbContext(serviceProvider.GetRequiredService<
                DbContextOptions<MyDbContext>>()))
            {
                // Look for any existing data
                if (context.MemAuthor.Any())
                {
                    return;   // Data was already seeded
                }

                var author = new MemAuthor
                {
                    NickName = "Janek123",
                    Imie = "Jan",
                    Nazwisko = "Kowalski",
                    BankAccountNumber = "PL61109010140000071219812874",
                    OffersMemAuthor = new List<OfferMemAuthor>()
                };

                context.SaveChanges();
            }
            }
        }

    
}
