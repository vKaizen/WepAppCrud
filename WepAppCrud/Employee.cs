using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WepAppCrud
{
    [Table("Employees", Schema = "HR")]
    public class Employee
    {

        [Key]
        [Display(Name = "Employee ID")]
        public int? EmployeeId { get; set; }

        
        [Display(Name = "Employee Name")]
        [Column(TypeName = "varchar(200)")]
        public string EmployeeName { get; set; }

        [Display(Name = "User's image")]
        [Column(TypeName = "varchar(250)")]
        public string? ImageUser { get; set; }


        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public  DateTime BirthDate { get; set; }

        [Display(Name = "Salary")]
        [Column(TypeName = "decimal(12,2)")]
        public decimal Salary { get; set; }

        [Display(Name = "Hiring Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMMM-yyyy}")]
        public DateTime HiringDate { get; set; }


        [Display(Name = "Naitonal Id")]
        [MaxLength(14)]
        [MinLength(14)]
        [Column(TypeName = "varchar(14)")]
        public required string NationalId { get; set; }

        public int DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public Department? department { get; set; }


    }
}
