using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCMDeveloperPracticum
{
    public class Meal
    {
        //constants for meal times
        public const string MORNING = "morning";
        public const string NIGHT = "night";

        //static lists for all meal dishes
        private static Dish[] MORNING_DISHES = { new Dish(1, "eggs"), new Dish(2, "toast"), new Dish(3, "coffee") };
        private static Dish[] NIGHT_DISHES = { new Dish(1, "steak"), new Dish(2, "potato"), new Dish(3, "wine"), new Dish(4, "cake") };

        //the time of the meal (morning or night)
        private string m_time;
        //list of the dishes of the meal
        private List<Dish> m_dishes;

        public Meal(string input)
        {
            m_dishes = new List<Dish>();
            parseInput(input);
        }

        //parse the entire line of input including the meal time and all dishes
        private void parseInput(string input) 
        {
            var inputs = input.ToLower().Split(',');

            //validate input
            if (inputs.Count() <= 1)
                throw new ArgumentException("Not enough selections");

            if (inputs[0] != MORNING && inputs[0] != NIGHT)
                throw new ArgumentException("No valid time of day");

            //parse individual dishes
            m_time = inputs[0];
            try
            { 
                for(var i = 1; i < inputs.Count(); i++)
                {
                    parseDish(inputs[i].Trim());
                }
            }
            catch (ArgumentException)
            {
                throw new Exception(this.ToString() + ", error");
            }
        }

        //parse individually dishes
        private void parseDish(string input)
        {
            int num;
            //validate dish
            if (!int.TryParse(input, out num) || num <= 0)
                throw new ArgumentException("'" + input + "' is not a valid selection number");

            num--;
            var dishes = MORNING_DISHES;
            if (m_time != MORNING)
                dishes = NIGHT_DISHES;

            //validate that dish is acceptable for meal
            if (num >= dishes.Count())
                throw new ArgumentException("'" + input + "' is not a valid selection number for " + m_time + " meal");

            if (m_dishes.Contains(dishes[num]))
            {
                if (!(m_time == MORNING && num == 2) && !(m_time == NIGHT && num  == 1))
                    throw new ArgumentException("Cannot have more that one order of '" + input + "' (" + dishes[num].Name + ") for " + m_time + " meal");
            }

            m_dishes.Add(dishes[num]);
        }

        //display dishes in the order entree, side, drink, dessert
        public override string ToString()
        {
            var multi = 1;
            var str = new List<string>();            
            m_dishes = m_dishes.OrderBy(u => u.Id).ToList();
            for (var i = 0; i < m_dishes.Count(); i++)
            {
                if (i > 0 && m_dishes[i] == m_dishes[i - 1])
                {
                    multi++;
                    str[str.Count() - 1] = m_dishes[i].Name + "(x" + multi + ")";
                } else
                {
                    str.Add(m_dishes[i].Name);
                }
            }
            return String.Join(", ", str);
        }
    }
}
