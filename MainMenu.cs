using System.Runtime.CompilerServices;

namespace ECOMMERCE_AP
{
	public class MainMenu
	{
		int attempt = 1;
         Product product = new Product();
		public void Menu()
		{
			Console.WriteLine("Welcome to ECOMMERCE");
			Console.WriteLine("Input 1 to Register as Admin \nInput 2 to register as customer \nInput 3 to login as admin \n Input 4 to login as Customer");
			string input = Console.ReadLine();
			if(input == "1")
			{
			   RegisterAdminMenu();
			}
			else if(input == "2")
			{
				RegisterCustomerMenu();
			}
			else if(input == "3")
			{
				AdminLoginMenu();
			}
			else if(input == "4")
			{
				CustomerLoginMenu();
				
			}
			else
			{
				Console.WriteLine("Invalid input");
				Menu();
			}
		}
		public void RegisterAdminMenu()
		{
			Console.WriteLine("Enter your firstName");
			string firstName = Console.ReadLine();
			Console.WriteLine("Enter your lastName");
			string lastName = Console.ReadLine();
			Console.WriteLine("Enter your email");
			string email = Console.ReadLine();
			Console.WriteLine("Enter your password");
			string password = Console.ReadLine();
			var admin = Admin.RegisterAdmin(firstName, lastName, email,password);
			if(admin == null)
			{
				Menu();
			}
			else
			{
				Console.WriteLine("Enter 1 to login or any key to go to main menu");
				string key = Console.ReadLine();
				if(key == "1")
				{
					
				AdminLoginMenu();
				}
				else
				{
					Menu();
				}
			}
		}
		public void RegisterCustomerMenu()
		{
			Console.WriteLine("Enter your firstName");
			string firstName = Console.ReadLine();
			Console.WriteLine("Enter your lastName");
			string lastName = Console.ReadLine();
			Console.WriteLine("Enter your email");
			string email = Console.ReadLine();
			Console.WriteLine("Enter your password");
			string password = Console.ReadLine();
			var customer = Customer.AddCustomer(firstName, lastName, email,password);
			if(customer == null)
			{
				Menu();
			}
			else
			{
				
				 Console.WriteLine("Enter 1 to login or any key to go to main menu");
				string key = Console.ReadLine();
				if(key == "1")
				{
					
				 CustomerLoginMenu();
				}
				else
				{
					Menu();
				}
			}
		}
		public void AdminLoginMenu()
		{
			Console.WriteLine();
			Console.WriteLine("Welcome to Admin Login Page");
			Console.WriteLine("Enter your email");
			string email = Console.ReadLine();
			Console.WriteLine("Enter your password");
			string password = Console.ReadLine();
			var admin = Admin.AdminLogin(email, password);
			if(admin == null)
			{
				
				if(attempt == 3)
				{
					Console.WriteLine("Too many attempt");
					attempt =1 ;
					Menu();
				}
				Console.WriteLine("Enter 1 to continue or any key to cancel");
				string key = Console.ReadLine();
				if(key == "1")
				{
					
					attempt++;
					AdminLoginMenu();
				}
				else
				{
					attempt = 1;
					Menu();
				}
			}
			else
			{
				AdminDashboard();
			}
		}
		public void CustomerLoginMenu()
		{
			Console.WriteLine();
			Console.WriteLine("Welcome to Customer Login Page"); 
			
			Console.WriteLine("Enter your email");
			string email = Console.ReadLine();
			Console.WriteLine("Enter your password");
			string password = Console.ReadLine();
			var customer = Customer.CustomerLogin(email, password);
			if(customer == null)
			{
				
				if(attempt == 3)
				{
					Console.WriteLine("Too many attempt");
					attempt = 1;
					Menu();
				}
				Console.WriteLine("Enter 1 to continue or any key to cancel");
				string key = Console.ReadLine();
				if(key == "1")
				{
					
					attempt++;
					CustomerLoginMenu();
				}
				else
				{
					attempt = 1;
					Menu();
				}
			}
			else
			{
				CustomerDashboard(customer);
			}
		}
		public void AdminDashboard()
		{

			Console.WriteLine("Welcome to admin Dashboard");
			Console.WriteLine("press 1 to view all customers\n press 2 to add product\n press 3 to get all product\npress 4 to logout");
			string key = Console.ReadLine();
			if(key == "1")
			{
				GetAllCustomer();
				Console.WriteLine();
				Console.WriteLine("Enter any key to continue...");
				Console.ReadKey();
				AdminDashboard();
			}
			else if(key == "2")
			{
				AddProduct();
			}
			else if(key == "3")
			{
				GetAllProducts();
			}
			else if(key == "4")
			{
				Menu();
			}
			else
			{
				Console.WriteLine("Invalid input");
				AdminDashboard();
			}
		}
		public void CustomerDashboard(Customer customer)
		{

			Console.WriteLine("Welcome to customer Dashboard");
			Console.WriteLine("press 1 to view all products\n press 2 to buy product\n press 3 to credit wallet\npress 4 view history\n press 5 to view wallet balance\npress 6 to logout");
			string key = Console.ReadLine();
			switch(key)
			{
				case "1":
				product.GetAllProduct();
				CustomerDashboard(customer);
				break;
				case "2":
				Console.WriteLine("Enter product name");
				string productName = Console.ReadLine();
				Console.WriteLine("Enter the quantity");
				int quantity = int.Parse(Console.ReadLine());
				var mssg = customer.PurchasePoduct(productName, quantity);
				Console.WriteLine(mssg);
				CustomerDashboard(customer);
				break;
				case "3" :
				Console.WriteLine("Enter the amount");
				var amount = decimal.Parse(Console.ReadLine());
				customer.Wallet.Balance += amount;
				CustomerDashboard(customer);
				break;
				case "4" :
					foreach (var item in customer.Histories)
					{
						Console.WriteLine(item);
					}
					CustomerDashboard(customer);
				break;
				case "5" :
				Console.WriteLine(customer.Wallet.Balance);
				CustomerDashboard(customer);
				break;
				case "6" :
				Menu();
				break;
				default :
				Console.WriteLine("Invalid input");
				Menu();
				break;
				

			}
	
		}
		public void GetAllCustomer()
		{
			Customer.GetAllCustomer();
		}
		public void AddProduct()
		{
			Console.WriteLine("Enter product name");
			string name = Console.ReadLine();
			Console.WriteLine("Enter product price");
			decimal price = decimal.Parse(Console.ReadLine());
			Console.WriteLine("Enter product quantity");
			int quantity = int.Parse(Console.ReadLine());
			product.AddProduct(name, price, quantity);

			Console.WriteLine();
			Console.WriteLine("Enter any key to continue...");
			Console.ReadKey();

			AdminDashboard();
		}
		public void GetAllProducts()
		{
			product.GetAllProduct();
			Console.WriteLine();
			Console.WriteLine("Enter any key to continue...");
			Console.ReadKey();

			AdminDashboard();
		}
	}
}