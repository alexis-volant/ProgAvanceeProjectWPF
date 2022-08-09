using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

internal class RideDAO : DAO<Ride>
{
    public RideDAO() { }

    public override bool Create(Ride r)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("INSERT into dbo.Ride (placeDeparture, dateDeparture, packageFee, numCategory) " +
                    "values(@PlaceDeparture, @DateDeparture, @PackageFee, @numCategory)", connection);
                cmd.Parameters.AddWithValue("PlaceDeparture", r.PlaceDeparture);
                cmd.Parameters.AddWithValue("DateDeparture", r.DateDeparture);
                cmd.Parameters.AddWithValue("PackageFee", r.PackageFee);
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
    public override bool Update(Ride r)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("UPDATE dbo.Ride set placeDeparture = @PlaceDeparture, dateDeparture = @DateDeparture, packageFee = @PackageFee WHERE numRide = @numRide",
                    connection);
                cmd.Parameters.AddWithValue("numRide", r.Num);
                cmd.Parameters.AddWithValue("PlaceDeparture", r.PlaceDeparture);
                cmd.Parameters.AddWithValue("DateDeparture", r.DateDeparture);
                cmd.Parameters.AddWithValue("PackageFee", r.PackageFee);
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
    public override bool Delete(Ride r)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("DELETE from dbo.Ride WHERE numRide = @numRide ", connection);
                cmd.Parameters.AddWithValue("numRide", r.Num);
                if (r.Num == 0)
                {
                    throw new Exception("No ride deleted");
                }
                else
                {
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
        catch (SqlException e)
        {
            return false;
            throw new Exception(e.Message);
        }
        
        return true;
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
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Ride R join dbo.Category C on R.numCategory = C.numCategory " +
                    "WHERE C.numCategory = @numCategory", connection);
                cmd.Parameters.AddWithValue("numCategory", numCategory);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    
                    VehicleDAO vehicleDAO = new VehicleDAO();
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
                        ride.Vehicles = vehicleDAO.FindByRide(ride);
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

    //public List<Ride> FindByMember(Member member)
    //{
    //    List<Ride> rides = new List<Ride>();
    //    try
    //    {
    //        using (SqlConnection connection = new SqlConnection(this.connectionString))
    //        {
    //            SqlCommand cmd = new SqlCommand("SELECT * from dbo.Ride R join dbo.Inscription I " +
    //                "on R.numRide = I.numRide join dbo.Member M on I.idMember = M.idMember where M.idMember = @id", connection);
    //            cmd.Parameters.AddWithValue("id", member.Id);
                
    //            connection.Open();
    //            using (SqlDataReader reader = cmd.ExecuteReader())
    //            {
    //                CategoryDAO categoryDAO = new CategoryDAO();
    //                while (reader.Read())
    //                {
    //                    Ride ride = new Ride
    //                    (
    //                        reader.GetInt32("num"),
    //                        reader.GetString("placeDeparture"),
    //                        reader.GetDateTime("dateDeparture"),
    //                        reader.GetDouble("packageFee"),
    //                        categoryDAO.Find(reader.GetInt32("numCategory"))
                            
    //                    );
    //                    rides.Add(ride);
    //                }
    //            }
    //        }
    //    }
    //    catch (SqlException e)
    //    {
    //        throw new Exception(e.Message);

    //    }
    //    return rides;
    //}
}
