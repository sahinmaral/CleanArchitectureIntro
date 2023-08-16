using Microsoft.AspNetCore.Identity;

namespace CleanArchitectureIntro.Domain.Entities;

public sealed class User : IdentityUser<string>
{
	public User()
	{
		Id = Guid.NewGuid().ToString();
	}

	public string? RefreshToken { get; set; }
	public DateTime? RefreshTokenExpires { get; set; }

	//public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

}
