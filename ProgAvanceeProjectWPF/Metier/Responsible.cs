using System;

public class Responsible : Person
{
    private Category? category;

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

    public Responsible loginCheck(string login, string password)
    {
        ResponsibleDAO dao = new ResponsibleDAO();
           
        return dao.loginCheck(login, password);
    }
}
   