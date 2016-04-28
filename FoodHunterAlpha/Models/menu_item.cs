namespace FoodHunterAlpha.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("fh.menu_item")]
    public partial class menu_item
    {
        [Key]
        public long item_id { get; set; }

        public int cate_id { get; set; }

        public long? rest_id { get; set; }

        [StringLength(200)]
        public string item_desc { get; set; }

        [StringLength(200)]
        public string second_item_desc { get; set; }

        [StringLength(500)]
        public string item_note { get; set; }

        [StringLength(10)]
        public string item_code { get; set; }

        public decimal? item_price { get; set; }

        [StringLength(100)]
        public string photo_loc { get; set; }

        [StringLength(100)]
        public string thumb_loc { get; set; }

        [StringLength(500)]
        public string item_label { get; set; }


    }
}
