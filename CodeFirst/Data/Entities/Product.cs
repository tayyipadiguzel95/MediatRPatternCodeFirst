using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst.Data.Entities
{
    [Table("Products")]
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
