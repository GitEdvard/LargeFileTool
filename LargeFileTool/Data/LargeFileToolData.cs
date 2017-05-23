using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;
using LargeFileTool.Database;

namespace LargeFileTool.Data
{
    public enum TopBotKeyWords
    {
        TOP,
        BOT
    }

    public enum PlusMinusKeyWords
    {
        PLUS,
        MINUS
    }

    public enum TopBotReference
    {
        T,
        B
    }

    public enum PlusMinusReference
    {
        P,
        M
    }

    public enum ForwardReverseReference
    {
        F,
        R
    }

    public enum AlleleVariantTable
    {
        AlleleVariantId = 0,
        Variant = 1,
        Complement = 2
    }

    public class LargeFileToolData
    {
        public const int NO_ID_TINY = 0;
        public const int NO_INDEX = -1;

        private static Database.Dataserver MyDatabase = null;

        public static Database.Dataserver Database
        {
            get { return MyDatabase; }
            set
            {
                if (IsNotNull(MyDatabase))
                {
                    //MyDatabase.TransactionCommited -= MyTransactionCommitedEventHandler;
                    //MyDatabase.TransactionRollbacked -= MyTransactionRollbackedEventHandler;
                }
                MyDatabase = value;
                if (IsNotNull(MyDatabase))
                {
                    //MyTransactionCommitedEventHandler = new TransactionCommitedEventHandler(TransactionCommited);
                    //MyDatabase.TransactionCommited += MyTransactionCommitedEventHandler;
                    //MyTransactionRollbackedEventHandler = new TransactionRollbackedEventHandler(TransactionRollbacked);
                    //MyDatabase.TransactionRollbacked += MyTransactionRollbackedEventHandler;
                    //MyEventHandlerTable = new Hashtable();
                }
            }
        }

        public LargeFileToolData()
        { 
        
        }

        public static Int32 CompareStringWithNumbers(String string1, String string2)
        {
            // Handles a string with numbers in it, and handles string and number separately
            // e.g. string10 comes after string9, and string10string20 comes after string10string3
            int output;
            if (string1.Length > 0 && char.IsNumber(string1[0]) &&
                string2.Length > 0 && char.IsNumber(string2[0]))
            {
                output = LoopWithNumberFirst(string1, string2);
                if (output != 0)
                {
                    return output;
                }
            }
            else if (string1.Length > 0 && !char.IsNumber(string1[0]) &&
                string2.Length > 0 && !char.IsNumber(string2[0]))
            {
                output = LoopWithCharFirst(string1, string2);
                if (output != 0)
                {
                    return output;
                }
            }
            return string1.CompareTo(string2);
        }
        
        private static Int32 LoopWithCharFirst(String string1, String string2)
        {
            // Belongs to CompareStringWithNumbers
            int i = 0, j = 0, startInd1, startInd2;
            String subString1, subString2, numberStr;
            int output;
            Int64 number1, number2;
            while (i < string1.Length && j < string2.Length)
            {
                startInd1 = i;
                startInd2 = j;
                //separate the string part
                while (++i < string1.Length && !char.IsNumber(string1[i]))
                { }
                while (++j < string2.Length && !char.IsNumber(string2[j]))
                { }
                subString1 = string1.Substring(startInd1, i - startInd1);
                subString2 = string2.Substring(startInd2, j - startInd2);
                output = subString1.CompareTo(subString2);
                if (output != 0)
                {
                    return output;
                }
                if (i == string1.Length || j == string2.Length)
                {
                    break;
                }
                startInd1 = i;
                startInd2 = j;
                //handle the number part
                while (++i < string1.Length && char.IsNumber(string1[i]))
                { }
                while (++j < string2.Length && char.IsNumber(string2[j]))
                { }
                numberStr = string1.Substring(startInd1, i - startInd1);
                number1 = Convert.ToInt64(numberStr);
                numberStr = string2.Substring(startInd2, j - startInd2);
                number2 = Convert.ToInt64(numberStr);
                if (number1 > number2)
                {
                    return 1;
                }
                else if (number1 < number2)
                {
                    return -1;
                }
            }
            return 0;
        }

