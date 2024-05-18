using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class product
    {
        [Key]
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? Description { get; set; }
        public int QuantityInStock { get; set; }
        public virtual ICollection<stockInDetail> stockInDetails { get; set; } = new HashSet<stockInDetail>();


    }
}
