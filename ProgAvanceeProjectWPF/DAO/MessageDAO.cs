using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

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
                if (message.Member == null)
                {
                    SqlCommand cmd = new SqlCommand("INSERT into dbo.Message (idMessage,object,contentText,idTreasurer,isRead) " +
                    "values(@idMessage, @object, @contentText, @idTreasurer, @isRead)", connection);
                    cmd.Parameters.AddWithValue("idMessage", message.IdMessage);
                    cmd.Parameters.AddWithValue("object", message.Obj);
                    cmd.Parameters.AddWithValue("contentText", message.Content);
                    cmd.Parameters.AddWithValue("idTreasurer", message.Treasurer.Id);
                    cmd.Parameters.AddWithValue("isRead", message.IsRead);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("INSERT into dbo.Message (idMessage,object,contentText,idTreasurer,idMember,isRead) " +
                    "values(@idMessage, @object, @contentText, @idTreasurer, @idMember, @isRead)", connection);
                    cmd.Parameters.AddWithValue("idMessage", message.IdMessage);
                    cmd.Parameters.AddWithValue("object", message.Obj);
                    cmd.Parameters.AddWithValue("contentText", message.Content);
                    cmd.Parameters.AddWithValue("idTreasurer", message.Treasurer.Id);
                    cmd.Parameters.AddWithValue("idMember", message.Member);
                    cmd.Parameters.AddWithValue("isRead", message.IsRead);
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

    public List<Message> FindAllByMember(Member member)
    {
        List<Message> messages = new List<Message>();
        try
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Message Msg " +
                    "join dbo.Treasurer T on Msg.idTreasurer = T.idTreasurer WHERE Msg.idMember = @id", connection);
                cmd.Parameters.AddWithValue("id", member.Id);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Treasurer treasurer = new Treasurer(
                            reader.GetGuid("idTreasurer"),
                            reader.GetString("name"),
                            reader.GetString("firstName"),
                            reader.GetString("telephone"),
                            reader.GetString("login"),
                            reader.GetString("password")
                            );
                        Message message = new Message
                        (
                            reader.GetGuid("idMessage"),
                            reader.GetString("object"),
                            reader.GetString("contentText"),
                            treasurer,
                            member,
                            reader.GetBoolean("isRead")
                        );
                        messages.Add(message);
                    }
                }
            }
        }
        catch (SqlException e)
        {
            throw new Exception(e.Message);
        }
        return messages;

    }
}
