using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace muddleapp.Models
{
    public class Hit
    {
        public int ID { get; set; }
        public string idDrink { get; set; }
        public int hits { get; set; }
        //public DateTime date { get; set; }

        public void addHit()
        {
            this.hits++;
        }

    }

}
