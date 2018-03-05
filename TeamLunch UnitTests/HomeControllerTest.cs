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
        [TestMethod]
        public void EnoughMealsTest()
        {
            HomeController controller = new HomeController();
            var result = controller.GetMeals() as Dictionary<KeyValuePair<string, string>, string>;
            //var a = result.
        }

        /// <summary>
        /// Tests if the restaurant list is sorted consistently.
        /// A copy list is created which is then shuffled. The same sort is then applied to this shuffled list.
        /// If the once-shuffled-then-sorted list is the same as the sorted list, then our sort is indeed working as it should be.
        /// </summary>
        [TestMethod]
        public void RestaurantSortTest()
        {
            List<Restaurant> sortedCopy = Data.Instance.Restaurants.OrderByDescending(restaurant => restaurant.rating).ToList();    // exactly what is done in HomeController

            Random rnd = new Random();
            List<Restaurant> shuffledCopy = sortedCopy.OrderBy(restaurant => rnd.Next()).ToList();
            List<Restaurant> result = shuffledCopy.OrderByDescending(restaurant => restaurant.rating).ToList();

            Assert.AreEqual(result, sortedCopy);
        }
    }
}
