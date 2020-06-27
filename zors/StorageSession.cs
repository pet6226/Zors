using System;
using System.Web;


public class StorageSession
{
    // private constructor
    private StorageSession()
    {
        Username = string.Empty;
        UserRole = string.Empty;
        EmployeeId = string.Empty;
        Name = string.Empty;
        JobID = string.Empty;
   
    }

    // Gets the current session.
    public static StorageSession Current
    {
        get
        {
            StorageSession session =
              (StorageSession)HttpContext.Current.Session["__StorageSession__"];
            if (session == null)
            {
                session = new StorageSession();
                HttpContext.Current.Session["__StorageSession__"] = session;
            }
            return session;
        }
    }

    // **** add your session properties here, e.g like this:
    public string Username { get; set; }
    public string UserRole { get; set; }
    public string EmployeeId { get; set; }
    public string Name { get; set; }
    public string JobID { get; set; }
    
   
}