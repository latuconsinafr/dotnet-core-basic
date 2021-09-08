namespace dotnet_basic.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public virtual Category Category { get; set; }
    }
}