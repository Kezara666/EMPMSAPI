
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMPMS_API.Data.Employee
{
    public class EmployeeData
    {
        [Key] // Marks this as the primary key
        public int ID { get; set; } // Auto-increment by default in EF

        [Required] // Specifies that the field is required
        [MaxLength(100)] // Optional: Max length for name
        public string Name { get; set; }

        [Required]
        [EmailAddress] // Email format validation
        public string Email { get; set; }

        [Required]
        [Phone] // Phone format validation
        public string Phone { get; set; }

        [Required]
        [Range(0, double.MaxValue)] // Ensures salary is non-negative
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Salary { get; set; }

        [Required]
        [MaxLength(50)] // Optional: Max length for department
        public string Department { get; set; }
    }
}
