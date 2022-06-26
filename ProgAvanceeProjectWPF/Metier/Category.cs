using System.Collections.Generic;

class Category
{
    private int num = 0;
    private string nameCategory = "";
    private List<Member> members = new List<Member>();

    public int Num
    {
        get { return num; }
        set { num = value; }
    }

    public string NameCategory
    {
        get { return nameCategory; }
        set { nameCategory = value; }
    }

    public List<Member> Members
    {
        get { return members; }
        set { members = value; }
    }
}
