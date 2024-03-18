namespace ECOMMERCE_AP
{
	public class Product
	{
		public string Name { get; set; }
		public decimal Price { get; set; }
		public int Quantity { get; set; }
		public Product(string name, decimal price, int quantity)
		
		{
			Name = name; 
			Price = price; 
			Quantity = quantity;
		}
		public Product()
		{
			
		}
		public List<History> Histories {get;set;} = new List<History>();
		public static List<Product> Products { get; set; } = new List<Product>();
		
		public Product AddProduct(string name, decimal price, int quantity)
		{
			Product product = new Product(name , price, quantity);
			Products.Add(product);
			return product;
		}
		
		public Product GetAvailaibleProduct (string name, int quantity)
		{
			Product product = null;
			foreach (var goods in Products)
			{
				if(goods.Name == name && goods.Quantity >= quantity)
				
				{
					product = goods;
					break;
				}
			}
			return product;
		}

		public void GetAllProduct()
		{
            Console.WriteLine("List of all product");
            foreach (var product in Products)
			{
                Console.WriteLine($"Name :: {product.Name}\tPrice :: {product.Price}\tQuantity :: {product.Quantity}");
            }
		}
	}
}