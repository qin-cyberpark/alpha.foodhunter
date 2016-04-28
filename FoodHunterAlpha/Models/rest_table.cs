namespace FoodHunterAlpha.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("fh.rest_table")]
    public partial class rest_table
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long rest_id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string table_number { get; set; }

        public short? num_of_seats { get; set; }

        [Column(TypeName = "bit")]
        public bool? is_occupied { get; set; }
    }
}
