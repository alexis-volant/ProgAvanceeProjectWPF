using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

internal class BikeDAO : DAO<Bike>
{
    public BikeDAO() { }
    public override bool Create(Bike b)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("INSERT into dbo.Bike (idBike, weight, length, type, idMember) " +
                    "values(@idBike, @weight, @length, @type, @idMember)", connection);

                cmd.Parameters.AddWithValue("idBike", b.IdBike);
                cmd.Parameters.AddWithValue("weight", b.Weight);
                cmd.Parameters.AddWithValue("length", b.Length);
                cmd.Parameters.AddWithValue("type", b.Type);
                cmd.Parameters.AddWithValue("idMember", b.Member.Id);

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
    public override bool Update(Bike obj)
    {
        return false;
    }
    public override bool Delete(Bike obj)
    {
        return false;
    }
    public override Bike Find(int id)
    {
        return null;
    }
    public List<Bike> FindBikesByMember(Member member)
    {
        List<Bike> bikes = new List<Bike>();
        try
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Bike WHERE idMember = @id", connection);
                cmd.Parameters.AddWithValue("id", member.Id);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Bike bike = new Bike
                        (
                            reader.GetGuid("idBike"),
                            reader.GetDouble("weight"),
                            reader.GetString("type"),
                            reader.GetDouble("length"),
                            member
                        );
                        bikes.Add(bike);
                    }
                }
            }
        }
        catch (SqlException e)
        {
            throw new Exception(e.Message);
        }
        return bikes;
    }

    public List<Bike> FindAll()
    {
        List<Bike> bikes = new List<Bike>();
        try
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Bike", connection);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Bike bike = new Bike
                        (
                            reader.GetGuid("idBike"),
                            reader.GetDouble("weight"),
                            reader.GetString("type"),
                            reader.GetDouble("length")   
                        );
                        bikes.Add(bike);
                    }
                }
            }
        }
        catch (SqlException)
        {
            throw new Exception("Une erreur sql s'est produite!");
        }
        return bikes;
    }
}
