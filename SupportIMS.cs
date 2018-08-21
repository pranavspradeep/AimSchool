using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;
using System.IO;
using System.Xml;
using System.Reflection;
using Microsoft.VisualBasic;

namespace SchoolManagement
{
    class SupportIMS
    {
        public String changeCurrencyToWords(String numb, String curmain, String cursub)
        {
            numb = numb.TrimStart('0');
            numb = numb.TrimStart(' ');

            if (numb.Length != 0)
            {
                return changeToWords(numb, curmain, cursub, true);
            }
            else
                return "";
        }


        private String changeToWords(String numb, String curmain, String cursub, bool isCurrency)
        {

            String val = "", wholeNo = numb, points = "", andStr = "", pointStr = "";

            String endStr = " Only";
            //String endStr = (isCurrency) ? (curmain + " Only") : (" Only");

            try
            {

                int decimalPlace = numb.IndexOf(".");

                if (decimalPlace >= 0)
                {

                    wholeNo = numb.Substring(0, decimalPlace);

                    points = numb.Substring(decimalPlace + 1);

                    while (points.EndsWith("00"))
                    {
                        points = points.Remove(points.Length - 1, 1);
                    }
                    if (points != "0")
                    {
                        while (points.StartsWith("0"))
                        {
                            points = points.Remove(0, 1);

                        }
                    }

                    if ((points == "" ? 0 : Convert.ToInt32(points)) > 0)
                    {

                        andStr = (isCurrency) ? (" And" + " ") : ("point");// just to separate whole numbers from points/cents

                        endStr = (isCurrency) ? (" " + cursub + " Only") : (" Only");

                        //pointStr = translateCents(points);
                        pointStr = translateWholeNumber(points).Trim();                        
                    }
                    else if (Convert.ToInt32(points) == 0)
                    {
                        //Error in .000 type
                        pointStr = " ";
                    }

                }
                if (wholeNo.Trim() != "")
                {
                    val = String.Format("{1} {0}{2}{3}{4}", curmain, translateWholeNumber(wholeNo).Trim(), andStr, pointStr, endStr);
                }
                else
                {
                    //val = "";


                    //val = String.Format("{0} {1}{2}",cursub, pointStr, endStr);  
                    val = String.Format("{0}{1}{2}", "", pointStr, endStr);

                }
            }

            catch { ;}

            return val;

        }

        private String translateWholeNumber(String number)
        {

            string word = "";

            try
            {

                bool beginsZero = false;//tests for 0XX

                bool isDone = false;//test if already translated

                double dblAmt = (Convert.ToDouble(number));

                //if ((dblAmt > 0) && number.StartsWith("0"))

                if (dblAmt > 0)
                {//test for zero or digit zero in a nuemric

                    beginsZero = number.StartsWith("0");

                    int numDigits = number.Length;

                    int pos = 0;//store digit grouping

                    String place = "";//digit grouping name:hundres,thousand,etc...

                    switch (numDigits)
                    {

                        case 1://ones' range

                            word = ones(number);

                            isDone = true;

                            break;

                        case 2://tens' range

                            word = tens(number);

                            isDone = true;

                            break;

                        case 3://hundreds' range

                            pos = (numDigits % 3) + 1;

                            place = " Hundred ";

                            break;

                        case 4://thousands' range

                        case 5:

                            pos = (numDigits % 4) + 1;

                            place = " Thousand ";

                            break;

                        case 6://Lakh' range


                        case 7:

                            pos = (numDigits % 6) + 1;

                            place = " Lakh ";

                            break;
                        case 8://Crore' Range

                        case 9:

                        case 10:

                        case 11:

                        case 12:

                        case 13:
                            pos = (numDigits % 8) + 1;

                            place = " Crore ";

                            break;

                        //add extra case options for anything above Billion...

                        default:

                            isDone = true;

                            break;

                    }

                    if (!isDone)
                    {//if transalation is not done, continue...(Recursion comes in now!!)

                        word = translateWholeNumber(number.Substring(0, pos)) + place + translateWholeNumber(number.Substring(pos));

                        //check for trailing zeros

                        if (beginsZero) word = " and " + word.Trim();

                    }

                    //ignore digit grouping names

                    if (word.Trim().Equals(place.Trim())) word = "";

                }

            }

            catch { ;}

            return word.Trim();

        }

