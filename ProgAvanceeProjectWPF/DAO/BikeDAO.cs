using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

internal class BikeDAO : DAO<Bike>
{
    public BikeDAO() { }
    public override bool Create(Bike obj)
    {
        return false;
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
    public List<Bike> FindAllByMember(Member member)
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
                        {
                            IdBike = reader.GetGuid("idBike"),
                            Weight = reader.GetFloat("weight"),
                            Type = reader.GetString("type"),
                            Length = reader.GetFloat("length"),
                        };
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
                        {
                            IdBike = reader.GetGuid("idBike"),
                            Weight = reader.GetFloat("weight"),
                            Type = reader.GetString("type"),
                            Length = reader.GetFloat("length"),
                        };
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
