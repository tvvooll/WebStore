using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStore.Models
{
    [Table("clothes_colors")]
    public class ClothesColors
    {
        [Column("id", Order = 1)]
        [Key]
        public int Id { get; set; }

        [Column("clothes_id", Order = 2)]
        [ForeignKey(nameof(Clothes))]
        [Required]
        public int ClothesId { get; set; }

        [Column("color_id", Order = 3)]
        [ForeignKey(nameof(Color))]
        [Required]
        public int ColorId { get; set; }

        public virtual Clothes Clothes { get; set; }
        public virtual Color Color { get; set; }
    }
}
