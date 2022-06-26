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
    public override Category Find(int id)
    {
        return null;
    }
    public List<Category> FindAll(Member member)
    {
        List<Category> categories = new List<Category>();
        try
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
                            Num = reader.GetInt32("num"),
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
        }
        return categories;
    }
}
