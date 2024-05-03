namespace CodeZoneTask.Models.Entities
{
    public class Purchase : BaseEntity
    {
        public int StockID { get; set; }
        public int ItemID { get; set; }
        public decimal Quantity { get; set; }
    }
}
