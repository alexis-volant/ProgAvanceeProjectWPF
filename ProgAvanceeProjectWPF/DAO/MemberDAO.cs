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
                SqlCommand cmd = new SqlCommand("INSERT into dbo.Member (idMember,name,firstName,telephone,login,password,balance,DatePayment,PaymentCheck) " +
                    "values(@idMember, @Name, @FirstName, @Tel, @Login, @PassWord, @Balance, @DatePayment, @PaymentCheck)", connection);
                cmd.Parameters.AddWithValue("idMember", m.Id);
                cmd.Parameters.AddWithValue("Name", m.Name);
                cmd.Parameters.AddWithValue("FirstName", m.FirstName);
                cmd.Parameters.AddWithValue("Tel", m.Tel);
                cmd.Parameters.AddWithValue("Login", m.Login);
                cmd.Parameters.AddWithValue("PassWord", m.PassWord);
                cmd.Parameters.AddWithValue("Balance", m.Balance);
                cmd.Parameters.AddWithValue("DatePayment", DateTime.Now);
                cmd.Parameters.AddWithValue("PaymentCheck", true);
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
    public override bool Update(Member m)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("UPDATE dbo.Member set name = @Name, firstName = @FirstName, telephone = @Tel, " +
                    "login = @Login, passWord = @PassWord, balance = @Balance, DatePayment = @DatePayment, PaymentCheck = @PaymentCheck WHERE idMember = @idMember",
                    connection);
                cmd.Parameters.AddWithValue("idMember", m.Id);
                cmd.Parameters.AddWithValue("Name", m.Name);
                cmd.Parameters.AddWithValue("FirstName", m.FirstName);
                cmd.Parameters.AddWithValue("Tel", m.Tel);
                cmd.Parameters.AddWithValue("Login", m.Login);
                cmd.Parameters.AddWithValue("PassWord", m.PassWord);
                cmd.Parameters.AddWithValue("Balance", m.Balance);
                cmd.Parameters.AddWithValue("DatePayment", m.DatePayment);
                cmd.Parameters.AddWithValue("PaymentCheck", m.PaymentCheck);
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
                        CategoryDAO categoryDAO = new CategoryDAO();
                        BikeDAO bikeDAO = new BikeDAO();
                        InscriptionDAO inscriptionDAO = new InscriptionDAO();
                        member = new Member(
                            reader.GetGuid("idMember"),
                            reader.GetString("name"),
                            reader.GetString("firstName"),
                            reader.GetString("telephone"),
                            reader.GetString("login"),
                            reader.GetString("password"),
                            reader.GetDouble("balance"),
                            reader.GetDateTime("DatePayment"),
                            reader.GetBoolean("PaymentCheck")
                            );
                        member.Categories = categoryDAO.FindAllByMember(member);
                        member.Bikes = bikeDAO.FindAllByMember(member);
                        member.Inscriptions = inscriptionDAO.FindAllByMember(member);
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
                    InscriptionDAO inscriptionDAO = new InscriptionDAO();
                    while (reader.Read())
                    {
                        Member member = new Member(
                            reader.GetGuid("idMember"),
                            reader.GetString("name"),
                            reader.GetString("firstName"),
                            reader.GetString("telephone"),
                            reader.GetString("login"),
                            reader.GetString("password"),
                            reader.GetDouble("balance"),
                            reader.GetDateTime("DatePayment"),
                            reader.GetBoolean("PaymentCheck")
                            );
                        member.Categories = categoryDAO.FindAllByMember(member);
                        member.Bikes = bikeDAO.FindAllByMember(member);
                        member.Inscriptions = inscriptionDAO.FindAllByMember(member);
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
    public List<Member> FindByCategory(int numCategory)
    {
        List<Member> members = new List<Member>();
        try
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Member M " +
                    "join dbo.CategoryMember CM on M.idMember = CM.idMember " +
                    "WHERE CM.numCategory = @numCategory", connection);
                cmd.Parameters.AddWithValue("numCategory", numCategory);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    CategoryDAO categoryDAO = new CategoryDAO();
                    BikeDAO bikeDAO = new BikeDAO();
                    InscriptionDAO inscriptionDAO = new InscriptionDAO();
                    while (reader.Read())
                    {
                        Member member = new Member(
                            reader.GetGuid("idMember"),
                            reader.GetString("name"),
                            reader.GetString("firstName"),
                            reader.GetString("telephone"),
                            reader.GetString("login"),
                            reader.GetString("password"),
                            reader.GetDouble("balance"),
                            reader.GetDateTime("DatePayment"),
                            reader.GetBoolean("PaymentCheck")
                            );
                        member.Categories = categoryDAO.FindAllByMember(member);
                        member.Bikes = bikeDAO.FindAllByMember(member);
                        member.Inscriptions = inscriptionDAO.FindAllByMember(member);
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

    public bool AddMemberCategory(Category category,Member member)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("INSERT into dbo.CategoryMember (numCategory,idMember) " +
                    "values(@numCategory, @idMember)", connection);
                cmd.Parameters.AddWithValue("idMember", member.Id);
                cmd.Parameters.AddWithValue("numCategory", category.Num);
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

    public bool RemoveMemberCategory(Member member)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("DELETE from dbo.CategoryMember WHERE idMember = @idMember ", connection);
                cmd.Parameters.AddWithValue("idMember", member.Id);
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
