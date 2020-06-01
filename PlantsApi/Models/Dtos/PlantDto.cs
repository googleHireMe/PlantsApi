using PlantsApi.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlantsApi.Models.Dtos
{
    public class PlantDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Image { get; set; }
        public string Bloom { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string Soil { get; set; }
        public string Sunlight { get; set; }
        public string Water { get; set; }
        public string Fertility { get; set; }
        public int MaxLightMmol { get; set; }
        public int MinLightMmol { get; set; }
        public int MaxLightLux { get; set; }
        public int MinLightLux { get; set; }
        public int MaxTemperature { get; set; }
        public int MinTemperature { get; set; }
        public int MaxEnvHumid { get; set; }
        public int MinEnvHumid { get; set; }
        public int MaxSoilMoist { get; set; }
        public int MinSoilMoist { get; set; }
        public int MaxSoilEc { get; set; }
        public int MinSoilEc { get; set; }

        public PlantDto(Plant plant)
        {
            Id = plant.Id;
            Name = plant.Name;
            Country = plant.Country;
            Image = plant.Image;
            Bloom = plant.Bloom;
            Color = plant.Color;
            Size = plant.Size;
            Soil = plant.Soil;
            Sunlight = plant.Sunlight;
            Water = plant.Water;
            Fertility = plant.Fertility;
            MaxLightMmol = plant.MaxLightMmol;
            MinLightMmol = plant.MinLightMmol;
            MaxLightLux = plant.MaxLightLux;
            MinLightLux = plant.MinLightLux;
            MaxTemperature = plant.MaxTemperature;
            MinTemperature = plant.MinTemperature;
            MaxEnvHumid = plant.MaxEnvHumid;
            MinEnvHumid = plant.MinEnvHumid;
            MaxSoilMoist = plant.MaxSoilMoist;
            MinSoilMoist = plant.MinSoilMoist;
            MaxSoilEc = plant.MaxSoilEc;
            MinSoilEc = plant.MinSoilEc;
        }
    }
}
