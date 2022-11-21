using System;
namespace Inlämningsuppgift.nosql.Models
{
    public class ProductCatalog
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string ArticleNumber { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int Price { get; set; } 
        public string Description { get; set; } = null!;

    }
}

