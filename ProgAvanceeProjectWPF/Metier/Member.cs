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
    MemberDAO dao = new MemberDAO();

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

    //Ajoute une catégorie dans la liste des catégorie de ce membre
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
}