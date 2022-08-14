using System;
using System.Linq;
using System.Collections.Generic;

public class Treasurer : Person
{
    List<Message> messages = new List<Message>();
    AbstractDAOFactory adf = AbstractDAOFactory.GetFactory(DAOFactoryType.MS_SQL_FACTORY);

    public Treasurer()
    {

    }

    public Treasurer(Guid id, string name, string firstName, string tel, string login, string passWord) : base(id, name, firstName, tel, login, passWord)
    {

    }

    public List<Message> Messages
    {
        get { return messages; }
        set { messages = value; }
    }

    public bool payerConducteur(Member member, double amount)
    {
        member.calculBalance(amount);
        return member.UpdateMember(member);
    }

    public bool reclamerForfait(Member member, double amount)
    {
        member.calculBalance(-amount);
        return member.UpdateMember(member);
    }

    public void updateMessage(Message message)
    {
        int index = this.messages.IndexOf(message);
        this.messages[index] = message;
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

    public Treasurer GetTreasurer()
    {
        TreasurerDAO dao = new TreasurerDAO();
        return dao.FindAll().FirstOrDefault();
    }
}