        private String tens(String digit)
        {

            int digt = Convert.ToInt32(digit);

            String name = null;

            switch (digt)
            {

                case 10:

                    name = "Ten";

                    break;

                case 11:

                    name = "Eleven";

                    break;

                case 12:

                    name = "Twelve";

                    break;

                case 13:

                    name = "Thirteen";

                    break;

                case 14:

                    name = "Fourteen";

                    break;

                case 15:

                    name = "Fifteen";

                    break;

                case 16:

                    name = "Sixteen";

                    break;

                case 17:

                    name = "Seventeen";

                    break;

                case 18:

                    name = "Eighteen";

                    break;

                case 19:

                    name = "Nineteen";

                    break;

                case 20:

                    name = "Twenty";

                    break;

                case 30:

                    name = "Thirty";

                    break;

                case 40:

                    name = "Fourty";

                    break;

                case 50:

                    name = "Fifty";

                    break;

                case 60:

                    name = "Sixty";

                    break;

                case 70:

                    name = "Seventy";

                    break;

                case 80:

                    name = "Eighty";

                    break;

                case 90:

                    name = "Ninety";

                    break;

                default:

                    if (digt > 0)
                    {

                        name = tens(digit.Substring(0, 1) + "0") + " " + ones(digit.Substring(1));

                    }

                    break;

            }

            return name;

        }

        private String ones(String digit)
        {

            int digt = Convert.ToInt32(digit);

            String name = "";

            switch (digt)
            {

                case 1:

                    name = "One";

                    break;

                case 2:

                    name = "Two";

                    break;

                case 3:

                    name = "Three";

                    break;

                case 4:

                    name = "Four";

                    break;

                case 5:

                    name = "Five";

                    break;

                case 6:

                    name = "Six";

                    break;

                case 7:

                    name = "Seven";

                    break;

                case 8:

                    name = "Eight";

                    break;

                case 9:

                    name = "Nine";

                    break;

            }

            return name;

        }

        private String translateCents(String cents)
        {

            String cts = "", digit = "", engOne = "";

            for (int i = 0; i < cents.Length; i++)
            {

                digit = cents[i].ToString();

                if (digit.Equals("0"))
                {

                    engOne = "Zero";

                }

                else
                {

                    engOne = ones(digit);

                }

                cts += " " + engOne;

            }

            return cts;

        }
    }
    class AimSValidator
    {
        public static void NumberChecker(KeyPressEventArgs e)
        {
            if (((Convert.ToInt32(e.KeyChar) <= 0x2f) || (Convert.ToInt32(e.KeyChar) >= 0x3a)) && (Convert.ToInt32(e.KeyChar) != 8))
            {
                e.Handled = true;
            }
        }

        public static void AmountChecker(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')
            {
                string text = ((TextBox)sender).Text;
                if (e.KeyChar.ToString() == ".")
                {
                    if (text.LastIndexOf(".") > -1)
                    {
                        e.Handled = true;
                    }
                }
                else
                {
                    NumberChecker(e);
                }
            }
        }

        public static void NameChecker(KeyPressEventArgs e)
        {
            if (((((Convert.ToInt32(e.KeyChar) <= 0x40) || (Convert.ToInt32(e.KeyChar) >= 0x5b)) && ((Convert.ToInt32(e.KeyChar) <= 0x60) || (Convert.ToInt32(e.KeyChar) >= 0x7b))) && ((Convert.ToInt32(e.KeyChar) != 8) && (Convert.ToInt32(e.KeyChar) != 0x20))) && (Convert.ToInt32(e.KeyChar) != 13))
            {
                e.Handled = true;
            }
        }

