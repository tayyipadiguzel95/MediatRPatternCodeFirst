using CodeFirst.Models;

namespace CodeFirst.Requests
{
    public class CreateOrderRequest
    {
        public double Amount { get; set; }
        public double Tax { get; set; }
        public CustomerDeviceInfo DeviceInfo { get; set; } = new CustomerDeviceInfo();
    }
}
