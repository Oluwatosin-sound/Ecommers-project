namespace ECOMMERCE_AP
{
	public abstract class Person
	{
		public string FirstName { get; set; }
		public string LastName { get; set; } 
		public string Email { get; set; }
		public string Password { get; set; }
		protected Person(string firstName, string lastName, string email, string password)
		{
			Password = password;
			FirstName = firstName;
			LastName = lastName;
			Email = email;
		}
	}
}