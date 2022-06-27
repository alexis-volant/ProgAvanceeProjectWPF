using System;
using System.Collections.Generic;

class Bike
{
    private Guid idBike;
    private float weight; 
    private string type;
    private float length;
    private Member member;
    private Vehicle vehicle;
    private List<Inscription> inscriptions = new List<Inscription>();

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

    public Vehicle Vehicle
    {
        get { return vehicle; }
        set { vehicle = value; }
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
