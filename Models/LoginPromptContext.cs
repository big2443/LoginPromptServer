using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LoginPromptServer.Models
{
    public class LoginPromptContext : DbContext
    {
        public LoginPromptContext(DbContextOptions<LoginPromptContext> options)
            : base(options)
        {
            this.Initialize();
        }

        public DbSet<LoginPrompt> LoginPrompts { get; set; }

        private void Initialize()
        {
            this.Database.EnsureCreated();

            if (this.LoginPrompts.Any())
            {
                return;
            }

            var baseImageUrl = "http://media5.wgt.com/assets/community/images/wgt/";
            var loginPrompts = new LoginPrompt[]
            {
                new LoginPrompt{ImageUrl=baseImageUrl + "sysmessage_2017_wgtvt_mer.jpg", Caption="Play Merion!"},
                new LoginPrompt{ImageUrl=baseImageUrl + "sysmessage_bandon_brackets.jpg", Caption="Play a bracket tournament!"},
                new LoginPrompt{ImageUrl=baseImageUrl + "sysmessage_baseball_golfball.jpg.jpg", Caption="Buy a funny ball!"}
            };
            
            foreach (var p in loginPrompts)
            {
                this.Add(p);
            }

            this.SaveChanges();
        }
    }
}