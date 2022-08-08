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
                
                cmd = new SqlCommand("SELECT * from dbo.Category", connection);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Category cat = new Category(
                            reader.GetInt32("numCategory"),
                            reader.GetString("nameCategory")
                            );
                        categories.Add(cat);
                    }
                }
                connection.Close();
                
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

    public List<Category> FindAllByMember(Member member)
    {
        List<Int32> idCategories = new List<Int32>();
        List<Category> categories = new List<Category>();
        try
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.CategoryMember WHERE idMember = @id", connection);
                cmd.Parameters.AddWithValue("id", member.Id);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        idCategories.Add(reader.GetInt32("numCategory"));
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
}
