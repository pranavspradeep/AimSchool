using System;
using System.Data;
using System.Configuration;
using System.Web;

using System.Data.SqlClient;
/// <summary>
/// Summary description for DataLayer
/// </summary>
public class DataLayer_Old
{
    //public  SqlConnection con = new SqlConnection("Data Source=DMTPGM\\SQLEXPRESS;Initial Catalog=DMT;Integrated Security=SSPI;");
    //public SqlConnection con = new SqlConnection("Data Source=virtualteacher.db.4826737.hostedresource.com; Initial Catalog=virtualteacher; User ID=virtualteacher; Password=me@Digital123;");
    //public SqlConnection con = new SqlConnection("Data Source=TLT-LAP4\\SQLEXPRESS;Initial Catalog=Thalasthanam;Trusted_Connection=yes;User ID=sa;Password=;");
    //Data Source=.\SQLEXPRESS;AttachDbFilename=D:\hari\Hi-TechSchool\DataBase\itecschool.mdf;Integrated Security=True;Connect Timeout=30;User Instance=False
    public SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=E:\\Bckup_My_Pc\\Hi-TechSchool\\DataBase\\itecschool.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
	
    public DataLayer_Old()
	{
		//
		// TODO: Add constructor logic here
		//
        

	}
    
    public void con_open()
    {
        
        con.Open();
    }
    public void con_close()
    {
        con.Close();
    }
}
