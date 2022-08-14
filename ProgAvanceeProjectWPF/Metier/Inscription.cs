using System;

public class Inscription
{
    private Guid idInscription;
    private Member member;
    private Ride ride; 
    private Bike bike;
    private bool passenger; 
    private bool hasbike;

    AbstractDAOFactory adf = AbstractDAOFactory.GetFactory(DAOFactoryType.MS_SQL_FACTORY);
    public Inscription() { }
    public Inscription(Guid idInscription, Member member, Ride ride, Bike bike, bool passenger, bool hasbike)
    {
        this.idInscription = idInscription;
        this.member = member;   
        this.ride = ride;
        this.bike = bike;
        this.passenger = passenger;
        this.hasbike = hasbike;
        
    }

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
    public bool Passenger
    {
        get { return passenger; }
        set { passenger = value; }
    }

    public bool Hasbike
    {
        get { return hasbike; }
        set { hasbike = value; }   
    }
    

    public bool AddInscription(Member member, Ride ride, Bike bike, bool passenger, bool hasBike, Vehicle vehicle)
    {
        DAO<Inscription> inscriptionDAO = adf.GetInscriptionDAO();
        InscriptionDAO dao = new InscriptionDAO();
        bool result;

        Inscription inscription = new Inscription(Guid.NewGuid(), member, ride, bike, passenger, hasBike);

        result = inscriptionDAO.Create(inscription);

        if (!result) return false;

        if (passenger)
        {
            if (!dao.AddPassenger(member, ride, vehicle)) return false;
            vehicle.addPassenger(member);
        }

        if (hasBike)
        {
            if (!dao.AddBikeVehicle(bike, ride, vehicle)) return false;
            vehicle.addBike(bike);
        }

        if (!passenger && !hasBike)
        {
            if (!dao.AddVehicleRide(ride, vehicle)) return false;
            ride.addVehicle(vehicle);
            vehicle.addRide(ride);
        }

        member.AddInscription(inscription);

        
       
        return true;
    }

}
