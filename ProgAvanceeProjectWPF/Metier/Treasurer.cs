using System;

public class Treasurer : Person
{
    AbstractDAOFactory adf = AbstractDAOFactory.GetFactory(DAOFactoryType.MS_SQL_FACTORY);

    public Treasurer()
    {

    }
    public Treasurer(Guid id, string name, string firstName, string tel, string login, string passWord) : base(id, name, firstName, tel, login, passWord)
    {

    }

    public void payerConducteur()
    {

    }

    public void reclamerForfait()
    {

    }

    public bool envoiLettreRappel(string obj, string content, Treasurer tres, Member member)
    {
        DAO<Message> messageDAO = adf.GetMessageDAO();
        Message message = new Message(Guid.NewGuid(), obj, content, tres, member, false);

        return messageDAO.Create(message);
    }

    public Treasurer loginCheck(string login, string password)
    {
        TreasurerDAO dao = new TreasurerDAO();

        return dao.loginCheck(login, password);
    }
}
