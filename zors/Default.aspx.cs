using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ActiveDirectoryProviders;
using System.Web.Security;
using System.Data;
using System.Data.OracleClient;
using System.Configuration;


namespace zors
{
    public partial class _Default : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["ConnectionStringUSSKAD"].ConnectionString;
        Control ControlLoader; //Nova kontrola
        LdapAccess ldap = new LdapAccess(); // Nova instanca ldapa ldap. poziva LdapAccess.cs
        //ActiveDirectoryRoleProvider adRoleProvider = new ActiveDirectoryRoleProvider(); // Nova instanca za ActiveDirectoryRoleProvider.cs (get users in roles ...)
        
        //string[] allRoles = new string[] //-- Definisanje rola koje se koriste u projektu(grupe)
        //    {
        //        "SMIT_SPG",
        //        "SMIT_HD",
        //        "SMIT_ADM",
        //        "SMIT_HEAD"
        //    };

        protected void Page_Load(object sender, EventArgs e)
        {
            StorageSession.Current.Username = User.Identity.Name; // ovo upisuje ad nalog u storragesession
            if (StorageSession.Current.Username != string.Empty)
            {
                StorageSession.Current.EmployeeId = ldap.GetOfficeByUsername(StorageSession.Current.Username); // Ovo vraca maticni broj (EmployeeId) na osnovu ad naloga(User.Identity.Name)
                //= User.Identity.Name; ako terba logovanje sa samo maticnim brojem
                // StorageSession.Current.UserRole = GetUsersGroup(StorageSession.Current.Username, allRoles); // Ispituje da li je user u definisanim rolama (allRoles). ako jeste vraca rolu ako ne vraca string unknown
                StorageSession.Current.Name = ldap.GetUserByUsername(StorageSession.Current.Username);

                //Proveriti da li je iznad nivoa sefa/rukovodioca
                //435 rukovodilac
                //434 direktor
                //50  izvršni dir i gm
                //433 kineski menadzment
                //439 dvojna uloga i dir i gm

                if ((VratiDaLiJeShef() == "435") || (VratiDaLiJeShef() == "434") || (VratiDaLiJeShef() == "50") || (VratiDaLiJeShef() == "433") || (VratiDaLiJeShef() == "439"))
                {
                    StorageSession.Current.JobID = VratiDaLiJeShef();
                    Response.Redirect("~/Forma.aspx");
                }
                else
                {
                    Logout();
                }
            }
        }

        protected string VratiDaLiJeShef()
        {
            using (OracleConnection con = new OracleConnection(cs))
            {
                OracleCommand cmd = new OracleCommand("select JOBID from prekovremeni_sasa@prhrbqat.zelsd.rs where MATICNI_BROJ = " + StorageSession.Current.EmployeeId, con);

                con.Open();
                using (OracleDataReader reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    string vracen_job_id = Convert.ToString(reader[0]);
                    con.Close();
                    return vracen_job_id;
                }
                
            }

        }

        private void Logout()
        {
            StorageSession.Current.EmployeeId = string.Empty;
            StorageSession.Current.Username = string.Empty;
            StorageSession.Current.UserRole = string.Empty;
            Session.Clear();
            Session.Abandon();
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();


        }

        //public string GetUsersGroup(string username, string[] allRoles) // Cita grupu na osnovu username-a
        //{
        //    string userRole = String.Empty;
        //    string[] allUsers;
        //    int i = 0;
        //    int j = 0;
        //    bool flag = false;

        //    while (i < allRoles.Length)
        //    {
        //        allUsers = adRoleProvider.GetUsersInRole(allRoles[i]);
        //        j = 0;
        //        while (j < allUsers.Length)
        //        {
        //            if (username == allUsers[j])
        //            {
        //                flag = true;
        //                userRole = allRoles[i];
        //            }
        //            j++;
        //        }
        //        i++;
        //    }

        //    if (flag)
        //    {
        //        return userRole;
        //    }
        //    else
        //    {
        //        return "Unknown";
        //    }
        //}

    }
}
