using System;
using System.Collections.Generic;

public class Bike
{
    private Guid idBike;
    private double weight; 
    private string type;
    private double length;
    private Member member;
    private List<Inscription> inscriptions = new List<Inscription>();

    AbstractDAOFactory adf = AbstractDAOFactory.GetFactory(DAOFactoryType.MS_SQL_FACTORY);
    public Bike() { }
    public Bike(Guid idBike, double weight, string type, double length, Member member)
    {
        this.idBike = idBike;
        this.weight = weight;
        this.type = type;
        this.length = length;
        this.member = member;
      
    }  
    
    public Bike(Guid idBike, double weight, string type, double length)
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

    public bool AddBike(string cat, double weigth, double length, Member member)
    {
        DAO<Bike> bikeDAO = adf.GetBikeDAO();
        Bike bike = new Bike(Guid.NewGuid(), weigth, cat, length, member);

        return bikeDAO.Create(bike);
    }

    //public bool UpdateRide(Ride r, string UpdatePlace, DateTime UpdateDate, double UpdateFee)
    //{
    //    DAO<Ride> rideDAO = adf.GetRideDAO();

    //    r.PlaceDeparture = UpdatePlace;
    //    r.DateDeparture = UpdateDate;
    //    r.PackageFee = UpdateFee;

    //    return rideDAO.Update(r);
    //}

    public List<Bike> GetBikesByMember(Member member)
    {
        BikeDAO dao = new BikeDAO();

        List<Bike> bikes = dao.FindBikesByMember(member);

        return bikes;
    }

}
