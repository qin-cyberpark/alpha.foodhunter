namespace FoodHunterAlpha.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("fh.rest_cust_details")]
    public partial class rest_cust_details
    {
        public long? rest_id { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long cust_id { get; set; }

        [StringLength(100)]
        public string cust_email { get; set; }

        [StringLength(50)]
        public string cust_name { get; set; }

        [StringLength(50)]
        public string cust_phone { get; set; }

        [StringLength(100)]
        public string cust_address { get; set; }

        [StringLength(100)]
        public string cust_apartment { get; set; }
    }
}
