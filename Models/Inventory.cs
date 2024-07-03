using System.ComponentModel.DataAnnotations.Schema;

namespace martins_aleogho_IntroToLinqAndAsp.netLab1.Models {
    public class Inventory {
        public int Id { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public int StockQuantity { get; set; }
        public virtual Product Product { get; set;}
    }
}