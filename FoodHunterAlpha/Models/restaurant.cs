namespace FoodHunterAlpha.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("fh.restaurant")]
    public partial class restaurant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long rest_id { get; set; }

        [Required]
        [StringLength(50)]
        public string rest_name { get; set; }

        [Required]
        [StringLength(50)]
        public string second_rest_name { get; set; }

        [Required]
        [StringLength(400)]
        public string rest_desc { get; set; }

        [Required]
        [StringLength(100)]
        public string apartment { get; set; }

        [Required]
        [StringLength(100)]
        public string address { get; set; }

        [StringLength(50)]
        public string suburb { get; set; }

        [StringLength(50)]
        public string city { get; set; }

        [StringLength(10)]
        public string country_code { get; set; }

        [StringLength(50)]
        public string country { get; set; }

        public float rest_lat { get; set; }

        public float rest_lng { get; set; }

        [Required]
        [StringLength(5)]
        public string currency_symbol { get; set; }

        [Required]
        [StringLength(10)]
        public string currency_code { get; set; }

        [Required]
        [StringLength(50)]
        public string phone_num { get; set; }

        [StringLength(100)]
        public string logo_loc { get; set; }

        [Required]
        [StringLength(50)]
        public string login_email { get; set; }

        [Required]
        [StringLength(50)]
        public string login_password { get; set; }

        [StringLength(50)]
        public string last_ip_addr { get; set; }

        [Column(TypeName = "binary")]
        public byte[] is_online_order_enabled { get; set; }

        [Column(TypeName = "binary")]
        public byte[] is_vip_cust_enabled { get; set; }

        [Column(TypeName = "binary")]
        public byte[] is_staff_order_enabled { get; set; }

        [Column(TypeName = "binary")]
        public byte[] is_online_payment_enabled { get; set; }

        [StringLength(10)]
        public string online_payment_charge_type { get; set; }

        public sbyte? online_payment_charge_percent { get; set; }

        public decimal? online_payment_charge_amount { get; set; }

        [Column(TypeName = "binary")]
        public byte[] is_delivery_enabled { get; set; }

        [Column(TypeName = "binary")]
        public byte[] is_dinein_enabled { get; set; }

        [StringLength(50)]
        public string order_notice_email { get; set; }

        [StringLength(50)]
        public string order_notice_mobile { get; set; }

        [Column(TypeName = "binary")]
        public byte[] is_activated { get; set; }

        [StringLength(60)]
        public string activation_key { get; set; }

        [StringLength(30)]
        public string rest_category { get; set; }

        [Column(TypeName = "date")]
        public DateTime? account_active_until_date { get; set; }

        [Column(TypeName = "date")]
        public DateTime? register_date { get; set; }

        public decimal? delivery_charge { get; set; }

        public decimal? delivery_distance_limit { get; set; }

        public decimal? free_delivery_min_amt { get; set; }

        public short? wait_time { get; set; }

        public short? delivery_time { get; set; }

        [StringLength(500)]
        public string delivery_term { get; set; }

        public int? rep_id { get; set; }

        public int? item_count { get; set; }

        [Column(TypeName = "binary")]
        public byte[] is_dinein_online_payment_enabled { get; set; }

        [Column(TypeName = "binary")]
        public byte[] is_delivery_online_payment_enabled { get; set; }

        [Column(TypeName = "binary")]
        public byte[] is_pickup_online_payment_enabled { get; set; }

        [Column(TypeName = "binary")]
        public byte[] is_dinein_payment_to_staff_enabled { get; set; }

        [Column(TypeName = "binary")]
        public byte[] is_delivery_payment_to_staff_enabled { get; set; }

        [Column(TypeName = "binary")]
        public byte[] is_pickup_payment_to_staff_enabled { get; set; }

        public short? order_verify_type { get; set; }

    }
}
