abstract class Person
{
    private int id;
    private string name;
    private string firstName;
    private int tel;
    private string login;
    private string passWord;

    public Person(int id, string name, string firstName, int tel, string login, string passWord)
    {
        this.id = id;
        this.name = name;
        this.firstName = firstName;
        this.tel = tel;
        this.login = login;
        this.passWord = passWord;
    }

    public int Id
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

    public int Tel
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
