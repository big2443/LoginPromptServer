using Microsoft.EntityFrameworkCore;
using System;
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
        public DbSet<User> Users { get; set; }
        public DbSet<LoginPromptView> LoginPropmtViews { get; set; }

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

            var users = new User[]
            {
                new User{ UserName = "User1"},
                new User{UserName = "User2"},
                new User{ UserName = "User3"},

            };

            foreach (var u in users)
            {
                this.Add(u);
            }

            

            this.SaveChanges();
        }
    }
}