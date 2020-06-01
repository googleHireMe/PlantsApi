using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlantsApi.Models.DbModels
{
    public class User 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Guid { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public string RealName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Sex { get; set; }
        public DateTime Birthday { get; set; }
        public int Passport { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime LastLoginDate { get; set; }

        public ICollection<Device> Devices { get; set; }

    }
}
