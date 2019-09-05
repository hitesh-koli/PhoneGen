using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace PhoneGen.AppLogic
{
    /// <summary>
    /// Acts as the business logic module for seperation of concerns. Can be independently changed from the View or page that displays values.
    /// Essentially can be a seperate entity or dll project to test indepenently
    /// </summary>
    public static class PhoneNumberGenerator
    {


        // static list of keypad parts
        private static readonly string[] phoneKeyParts = { "0", "1", "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };

        /// <summary>
        /// Generates the substrings of the phone and adds it to the return list. we use monetization to store values previously computed and add it to the final string.
        /// </summary>
        /// <param name="phNum"></param>
        /// <param name="singleDigit">used to be the digit that was being passed, but now just index is fine with this implementation</param>
        /// <param name="phoneSubString"> partial substring of the phnNum that is being built recursively</param>
        /// <param name="retListPhones">the actual list that needs to be sent out</param>
        public static void numGenerator(String phNum, int singleDigit, char[] phoneSubString, List<string> retListPhones)
        {
            if(singleDigit == phNum.Length)
            {
                retListPhones.Add(new string(phoneSubString));
            }
            else
            {
                int keyIndex = (int)Char.GetNumericValue(phNum.ToCharArray()[singleDigit]);
                for (int i=0;i< phoneKeyParts[keyIndex].Length;i++)
                {
                    char c = phoneKeyParts[keyIndex].ToCharArray()[i];
                    phoneSubString[singleDigit] = c;
                    numGenerator(phNum, singleDigit + 1, phoneSubString, retListPhones);
                }
            }
        }

        /*
         * this solution does not help in recursion level problem, it works for iterative approach
         * had to keep an arraylist of the used element and push and pop multiple times for previous elemntst to get all possible partial elements
        private static Dictionary<int, List<char>> dtPhoneConstants = new Dictionary<int, List<char>>()
        {
            { 2,new List<char>{'a','b', 'c'} },
            { 3,new List<char>{'d', 'e', 'f' } },
            { 4,new List<char>{'g', 'h', 'i' } },
            { 5,new List<char>{'j', 'k', 'l' } },
            { 6,new List<char>{'m', 'n', 'o' } },
            { 7,new List<char>{'p', 'q', 'r','s'} },
            { 8,new List<char>{'t', 'u', 'v' } },
            { 9,new List<char>{'w', 'x', 'y','z' } }
            };

        */


            /// <summary>
            /// helper function to call for recursion 
            /// </summary>
            /// <param name="inpPhoneNum"></param>
            /// <returns></returns>
        public static List<String> GeneratePhoneNumber(String inpPhoneNum)
        {
            if (String.IsNullOrEmpty(inpPhoneNum))
                return null;

            //input validation during business logic call to check if string is 7 digit or 10 digit only.
            if (!Regex.IsMatch(inpPhoneNum, "^([0-9]{7})$|^([0-9]{10})$"))
                return null;

            char[] subStringPh = new char[inpPhoneNum.Length];
            List<string> PhoneNums = new List<string>();
            numGenerator(inpPhoneNum, 0, subStringPh, PhoneNums);
            return PhoneNums;

            /*
            if (String.IsNullOrEmpty(inpPhoneNum))
                return null;
            else
            {
                StringBuilder replacePhoneNum = new StringBuilder( inpPhoneNum);
                int strLen = replacePhoneNum.Length;
                List<String> retString = new List<string>();
                int index = 0;
                foreach(char s in inpPhoneNum.ToCharArray())
                {
                    int keyIndex = (int)Char.GetNumericValue(s);
                    if(dtPhoneConstants.ContainsKey(keyIndex))
                    {
                        foreach(char l in dtPhoneConstants[keyIndex])
                        {
                            replacePhoneNum[index] = l;
                            retString.Add(replacePhoneNum.ToString());
                        }
                    }
                    index++;
                }
                return retString;
            }
            */

        }
    }
}
