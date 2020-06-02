using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using PlantsApi.Interfaces;
using PlantsApi.Models;
using PlantsApi.Models.DbModels;
using PlantsApi.Models.Enums;
using PlantsApi.Models.Dtos;
using PlantsApi.Repository;

namespace PlantsApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class DeviceController : ControllerBase
	{
		private readonly IPlantsStateRepository plantsStateRepository;
		private readonly IDevicesRepository devicesRepository;
		private readonly IFileProvider fileProvider;

		public DeviceController(IPlantsStateRepository plantsStateRepository,
									 IDevicesRepository devicesRepository,
									 IFileProvider fileProvider)
		{
			this.plantsStateRepository = plantsStateRepository;
			this.devicesRepository = devicesRepository;
			this.fileProvider = fileProvider;
		}

		[HttpPost]
        public IActionResult Post([FromBody] DeviceInfoDto value)
        {
            var device = devicesRepository.GetDevice(value.SerialNumber);
            if (device == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, $"Device with serial {value.SerialNumber} doesn't exists");
            }
            if (device.UserId == null)
            {
				return StatusCode(StatusCodes.Status403Forbidden, "Device isn't connected to any user");
            }
			if(device.PlantId == null)
			{
				return StatusCode(StatusCodes.Status403Forbidden, "Device isn't connected to any plant");
			}
            var plantState = DeviceInfoDto.MapToPlantState(value, device.Id);
            plantsStateRepository.CreateOrUpdatePlantState(plantState);
			var conditionIndicators = devicesRepository.GetConditionIndicators(value);

			return Ok(conditionIndicators);
        }

        [HttpGet]
		[Route("[action]")]
		public IActionResult GetFirmware()
		{
			var files = fileProvider.GetDirectoryContents(@"StaticFiles");
			var latestFile = files
				.ToList()
				.OrderByDescending(f => f.LastModified)
				.First();
			var fileNameWithExtension = latestFile.Name;
			var fileName = latestFile.Name.Split('.').First();
			var version = Convert.ToUInt64(fileName);

			var url = $"{this.Request.Scheme}://{this.Request.Host}/{fileNameWithExtension}";

			var response = new DeviceResponseDto()
			{
				Version = version,
				Link = url
			};
			return Ok(response);
		}

	}
}
