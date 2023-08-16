using Microsoft.AspNetCore.Identity;

namespace CleanArchitectureIntro.Domain.Entities;

public sealed class Role : IdentityRole<string>
{
	public Role()
	{
		Id = Guid.NewGuid().ToString();
	}


	//public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}