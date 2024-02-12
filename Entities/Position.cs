using System.ComponentModel.DataAnnotations;

namespace TestNetCore_Castor.Entities
{
    public class Position
    {
        public int Id { get; set; }

        [Display(Name = "Position Name")]
        public string Name { get; set; }
    }
}
