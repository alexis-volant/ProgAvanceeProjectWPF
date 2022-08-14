public enum DAOFactoryType
{
    MS_SQL_FACTORY,
    XML_FACTORY
}
internal abstract class AbstractDAOFactory
{
    public abstract DAO<Member> GetMemberDAO();
    public abstract DAO<Category> GetCategoryDAO();
    public abstract DAO<Responsible> GetResponsibleDAO();
    public abstract DAO<Ride> GetRideDAO();
    public abstract DAO<Bike> GetBikeDAO();
    public abstract DAO<Inscription> GetInscriptionDAO();
    public abstract DAO<Vehicle> GetVehicleDAO();
    public abstract DAO<Message> GetMessageDAO();

    public static AbstractDAOFactory GetFactory(DAOFactoryType type)
    {
        switch (type)
        {
            case DAOFactoryType.MS_SQL_FACTORY:
                return new MSSQLFactory();
            case DAOFactoryType.XML_FACTORY:
                return null;
            default:
                return null;
        }
    }
}
