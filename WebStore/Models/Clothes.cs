using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStore.Models
{
    [Table("clothes")]
    public class Clothes
    {
        [Column("id", Order = 1)]
        [Key]
        public int Id { get; set; }

        [Column("name", Order = 2)]
        [StringLength(100)]
        [Required]
        public string Name { get; set; }

        [Column("type_id", Order = 3)]
        [ForeignKey(nameof(Type))]
        [Required]
        public int TypeId { get; set; }

        [Column("material_id", Order = 4)]
        [ForeignKey(nameof(Material))]
        [Required]
        public int MaterialId { get; set; }

        public virtual Type Type { get; set; }
        public virtual Material Material { get; set; }
    }
}
