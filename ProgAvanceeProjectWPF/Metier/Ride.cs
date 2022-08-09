using System;
using System.Collections.Generic;

public class Ride
{
    private int num;
    private string placeDeparture;
    private DateTime dateDeparture;
    private double packageFee;
    private Category category;
    private List<Vehicle> vehicles;

    AbstractDAOFactory adf = AbstractDAOFactory.GetFactory(DAOFactoryType.MS_SQL_FACTORY);

    public Ride()
    {

    }

    public Ride(int num, string placeDeparture, DateTime dateDeparture, double packageFee, Category category)
    {
        this.num = num;
        this.placeDeparture = placeDeparture;
        this.dateDeparture = dateDeparture;
        this.packageFee = packageFee;
        this.category = category;
    }

    public int Num
    {
        get { return num; }
        set { num = value; }
    }

    public string PlaceDeparture
    {
        get { return placeDeparture; }
        set { placeDeparture = value; }
    }

    public DateTime DateDeparture
    {
        get { return dateDeparture; }
        set { dateDeparture = value; }
    }

    public double PackageFee
    {
        get { return packageFee; }
        set { packageFee = value; }
    }

    public Category Category
    {
        get { return category; }
        set { category = value; }
    }

    public List<Vehicle> Vehicles
    {
        get { return vehicles; }
        set { vehicles = value; }
    }

    public void addParticipant()
    {

    }

    public void getTotalMemberPlaces()
    {

    }

    public void getRestMemberPlaces()
    {

    }

    public void getTotalBikePlaces()
    {

    }

    public void getRestBikePlaces()
    {

    }

    public void getMemberPlacesNeed()
    {

    }

    public void getBikePlacesNeed()
    {

    }

    public void addVehicle()
    {

    }

    public bool AddRide(string UpdatePlace, DateTime UpdateDate, double UpdateFee, Category cat)
    {
        DAO<Ride> rideDAO = adf.GetRideDAO();
        Ride ride = new Ride(0, UpdatePlace, UpdateDate, UpdateFee, cat);

        return rideDAO.Create(ride);
    }

    public bool UpdateRide(Ride r, string UpdatePlace, DateTime UpdateDate, double UpdateFee)
    {
        DAO<Ride> rideDAO = adf.GetRideDAO();

        r.PlaceDeparture = UpdatePlace;
        r.DateDeparture = UpdateDate;
        r.PackageFee = UpdateFee;

        return rideDAO.Update(r);
    }

    public bool DeleteRide(Ride r)
    {
        DAO<Ride> rideDAO = adf.GetRideDAO();

        return rideDAO.Delete(r);
    }

    public List<Ride> GetRides(int numCategory)
    {
        RideDAO dao = new RideDAO();

        List<Ride> rides = dao.FindByCategory(numCategory);

        return rides;
    }

    //public List<Ride> GetRidesByMember(Member member)
    //{
    //    RideDAO dao = new RideDAO();

    //    List<Ride> rides = dao.FindByMember(member);

    //    return rides;
    //}
    
    public List<Ride> GetRidesByCategory(int numCategory)
    {
        RideDAO dao = new RideDAO();

        List<Ride> rides = dao.FindByCategory(numCategory);

        return rides;
    }

    

}
