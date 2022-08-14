internal class MSSQLFactory : AbstractDAOFactory
{
    public override DAO<Member> GetMemberDAO()
    {
        return new MemberDAO();
    }

    public override DAO<Bike> GetBikeDAO()
    {
        return new BikeDAO();
    }

    public override DAO<Category> GetCategoryDAO()
    {
        return new CategoryDAO();
    }

    public override DAO<Inscription> GetInscriptionDAO()
    {
        return new InscriptionDAO();
    }

    public override DAO<Responsible> GetResponsibleDAO()
    {
        return new ResponsibleDAO();
    }

    public override DAO<Ride> GetRideDAO()
    {
        return new RideDAO();
    }

    public override DAO<Vehicle> GetVehicleDAO()
    {
        return new VehicleDAO();
    }

    public override DAO<Message> GetMessageDAO()
    {
        return new MessageDAO();
    }
}