        private static Int32 LoopWithNumberFirst(String string1, String string2)
        {
            // Belongs to CompareStringWithNumbers
            int i = 0, j = 0, startInd1, startInd2;
            String subString1, subString2, numberStr;
            int output;
            Int64 number1, number2;
            while (i < string1.Length && j < string2.Length)
            {
                startInd1 = i;
                startInd2 = j;
                //handle the number part
                while (++i < string1.Length && char.IsNumber(string1[i]))
                { }
                while (++j < string2.Length && char.IsNumber(string2[j]))
                { }
                numberStr = string1.Substring(startInd1, i - startInd1);
                number1 = Convert.ToInt64(numberStr);
                numberStr = string2.Substring(startInd2, j - startInd2);
                number2 = Convert.ToInt64(numberStr);
                if (number1 > number2)
                {
                    return 1;
                }
                else if (number1 < number2)
                {
                    return -1;
                }
                if (i == string1.Length || j == string2.Length)
                {
                    break;
                }
                startInd1 = i;
                startInd2 = j;
                //separate the string part
                while (++i < string1.Length && !char.IsNumber(string1[i]))
                { }
                while (++j < string2.Length && !char.IsNumber(string2[j]))
                { }
                subString1 = string1.Substring(startInd1, i - startInd1);
                subString2 = string2.Substring(startInd2, j - startInd2);
                output = subString1.CompareTo(subString2);
                if (output != 0)
                {
                    return output;
                }
            }
            return 0;
        }

        public static bool OpenReadFile(ref StreamReader sr, string filePath, out string message)
        {
            message = "";
            try
            {
                if (sr != null)
                {
                    sr.Close();
                }
                sr = new StreamReader(filePath);
                return true;
            }
            catch (Exception)
            {
                message = "Could not open file: " + filePath;
                return false;
            }
        }

        protected void RemoveDirectory(string path)
        {
            string[] files;
            try
            {
                files = Directory.GetFiles(path);
                foreach (string file in files)
                {
                    File.Delete(file);
                }
                Directory.Delete(path);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected static Boolean IsNotNull(Object testObject)
        {
            return (testObject != null);
        }

        protected static Boolean IsNotEmpty(ICollection collection)
        {
            return ((collection != null) && (collection.Count > 0));
        }

        protected static bool IsNotEmpty(string str)
        {
            return IsNotNull(str) && str.Trim().Length != 0;
        }

        protected static Boolean IsNull(Object testObject)
        {
            return (testObject == null);
        }

        public bool IsEmpty(string str)
        {
            return str == null || str.Trim() == "";
        }

        protected static void CloseDataReader(DataReader dataReader)
        {
            if (dataReader != null)
            {
                dataReader.Close();
            }
        }

        protected Boolean LoginDataBase(String userName, String password)
        {
            // Set newLoginInfo to "null" for integrated security, or to a user name and password for manual login.

            try
            {
                // Try to connect to the database.
                Database = new Database.Dataserver(userName, password);
                if (!Database.Connect())
                {
                    throw new Exception("Could not connect user " + userName + " to database");
                }

            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Get integers grouped in subsections of three numbers: x xxx xxx
        /// </summary>
        /// <param name="integer"></param>
        /// <returns></returns>
        protected string ParseInt(int integer)
        {
            string intStr, parsedInt = "";
            int subStrLen, subtractIndex = 0;
            intStr = integer.ToString();
            for (int i = 0; i <= (intStr.Length - 1) / 3; i++)
            {
                subStrLen = Math.Min((i + 1) * 3, intStr.Length) % 3;
                if (subStrLen == 0)
                {
                    subStrLen = 3;
                }
                subtractIndex += subStrLen;
                if (i > 0)
                {
                    parsedInt = " " + parsedInt;
                }
                parsedInt = intStr.Substring(intStr.Length - subtractIndex, subStrLen) + parsedInt;
                if (i > 0)
                {
                    parsedInt += " ";
                }
            }
            return parsedInt;
        }


    }
}
