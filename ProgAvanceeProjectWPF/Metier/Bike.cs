using System.Collections.Generic;

public class Bike
{
    private int idBike;
    private double weight; 
    private string type;
    private double length;
    private Member member;
    private List<Inscription> inscriptions = new List<Inscription>();

    public int IdBike
    {
        get { return idBike; }
        set { idBike = value; }
    }

    public double Weight
    {
        get { return weight; } 
        set { weight = value; } 
    }

    public string Type
    {
        get { return type; }
        set { type = value; }
    }

    public double Length
    {
        get { return length; }
        set { length = value; }
    }

    public Member Member
    {
        get { return member; }
        set { member = value; }
    }

    public List<Inscription> Inscriptions
    {
        get { return inscriptions; }
        set { inscriptions = value; }
    }

    public List<Bike> GetAllBikes()
    {
        BikeDAO dao = new BikeDAO();

        List<Bike> bikes = dao.FindAll();

        return bikes;
    }

}
