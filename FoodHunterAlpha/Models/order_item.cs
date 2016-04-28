namespace FoodHunterAlpha.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("fh.order_item")]
    public partial class order_item
    {
        [Key]
        [Column(Order = 0, TypeName = "ubigint")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal order_item_id { get; set; }

        [Column(TypeName = "ubigint")]
        public decimal? rest_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long order_id { get; set; }

        public long item_id { get; set; }

        [StringLength(10)]
        public string item_code { get; set; }

        [StringLength(200)]
        public string item_desc { get; set; }

        [StringLength(100)]
        public string second_item_desc { get; set; }

        [StringLength(10)]
        public string option_code { get; set; }

        public decimal? price { get; set; }

        public int? quantity { get; set; }

        public decimal? item_disc { get; set; }

        public bool? is_served { get; set; }

        public bool? is_paid { get; set; }

        public sbyte? is_pos_synced { get; set; }

        [StringLength(50)]
        public string sync_batch_id { get; set; }
    }
}
