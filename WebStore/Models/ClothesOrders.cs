using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStore.Models
{
    [Table("clothes_orders")]
    public class ClothesOrders
    {
        [Column("id", Order = 1)]
        [Key]
        public int Id { get; set; }

        [Column("quantity", Order = 2)]
        [Range(0, int.MaxValue)]
        [Required]
        public int Quantity { get; set; }

        [Column("clothes_sizes_id", Order = 3)]
        [ForeignKey(nameof(ClothesSizes))]
        [Required]
        public int ClothesSizesId { get; set; }

        [Column("order_id", Order = 4)]
        [ForeignKey(nameof(Order))]
        [Required]
        public int OrderId { get; set; }

        public virtual ClothesSizes ClothesSizes { get; set; }
        public virtual Order Order { get; set; }
    }
}
