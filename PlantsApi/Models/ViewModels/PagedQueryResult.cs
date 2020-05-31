using PlantsApi.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlantsApi.Models.ViewModels
{
    public class PagedQueryResult
    {
        public int PageSize { get; set; }
        public int TotalItemsCount { get; set; }
        public int TotalPagesCount { get; set; }
        public IEnumerable<Plant> Results { get; set; }
    }
}
