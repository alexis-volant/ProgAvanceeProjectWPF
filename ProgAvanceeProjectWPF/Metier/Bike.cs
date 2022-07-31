using System;
using System.Collections.Generic;

public class Bike
{
    private Guid idBike;
    private float weight; 
    private string type;
    private float length;
    private Member member;
    private List<Inscription> inscriptions = new List<Inscription>();

    public Bike(Guid idBike, float weight, string type, float length)
    {
        this.idBike = idBike;
        this.weight = weight;
        this.type = type;
        this.length = length;
    }

    public Guid IdBike
    {
        get { return idBike; }
        set { idBike = value; }
    }

    public float Weight
    {
        get { return weight; } 
        set { weight = value; } 
    }

    public string Type
    {
        get { return type; }
        set { type = value; }
    }

    public float Length
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
