namespace FoodHunterAlpha.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("fh.menu_category")]
    public partial class menu_category
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long rest_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int cate_id { get; set; }

        [Required]
        [StringLength(100)]
        public string cate_desc { get; set; }

        [StringLength(100)]
        public string second_cate_desc { get; set; }

        [Required]
        [StringLength(200)]
        public string cate_note { get; set; }

        public int cate_seq_no { get; set; }

        public sbyte is_kitchen { get; set; }

        public sbyte is_vip_only { get; set; }

    }
}
