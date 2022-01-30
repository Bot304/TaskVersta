using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace versta.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string CitySet { get; set; }
        public string AddressSet { get; set; }
        public string CityGet { get; set; }
        public string AddressGet { get; set; }
        public int Weight { get; set; }
        public DateTime Date { get; set; }
    }
}
