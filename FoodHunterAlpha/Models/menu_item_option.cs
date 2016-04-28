namespace FoodHunterAlpha.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("fh.menu_item_option")]
    public partial class menu_item_option
    {
        [Key]
        public int menu_item_option_id { get; set; }

        public long? rest_id { get; set; }

        public long? item_id { get; set; }

        public int? option_group_id { get; set; }

        [StringLength(50)]
        public string option_group_desc { get; set; }

        public int? option_number { get; set; }

        [StringLength(50)]
        public string option_desc { get; set; }

        [StringLength(50)]
        public string second_option_desc { get; set; }

        public decimal? price_difference { get; set; }

        public sbyte? is_default_option { get; set; }

        [StringLength(10)]
        public string item_code { get; set; }
    }
}
