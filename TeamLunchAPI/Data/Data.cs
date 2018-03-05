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
    /// Returns a copy of the TeamMembers dictionary.
    /// </summary>
    public Dictionary<string, string> GetTeamMembersCopy()
    {
        Dictionary<string, string> copy = new Dictionary<string, string>();
        foreach (string key in TeamMembers.Keys)
        {
            copy.Add(key, TeamMembers[key]);
        }
        return copy;
    }

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
    /// Call to populate our restaurant and team member records with a small set of pre-made data.<para/>
    /// WARNING: Clears stored team members and restaurants when called.
    /// </summary>
    public void SetupSmallScenario()
    {
        TeamMembers.Clear();
        Restaurants.Clear();

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
        TeamMembers.Add("9", "g");
        TeamMembers.Add("10", "g");
        TeamMembers.Add("11", "n");
        TeamMembers.Add("12", "");
        TeamMembers.Add("13", "v");
        TeamMembers.Add("14", "f");
        TeamMembers.Add("15", "f");
        TeamMembers.Add("16", "");
        TeamMembers.Add("17", "n");
        TeamMembers.Add("18", "g");
        TeamMembers.Add("19", "");

        // Add some restaurants
        Restaurants.Add(new Restaurant("A", 4, 20, new Dictionary<string, int> { { "v", 2 }, { "g", 1 }, { "n", 5 }, { "f", 1 } }));
        Restaurants.Add(new Restaurant("B", 5, 5, new Dictionary<string, int> { { "v", 1 }, { "g", 0 }, { "n", 0 }, { "f", 0 } }));
        Restaurants.Add(new Restaurant("C", 2, 30, new Dictionary<string, int> { { "v", 5 }, { "g", 5 }, { "n", 5 }, { "f", 5 } }));
    }

    /// <summary>
    /// Call to populate our restaurant and team member records with a large set of pre-made data. This is the demo example in the Code Challenge spec sheet.<para/>
    /// WARNING: Clears stored team members and restaurants when called.
    /// </summary>
    public void SetupLargeScenario()
    {
        for(int i = 1; i <= 38; i++)
        {
            TeamMembers.Add(i.ToString(), "");
        }
        for(int i = 39; i <= 43; i++)
        {
            TeamMembers.Add(i.ToString(), "v");
        }
        for(int i = 44; i <= 50; i++)
        {
            TeamMembers.Add(i.ToString(), "g");
        }

        Restaurants.Add(new Restaurant("A", 5, 40, new Dictionary<string, int> { { "v", 4 }, { "g", 0 }, { "n", 0 }, { "f", 0 } }));
        Restaurants.Add(new Restaurant("B", 3, 100, new Dictionary<string, int> { { "v", 20 }, { "g", 20 }, { "n", 0 }, { "f", 0 } }));
    }
}
