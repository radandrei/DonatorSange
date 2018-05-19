using BusinessLayer.Models;

namespace AntiClimacus.Models
{
    public class BloodComponentQuantity
    {
        public BloodComponentModel BloodComponent { get; set; }
        public int Quantity { get; set; }

        public BloodComponentQuantity()
        {

        }
    }
}