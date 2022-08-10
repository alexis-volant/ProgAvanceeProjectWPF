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

    public Vehicle()
    {
    }
    public Vehicle(Guid idVehicle, int nbrPlacesMembers, int nbrPlacesBikes)
    {
        this.idVehicle = idVehicle;
        this.nbrPlacesMembers = nbrPlacesMembers;
        this.nbrPlacesBikes = nbrPlacesBikes;
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

    public int CalculPassengersLeft(Vehicle vehicle)
    {
        var totalPlaces = vehicle.nbrPlacesMembers;
        var usedPlaces = vehicle.Passengers.Count;

        return totalPlaces - usedPlaces;
    }

    public int CalculBikeLeft(Vehicle vehicle)
    {
        var totalPlaces = vehicle.nbrPlacesBikes;
        var usedPlaces = vehicle.Bikes.Count;

        return totalPlaces - usedPlaces;
    }

}
