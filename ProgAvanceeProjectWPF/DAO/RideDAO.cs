using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

internal class RideDAO : DAO<Ride>
{
    public RideDAO() { }

    public override bool Create(Ride r)
    {
        return false;
    }
    public override bool Update(Ride obj)
    {
        return false;
    }
    public override bool Delete(Ride r)
    {
        return false;
    }
    public override Ride Find(int id)
    {
        return null;
    }

    public List<Ride> FindByCategory(int numCategory)
    {
        List<Ride> rides = new List<Ride>();
        try
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Ride WHERE numCategory = @numCategory", connection);
                cmd.Parameters.AddWithValue("numCategory", numCategory);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    CategoryDAO categoryDAO = new CategoryDAO();
                    while (reader.Read())
                    {
                        Ride ride = new Ride(
                            reader.GetInt32("numRide"),
                            reader.GetString("placeDeparture"),
                            reader.GetDateTime("dateDeparture"),
                            reader.GetFloat("packageFee"),
                            categoryDAO.Find(numCategory)
                            );
                        rides.Add(ride);
                    }
                }
            }
        }
        catch (SqlException e )
        {
            throw new Exception(e.Message);
        }
        return rides;
    }
}
