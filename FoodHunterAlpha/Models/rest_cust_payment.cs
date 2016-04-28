namespace FoodHunterAlpha.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("fh.rest_cust_payment")]
    public partial class rest_cust_payment
    {
        public long? rest_id { get; set; }

        public long? cust_id { get; set; }

        [Key]
        [Column(Order = 0)]
        public decimal payment { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime date_paid { get; set; }

        [Key]
        [Column(Order = 2)]
        public decimal remain_balance { get; set; }
    }
}
