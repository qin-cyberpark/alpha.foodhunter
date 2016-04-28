namespace FoodHunterAlpha.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("fh.customer")]
    public partial class customer
    {
        [Key]
        [Column(TypeName = "ubigint")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal cust_id { get; set; }

        [StringLength(50)]
        public string cust_name { get; set; }

        [StringLength(100)]
        public string cust_email { get; set; }

        [StringLength(50)]
        public string cust_password { get; set; }

        [StringLength(50)]
        public string cust_phone { get; set; }

        [StringLength(100)]
        public string cust_address { get; set; }

        [StringLength(20)]
        public string cust_postcode { get; set; }

        [StringLength(100)]
        public string cust_apartment { get; set; }

        [StringLength(50)]
        public string cust_street_num { get; set; }

        [StringLength(50)]
        public string cust_street_name { get; set; }

        [StringLength(50)]
        public string last_ip_addr { get; set; }

        [StringLength(50)]
        public string cust_suburb { get; set; }

        [StringLength(50)]
        public string cust_city { get; set; }

        [StringLength(50)]
        public string cust_country { get; set; }

        [StringLength(50)]
        public string cust_region { get; set; }

        [StringLength(10)]
        public string cust_country_code { get; set; }

        public float? cust_lat { get; set; }

        public float? cust_lng { get; set; }

        public bool? is_verified { get; set; }

        [Column(TypeName = "ubigint")]
        public decimal? created_by_rest_id { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime? date_created { get; set; }
    }
}
