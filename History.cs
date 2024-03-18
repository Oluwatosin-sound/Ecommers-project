namespace ECOMMERCE_AP
{
	public class History
	{
		public Product Product { get; set; }
		public int Quantity { get; set; }
		public decimal Price { get; set; }
		public DateTime DateCreated { get; set; } = DateTime.Now;
		public Customer Customer { get; set;}
        public override string ToString()
        {
            return $"{Product.Name}\t {Price}\t{Quantity}\t{DateCreated}";
        }
    	
	}
}