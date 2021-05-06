using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStore.Models
{
    [Table("clothes_sizes")]
    public class ClothesSizes
    {
        [Column("id", Order = 1)]
        [Key]
        public int Id { get; set; }

        [Column("quantity", Order = 2)]
        [Range(0, int.MaxValue)]
        [Required]
        public int Quantity { get; set; }

        [Column("price", Order = 3)]
        [DataType(DataType.Currency)]
        [Range(0, int.MaxValue)]
        [Required]
        public decimal Price { get; set; }

        [Column("clothes_id", Order = 4)]
        [ForeignKey(nameof(Clothes))]
        [Required]
        public int ClothesId { get; set; }

        [Column("size_id", Order = 5)]
        [ForeignKey(nameof(Size))]
        [Required]
        public int SizeId { get; set; }


        public virtual Clothes Clothes { get; set; }
        public virtual Size Size { get; set; }
        public virtual ICollection<ClothesOrders> ClothesOrders { get; set; }
    }
}
