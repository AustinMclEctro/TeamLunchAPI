using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// A class to hold relevant information for an individual restaurant.
/// </summary>
public class Restaurant
{
    public string name;
    public int rating;
    public int totalMeals;
    public Dictionary<string, int> specialMeals = new Dictionary<string, int>();

    /// <summary>
    /// No argument constructor for a restaurant.
    /// </summary>
    public Restaurant() { }

    /// <summary>
    /// Constructor for creating a restaurant.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="rating"></param>
    /// <param name="totalMeals"></param>
    /// <param name="specialMeals"></param>
    public Restaurant(string name, int rating, int totalMeals, Dictionary<string, int> specialMeals)
    {
        this.name = name;
        this.rating = rating;
        this.totalMeals = totalMeals;
        this.specialMeals = specialMeals;
    }
}

