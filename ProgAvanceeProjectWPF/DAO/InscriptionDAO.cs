using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

internal class InscriptionDAO : DAO<Inscription>
{
    public InscriptionDAO() { }

    public override bool Create(Inscription i)
    {
        return false;
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
                        Inscription inscription = new Inscription(
                            reader.GetGuid("idInscription"),
                            member,
                            ride,
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
}
