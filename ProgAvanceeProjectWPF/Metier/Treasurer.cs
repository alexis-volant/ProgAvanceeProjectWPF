using System;

public class Treasurer : Person
{

    public Treasurer()
    {

    }
    public Treasurer(Guid id, string name, string firstName, string tel, string login, string passWord) : base(id, name, firstName, tel, login, passWord)
    {
    }

    public void envoiLettreRappel()
    {

    }

    public void payerConducteur()
    {

    }

    public void reclamerForfait()
    {

    }

    public Treasurer loginCheck(string login, string password)
    {
        TreasurerDAO dao = new TreasurerDAO();

        return dao.loginCheck(login, password);
    }
}
