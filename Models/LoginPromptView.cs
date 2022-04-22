using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginPromptServer.Models
{
    public class LoginPromptView
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int LoginPromptId { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
