using System.ComponentModel.DataAnnotations;

namespace TestNetCore_Castor.Entities
{
    public class Employee
    {

        public int Id { get; set; }

        [Display(Name = "Identification Number")]
        public int Identification { get; set; }

        [Display(Name = "Full Name")]
        public string Name { get; set; }

        [Display(Name = "Photo")]
        public byte[] Photo { get; set; } 

        [Display(Name = "Hire Date")]
        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }

        public int PositionId { get; set; }
    }
}
