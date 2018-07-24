using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHomeProject.Models
{
    public class Dish
    {
        public int DishID { get; set; }
        public string Title { get; set; }
        public string Recipe { get; set; }
        public String Category { get; set; }

        public List<Dish_Ingrident> Dish_Ingridients { get; set; }

            public Dish()
        {
            Dish_Ingridients = new List<Dish_Ingrident>();
        }

     
    }
}
