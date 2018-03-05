using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TeamLunchAPI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        /// <summary>
        /// GET request to populate the data class with pre-made team members and restaurants.
        /// </summary>
        [HttpGet]
        [Route("/SmallScenario")]
        public void SmallScenarioRequest()
        {
            Data.Instance.SetupSmallScenario();
        }

        /// <summary>
        /// GET request to populate the data class with the example from the Code Challenge spec sheet.
        /// </summary>
        [HttpGet]
        [Route("/LargeScenario")]
        public void LargeScenarioRequest()
        {
            Data.Instance.SetupLargeScenario();
        }

        /// <summary>
        /// Returns a list of restaurants that is sorted from highest rating to lowest rating.
        /// </summary>
        /// <param name="restaurants"></param>
        public List<Restaurant> SortHighestRating(List<Restaurant> restaurants)
        {
            return restaurants.OrderByDescending(restaurant => restaurant.rating).ToList();
        }

        /// <summary>
        /// GET request which returns the optimal meal dictionary.<para />
        /// Key: a key-value pair of the person and their dietary restriction, if any. Value: the name of the restaurant from which the person's meal is from.<para/>
        /// Returns a dictionary that illustrates which people get what meals, and from which restaurant.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("/Meals")]
        public Dictionary<KeyValuePair<string, string>, string> GetMeals()
        {
            List<Restaurant> sorted = SortHighestRating(Data.Instance.Restaurants);

            Dictionary<string, string> people = Data.Instance.GetTeamMembersCopy();      // remove people from this dictionary as their meal is found
            List<string> peopleToRemove = new List<string>();                           // list of ids to remove from people dictionary

            // Dictionary to illustrate which people get what meals from where.
            // Contains people keys (keyvaluepairs- id and diet restr.) and restaurant name values.
            Dictionary<KeyValuePair<string, string>, string> mealOrder = new Dictionary<KeyValuePair<string, string>, string>();

            foreach (Restaurant restaurant in sorted)
            {
                // get how many regular meals can be provided
                int regularMeals = restaurant.totalMeals - (restaurant.specialMeals["v"] + restaurant.specialMeals["g"] + restaurant.specialMeals["n"] + restaurant.specialMeals["f"]);
                // make a clone of the special meals dictionary so we can decrement amounts remaining w/o affecting the original dictionary
                Dictionary<string, int> specMealsClone = new Dictionary<string, int> { { "v", restaurant.specialMeals["v"] }, { "g", restaurant.specialMeals["g"] }, { "n", restaurant.specialMeals["n"] }, { "f", restaurant.specialMeals["f"] } }; 

                foreach (KeyValuePair<string, string> teamMember in people)
                {
                    if (teamMember.Value == string.Empty && regularMeals > 0)
                    {
                        // assign this person a meal, no dietary restrictions
                        mealOrder.Add(teamMember, restaurant.name);
                        regularMeals--;
                        System.Diagnostics.Debug.Write("\n+++ TeamMember " + teamMember.Key + " ASSIGNED REGULAR MEAL\n");
                        peopleToRemove.Add(teamMember.Key);
                    }
                    else if (teamMember.Value != string.Empty && specMealsClone[teamMember.Value] > 0) // the person has dietary restrictions, see if the restaurant can accommodate them
                    {
                        mealOrder.Add(teamMember, restaurant.name);
                        specMealsClone[teamMember.Value]--;
                        System.Diagnostics.Debug.Write("\n>>> TeamMember " + teamMember.Key + " ASSIGNED " + teamMember.Value + " MEAL\n");
                        peopleToRemove.Add(teamMember.Key);
                    }

                    // TODO: might have to implement something else here? Account for people who don't get a meal...
                    //throw new NotImplementedException();
                }

                // Update who we have accounted for
                foreach (string id in peopleToRemove)
                {
                    people.Remove(id);
                }
                peopleToRemove.Clear();

                // Break and return if we've given everyone a meal
                if (people.Count <= 0)
                    break;
            }
            return mealOrder;
        }
    }
}
