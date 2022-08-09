using System;
using System.Collections.Generic;

public class Vehicle
{
    private Guid idVehicle;
    private int nbrPlacesMembers;
    private int nbrPlacesBikes;
    private Member driver;
    private List<Member> passengers;
    private List<Bike> bikes;
    private List<Ride> rides;

    public Vehicle(Guid idVehicle, int nbrPlacesMembers, int nbrPlacesBikes, Member driver, List<Member> passengers, List<Bike> bikes, List<Ride> rides)
    {
        this.idVehicle = idVehicle;
        this.nbrPlacesMembers = nbrPlacesMembers;
        this.nbrPlacesBikes = nbrPlacesBikes;
        this.driver = driver;
        this.passengers = passengers;
        this.bikes = bikes;
        this.rides = rides;
    }

    public Guid IdVehicle
    {
        get { return idVehicle; }
        set { idVehicle = value; }
    }

    public int NbrPlacesMembers
    {
        get { return nbrPlacesMembers; }
        set { nbrPlacesMembers = value; }
    }

    public int NbrPlacesBikes
    {
        get { return nbrPlacesBikes; }
        set { nbrPlacesBikes = value; }
    }

    public Member Driver
    {
        get { return driver; }
        set { driver = value; }
    }

    public List<Member> Passengers
    {
        get { return passengers; }
        set { passengers = value; }
    }

    public List<Bike> Bikes
    {
        get { return bikes; }
        set { bikes = value; }
    }

    public List<Ride> Rides
    {
        get { return rides; }
        set { rides = value; }
    }

    public void addPassenger(Member passenger)
    {
        this.passengers.Add(passenger);
    }

    public void addBike(Bike bike)
    {
        this.bikes.Add(bike);
    }

    public void addRide(Ride ride)
    {
        this.rides.Add(ride);
    }
}
