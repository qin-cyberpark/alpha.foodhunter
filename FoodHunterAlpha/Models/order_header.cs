namespace FoodHunterAlpha.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("fh.order_header")]
    public partial class order_header
    {
        [Key]
        public long order_id { get; set; }

        public long? rest_id { get; set; }

        public long? cust_id { get; set; }

        public DateTime? order_datetime { get; set; }

        [StringLength(20)]
        public string order_ip_addr { get; set; }

        public decimal? header_disc { get; set; }

        [StringLength(100)]
        public string disc_comment { get; set; }

        [StringLength(20)]
        public string order_type { get; set; }

        public bool? is_acknowledged { get; set; }

        public bool? is_cust_confirmed { get; set; }

        public bool? is_served { get; set; }

        public bool? is_paid { get; set; }

        public DateTime? date_paid { get; set; }

        public bool? is_online_order { get; set; }

        public DateTime? expected_time { get; set; }

        public bool? is_asap { get; set; }

        public DateTime? serve_time { get; set; }

        [StringLength(50)]
        public string order_status { get; set; }

        [StringLength(50)]
        public string table_number { get; set; }

        [StringLength(200)]
        public string cust_note { get; set; }

        public short? num_of_people { get; set; }

        public decimal? delivery_charge { get; set; }

        [StringLength(50)]
        public string cust_name { get; set; }

        [StringLength(50)]
        public string cust_phone { get; set; }

        [StringLength(100)]
        public string cust_apartment { get; set; }

        [StringLength(100)]
        public string cust_address { get; set; }

        [StringLength(20)]
        public string cust_postcode { get; set; }

        public decimal? card_charge { get; set; }

        public sbyte? is_paid_by_card { get; set; }

        public sbyte? is_via_qr { get; set; }

        [StringLength(255)]
        public string user_agent { get; set; }

        public bool? is_pos_synced { get; set; }

        [StringLength(50)]
        public string sync_batch_id { get; set; }
    }
}
