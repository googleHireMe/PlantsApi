using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PlantsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        [HttpGet]
        public string Get() => "App is online";
    }
}