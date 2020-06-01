using Microsoft.EntityFrameworkCore;
using PlantsApi.Database;
using PlantsApi.Interfaces;
using PlantsApi.Models;
using PlantsApi.Models.DbModels;
using PlantsApi.Models.Enums;
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
			return db.Users.SingleOrDefault(u => u.Id == id);
		}


		public User GetUser(string guid)
		{
			return db.Users.SingleOrDefault(u => u.Guid == guid);
		}

		public User CreateUser(ApplicationUser applicationUser, string password)
		{
			var newUser = new User();
			newUser.Guid = applicationUser.Id;
			newUser.Email = applicationUser.Email;
			newUser.Name = applicationUser.UserName;
			newUser.Password = password;
			db.Users.Add(newUser);
			db.SaveChanges();
			return newUser;
		}

		public void UpdatePassword(ApplicationUser applicationUser, string password)
		{
			var user = db.Users.First(u => u.Guid == applicationUser.Id);
			user.Password = password;
			db.SaveChanges();
		}

	}
}