        public static void TitleCaseNameChecker(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != '\b') && (e.KeyChar.ToString() != "."))
            {
                //InvalidCastException exception;
                string text = "";
                try
                {
                    text = ((TextBox)sender).Text;
                }
                catch (InvalidCastException)
                {
                }
                if ((((text.Length == 0) || (text.Substring(text.Length - 1, 1) == " ")) || (text.Substring(text.Length - 1, 1) == ".")) || (text.Substring(text.Length - 1, 1) == "\n"))
                {
                    if (((((Convert.ToInt32(e.KeyChar) > 0x40) && (Convert.ToInt32(e.KeyChar) < 0x5b)) || ((Convert.ToInt32(e.KeyChar) > 0x60) && (Convert.ToInt32(e.KeyChar) < 0x7b))) || (((Convert.ToInt32(e.KeyChar) == 8) || (Convert.ToInt32(e.KeyChar) == 0x20)) || (Convert.ToInt32(e.KeyChar) == 13))) || (Convert.ToInt32(e.KeyChar) == 0x26))
                    {
                        try
                        {
                            ((TextBox)sender).Text = ((TextBox)sender).Text + e.KeyChar.ToString().ToUpper();
                            ((TextBox)sender).SelectionStart = text.Length + 1;
                        }
                        catch (InvalidCastException)
                        {
                        }
                        e.Handled = true;
                        return;
                    }
                    e.Handled = true;
                }
                NameChecker(e);
            }
        }

        public static bool IsValidEmail(string strEmail)
        {
            Regex regex = new Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            return regex.Match(strEmail).Success;
        }

        public static void PhoneChecker(KeyPressEventArgs e)
        {
            if ((((Convert.ToInt32(e.KeyChar) <= 0x2f) || (Convert.ToInt32(e.KeyChar) >= 0x3a)) && ((Convert.ToInt32(e.KeyChar) != 8) && (Convert.ToInt32(e.KeyChar) != 0x20))) && (Convert.ToInt32(e.KeyChar) != 0x2d))
            {
                e.Handled = true;
            }
        }

        public static void TitlecaseChecker(Object sender, KeyPressEventArgs e)
        {
            if (IsSpaceOrBegin(sender))
                e.KeyChar = Convert.ToChar(e.KeyChar.ToString().ToUpper());
            NameChecker(e);

        }

        private static int SelectionLength(object obj)
        {
            int Rvalue = 0;
            Type type = obj.GetType();
            PropertyInfo pr = type.GetProperty("SelectionLength");
            if (pr != null)
            {
                Rvalue = Convert.ToInt32(pr.GetGetMethod().Invoke(obj, null));
            }
            return (Rvalue);
        }

        private static bool AfterSelectionStart(object obj, char chrMatch)
        {
            bool Rvalue = false;
            Type type = obj.GetType();
            PropertyInfo pr = type.GetProperty("SelectionStart");
            if (pr != null)
            {
                string str = ((Control)obj).Text.Trim();
                if (Convert.ToInt32(pr.GetGetMethod().Invoke(obj, null)) > str.IndexOf(chrMatch))
                    Rvalue = true;
            }
            return (Rvalue);
        }

        private static bool IsSpaceOrBegin(object obj)
        {
            bool Rvalue = false;
            Type type = obj.GetType();
            PropertyInfo pr = type.GetProperty("SelectionStart");
            if (pr != null)
            {
                string str = ((Control)obj).Text;
                int SelStart = Convert.ToInt32(pr.GetGetMethod().Invoke(obj, null));
                if (SelStart == 0)
                    Rvalue = true;
                else
                    if (str.Substring((SelStart - 1), 1) == " ")
                        Rvalue = true;
            }
            return (Rvalue);
        }
    }

}
