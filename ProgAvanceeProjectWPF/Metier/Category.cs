﻿using System.Collections.Generic;

public class Category
{
    private int num = 0;
    private string nameCategory = "";
    private List<Member> members = new List<Member>();

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

    public List<Bike> GetBikesByMember(Member member)
    {
        BikeDAO dao = new BikeDAO();

        List<Bike> bikes = dao.FindBikesByMember(member);

        return bikes;
    }
}
