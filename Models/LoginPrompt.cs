namespace LoginPromptServer.Models
{
    public class LoginPrompt
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public string Caption { get; set; }

        // seconds
        public double QuietPeriod { get; set; }
    }
}