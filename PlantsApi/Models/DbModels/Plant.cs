using System.ComponentModel.DataAnnotations.Schema;

namespace PlantsApi.Models
{
    public class Plant
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public byte[] Image { get; set; }
        public string Bloom { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string Soil { get; set; }
        public string Sunlight { get; set; }
        public string Water { get; set; }
        public string Fertility { get; set; }
        public  int MaxLightMmol { get; set; }
        public int MinLightMmol { get; set; }
        public int MaxLightLux { get; set; }
        public int MinLightLux { get; set; }
        public int MaxTemp { get; set; }
        public int MinTemp { get; set; }
        public int MaxEnvHumid { get; set; }
        public int MinEnvHumid { get; set; }
        public int MaxSoilMoist { get; set; }
        public int MinSoilMoist { get; set; }
        public int MaxSoilEc { get; set; }
        public int MinSoilEc { get; set; }

        public static void Update(Plant value, Plant updatedValue)
        {
            value.Bloom = updatedValue.Bloom;
            value.Color = updatedValue.Color;
            value.Country = updatedValue.Country;
            value.Fertility = updatedValue.Fertility;
            value.Image = updatedValue.Image;
            value.MaxEnvHumid = updatedValue.MaxEnvHumid;
            value.MaxLightLux = updatedValue.MaxLightLux;
            value.MaxLightMmol = updatedValue.MaxLightMmol;
            value.MaxSoilEc = updatedValue.MaxSoilEc;
            value.MinSoilEc = updatedValue.MinSoilEc;
            value.MaxSoilMoist = updatedValue.MaxSoilMoist;
            value.MaxTemp = updatedValue.MaxTemp;
            value.MinEnvHumid = updatedValue.MinEnvHumid;
            value.MinLightLux = updatedValue.MinLightLux;
            value.MinLightMmol = updatedValue.MinLightMmol;
            value.MinSoilMoist = updatedValue.MinSoilMoist;
            value.MinTemp = updatedValue.MinTemp;
            value.Name = updatedValue.Name;
            value.Size = updatedValue.Size;
            value.Soil = updatedValue.Soil;
            value.Sunlight = updatedValue.Sunlight;
            value.Water = updatedValue.Water;
        }
    }

}
