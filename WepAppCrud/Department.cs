using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WepAppCrud
{

    [Table("Departments", Schema = "HR")]
    public class Department
    {

        [Key]
        [Display(Name = "Department ID")]
        public int DepartmentId { get; set; }


        [Display(Name = "Department Name")]
        [Column("varchar(300)")]
        public String? DepartmentName { get; set; }

    }
}
