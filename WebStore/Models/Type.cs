using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStore.Models
{
    [Table("types")]
    public class Type
    {
        [Column("id", Order = 1)]
        [Key]
        public int Id { get; set; }

        [Column("name", Order = 2)]
        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        [Column("description", Order = 3)]
        [StringLength(500)]
        public string Desription { get; set; }


        public virtual ICollection<Clothes> Clothes { get; set; }
    }
}
