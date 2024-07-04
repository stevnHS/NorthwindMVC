using System.ComponentModel;

namespace NorthwindMVC.Services.DTOs
{
    public class ProductDto
    {
        [DisplayName("商品編號")]
        public int Id { get; set; }

        [DisplayName("商品名稱")]
        public string? Name { get; set; }

        [DisplayName("單價")]
        public decimal UnitPrice { get; set; }

        //bool? Discontinued {  get; set; }

        [DisplayName("狀態")]
        public string? Status { get; set; }
    }
}
