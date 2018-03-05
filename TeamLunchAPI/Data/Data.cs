using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


/// <summary>
/// Singleton class which holds all submitted TeamMembers and Restaurants.
/// </summary>
public sealed class Data
{
    /// <summary>
    /// Dictionary of team members.
    /// Key: string, employee id.
    /// Value: string, dietary restrictions.<para />
    /// Team members are meant to have at most one dietary restriction: one of v, g, n, or f.
    /// </summary>
    public Dictionary<string, string> TeamMembers = new Dictionary<string, string>();

    /// <summary>
    /// List of restaurants.
    /// </summary>
    public List<Restaurant> Restaurants = new List<Restaurant>();

    /// <summary>
    /// Returns instance of restaurant with given name.
    /// Returns null if none is found.
    /// </summary>
    public Restaurant GetRestaurant(string name)
    {
        foreach (Restaurant r in Restaurants)
        {
            if (r.name == name)
                return r;
        }
        return null;
    }

    private static Data instance = new Data();

    static Data()
    {
    }

    private Data()
    {
    }

    public static Data Instance { get { return instance; } }

    /// <summary>
    /// Call to populate our restaurant and team member records with a small set of pre-made data.
    /// </summary>
    public void SetupSmallScenario()
    {
        // Set up some team members
        TeamMembers.Add("0", "");
        TeamMembers.Add("1", "");
        TeamMembers.Add("2", "");
        TeamMembers.Add("3", "");
        TeamMembers.Add("4", "");
        TeamMembers.Add("5", "v");
        TeamMembers.Add("6", "v");
        TeamMembers.Add("7", "v");
        TeamMembers.Add("8", "v");
    }

    /// <summary>
    /// Call to populate our restaurant and team member records with a small set of pre-made data.
    /// </summary>
    public void SetupLargeScenario()
    {

    }
}
