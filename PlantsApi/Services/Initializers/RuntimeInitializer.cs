using Microsoft.AspNetCore.Identity;
using PlantsApi.Database;
using PlantsApi.Models;
using PlantsApi.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlantsApi.Services.Initializers
{
    public class RuntimeInitializer
    {
        private readonly IdentityContext identityContext;
        private readonly PlantsContext plantsContext;
        private readonly UserManager<ApplicationUser> userManager;
        public RuntimeInitializer(IdentityContext identityContext,
                                  PlantsContext plantsContext,
                                  UserManager<ApplicationUser> userManager)
        {
            this.identityContext = identityContext;
            this.plantsContext = plantsContext;
            this.userManager = userManager;
        }

        public async Task InitializeDatabaseAsync()
        {
            await InitializeIdentityUserAsync(); ;
            InitializePlants();
            InitializePlantStates();
            InitializePlantAssignments();
        }

        private void InitializePlants()
        {
            if (plantsContext.Plants.Any()) { return; }
            var plants = GetPlants();
            plantsContext.Plants.AddRange(plants);
            plantsContext.SaveChanges();
        }

        private void InitializePlantStates()
        {
            if (plantsContext.PlantStates.Any()) { return; }
            var plantStates = GetPlantStates();
            plantsContext.PlantStates.AddRange(plantStates);
            plantsContext.SaveChanges();
        }

        private void InitializePlantAssignments()
        {
            if (plantsContext.PlantAssignments.Any()) { return; }
            var plantAssignments = GetPlantAssignments();
            plantsContext.PlantAssignments.AddRange(plantAssignments);
            plantsContext.SaveChanges();
        }

        private async Task InitializeIdentityUserAsync()
        {
            identityContext.Database.EnsureCreated();
            if (identityContext.Users.Any()) { return; }

            var password = "Qwerty1234";
            var user = new ApplicationUser()
            {
                Email = "gegor@gmail.com",
                UserName = "Egor",
                SecurityStamp = Guid.NewGuid().ToString()
            };
            var result = await userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                InitializeUser(user, password);
            }

        }

        private void InitializeUser(ApplicationUser applicationUser, string password)
        {
            if (plantsContext.Users.Any()) { return; }
            var user = new User
            {
                Guid = applicationUser.Id,
                Name = applicationUser.UserName,
                Email = applicationUser.Email,
                Password = password,
                RealName = "Egor",
                Phone = "+79326472394",
                Sex = "male",
                Birthday = DateTime.Now.AddYears(-21),
                Passport = 1234,
                City = "Moscow",
                Address = "Davidova street 5",
                RegistrationDate = DateTime.Now,
                LastLoginDate = DateTime.Now
            };
            plantsContext.Users.Add(user);
            plantsContext.SaveChanges();
        }

        private List<Plant> GetPlants()
        {
            var plant1 = new Plant
            {
                Name = "Abelia Chinensis",
                Country = "China",
                Image = "http://pkb.resource.huahuacaocao.com/YWJlbGlhIGNoaW5lbnNpcy5qcGc=?imageView2/1/w/%d/h/%d",
                Bloom = "Flowering period July-August, fruiting period October",
                Color = "Flower color pink, white",
                Size = "Diameter â¥ 10 cm, height â¥ 15 cm",
                Soil = "Peat or soil with specific nutrients",
                Sunlight = "Like sunshine, slightly resistant to half shade",
                Water = "Water thoroughly when soil is dry, avoid saturated water",
                Fertility = "Dilute fertilizers following instructions, apply 1-2 times monthly",
                MaxLightMmol = 4500,
                MinLightMmol = 2500,
                MaxLightLux = 30000,
                MinLightLux = 3500,
                MaxTemperature = 35,
                MinTemperature = 8,
                MaxEnvHumid = 85,
                MinEnvHumid = 30,
                MaxSoilMoist = 60,
                MinSoilMoist = 15,
                MaxSoilEc = 2000,
                MinSoilEc = 350
            };
            var plant2 = new Plant
            {
                Name = "Aeonium Haworthii",
                Country = "Africa",
                Image = "http://pkb.resource.huahuacaocao.com/YWVvbml1bSBoYXdvcnRoaWkuanBn?imageView2/1/w/%d/h/%d",
                Bloom = "Succulent plants, sometimes flowers",
                Color = "Leaf color yellow green , when sunny leaf margine turnning to red",
                Size = "Diameter â¥ 5 cm, height 5-20 cm",
                Soil = "Peat and akadama mixed in 3:1 ratio",
                Sunlight = "Likes sunshine, when in a short period of dormancy in summer, reduce water and shade properly",
                Water = "Do not water frequently, keep a dry environment, water every 10-15 days",
                Fertility = "Dilute fertilizers following instructions, apply once monthly",
                MaxLightMmol = 6000,
                MinLightMmol = 4000,
                MaxLightLux = 60000,
                MinLightLux = 3700,
                MaxTemperature = 35,
                MinTemperature = 8,
                MaxEnvHumid = 80,
                MinEnvHumid = 15,
                MaxSoilMoist = 50,
                MinSoilMoist = 7,
                MaxSoilEc = 1000,
                MinSoilEc = 300
            };
            var plant3 = new Plant
            {
                Name = "Echeveria agavoides 'Romeo'",
                Country = "Asia",
                Image = "http://pkb.resource.huahuacaocao.com/ZWNoZXZlcmlhIGFnYXZvaWRlcyAncm9tZW8nLmpwZw==?imageView2/1/w/%d/h/%d",
                Bloom = "Succulent plants, sometimes flowers with a short period time",
                Color = "Leaf color light greenï¼and will turn red with sufficient light",
                Size = "Diameter3-10cmï¼Height5-15cm",
                Soil = "Peat and akadama mixed in 3:1 ratio",
                Sunlight = "Enjoy sunlight, temporary dormancy in summerï¼planted in half shade",
                Water = "Water thoroughly when soil surface is dry",
                Fertility = "Dilute fertilizers following instructions, apply once monthly in spring and autumn",
                MaxLightMmol = 9500,
                MinLightMmol = 3200,
                MaxLightLux = 100000,
                MinLightLux = 3300,
                MaxTemperature = 35,
                MinTemperature = 6,
                MaxEnvHumid = 80,
                MinEnvHumid = 15,
                MaxSoilMoist = 50,
                MinSoilMoist = 7,
                MaxSoilEc = 1500,
                MinSoilEc = 50
            };
            var plant4 = new Plant
            {
                Name = "Nolana paradoxa",
                Country = "South America",
                Image = "http://pkb.resource.huahuacaocao.com/bm9sYW5hIHBhcmFkb3hhLmpwZw==?imageView2/1/w/%d/h/%d",
                Bloom = "Flowering period April-December, viewing period 2-3 weeks",
                Color = "Flower color red, pink, white",
                Size = "Diameter â¥ 10 cm, height â¥ 15 cm",
                Soil = "Peat or soil with specific nutrients",
                Sunlight = "Likes moderate sunlight, in summer use half shade for better care",
                Water = "Water thoroughly after soil surface dries",
                Fertility = "Dilute fertilizers following instructions, apply 1-2 times monthly in spring and autumn",
                MaxLightMmol = 4500,
                MinLightMmol = 2500,
                MaxLightLux = 30000,
                MinLightLux = 3500,
                MaxTemperature = 35,
                MinTemperature = 8,
                MaxEnvHumid = 85,
                MinEnvHumid = 30,
                MaxSoilMoist = 60,
                MinSoilMoist = 15,
                MaxSoilEc = 2000,
                MinSoilEc = 350
            };
            var plant5 = new Plant
            {
                Name = "Zantedeschia 'Captain Hollywood'",
                Country = "Holland",
                Image = "http://pkb.resource.huahuacaocao.com/emFudGVkZXNjaGlhICdjYXB0YWluIGhvbGx5d29vZCcuanBn?imageView2/1/w/%d/h/%d",
                Bloom = "Flowering period November-May, viewing period 1-2 months",
                Color = "Bract pink red",
                Size = "Diameter â¥ 10 cm, height 16-20 cm",
                Soil = "Peat and perlite mixed",
                Sunlight = "Put in sunny places, but avoid strong sunlight at noon, less flowers with less sunlight",
                Water = "Water thoroughly after soil dries, spray water in the air when relative humidity lower than 30%",
                Fertility = "Dilute fertilizers following instructions, apply 1-2 times monthly, except in summer",
                MaxLightMmol = 6000,
                MinLightMmol = 4000,
                MaxLightLux = 60000,
                MinLightLux = 3700,
                MaxTemperature = 35,
                MinTemperature = 8,
                MaxEnvHumid = 80,
                MinEnvHumid = 15,
                MaxSoilMoist = 50,
                MinSoilMoist = 7,
                MaxSoilEc = 1000,
                MinSoilEc = 300
            };

            var result = new List<Plant>();
            result.Add(plant1);
            result.Add(plant2);
            result.Add(plant3);
            result.Add(plant4);
            result.Add(plant5);

            return result;
        }

        private List<PlantState> GetPlantStates()
        {
            var result = new List<PlantState>();
            var commonPlantState = new PlantState
            {
                Time = DateTime.Now,
                Light = 129,
                Temperature = 20,
                EnvHumid = 643,
                SoilMoist = 9342,
                SoilEc = 834,
                Battery = 91,
                WaterRemained = 65
            };
            var plants = plantsContext.Plants.ToList();
            var userId = plantsContext.Users.First(u => u.Email == "gegor@gmail.com").Id;
            foreach (var plant in plants)
            {
                for (var i = 0; i < 5; i++)
                {
                    var plantState = PlantState.Clone(commonPlantState);
                    plantState.PlantId = plant.Id;
                    plantState.UserId = userId;
                    result.Add(plantState);
                }
            }
            return result;
        }

        private List<PlantAssignment> GetPlantAssignments()
        {
            var result = new List<PlantAssignment>();
            var userId = plantsContext.Users.First(u => u.Email == "gegor@gmail.com").Id;
            var plants = plantsContext.Plants.ToList();
            foreach (var plant in plants)
            {
                // TODO: use device id
                var plantAssignment = new PlantAssignment(userId, plant.Id, 1);
                result.Add(plantAssignment);
            }
            return result;
        }


    }
}
