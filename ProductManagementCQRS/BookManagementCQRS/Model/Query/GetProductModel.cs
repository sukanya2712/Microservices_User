namespace BookManagementCQRS.Model.Query
{
    public class GetProductModel
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int qty { get; set; }

        public float price { get; set; }


    }
}
