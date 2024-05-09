using System.Text.Json.Serialization;

namespace Configurator.Api.Dtos.Contracts
{
    public class UserDetailsDto
    {
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }

		[JsonConstructor]
		public UserDetailsDto(string firstName, string lastName, string email, string phone)
		{
			FirstName = firstName;
			LastName = lastName;
			Email = email;
			Phone = phone;
		}
	}
}
