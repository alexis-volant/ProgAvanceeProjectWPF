using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

internal class TreasurerDAO : DAO<Treasurer>
{
    public TreasurerDAO() { }
    public override bool Create(Treasurer m)
    {      
        return false;
    }
    public override bool Update(Treasurer obj)
    {  
        return false;
    }
    public override bool Delete(Treasurer t)
    {
        return false;
    }
    public override Treasurer Find(int id)
    {
        return null;
    }
    public Treasurer loginCheck(string login, string password)
    {
        Treasurer treasurer = null;
        try
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Treasurer WHERE login = @login and password = @password", connection);
                cmd.Parameters.AddWithValue("login", login);
                cmd.Parameters.AddWithValue("password", password);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    MessageDAO messageDAO = new MessageDAO();
                    if (reader.Read())
                    {
                        treasurer = new Treasurer(
                            reader.GetGuid("idTreasurer"),
                            reader.GetString("name"),
                            reader.GetString("firstName"),
                            reader.GetString("telephone"),
                            reader.GetString("login"),
                            reader.GetString("password")
                            );
                        treasurer.Messages = messageDAO.FindAll(treasurer);
                    }
                }
            }
        }
        catch (SqlException e)
        {
            throw new Exception(e.Message);
        }
        return treasurer;
    }

    public List<Treasurer> FindAll()
    {
        List<Treasurer> treasurers = new List<Treasurer>();
        try
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Treasurer", connection);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Treasurer tres = new Treasurer
                        (
                            reader.GetGuid("idTreasurer"),
                            reader.GetString("name"),
                            reader.GetString("firstName"),
                            reader.GetString("telephone"),
                            reader.GetString("login"),
                            reader.GetString("password")
                        );
                        treasurers.Add(tres);
                    }
                }
            }
        }
        catch (SqlException)
        {
            throw new Exception("Une erreur sql s'est produite!");
        }
        return treasurers;
    }
    
}
