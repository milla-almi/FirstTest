using Employee.Data;
using System.ComponentModel.DataAnnotations;

namespace Employee.Models
{
    public class EmployementData
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Department { get; set; }
        
        [Required]
        public int Salary { get; set; }
        [Required]
        public int Service { get; set; }
    }
}
