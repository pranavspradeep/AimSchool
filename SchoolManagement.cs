using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace SchoolManagement
{
    class SchoolManagement
    {
        public static string rno = "";
        public static string standard = "";
        public static string Newsyll = "";
        public static string empno = "";
        public static string empnoad = "";
        public static string ptnum = "";
        public static string feeid = "";
        public static string adno = "";
        public static string admno = "";
        public static string clasno = "";
        public static string exmno = "";
        public static string slno = "";
        public static string dtp1 = "";
        public static string dtp2 = "";
        public static string dtpb1 = "";
        public static string dtpb2 = "";
        public static string accno = "";
        public static string dtp3 = "";
        public static string dtp4 = "";
        public static string date = "";
        public static string str = "";
        public static string opngbalc = "";
        public static string clngbalc = "";
        public static string UserType = "";
        public static string SchoolName = "";
        public static int receiptno = 0;
        public static string salesbillno = "";
        public static string sladmno = "";
        public static string slname = "";
        public static double sldiscount = 0;
        public static double sltotal = 0;
        public static string rptstd = "";
        public static string rptdiv = "";
        public static string PurSvName = "";
        public static string LPurNo = "";
        public static double Feettl = 0;
        string r = "";
        DataLayer d = new DataLayer();
        /// <summary>
        /// Taking last receipt Number
        /// </summary>
        public int rtv_receiptno()
        {
            SqlDataAdapter ad = new SqlDataAdapter("select Max(TrNo) from tbl_Transaction", d.con);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            DataRow dr1;
            receiptno = 0;
            if (ds.Tables[0].Rows.Count > 0)
            {
                dr1 = ds.Tables[0].Rows[0];
                r = dr1[0].ToString();
                if (r == "" || r == null)
                {
                    r = "0";
                }
                receiptno = int.Parse(r.ToString()) + 1;
            }
            return receiptno;
        }        
       
            static bool HelperConvertNumberToText(int num, out string buf)
            {
                string[] strones = {
            "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight",
            "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen",
            "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen",
          };

                string[] strtens = {
              "Ten", "Twenty", "Thirty", "Fourty", "Fifty", "Sixty",
              "Seventy", "Eighty", "Ninety", "Hundred"
          };

                string result = "";
                buf = "";
                int single, tens, hundreds;

                if (num > 1000)
                    return false;

                hundreds = num / 100;
                num = num - hundreds * 100;
                if (num < 20)
                {
                    tens = 0; // special case
                    single = num;
                }
                else
                {
                    tens = num / 10;
                    num = num - tens * 10;
                    single = num;
                }

                result = "";

                if (hundreds > 0)
                {
                    result += strones[hundreds - 1];
                    result += " Hundred ";
                }
                if (tens > 0)
                {
                    result += strtens[tens - 1];
                    result += " ";
                }
                if (single > 0)
                {
                    result += strones[single - 1];
                    result += " ";
                }

                buf = result;
                return true;
            }

            static bool ConvertNumberToText(int num, out string result)
            {
                string tempString = "";
                int thousands;
                int temp;
                result = "";
                if (num < 0 || num > 100000)
                {
                    System.Console.WriteLine(num + " \tNot Supported");
                    return false;
                }

                if (num == 0)
                {
                    System.Console.WriteLine(num + " \tZero");
                    return false;
                }

                if (num < 1000)
                {
                    HelperConvertNumberToText(num, out tempString);
                    result += tempString;
                }
                else
                {
                    thousands = num / 1000;
                    temp = num - thousands * 1000;
                    HelperConvertNumberToText(thousands, out tempString);
                    result += tempString;
                    result += "Thousand ";
                    HelperConvertNumberToText(temp, out tempString);
                    result += tempString;
                }
                return true;
            }

            static void Main(string[] args)
            {
                string result;
                int i, num;
                int[] arrNum =
          {
            -1, 0, 5, 10, 15, 19, 20, 21, 25, 33, 49, 50, 72,
            99, 100, 101, 117, 199, 200, 214, 517, 589, 999,
            1000, 1010, 1018, 1200, 9890, 10119, 13535, 57019,
            99999, 100000, 100001
          };

                for (i = 0; i < arrNum.Count(); i++)
                {
                    num = arrNum[i];
                    if (ConvertNumberToText(num, out result) == true)
                        Console.WriteLine(num + "\t" + result);
                }
            }
        
    }
}