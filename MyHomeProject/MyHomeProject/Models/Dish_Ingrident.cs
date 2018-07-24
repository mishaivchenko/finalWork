using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHomeProject.Models
{
    public class Dish_Ingrident
    {

        public int DishId { get; set; }

        public Dish Dish { get; set; }

        public int IngridientId { get; set; }

        public Ingridient Ingridient { get; set; }

    }
}
