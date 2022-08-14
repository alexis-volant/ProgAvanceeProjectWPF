using System;
using System.Collections.Generic;
using System.Linq;

public class Member : Person
{
    private double balance = 0;
    private DateTime datePayment;
    private bool paymentCheck;
    private List<Category> categories = new List<Category>();
    private List<Bike> bikes = new List<Bike>();
    private List<Inscription> inscriptions = new List<Inscription>();
    private List<Vehicle> vehicles = new List<Vehicle>();
    private List<Message> messages = new List<Message>();

    AbstractDAOFactory adf = AbstractDAOFactory.GetFactory(DAOFactoryType.MS_SQL_FACTORY);
    MemberDAO dao = new MemberDAO();

    public Member()
    {

    }

    public Member(Guid id, string name, string firstName, string tel, string login, string passWord, double balance) : base(id, name, firstName, tel, login, passWord)
    {
        this.balance = balance;
    }

    public Member(Guid id, string name, string firstName, string tel, string login, string passWord, double balance, DateTime datePayment, bool paymentCheck) : base(id, name, firstName, tel, login, passWord)
    {
        this.balance = balance;
        this.datePayment = datePayment;
        this.paymentCheck = paymentCheck;
    }

    public double Balance
    {
        get { return balance; }
        set { balance = value; }
    }

    public DateTime DatePayment
    {
        get { return datePayment; }
        set { datePayment = value; }
    }

    public bool PaymentCheck
    {
        get { return paymentCheck; }
        set { paymentCheck = value; }
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
    
    public List<Message> Messages
    {
        get { return messages; }
        set { messages = value; }
    }

    public List<Vehicle> Vehicles
    {
        get { return vehicles; }
        set { vehicles = value; }   
    }

    public void calculBalance(double amount)
    {
        balance += amount;
    }

    public bool verifyBalance(double amount)
    {
        return Balance >= amount;
    }

    //Récupère tous les membres
    public List<Member> GetAllMembers()
    {
        MemberDAO dao = new MemberDAO();
        return dao.GetAllMembers();
    }

    //CRUD MEMBER
    public bool AddMember(string AddName, string AddFirstName, string AddTelephone, string AddLogin, string AddPassWord, double AddBalance, Category cat)
    {
        DAO<Member> memberDAO = adf.GetMemberDAO();

        Member m = new Member(Guid.NewGuid(), AddName, AddFirstName, AddTelephone, AddLogin, AddPassWord, AddBalance);

        if (memberDAO.Create(m))
        {
            m.AddCategory(cat, m);
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool UpdateMember(Member m)
    {
        DAO<Member> memberDAO = adf.GetMemberDAO();
        return memberDAO.Update(m);
    }
    public bool DeleteMember(Member m)
    {
        DAO<Member> memberDAO = adf.GetMemberDAO();

        if (dao.RemoveMemberCategory(m))
        {
            memberDAO.Delete(m);
            return true;
        }
        else
        {
            return false;
        }
    }

    //Vérifie si le Membre existe en Base de données
    public Member loginCheck(string login, string password)
    {
        return dao.loginCheck(login, password);
    }

    //Ajout modification Suppression d'un vélo 
    public void AddBike(Bike bike)
    {
        this.bikes.Add(bike);
    }
    public void UpdateBike(Bike bike)
    {
        var updatedBikeIndex = this.bikes.FindIndex(x => x.IdBike == bike.IdBike);
        bikes[updatedBikeIndex]= bike;
    }
    public void DeleteBike(Bike bike)
    {
        this.bikes.Remove(bike);
    }

    public void AddVehicle(Vehicle vehicle)
    {
        this.vehicles.Add(vehicle);
    }

    public void AddInscription(Inscription inscription)
    {
        this.inscriptions.Add(inscription);
    }
    public bool AddCategory(Category category, Member member)
    {
        if(dao.AddMemberCategory(category, member))
        {
            this.Categories.Add(category);
            return true;
        }
        else
        {
            return false;
        }
    }

    public List<Member> CheckDate(List<Member> members)
    {
        foreach (Member m in members)
        {
            if (m.DatePayment.AddYears(1) < DateTime.Now)
            {
                m.PaymentCheck = false;
                m.UpdateMember(m);
            }
        }
        return members;
    }


}
