using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace muddleapp.Models
{
    public class Nugget
    {
        public Drink[] drinks { get; set; }
        public Drink drink { get; set; }
        public string userDrink { get; set; }
        public int hits { get; set; }
    }
}
