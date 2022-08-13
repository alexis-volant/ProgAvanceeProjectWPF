using System;

public class Message
{
    private Guid idMessage;
    private string obj;
    private string content;
    private Treasurer treasurer;
    private Member member;
    private bool isRead;

    AbstractDAOFactory adf = AbstractDAOFactory.GetFactory(DAOFactoryType.MS_SQL_FACTORY);

    public Message() { }

    public Message(Guid idMessage, string obj, string content, Treasurer treasurer, Member member, bool isRead)
    {
        this.idMessage = idMessage;
        this.obj = obj;
        this.content = content;
        this.treasurer = treasurer;
        this.member = member;
        this.isRead = isRead;
    }


    public Guid IdMessage
    {
        get { return idMessage; }
        set { idMessage = value; }
    }

    public string Obj
    {
        get { return obj; }
        set { obj = value; }
    }

    public string Content
    {
        get { return content; }
        set { content = value; }
    }

    public Treasurer Treasurer
    {
        get { return treasurer; }
        set { treasurer = value; }
    }

    public Member Member
    {
        get { return member; }
        set { member = value; }
    }

    public bool IsRead
    {
        get { return isRead; }
        set { isRead = value; }
    }

    public bool AddMessage(string obj, string content,Treasurer tres, Member member)
    {
        DAO<Message> messageDAO = adf.GetMessageDAO();
        Message message = new Message(Guid.NewGuid(),obj, content, tres, member, false);

        return messageDAO.Create(message);
    }
}

