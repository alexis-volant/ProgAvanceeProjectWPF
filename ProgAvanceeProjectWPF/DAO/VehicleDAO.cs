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
}
