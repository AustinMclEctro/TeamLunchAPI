using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TeamLunchAPI.Controllers;

namespace TeamLunch_UnitTests
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void GetMealsTest()
        {
            HomeController controller = new HomeController();
            var result = controller.GetMeals() as Dictionary<KeyValuePair<string, string>, string>;
            //var a = result.
        }
    }
}
