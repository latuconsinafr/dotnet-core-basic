using System.Collections.Generic;

namespace dotnet_basic.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}