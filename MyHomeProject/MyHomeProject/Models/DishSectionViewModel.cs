using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHomeProject.Models
{
    public class DishSectionViewModel
    {
        public List<Dish> dishes;
        public SelectList category;
        public string dishCategory { get; set; }
    }
}
