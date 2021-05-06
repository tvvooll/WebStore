using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStore.Models
{
    [Table("orders")]
    public class Order
    {
        [Column("id", Order = 1)]
        [Key]
        public int Id { get; set; }

        [Column("address",Order = 2)]
        [StringLength(150)]
        [Required]
        public string Address { get; set; }

        [Column("status", Order = 3)]
        [EnumDataType(typeof(Status))]
        [Required]
        public Status Status { get; set; }

        [Column("ordered_date", Order = 4)]
        [Required]
        public DateTime OrderedDate { get; set; }

        [Column("delivered_date", Order = 5)]
        public DateTime DeliveredDate { get; set; }

        public virtual ICollection<ClothesOrders> ClothesOrders { get; set; }
    }

    
    public enum Status
    {
        Ordered,
        Processed,
        FormedInStorage,
        SentFromStorage,
        Delivered,
        Received
    }
}
