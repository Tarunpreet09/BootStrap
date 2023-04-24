using System.ComponentModel.DataAnnotations;

namespace asset2.Models
{
    public class social
    {
        [Required]
        public string face { get; set; }

        [Required]
        public string twit { get; set; }

        [Required]
        public string insta { get; set; }

        public string link { get; set; }

        public string pint { get; set; }

        public string you { get; set; }
    }
}
