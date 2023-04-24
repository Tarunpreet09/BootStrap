using System.ComponentModel.DataAnnotations;

namespace asssignment.Models
{
    public class students
    {     
        public string? Subject { get; set; }
        public int? Marks { get; set; } 
        public Guid Guid { get; set; }
    }
}
