using System;
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
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Category WHERE num = @num", connection);
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
        catch (SqlException)
        {
            throw new Exception("Une erreur sql s'est produite!");
        }
        return category;
    }
    public List<Category> FindAll(Member member)
    {
        List<Category> categories = new List<Category>();
        /*try
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.infoCatMember WHERE idMember = @id", connection);
                cmd.Parameters.AddWithValue("id", member.Id);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Category cat = new Category
                        {
                            Num = reader.GetInt32("numCategory"),
                            NameCategory = reader.GetString("nameCategory")
                        };
                        categories.Add(cat);
                    }
                }
            }
        }
        catch (SqlException)
        {
            throw new Exception("Une erreur sql s'est produite!");
        }*/
        return categories;
    }
}
