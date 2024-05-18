namespace WebApplication4.Models
{
    public class stockInDetail
    {
        public int Id { get; set; }

        public int quantitySold { get; set; }
        public int price { get; set; }
        public int TotalPrice => quantitySold * price;
        public virtual int? prodId { get; set; }
        public virtual product? prod { get; set; }


    }
}
