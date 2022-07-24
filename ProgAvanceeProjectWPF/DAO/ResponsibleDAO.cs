using System;
using System.Data;
using System.Data.SqlClient;

internal class ResponsibleDAO : DAO<Responsible>
{
    public ResponsibleDAO() { }
    public override bool Create(Responsible obj)
    {
        return false;
    }
    public override bool Update(Responsible obj)
    {
        return false;
    }
    public override bool Delete(Responsible obj)
    {
        return false;
    }
    public override Responsible Find(int id)
    {
        return null;
    }

    public Responsible loginCheck(string login, string password)
    {
        Responsible responsible = null;
        try
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Responsible WHERE login = @login and password = @password", connection);
                cmd.Parameters.AddWithValue("login", login);
                cmd.Parameters.AddWithValue("password", password);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        CategoryDAO categoryDAO = new CategoryDAO();
                        responsible = new Responsible(
                            reader.GetGuid("idResponsible"),
                            reader.GetString("name"),
                            reader.GetString("firstName"),
                            reader.GetString("telephone"),
                            reader.GetString("login"),
                            reader.GetString("password"),
                            categoryDAO.Find(reader.GetInt32("numCategory"))
                            );
                    }
                }
            }
        }
        catch (SqlException e)
        {
            throw new Exception(e.Message);
        }
        return responsible;
    }
}