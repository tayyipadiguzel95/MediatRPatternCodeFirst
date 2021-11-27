using CodeFirst.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst.Data.Entities
{
    [Table("Orders")]
    public class Order
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public double Tax { get; set; }
        [Column(TypeName = "jsonb")]
        public CustomerDeviceInfo DeviceInfo { get; set; }
    }
}
