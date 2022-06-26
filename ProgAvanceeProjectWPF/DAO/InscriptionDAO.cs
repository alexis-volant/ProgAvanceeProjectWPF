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
    public override bool Update(Inscription obj)
    {
        return false;
    }
    public override bool Delete(Inscription obj)
    {
        return false;
    }
    public override Inscription Find(int id)
    {
        return null;
    }
    public List<Inscription> FindAll(Member member)
    {
        List<Inscription> inscriptions = new List<Inscription>();
        try
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Inscription WHERE idMember = @id", connection);
                cmd.Parameters.AddWithValue("id", member.Id);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Inscription inscription = new Inscription
                        {
                            IdInscription = reader.GetInt32("idInscription"),
                            Passenger = reader.GetBoolean("passenger"),
                            Bike = reader.GetBoolean("bike")
                        };
                        inscriptions.Add(inscription);
                    }
                }
            }
        }
        catch (SqlException)
        {
            throw new Exception("Une erreur sql s'est produite!");
        }
        return inscriptions;
    }
}
