using PlantsApi.Models;
using System.Collections.Generic;

namespace PlantsApi.Interfaces
{
	public interface IUsersRepository
	{
		User GetUser(int id);
		User GetUser(string guid);
		IEnumerable<User> GetUsers();
	}
}
