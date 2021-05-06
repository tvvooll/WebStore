using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStore.Models
{
    [Table("sizes")]
    public class Size
    {
        [Column("id", Order = 1)]
        [Key]
        public int Id { get; set; }

        [Column("eu_size", Order = 2)]
        [StringLength(50)]
        public string EuSize { get; set; }

        [Column("uk_size", Order = 3)]
        [StringLength(50)]
        public string UkSize { get; set; }

        [Column("us_size", Order = 4)]
        [StringLength(50)]
        public string UsSize { get; set; }

        
        public virtual ICollection<ClothesSizes> ClothesSizes { get; set; }
    }
}
