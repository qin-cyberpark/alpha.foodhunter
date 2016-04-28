namespace FoodHunterAlpha.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("fh.rest_hours")]
    public partial class rest_hours
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long rest_id { get; set; }

        [Key]
        [Column(Order = 1)]
        public sbyte weekday_num { get; set; }

        [Key]
        [Column(Order = 2)]
        public sbyte period_num { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short open_time { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short close_time { get; set; }
    }
}
