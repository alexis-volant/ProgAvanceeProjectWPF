using System;
using System.Collections.Generic;

public class Responsible : Person
{
    private Category? category;

    AbstractDAOFactory adf = AbstractDAOFactory.GetFactory(DAOFactoryType.MS_SQL_FACTORY);

    public Responsible()
    {

    }

    public Responsible(Guid id, string name, string firstname, string tel, string login, string password, Category category) : base(id, name, firstname, tel, login, password)
    {
        this.category = category;
    }

    public Category Category
    {
        get { return category; }
        set { category = value; }
    }

    public List<Responsible> GetAllResponsibles()
    {
        ResponsibleDAO dao = new ResponsibleDAO();
        return dao.GetAllResponsibles();
    }

    public bool AddResponsible(string AddName, string AddFirstName, string AddTelephone, string AddLogin, string AddPassWord, Category AddCategory)
    {
        DAO<Responsible> responsibleDAO = adf.GetResponsibleDAO();

        Responsible r = new Responsible(Guid.NewGuid(), AddName, AddFirstName, AddTelephone, AddLogin, AddPassWord, AddCategory);

        return responsibleDAO.Create(r);
    }
    
    public bool UpdateResponsible(Responsible r, string UpdateName, string UpdateFirstName, string UpdateTelephone, string UpdateLogin, string UpdatePassWord)
    {
        DAO<Responsible> responsibleDAO = adf.GetResponsibleDAO();

        r.Name = UpdateName;
        r.FirstName = UpdateFirstName;
        r.Tel = UpdateTelephone;
        r.Login = UpdateLogin;
        r.PassWord = UpdatePassWord;

        return responsibleDAO.Update(r);
    }

    public bool DeleteResponsible(Responsible r)
    {
        DAO<Responsible> responsibleDAO = adf.GetResponsibleDAO();

        return responsibleDAO.Delete(r);
    }

    public Responsible loginCheck(string login, string password)
    {
        ResponsibleDAO dao = new ResponsibleDAO();
           
        return dao.loginCheck(login, password);
    }
}
   