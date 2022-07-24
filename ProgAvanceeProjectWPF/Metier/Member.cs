using System;
using System.Collections.Generic;

class Member : Person
{
    private float balance = 0;
    private List<Category> categories = new List<Category>();
    private List<Bike> bikes = new List<Bike>();
    private List<Inscription> inscriptions = new List<Inscription>();

    public Member(Guid id, string name, string firstName, string tel, string login, string passWord, float balance) : base(id, name, firstName, tel, login, passWord)
    {
        this.balance = balance;
    }

    public float Balance
    {
        get { return balance; }
        set { balance = value; }
    }

    public List<Category> Categories
    {
        get { return categories; }
        set { categories = value; }
    }

    public List<Bike> Bikes
    {
        get { return bikes; }
        set { bikes = value; }
    }

    public List<Inscription> Inscriptions
    {
        get { return inscriptions; }
        set { inscriptions = value; }
    }

    public void calculBalance()
    {

    }

    public void verifyBalance()
    {

    }

    public Member loginCheck(string login, string password)
    {
        MemberDAO dao = new MemberDAO();

        return dao.loginCheck(login, password);
    }

}
