public class Inscription
{
    private int idInscription;
    private Member member;
    private Ride ride; 
    private bool passenger; 
    private bool bike; 

    public int IdInscription
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

    public bool Passenger
    {
        get { return passenger; }
        set { passenger = value; }
    }

    public bool Bike
    {
        get { return bike; }
        set { bike = value; }
    }

}
