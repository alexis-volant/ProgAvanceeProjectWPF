using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

internal class CategoryDAO : DAO<Category>
{
    public CategoryDAO() { }
    public override bool Create(Category obj)
    {
        return false;
    }
    public override bool Update(Category obj)
    {
        return false;
    }
    public override bool Delete(Category obj)
    {
        return false;
    }

    public override Category Find(int num)
    {
        Category category = null;
        try
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Category WHERE numCategory = @num", connection);
                cmd.Parameters.AddWithValue("num", num);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        category = new Category(
                            reader.GetInt32("numCategory"),
                            reader.GetString("nameCategory")
                            );
                    }
                }
            }
        }
        catch (SqlException e)
        {
            throw new Exception(e.Message);
        }
        return category;
    }

    public List<Category> FindWOResponsible()
    {
        List<Category> categories = new List<Category>();
        List<Category> catWithResp = new List<Category>();
        try
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT numCategory from dbo.Responsible", connection);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        catWithResp.Add(Find(reader.GetInt32("numCategory")));
                    }
                }

                categories = FindAll();
                
                foreach (Category cat in catWithResp)
                {
                    categories.RemoveAll(c => c.Num == cat.Num);
                }
            }
        }
        catch (SqlException e)
        {
            throw new Exception(e.Message);
        }

        return categories;
    }

    public List<Category> FindAll()
    {
        List<Category> categories = new List<Category>();
        Category cat = new Category();
        try
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Category", connection);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    MemberDAO memberDAO = new MemberDAO();
                    while (reader.Read())
                    {
                        cat = new Category(
                            reader.GetInt32("numCategory"),
                            reader.GetString("nameCategory")
                            );
                        cat.Members = memberDAO.FindByCategory(reader.GetInt32("numCategory"));
                        categories.Add(cat);
                    }
                }
            }
        }
        catch (SqlException e)
        {
            throw new Exception(e.Message);
        }

        return categories;

    }

    public List<Category> FindAllByMember(Member member)
    {
        List<Int32> idCategories = new List<Int32>();
        List<Category> categories = new List<Category>();
        try
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Category C join dbo.CategoryMember CATMEMBER " +
                    "on C.numCategory = CATMEMBER.numCategory join dbo.Member M on CATMEMBER.idMember =  M.idMember WHERE M.idMember = @id", connection);
                cmd.Parameters.AddWithValue("id", member.Id);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Category cat = new Category
                        (
                            reader.GetInt32("numCategory"),
                            reader.GetString("nameCategory")
                        );
                        categories.Add(cat);
                    }   
                }
            }
        }
        catch (SqlException e)
        {
            throw new Exception(e.Message);
        }
        return categories;

    }

    public bool RemoveMember(Member member, Category cat)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("DELETE from dbo.CategoryMember WHERE idMember = @idMember and numCategory = @numCategory ", connection);
                cmd.Parameters.AddWithValue("idMember", member.Id);
                cmd.Parameters.AddWithValue("numCategory", cat.Num);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
        catch (SqlException e)
        {
            return false;
            throw new Exception(e.Message);
        }

        return true;
    }
}
