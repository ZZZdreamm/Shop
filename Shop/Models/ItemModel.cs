using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace Shop.Models
{
    public class ItemModel
    {
        [Key]
        public int Id { get; set; }

        public string? Image { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }

        public int ItemsOnStock { get; set; }

        public int ItemsTaken { get; set; } = 0;
        public string? Category { get; set; }

        public bool Available { get; set; }
        public bool Checked { get; set; } = true;
    }
}
