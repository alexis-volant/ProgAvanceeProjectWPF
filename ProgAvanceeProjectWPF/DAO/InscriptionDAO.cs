using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

internal class InscriptionDAO : DAO<Inscription>
{
    public InscriptionDAO() { }

    public override bool Create(Inscription i)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("INSERT into dbo.Inscription (idInscription, passenger, bike, numRide, idMember, idBike) " +
                    "values(@idInscription, @passenger, @bike, @numRide, @idMember, @idBike)", connection);

                cmd.Parameters.AddWithValue("idInscription", i.IdInscription);
                cmd.Parameters.AddWithValue("passenger", i.Passenger);
                cmd.Parameters.AddWithValue("bike", i.Hasbike);
                cmd.Parameters.AddWithValue("numRide", i.Ride.Num);
                cmd.Parameters.AddWithValue("idMember", i.Member.Id);
                cmd.Parameters.AddWithValue("idBike", i.Bike.IdBike);

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
    public override bool Update(Inscription i)
    {
        return false;
    }
    public override bool Delete(Inscription i)
    {
        return false;
    }
    public override Inscription Find(int id)
    {
        return null;
    }
    public List<Inscription> FindAllByMember(Member member)
    {
        List<Inscription> inscriptions = new List<Inscription>();
        try
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Member M " +
                    "join dbo.Inscription I on M.idMember = I.idMember " +
                    "join dbo.Ride R on I.numRide = R.numRide " +
                    "join dbo.Bike B on I.IdBike = B.idBike "+
                    "join dbo.Category C on R.numCategory = C.numCategory " +
                    "WHERE M.idMember = @id", connection);
                cmd.Parameters.AddWithValue("id", member.Id);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        Category category = new Category(
                            reader.GetInt32("numCategory"),
                            reader.GetString("nameCategory")
                            );
                        Ride ride = new Ride(
                            reader.GetInt32("numRide"),
                            reader.GetString("placeDeparture"),
                            reader.GetDateTime("dateDeparture"),
                            reader.GetDouble("packageFee"),
                            category
                            );
                        Bike bike = new Bike(
                            reader.GetGuid("idBike"),
                            reader.GetDouble("weight"),
                            reader.GetString("type"),
                            reader.GetDouble("length"),
                            member
                            );
                        Inscription inscription = new Inscription(
                            reader.GetGuid("idInscription"),
                            member,
                            ride,
                            bike,
                            reader.GetBoolean("passenger"),
                            reader.GetBoolean("bike")
                            );
                        inscriptions.Add(inscription);
                    }
                }
            }
        }
        catch (SqlException e)
        {
            throw new Exception(e.Message);
        }
        return inscriptions;
    }

    public bool AddPassenger(Member m,Ride r,Vehicle v)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("INSERT into dbo.Passenger (idMember, idVehicle, numRide) " +
                    "values(@idMember, @idVehicle, @numRide)", connection);

                cmd.Parameters.AddWithValue("idMember", m.Id);
                cmd.Parameters.AddWithValue("idVehicle", v.IdVehicle);
                cmd.Parameters.AddWithValue("numRide", r.Num);
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
    public bool AddBikeVehicle(Bike b,Ride r,Vehicle v)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("INSERT into dbo.BikeVehicle (idBike, idVehicle, numRide) " +
                    "values(@idBike, @idVehicle, @numRide)", connection);

                cmd.Parameters.AddWithValue("idBike", b.IdBike);
                cmd.Parameters.AddWithValue("idVehicle", v.IdVehicle);
                cmd.Parameters.AddWithValue("numRide", r.Num);
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

    public bool AddVehicleRide(Ride r, Vehicle v)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("INSERT into dbo.VehicleRide (idVehicle, numRide) " +
                    "values(@idVehicle, @numRide)", connection);
                cmd.Parameters.AddWithValue("idVehicle", v.IdVehicle);
                cmd.Parameters.AddWithValue("numRide", r.Num);
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

    public List<Member> GetAllParticipants(Ride ride)
    {
        List<Member> members = new List<Member>();
        try
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand("Select * from dbo.Member M " +
                    "join dbo.Inscription I on M.idMember = I.idMember " +
                    "join dbo.Ride R on I.numRide = R.numRide " +
                    "WHERE I.numRide = @numRide", connection);

                cmd.Parameters.AddWithValue("numRide", ride.Num);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
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
}
