namespace DBModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Orders
    {
        
        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(10)]
        public string Client { get; set; }

        [Required]
        [StringLength(10)]
        public string Product { get; set; }

        public double Sum { get; set; }

        [Column("Manager Id")]
        public int Manager_Id { get; set; }

        public virtual Managers Managers { get; set; }
    }
}
