using System.Collections.Generic;

public class Calender
{
    private Category category;
    private List<Ride> rides = new List<Ride>();

    public Calender(Category category)
    {
        this.category = category;
    }

    public Category Category
    {
        get { return category; }
        set { category = value; }
    }

    public List<Ride> Rides
    {
        get { return rides; }
        set { rides = value; }
    }

    public void ajouterBalade(Ride ride)
    {
        this.rides.Add(ride);
    }
}