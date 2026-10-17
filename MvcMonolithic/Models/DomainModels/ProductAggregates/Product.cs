


using MvcMonolithic.Models.DomainModels.ProductType;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMonolithic.Models.DomainModels.ProductAggregates
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int Count { get; set; }

        
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }


    }
}
