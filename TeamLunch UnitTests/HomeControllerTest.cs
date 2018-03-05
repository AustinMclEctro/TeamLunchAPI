using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using TeamLunchAPI.Controllers;

namespace TeamLunch_UnitTests
{
    [TestClass]
    public class HomeControllerTest
    {
        /// <summary>
        /// Tests if there is a meal for every person.<para/>
        /// Compares the number of people with meals in the result dictionary given by the algorithm with the total number of team members (should be equal).
        /// </summary>
        [TestMethod]
        public void EnoughMealsTest()
        {
            HomeController controller = new HomeController();
            Dictionary<KeyValuePair<string, string>, string> result = controller.GetMeals();
            int numMeals = result.Count();
            int numPeople = Data.Instance.TeamMembers.Count();
            Assert.AreEqual(numPeople, numMeals);
        }

        /// <summary>
        /// Tests if the restaurant list is sorted consistently.<para/>
        /// A copy list is created which is then shuffled. The same sort is then applied to this shuffled list.
        /// If the once-shuffled-then-sorted list is the same as the sorted list, then our sort is indeed working as it should be.
        /// </summary>
        [TestMethod]
        public void RestaurantSortTest()
        {
            HomeController controller = new HomeController();
            List<Restaurant> sortedCopy = controller.SortHighestRating(Data.Instance.Restaurants);

            Random rnd = new Random();
            List<Restaurant> shuffledCopy = sortedCopy.OrderBy(restaurant => rnd.Next()).ToList();
            List<Restaurant> result = shuffledCopy.OrderByDescending(restaurant => restaurant.rating).ToList();

            Assert.AreEqual(result, sortedCopy);
        }

        // unit test for meal subtraction (is it working on sorted or original list? should be on copy)

    }
}
