namespace OrdersModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Column("Seller Id")]
        public int Seller_Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Client { get; set; }

        [Column("Product Id")]
        public int Product_Id { get; set; }

        [Column(TypeName = "real")]
        public double Sum { get; set; }

        public virtual Product Product { get; set; }

        public virtual Seller Seller { get; set; }
    }
}
