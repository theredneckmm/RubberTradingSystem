namespace RubberTradingSystem.Models
{

  public class StockTransferItemModel
        {
            public string Id { get; set; } = string.Empty;
            public string SourceCategory { get; set; } = string.Empty; // "TempStock" သို့မဟုတ် "TruckStock"
            public string ContactOrVehicleName { get; set; } = string.Empty; // ခြံရှင်နာမည် သို့မဟုတ် ကားအမှတ်
            public string RubberTypeName { get; set; } = string.Empty;
            public decimal Quantity { get; set; }
            public decimal MoistureOrDetails { get; set; } // အစိုဓာတ် % (သို့) အခြားအချက်အလက်

            // Original IDs for database updates
            public string OriginalId { get; set; } = string.Empty;
            public string RubberTypeId { get; set; } = string.Empty;
            public string? ContactId { get; set; }
        }
    

    public class WarehouseBatchModel
    {
        public string id { get; set; } = string.Empty;
        public string warehouse_id { get; set; } = string.Empty;
        public string batch_number { get; set; } = string.Empty;
        public string rubber_type_id { get; set; } = string.Empty;
        public decimal total_weight { get; set; }
        public string status { get; set; } = "Active";
    }

   
}