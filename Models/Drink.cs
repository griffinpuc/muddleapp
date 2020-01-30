using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace muddleapp.Models
{
    public class Drink
    {

        public string idDrink { get; set; }
        public string strDrink { get; set; }
        public string strCategory { get; set; }
        public string strGlass { get; set; }
        public string strInstructions { get; set; }
        public string strIngredient1 { get; set; }
        public string strIngredient2 { get; set; }
        public string strIngredient3 { get; set; }
        public string strIngredient4 { get; set; }
        public string strIngredient5 { get; set; }
        public string strIngredient6 { get; set; }
        public string strIngredient7 { get; set; }
        public string strIngredient8 { get; set; }
        public string strIngredient9 { get; set; }
        public string strIngredient10 { get; set; }
        public string strMeasure1 { get; set; }
        public string strMeasure2 { get; set; }
        public string strMeasure3 { get; set; }
        public string strMeasure4 { get; set; }
        public string strMeasure5 { get; set; }
        public string strMeasure6 { get; set; }
        public string strMeasure7 { get; set; }
        public string strMeasure8 { get; set; }
        public string strMeasure9 { get; set; }
        public string strMeasure10 { get; set; }
        public string strDrinkThumb { get; set; }

        public string[] strIngredients { get; set; }
        public string[] strMeasures { get; set; }

        public Drink[] deserializeDrinks(String json)
        {
            DrinkApi drinkArray = JsonConvert.DeserializeObject<DrinkApi>(json);

            if(drinkArray.drinks != null)
            {
                foreach (Drink drink in drinkArray.drinks)
                {
                    drink.strIngredients = new string[]
                    {
                    drink.strIngredient1,
                    drink.strIngredient2,
                    drink.strIngredient3,
                    drink.strIngredient4,
                    drink.strIngredient5,
                    drink.strIngredient6,
                    drink.strIngredient7,
                    drink.strIngredient8,
                    drink.strIngredient9,
                    drink.strIngredient10
                    };

                    drink.strMeasures = new string[]
                    {
                    drink.strMeasure1,
                    drink.strMeasure2,
                    drink.strMeasure3,
                    drink.strMeasure4,
                    drink.strMeasure5,
                    drink.strMeasure6,
                    drink.strMeasure7,
                    drink.strMeasure8,
                    drink.strMeasure9,
                    drink.strMeasure10
                    };
                }

            }
  
            return drinkArray.drinks;
        }

    }

}
