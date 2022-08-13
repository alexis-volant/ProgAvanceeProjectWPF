using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

internal class MessageDAO : DAO<Message>
{
    public MessageDAO() { }

    public override bool Create(Message message)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("INSERT into dbo.Message (idMessage,object,contentText,idTreasurer,idMember,isRead) " +
                    "values(@idMessage, @object, @contentText, @idTreasurer, @idMember, @isRead)", connection);
                cmd.Parameters.AddWithValue("idMessage", message.IdMessage);
                cmd.Parameters.AddWithValue("object", message.Obj);
                cmd.Parameters.AddWithValue("contentText", message.Content);
                cmd.Parameters.AddWithValue("idTreasurer", message.Treasurer.Id);
                cmd.Parameters.AddWithValue("idMember", message.Member.Id);
                cmd.Parameters.AddWithValue("isRead", message.IsRead);
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
    public override bool Update(Message message)
    {
        return false;
    }
    public override bool Delete(Message message)
    {
        return false;
    }
    public override Message Find(int id)
    {
        return null;
    }
}
