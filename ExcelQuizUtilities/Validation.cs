using System;
using System.Text.RegularExpressions;
using System.Globalization;

namespace ExcelQuiz.Utilities
{
    /// <summary>
    /// This is utility class for defining common method that will use in many projects.
    /// </summary>
    public class Validation
    {
        /// <summary>
        /// Function to test for input value based on regular expression
        /// </summary>
        /// <param name="input"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static bool IsValidateInput(string input, string expression)
        {
            return Regex.IsMatch(input, expression);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static bool IsValidateInput(string input, int condition)
        {

            bool returnValue = false;

            switch (condition)
            {

                case 1:
                    //For Numeric
                    returnValue = Regex.IsMatch(input, @"^[0-9]+$");
                    break;

                case 2:
                    //For Numeric with space
                    returnValue = Regex.IsMatch(input, @"^[0-9 ]+$");
                    break;

                case 3:
                    //For Numeric with single decimal (For rupees and paise format)
                    returnValue = Regex.IsMatch(input, @"^[0-9]+[.][0-9]+$");
                    break;

                case 4:
                    //For Numeric with comma seperator (For money)
                    returnValue = Regex.IsMatch(input, @"^[0-9,]+$");
                    break;

                case 5:
                    //For Numeric with comma and dot seperator (For money)
                    returnValue = Regex.IsMatch(input, @"^[0-9,.]+$");
                    break;

                case 6:
                    //For Numeric with comma and single decimal (For rupees and paise format)
                    returnValue = Regex.IsMatch(input, @"^[0-9,]+[.][0-9]+$");
                    break;

                case 7:
                    //For Integer (With Negative and Positive)
                    returnValue = Regex.IsMatch(input, @"^-[0-9]+$|^[0-9]+$");
                    break;

                case 8:
                    //For Alpha
                    returnValue = Regex.IsMatch(input, @"^[A-Za-z]+$");
                    break;

                case 9:
                    //For Alpha with space
                    returnValue = Regex.IsMatch(input, @"^[A-Za-z ]+$");
                    break;

                case 10:
                    //For Alpha with space and comma
                    returnValue = Regex.IsMatch(input, @"^[A-Za-z ,]+$");
                    break;


                case 11:
                    //For Alpha with space and comma
                    returnValue = Regex.IsMatch(input, @"^[A-Za-z ,]+$");
                    break;
                
                case 12:
                    //For Alpha with comma and dot seperator (For money)
                    returnValue = Regex.IsMatch(input, @"^[A-Za-z,.]+$");
                    break;

                case 13:
                    //For Alphanumeric
                    returnValue = Regex.IsMatch(input, @"^[A-Za-z0-9]+$");
                    break;

                case 14:
                    //For Alphanumeric with comma and space
                    returnValue = Regex.IsMatch(input, @"^[A-Za-z0-9, ]+$");
                    break;

                case 15:
                    //For Alphanumeric with space
                    returnValue = Regex.IsMatch(input, @"^[A-Za-z0-9 ]+$");
                    break;

                case 16:
                    //For Email
                    returnValue = Regex.IsMatch(input, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
                    break;

                case 17:
                    //For Website
                    returnValue = Regex.IsMatch(input, @"^[\w-\.]+([\w-]+\.)+[\w-]{2,4}$");
                    break;

            }

            return returnValue;
        }

        /// <summary>
        /// Function to test for Positive Integers.  
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsNaturalNumber(String input)
        {
            Regex notNaturalPattern = new Regex("[^0-9]");
            Regex naturalPattern = new Regex("0*[1-9][0-9]*");
            return !notNaturalPattern.IsMatch(input) &&
            naturalPattern.IsMatch(input);
        }

        /// <summary>
        /// Function to test for Positive Integers with zero inclusive 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsWholeNumber(String input)
        {
            Regex notWholePattern = new Regex("[^0-9]");
            return !notWholePattern.IsMatch(input);
        }
        
        /// <summary>
        /// Function to Test for Integers both Positive & Negative  
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsInteger(String input)
        {
            Regex intPattern = new Regex("^-[0-9]+$|^[0-9]+$");
            return intPattern.IsMatch(input);
        }
        
        /// <summary>
        /// Function to Test for Positive Number both Integer & Real  
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsPositiveNumber(String input)
        {
            Regex notPositivePattern = new Regex("[^0-9.]");
            Regex positivePattern = new Regex("^[.][0-9]+$|[0-9]*[.]*[0-9]+$");
            Regex twoDotPattern = new Regex("[0-9]*[.][0-9]*[.][0-9]*");
            return !notPositivePattern.IsMatch(input) &&
            positivePattern.IsMatch(input) &&
            !twoDotPattern.IsMatch(input);
        }
        
        /// <summary>
        /// Function to test whether the string is valid number or not
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsNumber(String input)
        {
            Regex notNumberPattern = new Regex("[^0-9.-]");
            Regex twoDotPattern = new Regex("[0-9]*[.][0-9]*[.][0-9]*");
            Regex twoMinusPattern = new Regex("[0-9]*[-][0-9]*[-][0-9]*");
            String validRealPattern = "^([-]|[.]|[-.]|[0-9])[0-9]*[.]*[0-9]+$";
            String validIntegerPattern = "^([-]|[0-9])[0-9]*$";
            Regex numberPattern = new Regex("(" + validRealPattern + ")|(" + validIntegerPattern + ")");
            return !notNumberPattern.IsMatch(input) &&
            !twoDotPattern.IsMatch(input) &&
            !twoMinusPattern.IsMatch(input) &&
            numberPattern.IsMatch(input);
        }
        
        /// <summary>
        /// Function To test for Alphabets. 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsAlpha(String input)
        {
            Regex alphaPattern = new Regex("[^a-zA-Z]");
            return !alphaPattern.IsMatch(input);
        }
        
        /// <summary>
        /// Function to Check for AlphaNumeric.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsAlphaNumeric(String input)
        {
            Regex alphaNumericPattern = new Regex("[^a-zA-Z0-9]");
            return !alphaNumericPattern.IsMatch(input);
        }
    }
}
