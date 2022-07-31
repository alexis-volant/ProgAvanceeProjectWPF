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

    public List<Ride> FindRidesByMember(Member member)
    {
        List<Ride> rides = new List<Ride>();
        try
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * from dbo.Ride R join dbo.Inscription I " +
                    "on R.num = I.idRide join dbo.Member M on I.idMember = M.idMember where M.idMember = @id", connection);
                cmd.Parameters.AddWithValue("id", member.Id);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Ride ride = new Ride
                        (
                            reader.GetInt32("num"),
                        Ride ride = new Ride(
                            reader.GetInt32("numRide"),
                            reader.GetString("placeDeparture"),
                            reader.GetString("dateDeparture"),
                            reader.GetDateTime("dateDeparture"),
                            reader.GetFloat("packageFee"),
                            reader.Get
                        );
                            categoryDAO.Find(numCategory)
                            );
                        rides.Add(ride);
                    }
                }
            }
        }
        catch (SqlException)
        {
            throw new Exception("Une erreur sql s'est produite!");
        }
        return rides;
    }
}
