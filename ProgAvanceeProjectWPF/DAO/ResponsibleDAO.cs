using System;
using System.Data;
using System.Data.SqlClient;

internal class ResponsibleDAO : DAO<Responsible>
{
    public ResponsibleDAO() { }
    public override bool Create(Responsible obj)
    {
        return false;
    }
    public override bool Update(Responsible obj)
    {
        return false;
    }
    public override bool Delete(Responsible obj)
    {
        return false;
    }
    public override Responsible Find(int id)
    {
        return null;
    }
}