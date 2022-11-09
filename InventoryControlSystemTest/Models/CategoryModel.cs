using System.ComponentModel.DataAnnotations;

namespace InventoryControlSystemTest.Models
{
    public class CategoryModel
    {
        [Key]
        public int IdCategory { get; set; }

        [Required, MaxLength(128)]
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

}
