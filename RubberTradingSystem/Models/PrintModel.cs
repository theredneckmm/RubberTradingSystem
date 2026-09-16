namespace RubberTradingSystem.Models
{
    // ဘောက်ချာတစ်ခုချင်းစီရဲ့ ဇယားကွက်အချက်အလက် (Item တစ်ခုချင်းစီ)
    public class PrintItemModel
    {
        public string Title { get; set; } = "";        // ဥပမာ - ရာဘာဝယ်ယူခြင်း (သို့) ကြိုပွိုင့်စာချုပ်
        public string Subtitle { get; set; } = "";     // ဥပမာ - RSS-3 (သို့) Grade အသေးစိတ်
        public decimal Quantity { get; set; }          // ပိဿာချိန် / ပမာဏ
        public decimal UnitPrice { get; set; }         // တစ်ယူနစ်ဈေး
        public decimal TotalAmount { get; set; }       // စုစုပေါင်းငွေ
    }

    // ဘောက်ချာရဲ့ အထွေထွေ အချက်အလက်များ (Meta Info)
    public class PrintContextModel
    {
        public string VoucherNumber { get; set; } = "";
        public string VoucherTypeTitle { get; set; } = "";
        public string PartyName { get; set; } = "";
        public string PartyRoleLabel { get; set; } = "ကုန်သည်/စိုက်ပျိုးသူ:";
        public DateTime? VoucherDate { get; set; } = DateTime.Today;
        public DateTime? DueDate { get; set; }
        public string Description { get; set; } = "";
        public List<PrintItemModel> Items { get; set; } = new();

        // ဤ Properties အသစ်များကို ထည့်ပေးပါ 👇
        public string PaperSize { get; set; } = "A5";
        public int CustomWidthMm { get; set; } = 148;
        public int CustomHeightMm { get; set; } = 210;
        public string HeaderTitle { get; set; } = "";
        public string HeaderAddress { get; set; } = "";
        public string FooterNote { get; set; } = "";
    }
}