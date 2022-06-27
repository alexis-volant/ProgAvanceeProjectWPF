using System;

class Responsible : Person
{
    private Category category;

    public Responsible(Guid id, string name, string firstname, string tel, string login, string password, Category category) : base(id, name, firstname, tel, login, password)
    {
        this.category = category;
    }

    public Category Category
    {
        get { return category; }
        set { category = value; }
    }
}
