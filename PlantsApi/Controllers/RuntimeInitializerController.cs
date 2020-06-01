using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PlantsApi.Interfaces;
using PlantsApi.Models;
using PlantsApi.Models.Enums;
using PlantsApi.Models.Dtos;
using PlantsApi.Repository;
using PlantsApi.Services.Initializers;

namespace PlantsApi.Controllers
{
	//[ApiController]
	//[Route("api/[controller]")]
	//public class RuntimeInitializerController : ControllerBase
	//{
	//	private readonly RuntimeInitializer runtimeInitializer;

	//	public RuntimeInitializerController(RuntimeInitializer runtimeInitializer)
	//	{
	//		this.runtimeInitializer = runtimeInitializer;
	//	}

	//	[HttpGet]
	//	public async Task<IActionResult> GetAsync()
	//	{
	//		await runtimeInitializer.InitializeDatabaseAsync();
	//		return Ok();
	//	}

	//}
}

