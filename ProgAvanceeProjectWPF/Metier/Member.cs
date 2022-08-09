using System;
using System.Collections.Generic;
using System.Linq;

public class Member : Person
{
    private double balance = 0;
    private List<Category> categories = new List<Category>();
    private List<Bike> bikes = new List<Bike>();
    private List<Inscription> inscriptions = new List<Inscription>();

    AbstractDAOFactory adf = AbstractDAOFactory.GetFactory(DAOFactoryType.MS_SQL_FACTORY);

    public Member()
    {

    }

    public Member(Guid id, string name, string firstName, string tel, string login, string passWord, double balance) : base(id, name, firstName, tel, login, passWord)
    {
        this.balance = balance;
    }

    public double Balance
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

    public List<Member> GetAllMembers()
    {
        MemberDAO dao = new MemberDAO();
        return dao.GetAllMembers();
    }

    public bool AddMember(string AddName, string AddFirstName, string AddTelephone, string AddLogin, string AddPassWord, double AddBalance)
    {
        DAO<Member> memberDAO = adf.GetMemberDAO();

        Member m = new Member(Guid.NewGuid(), AddName, AddFirstName, AddTelephone, AddLogin, AddPassWord, AddBalance);

        return memberDAO.Create(m);
    }

    public bool UpdateMember(Member m, string UpdateName, string UpdateFirstName, string UpdateTelephone, string UpdateLogin, string UpdatePassWord, double UpdateBalance)
    {
        DAO<Member> memberDAO = adf.GetMemberDAO();

        m.Name = UpdateName;
        m.FirstName = UpdateFirstName;
        m.Tel = UpdateTelephone;
        m.Login = UpdateLogin;
        m.PassWord = UpdatePassWord;
        m.Balance = UpdateBalance;

        return memberDAO.Update(m);
    }

    public bool DeleteMember(Member m)
    {
        DAO<Member> memberDAO = adf.GetMemberDAO();

        return memberDAO.Delete(m);
    }

    public Member loginCheck(string login, string password)
    {
        MemberDAO dao = new MemberDAO();
        return dao.loginCheck(login, password);
    }

    public void AddBike(Bike bike)
    {
        this.bikes.Add(bike);
    }
    public void UpdateBike(Bike bike)
    {
        // A VERIF
        var updatedBikeIndex = this.bikes.FindIndex(x => x.IdBike == bike.IdBike);
        bikes[updatedBikeIndex]= bike;
    }
    public void DeleteBike(Bike bike)
    {
        this.bikes.Remove(bike);
    }

    public bool AddCategory(Category category, Member member)
    {
        MemberDAO dao = new MemberDAO();
        dao.AddMemberCategory(category, member);
        this.Categories.Add(category);
        return true;
    }
}