using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlantsApi.Models.Dtos
{
    public class ConditionIndicatorsDto
    {
        public bool isLightOk { get; set; }
        public bool isTempOk { get; set; }
        public bool isEnvHumidOk { get; set; }
        public bool isSoilMoistOk { get; set; }
        public bool isSoilEcOk { get; set; }
    }
}
