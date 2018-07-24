using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHomeProject.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MyHomeProjectContext(
                serviceProvider.GetRequiredService<DbContextOptions<MyHomeProjectContext>>()))
            {
                // Look for any movies.
                if (context.Dishes.Any())
                {
                    return;   // DB has been seeded
                }

                var dishes = new[]
                {
                     new Dish
                     {
                         Title = "Оливье",
                         Recipe = " Смешать продукты и залить майонезом",
                         Category = "Салат",
                     },
                         new Dish
                     {
                         Title = "Борщ",
                         Recipe = " Смешать продукты, добавить буряк и сварить",
                         Category = "Суп",
                     },

                     new Dish
                     {
                         Title = "Фрикассе",
                         Recipe = " Никто не знает",
                         Category = "Гарнир",
                     }
                };
                var ingridients = new[]
                {
                    new Ingridient{title="огурец"},     //0
                    new Ingridient{title = "картофель"},    //1
                    new Ingridient{title="помидор"},    //2
                    new Ingridient{title = "мясо"},     //3
                    new Ingridient{title = "майонез"},  //4
                    new Ingridient{title ="колбаса"},   //5
                    new Ingridient{title="капуста"},    //6
                    new Ingridient{title = "соль"},     //7
                    new Ingridient{title = "горох"},    //8
                     new Ingridient{title = "фасоль"}   //9
                };

                context.AddRange(
                  
                  new Dish_Ingrident { Dish = dishes[0], Ingridient = ingridients[0] },
                  new Dish_Ingrident { Dish = dishes[0], Ingridient = ingridients[1] },
                  new Dish_Ingrident { Dish = dishes[0], Ingridient = ingridients[3] },
                  new Dish_Ingrident { Dish = dishes[0], Ingridient = ingridients[4] },
                  new Dish_Ingrident { Dish = dishes[0], Ingridient = ingridients[5] },
                  new Dish_Ingrident { Dish = dishes[0], Ingridient = ingridients[8] },
                  new Dish_Ingrident { Dish = dishes[1], Ingridient = ingridients[1] },
                  new Dish_Ingrident { Dish = dishes[1], Ingridient = ingridients[3] },
                  new Dish_Ingrident { Dish = dishes[1], Ingridient = ingridients[6] },
                  new Dish_Ingrident { Dish = dishes[2], Ingridient = ingridients[1] },
                  new Dish_Ingrident { Dish = dishes[2], Ingridient = ingridients[3] },
                  new Dish_Ingrident { Dish = dishes[2], Ingridient = ingridients[7] },
                  new Dish_Ingrident { Dish = dishes[2], Ingridient = ingridients[9] });

                context.SaveChanges();
            }
        }
    }
}
