using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

internal class ResponsibleDAO : DAO<Responsible>
{
    public ResponsibleDAO() { }
    public override bool Create(Responsible r)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("INSERT into dbo.Responsible (idResponsible,name,firstName,telephone,login,password,numCategory) " +
                    "values(@idResponsible, @Name, @FirstName, @Tel, @Login, @PassWord, @numCategory)", connection);
                cmd.Parameters.AddWithValue("idResponsible", r.Id);
                cmd.Parameters.AddWithValue("Name", r.Name);
                cmd.Parameters.AddWithValue("FirstName", r.FirstName);
                cmd.Parameters.AddWithValue("Tel", r.Tel);
                cmd.Parameters.AddWithValue("Login", r.Login);
                cmd.Parameters.AddWithValue("PassWord", r.PassWord);
                cmd.Parameters.AddWithValue("numCategory", r.Category.Num);
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
    public override bool Update(Responsible r)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("UPDATE dbo.Responsible set name = @Name, firstName = @FirstName," +
                    " telephone = @Tel, login = @Login, passWord = @PassWord WHERE idResponsible = @idResponsible",
                    connection);
                cmd.Parameters.AddWithValue("idResponsible", r.Id);
                cmd.Parameters.AddWithValue("Name", r.Name);
                cmd.Parameters.AddWithValue("FirstName", r.FirstName);
                cmd.Parameters.AddWithValue("Tel", r.Tel);
                cmd.Parameters.AddWithValue("Login", r.Login);
                cmd.Parameters.AddWithValue("PassWord", r.PassWord);
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
    public override bool Delete(Responsible r)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("DELETE from dbo.Responsible WHERE idResponsible = @idResponsible ", connection);
                cmd.Parameters.AddWithValue("idResponsible", r.Id);
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
    public override Responsible Find(int id)
    {
        return null;
    }

    public List<Responsible> GetAllResponsibles()
    {
        List<Responsible> responsibles = new List<Responsible>();
        try
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Responsible", connection);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    CategoryDAO categoryDAO = new CategoryDAO();
                    while (reader.Read())
                    {
                        Responsible responsible = new Responsible(
                            reader.GetGuid("idResponsible"),
                            reader.GetString("name"),
                            reader.GetString("firstName"),
                            reader.GetString("telephone"),
                            reader.GetString("login"),
                            reader.GetString("password"),
                            categoryDAO.Find(reader.GetInt32("numCategory"))
                            );
                        responsibles.Add(responsible);
                    }
                }
            }
        }
        catch (SqlException e)
        {
            throw new Exception(e.Message);
        }
        return responsibles;
    }

    public int CountResponsibles()
    {
        int count = 0;
        try
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT count(idResponsible) as count from dbo.Responsible", connection);
                cmd.ExecuteNonQuery();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if(reader.Read())
                    {
                        count = reader.GetInt32("count");
                    }
                }
            }
        }
        catch (SqlException e)
        {
            return -1;
            throw new Exception(e.Message);
        }

        return count;
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