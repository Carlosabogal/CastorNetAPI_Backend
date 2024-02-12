using TestNetCore_Castor.Entities;

namespace TestNetCore_Castor.DTO
{
    public class EmployeeDTO
    {

        public int Identification { get; set; }
        public string Name { get; set; }
        public IFormFile Photo { get; set; }
        public DateTime HireDate { get; set; }
        public int PositionId { get; set; }
    }
}
