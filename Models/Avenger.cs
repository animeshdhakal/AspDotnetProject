using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace avengerapi.Models
{
    public class Avenger
    {
        public int Id { get; set; }

        public string Name { get; set; } = "Iron Man";

        public string RealName { get; set; } = "Tony Stark";

        public string Power { get; set; } = "Intelligence";
    }
}