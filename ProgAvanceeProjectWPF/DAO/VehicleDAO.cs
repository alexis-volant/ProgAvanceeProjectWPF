using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

internal class VehicleDAO : DAO<Vehicle>
{
    public override bool Create(Vehicle v)
    {
        return false;
    }
    public override bool Update(Vehicle obj)
    {
        return false;
    }
    public override bool Delete(Vehicle obj)
    {
        return false;
    }
    public override Vehicle Find(int id)
    {
        return null;
    }

    public List<Vehicle> FindByRide(Ride ride)
    {
        List<Vehicle> vehicles = new List<Vehicle>();
        try
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Vehicule V join dbo.VehicleRide VC "+
                    "on V.idVehicule = VC.idVehicule join dbo.Ride R on VC.idRide = R.idRide WHERE idRide = @id", connection);
                cmd.Parameters.AddWithValue("id", ride.Num);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        Vehicle vehicle = new Vehicle
                        (
                            //TO DO
                            reader.GetGuid("idVehicle"),
                            reader.GetInt32("nbrPlacesMembers"),
                            reader.GetInt32("nbrPlacesBikes"),
                            
                        );
                        vehicles.Add(vehicle);
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

}
