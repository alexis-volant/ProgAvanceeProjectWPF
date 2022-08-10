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
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Vehicle V join dbo.VehicleRide VC "+
                    "on V.idVehicle = VC.idVehicle join dbo.Member M on V.idDriver = M.idMember join dbo.Ride R on VC.numRide = R.numRide WHERE VC.numRide = @id", connection);
                cmd.Parameters.AddWithValue("id", ride.Num);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    MemberDAO memberDao = new MemberDAO();
                    BikeDAO bikeDao = new BikeDAO();

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

                        Vehicle vehicle = new Vehicle
                        (
                            reader.GetGuid("idVehicle"),
                            reader.GetInt32("nbrPlacesMembers"),
                            reader.GetInt32("nbrPlacesBikes")
                            
                        );

                        vehicle.Driver = member;
                        vehicle.Passengers = memberDao.GetPassengers(reader.GetInt32("numRide"), reader.GetGuid("idVehicle"));
                        vehicle.Bikes = bikeDao.GetBikeVehicles(reader.GetInt32("numRide"), reader.GetGuid("idVehicle"));
                        vehicles.Add(vehicle);
                    }
                }
            }
        }
        catch (SqlException e)
        {
            throw new Exception(e.Message);
        }
        return vehicles;
    }

    internal List<Vehicle> FindAllByMember(Member member)
    {
        List<Vehicle> vehicles = new List<Vehicle>();
        try
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Vehicle where idDriver = @id", connection);
                cmd.Parameters.AddWithValue("id", member.Id);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    MemberDAO memberDao = new MemberDAO();
                    BikeDAO bikeDao = new BikeDAO();

                    while (reader.Read())
                    {
                        Vehicle vehicle = new Vehicle
                        (
                            reader.GetGuid("idVehicle"),
                            reader.GetInt32("nbrPlacesMembers"),
                            reader.GetInt32("nbrPlacesBikes")     
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
        return vehicles;
    }
}
