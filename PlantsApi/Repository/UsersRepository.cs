using PlantsApi.Database;
using PlantsApi.Interfaces;
using PlantsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlantsApi.Repository
{
	public class UsersRepository : IUsersRepository
	{
		private readonly PlantsContext db;

		public UsersRepository(PlantsContext db)
		{
			this.db = db;
		}


		public User GetUser(int id)
		{
			throw new NotImplementedException();
		}


		public User GetUser(string guid)
		{
			throw new NotImplementedException();
		}


		public IEnumerable<User> GetUsers()
		{
			throw new NotImplementedException();
		}

	}
}
