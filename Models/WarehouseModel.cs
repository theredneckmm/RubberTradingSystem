using System;

namespace RubberTradingSystem.Models
{
    public class WarehouseModel
    {
        public string id { get; set; } = Guid.NewGuid().ToString();
        public string owner_id { get; set; } = string.Empty;
        public string? staff_id { get; set; }
        public string warehouse_name { get; set; } = string.Empty;
        public string? location { get; set; }
        public string? manager_name { get; set; }
        public string? phone { get; set; }
        public string? capacity_desc { get; set; }
        public DateTime? created_at { get; set; }
    }
}