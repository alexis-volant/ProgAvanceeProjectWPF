using System;

abstract class Person
{
    private Guid id;
    private string name;
    private string firstName;
    private string tel;
    private string login;
    private string passWord;

    public Person(Guid id, string name, string firstName, string tel, string login, string passWord)
    {
        this.id = id;
        this.name = name;
        this.firstName = firstName;
        this.tel = tel;
        this.login = login;
        this.passWord = passWord;
    }

    public Guid Id
    {
        get { return id; }
        set { id = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string FirstName
    {
        get { return firstName; }
        set { firstName = value; }
    }

    public string Tel
    {
        get { return tel; }
        set { tel = value; }
    }

    public string Login
    {
        get { return login; }
        set { login = value; }
    }

    public string PassWord
    {
        get { return passWord; }
        set { passWord = value; }
    }
}
