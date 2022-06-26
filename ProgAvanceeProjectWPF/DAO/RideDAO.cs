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
}
