using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStore.Models
{
    [Table("colors")]
    public class Color
    {
        [Column("id", Order = 1)]
        [Key]
        public int Id { get; set; }

        [Column("name", Order = 2)]
        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        [Column("hex", Order = 3)]
        [StringLength(10)]
        public string Hex { get; set; }


        public virtual ICollection<ClothesColors> ClothesColors { get; set; }
    }
}
