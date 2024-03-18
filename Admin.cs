namespace ECOMMERCE_AP
{
	public class Admin : Person
	{
		public Admin(string firstName, string lastName, string email, string password) : base(firstName, lastName, email, password)	
		{
			Random random = new Random();
			StaffNo = random.Next(1000000, 9999990);
		}
		
		public int StaffNo { get;}
		public static List<Admin> Admins { get; set; } = new List<Admin>();
		public static Admin RegisterAdmin(string firstName, string lastName, string email, string password)
		{
			foreach(var ad in Admins)
			{
				if(ad.Email == email)
				{
					Console.WriteLine($"Email {email} already exist");
					return null;
				}
			}
			Admin admin = new Admin(firstName, lastName, email, password);
			Admins.Add(admin);
			Console.WriteLine("Successfully registered");
			return admin;	
		}
		public static Admin AdminLogin(string email , string password)
		{
			foreach (var ad in Admins)
			{
				if (ad.Email == email  && ad.Password == password)
				{
					Console.WriteLine("Successfully Login");
					return ad;
				}
			}
			Console.WriteLine("Email or Password does't exists");
			return null;

		}
	}
}