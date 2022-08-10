using System.Collections.Generic;

public class Category
{
    private int num = 0;
    private string nameCategory = "";
    private List<Member> members = new List<Member>();

    CategoryDAO dao = new CategoryDAO();

    public Category() { }
    

    public Category(int num, string nameCategory)
    {
        this.num = num;
        this.nameCategory = nameCategory;
    }

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

    public bool RemoveMember(Member m, Category cat)
    {
        this.Members.Remove(m);
        return dao.RemoveMember(m, cat);
    }

    public Category GetCategory(int numCategory)
    {
        return dao.Find(numCategory);
    }

    public List<Category> GetAllWOResponsible()
    {
        return dao.FindWOResponsible();
    }

    public List<Category> GetAllCategories()
    {
        return dao.FindAll();
    }
}
