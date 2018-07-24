using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHomeProject.Models
{
    public class Ingridient
    {
        public int IngridientId { get; set; }
        public String title { get; set; }

        public List<Dish_Ingrident> Dish_Ingridients { get; set; }

        public Ingridient()
        {
            Dish_Ingridients = new List<Dish_Ingrident>();
        }

      
    }
}
