using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSLTest.Helper
{
    public class CommonFunctions
    {
        public string ConvertToAgilixBasedSequence(string dlapSequence)
        {
            int sequence = Convert.ToInt32(dlapSequence);
            string sequenceString = "";
            decimal sequenceNumber = sequence;
            decimal currentLetterNumber = (sequenceNumber - 1) % 26;
            char currentLetter = (char)(currentLetterNumber + 65);
            sequenceString = currentLetter + sequenceString;

            sequenceNumber = (sequenceNumber - (currentLetterNumber + 1)) / 26;

            for (int i = 0; i < sequenceNumber; i++)
            {
                sequenceString = "Z" + sequenceString;
            }
            return sequenceString.ToLower();
        }
    }
}