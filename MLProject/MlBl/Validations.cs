using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlBl
{
    public static class Validations
    {

        public static bool CheckIfNameIsTooShort(string Name)
        {
            return Name.Length == 0;
        }
        public static bool CheckIfNumDoNotExceedX(double Num, double X)
        {
            return Num < X;
        }
        public static bool CheckIfNumExceedX(double Num, double X)
        {
            return Num > X;
        }
        public static bool CheckIfDateDayIsInFuture(DateTime Date)
        {
            return Date.Day > DateTime.Now.Day;
        }
        public static bool CheckIfDateHourIsInFuture(DateTime Date)
        {
            return Date.Hour > DateTime.Now.Hour;
        }
        public static bool CheckIfNameContainAnyWhiteSpaces(string Name)
        {
            for (int c = 0; c < Name.Length; c++)
            {
                if (Name[c] == ' ')
                {
                    return true;
                }
            }
            return false;
        }
        public static bool CheckIfStringContainAnyNums(string Name)
        {
            for (int c = 0; c < Name.Length; c++)
            {
                if (!CheckIfStringHoldAnyChar(Name[c].ToString()))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool CheckIfNameContainsOnlySpaces(string Name)
        {
            var WhiteSpaces = Name.Where(n => n == ' ');
            return WhiteSpaces.Count() == Name.Count();
        }
        public static bool CheckIfNumIsNull(decimal? Num)
        {

            return Num == null;



        }
        public static bool CheckIfNumIsNegative(decimal Num)
        {

            return Num < 0;



        }
        public static bool CheckIfstringIsNum(string Num)
        {
            if (double.TryParse(Convert.ToString(Num), out double num))
            {

                return true;

            }
            return false;

        }


        public static bool CheckIfStringLengthIsNotLessThanNum(string String, int Num)
        {
            return String.Length >= Num;

        }
        public static bool CheckIfStringLengthIsNotMoreThanNum(string String, int Num)
        {
            return String.Length <= Num;

        }
        public static bool CheckIfStringHoldAnyChar(string String)
        {
            return !int.TryParse(String, out int Pass);
        }

    }
}
