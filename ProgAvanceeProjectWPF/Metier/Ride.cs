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
    private List<Member> members;

    AbstractDAOFactory adf = AbstractDAOFactory.GetFactory(DAOFactoryType.MS_SQL_FACTORY);

    RideDAO dao = new RideDAO();

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

    public List<Member> Members
    {
        get { return members; }
        set { members = value; }
    }
    public void addParticipant(Member member)
    {
        this.members.Add(member);
    }

    public int getTotalMemberPlaces(Ride ride)
    {
        int total=0;
        foreach(Vehicle v in ride.vehicles)
        {
            total += v.NbrPlacesMembers;
        }
        return total;
    }

    public int getRestMemberPlaces(Ride ride)
    {
        int total = 0;
        foreach (Vehicle v in ride.vehicles)
        {
            total += v.CalculPassengersLeft(v);
        }
        return total;
    }

    public int getTotalBikePlaces(Ride ride)
    {
        int total = 0;
        foreach (Vehicle v in ride.vehicles)
        {
            total += v.NbrPlacesBikes;
        }
        return total;
    }

    public int getRestBikePlaces(Ride ride)
    {
        int total = 0;
        foreach (Vehicle v in ride.vehicles)
        {
            total += v.CalculBikeLeft(v);
        }
        return total;
    }


    public void addVehicle(Vehicle vehicle)
    {
        this.vehicles.Add(vehicle);
    }

    public bool AddRide(string UpdatePlace, DateTime UpdateDate, double UpdateFee, Calender calender)
    {
        DAO<Ride> rideDAO = adf.GetRideDAO();
        Ride ride = new Ride(0, UpdatePlace, UpdateDate, UpdateFee, calender.Category);

        if (rideDAO.Create(ride))
        {
            calender.AddRide(ride);
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool UpdateRide(Ride r, string UpdatePlace, DateTime UpdateDate, double UpdateFee, Calender calender)
    {
        DAO<Ride> rideDAO = adf.GetRideDAO();

        r.PlaceDeparture = UpdatePlace;
        r.DateDeparture = UpdateDate;
        r.PackageFee = UpdateFee;

        if (rideDAO.Update(r))
        {
            int index = calender.Rides.IndexOf(r);
            calender.Rides[index] = r;
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool DeleteRide(Ride r, Calender calender)
    {
        DAO<Ride> rideDAO = adf.GetRideDAO();

        if (rideDAO.Delete(r))
        {
            calender.Rides.Remove(r);
            return true;
        }
        else
        {
            return false;
        }
    }

    public List<Ride> GetRidesByCategory(int numCategory)
    {
        List<Ride> rides = dao.FindByCategory(numCategory);

        return rides;
    }

    

}
