using System;

class Inscription
{
    private Guid idInscription;
    private Member member;
    private Ride ride;
    private Bike bike;
    private bool isPassenger; 
    private bool hasBike; 

    public Guid IdInscription
    {
        get { return idInscription; }
        set { idInscription = value; }
    }

    public Member Member
    {
        get { return member; }
        set { member = value; }
    }

    public Ride Ride
    {
        get { return ride; }
        set { ride = value; }
    }

    public Bike Bike
    {
        get { return bike; }
        set { bike = value; }
    }

    public bool IsPassenger
    {
        get { return isPassenger; }
        set { isPassenger = value; }
    }

    public bool HasBike
    {
        get { return hasBike; }
        set { hasBike = value; }
    }

}
