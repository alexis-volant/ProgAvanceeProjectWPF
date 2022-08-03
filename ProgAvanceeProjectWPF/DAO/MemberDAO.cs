using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

internal class MemberDAO : DAO<Member>
{
    public MemberDAO() { }
    public override bool Create(Member m)
    {
        try
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
        }
        return false;
    }
    public override bool Update(Member m)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("UPDATE dbo.Member set name = @Name, firstName = @FirstName, telephone = @Tel, login = @Login, passWord = @PassWord, balance = @Balance WHERE idMember = @idMember",
                    connection);
                cmd.Parameters.AddWithValue("idMember", m.Id);
                cmd.Parameters.AddWithValue("Name", m.Name);
                cmd.Parameters.AddWithValue("FirstName", m.FirstName);
                cmd.Parameters.AddWithValue("Tel", m.Tel);
                cmd.Parameters.AddWithValue("Login", m.Login);
                cmd.Parameters.AddWithValue("PassWord", m.PassWord);
                cmd.Parameters.AddWithValue("Balance", m.Balance);
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
    public override bool Delete(Member m)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("DELETE from dbo.Member WHERE idMember = @idMember ", connection);
                cmd.Parameters.AddWithValue("idMember", m.Id);
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
    public override Member Find(int id)
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
        Member member = null;
        return member;
    }
    public Member loginCheck(string login, string password)
    {
        Member member = null;
        try
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Member WHERE login = @login and password = @password", connection);
                cmd.Parameters.AddWithValue("login", login);
                cmd.Parameters.AddWithValue("password", password);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        member = new Member(
                            reader.GetGuid("idMember"),
                            reader.GetString("name"),
                            reader.GetString("firstName"),
                            reader.GetString("telephone"),
                            reader.GetString("login"),
                            reader.GetString("password"),
                            reader.GetDouble("balance")
                            );
                    }
                }
            }
        }
        catch (SqlException e)
        {
            throw new Exception(e.Message);
        }
        return member;
    }

    public List<Member> GetAllMembers()
    {
        List<Member> members = new List<Member>();
        try
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Member", connection);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    CategoryDAO categoryDAO = new CategoryDAO();
                    BikeDAO bikeDAO = new BikeDAO();
                    while (reader.Read())
                    {
                        Member member = new Member(
                            reader.GetGuid("idMember"),
                            reader.GetString("name"),
                            reader.GetString("firstName"),
                            reader.GetString("telephone"),
                            reader.GetString("login"),
                            reader.GetString("password"),
                            reader.GetDouble("balance")
                            );
                        member.Categories = categoryDAO.FindAllByMember(member);
                        member.Bikes = bikeDAO.FindAllByMember(member);
                        members.Add(member);
                    }
                }
            }
        }
        catch (SqlException e)
        {
            throw new Exception(e.Message);
        }
        return members;
    }
    /*public List<Member> FindAll()
    {
        List<Member> listMember = new List<Member>();
        try
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Member", connection);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Member mem = new Member
                        {
                            Id = reader.GetInt32("idMember"),
                            Name = reader.GetString("name"),
                            FirstName = reader.GetString("firstName"),
                            Tel = reader.GetInt32("tel"),
                            Login = reader.GetString("login"),
                            PassWord = reader.GetString("passWord"),
                            Balance = reader.GetDouble("balance"),
                            Categories = new List<Category>(),
                            Bikes = new List<Bike>()
                        };
                        listMember.Add(mem);
                    }
                }
            }
        }
        catch (SqlException)
        {
            throw new Exception("Une erreur sql s'est produite!");
        }
        return listMember;
    }

    public bool Add(int idMember, int idCategory)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("INSERT into dbo.infoCatMember " +
                    "(idMember,idCategory) " +
                    "values('" + idMember + "' , '" + idCategory + "' )",
                    connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
        catch (SqlException)
        {
            throw new Exception("Une erreur sql s'est produite!");
        }
        return false;
    }
    public Member LoginCheck(string login, string password)
    {
        Member member = null;
        try
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {

                SqlCommand cmd = new SqlCommand("Select *  from dbo.Member where passWord = @pw and login = @login",
                    connection);
                cmd.Parameters.AddWithValue("pw", password);
                cmd.Parameters.AddWithValue("login", login);
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
                            Bikes = new List<Bike>()
                        };
                    }
                }
            }
        }
        catch (SqlException)
        {
            throw new Exception("Une erreur sql s'est produite!");
        }
        return member;
    }*/
}
