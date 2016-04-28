namespace FoodHunterAlpha.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("fh.sales_rep")]
    public partial class sales_rep
    {
        [Key]
        [Column(TypeName = "uint")]
        public long rep_id { get; set; }

        [Required]
        [StringLength(20)]
        public string rep_code { get; set; }

        [Required]
        [StringLength(50)]
        public string rep_family_name { get; set; }

        [StringLength(50)]
        public string rep_surname { get; set; }

        [StringLength(100)]
        public string rep_address { get; set; }

        [StringLength(100)]
        public string rep_apartment { get; set; }

        [StringLength(50)]
        public string rep_city { get; set; }

        [StringLength(50)]
        public string rep_country { get; set; }

        [StringLength(50)]
        public string rep_phone { get; set; }

        [Required]
        [StringLength(50)]
        public string rep_email { get; set; }

        [Required]
        [StringLength(50)]
        public string rep_password { get; set; }
    }
}
