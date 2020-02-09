﻿using PlantsApi.Models;
using PlantsApi.Models.Enums;
using System.Collections.Generic;

namespace PlantsApi.Interfaces
{
	public interface IUsersRepository
	{
		User GetUser(int id, UserInclude? include = null);
		User GetUser(string guid, UserInclude? include = null);
		IEnumerable<User> GetUsers();
	}
}
