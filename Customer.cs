namespace ECOMMERCE_AP
{
	public class Customer : Person
	{
		
		public Customer(string firstName, string lastName, string email, string password) : base(firstName, lastName, email, password)	
		{
			Random random = new Random();
			CustomerNo = random.Next(1000000, 9999990);
			Wallet = CreateWallet();
		}
		
		public int CustomerNo { get; }
		public Wallet Wallet {get;set;}
		public List<History> Histories {get;set;} = new List<History>();
		public static List<Customer> Customers { get; set; } = new List<Customer>();
		private Wallet CreateWallet()
		{
			var wallet = new Wallet();
			wallet.Balance = 0m;
			return wallet;
		}
		
		public static Customer AddCustomer(string firstName,string lastName, string email , string password)
		{
			foreach(var cus in Customers)
			{
				if(cus.Email == email)
				{
					Console.WriteLine($"Email {email} already exist");
					return null;
				}
			}
			Customer customer = new Customer(firstName,lastName,email,password);
			Customers.Add(customer);
			Console.WriteLine("Successfully added");
			return customer;
		}
		public static Customer CustomerLogin(string email, string password)
		{
			foreach (Customer cus in Customers)
			{
				if(cus.Email == email && cus.Password == password)
				{
					Console.WriteLine("Successfully Login");
					return cus;
				}
			}
			Console.WriteLine("Email or Password does't exists");
			return null;
		}
		public static void GetAllCustomer()
		{
			if(Customers.Count == 0)
			{
				Console.WriteLine("No available customers");
			}
			int index = 1;
			foreach (Customer cus in Customers)	
			{
				Console.WriteLine($"{index} FirstName :: {cus.FirstName}\tLastName :: {cus.LastName}\tEmail :: {cus.Email}");
				index++;
			}
		} 
		public string PurchasePoduct(string productName , int quantity)
		{
			var product = new Product();
			var availableProduct = product.GetAvailaibleProduct(productName, quantity);
			if(availableProduct == null)
			{
				return "The product is not available at the moment.";
			}
			if(this.Wallet.Balance < quantity * availableProduct.Price)
			{
				return "Insufficient wallet balance";
			}
			availableProduct.Quantity -= quantity;
			var history = new History();
			history.Product = availableProduct;
			history.Customer = this;
			history.Quantity = quantity;
			history.Price = quantity * availableProduct.Price;
			availableProduct.Histories.Add(history);
			this.Histories.Add(history);
			return $"Sucessfully purchased {availableProduct.Name} at {history.DateCreated}";
		}
		public void CreditWallet(decimal amount)
		
		{
			this.Wallet.Balance += amount;
		}
	}
}