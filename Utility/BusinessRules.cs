﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    /// <summary>
    /// Business Rules:  This class contains functionality that is specific to the
    /// business rules supporting the BANK OF BIT application.  As the course progresses,
    /// students are encouraged to add methods containing functionality common to various
    /// aspects of the BANK OF BIT application.
    /// </summary>
    public static class BusinessRules
    {
        public const int BANK_OF_BIT_NUMBER = 45910;

        /// <summary>
        /// BankNumber:  Returns the value of the BANK OF BIT bank number.
        /// </summary>
        /// <returns>The BANK OF BIT bank number.</returns>
        public static int BankNumber()
        {
            return BANK_OF_BIT_NUMBER;
        }

        /// <summary>
        /// AccountFormat:  A method that provides the formatting characters for each
        /// type of bank account.
        /// </summary>
        /// <param name="accountType">The type of bank account.</param>
        /// <returns>The formatting characters specific to the type of bank account.</returns>
        public static String AccountFormat(String accountType)
        {
            string[] ACCOUNT_TYPE = { "Savings", "Mortgage", "Investment", "Chequing" };
            string[] ACCOUNT_MASK = { "0-000-0", "000-000", "00-000-00", "000-00-000" };


            //initial format (empty string)
            string format = "";

            //compare account type to predefined types
            for (int i = 0; i < ACCOUNT_TYPE.Length; i++)
            {
                //if a match, return the corresonding mask
                if (accountType.ToLower().Equals(ACCOUNT_TYPE[i].ToLower()))
                {
                    format = ACCOUNT_MASK[i];
                }
            }
            //return the mask or empty string
            return format;
        }

        /// <summary>
        /// ParseName trims the length of the object name based on an index, or section of the substring
        /// </summary>
        /// <param name="ObjectName">The value of GetType().Name</param>
        /// <param name="index">The section of the name to count as the index</param>
        /// <returns>The object name parsed.</returns>
        public static string ParseName(string ObjectName, string index)
        {
            return ObjectName.Substring(0, ObjectName.IndexOf(index));
        }
    }
}
