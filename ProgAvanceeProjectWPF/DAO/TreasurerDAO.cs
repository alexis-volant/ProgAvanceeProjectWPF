using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

internal class TreasurerDAO : DAO<Treasurer>
{
    public TreasurerDAO() { }
    public override bool Create(Treasurer m)
    {
        /*try
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("INSERT into dbo.Member " +
                    "(idMember,name,firstName,tel,passWord,balance,login) " +
                    "values('" + m.Id + "' , '" + m.Name + "' , '" + m.FirstName + "'" +
                    " , '" + m.Tel + "' , '" + m.PassWord + "' , '" + m.Balance + "' , '" + m.Login + "')",
                    connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
        catch (SqlException)
        {
            throw new Exception("Une erreur sql s'est produite!");
        }*/
        return false;
    }
    public override bool Update(Treasurer obj)
    {
        /*try
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("update dbo.Vehicle set nbrPlacesmembers = @nbrMember, nbrPlacesBikes = @nbrBike WHERE idVehicle = @id",
                    connection);
                cmd.Parameters.AddWithValue("id", obj.IdVehicle);
                cmd.Parameters.AddWithValue("nbrMember", obj.NbrPlacesMembers);
                cmd.Parameters.AddWithValue("nbrBike", obj.NbrPlacesBikes);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
        catch (SqlException)
        {
            throw new Exception("Une erreur sql s'est produite!");
        }
        return false;*/
        return false;
    }
    public override bool Delete(Treasurer t)
    {
        /*try
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("DELETE from dbo.Member WHERE idMember = @id ", connection);
                cmd.Parameters.AddWithValue("id", m.Id);
                if (m.Id == 0)
                {
                    throw new Exception("No member deleted");
                }
                else
                {
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
        catch (SqlException)
        {
            throw new Exception("Une erreur sql s'est produite!");
        }*/
        return false;
    }
    public override Treasurer Find(int id)
    {
        /*Member member = null;
        try
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Member WHERE idMember = @id", connection);
                cmd.Parameters.AddWithValue("id", id);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        member = new Member
                        {
                            Id = reader.GetInt32("idMember"),
                            Name = reader.GetString("name"),
                            FirstName = reader.GetString("firstName"),
                            Tel = reader.GetInt32("tel"),
                            Login = reader.GetString("login"),
                            PassWord = reader.GetString("passWord"),
                            Balance = reader.GetDouble("balance"),
                            Categories = new List<Category>(),
                            Bikes = new List<Bike>(),
                            Inscriptions = new List<Inscription>()
                        };
                    }
                }
            }
            if (member != null)
            {
                CategoryDAO categoryDAO = new CategoryDAO();
                List<Category> categoryMember = categoryDAO.FindAll(member);
                foreach (Category cat in categoryMember)
                    member.Categories.Add(cat);
                BikeDAO bikeDAO = new BikeDAO();
                List<Bike> bikeMember = bikeDAO.FindAll(member);
                foreach (Bike bike in bikeMember)
                    member.Bikes.Add(bike);
                InscriptionDAO inscriptionDAO = new InscriptionDAO();
                List<Inscription> inscriptionMember = inscriptionDAO.FindAll(member);
                foreach (Inscription inscription in inscriptionMember)
                    member.Inscriptions.Add(inscription);
            }
        }
        catch (SqlException)
        {
            throw new Exception("Une erreur sql s'est produite!");
        }
        Member member = new Member(GUID, "Martens", "Rémi", "0492821292", "Member", "Password", 0);*/
        Treasurer treasurer = null;
        return treasurer;
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
