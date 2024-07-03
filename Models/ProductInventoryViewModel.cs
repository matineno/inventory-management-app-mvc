namespace martins_aleogho_IntroToLinqAndAsp.netLab1.Models {
    public class ProductInventoryViewModel {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
    }
}
