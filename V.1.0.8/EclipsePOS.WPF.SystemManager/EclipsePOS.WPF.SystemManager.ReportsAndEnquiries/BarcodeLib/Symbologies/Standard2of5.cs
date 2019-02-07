using System;
using System.Collections.Generic;
using System.Text;

namespace EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.BarcodeLib.Symbologies
{
    class Standard2of5 : BarcodeCommon, IBarcode
    {
        private string[] S25_Code = { "11101010101110", "10111010101110", "11101110101010", "10101110101110", "11101011101010", "10111011101010", "10101011101110", "10101110111010", "11101010111010", "10111010111010" };

        public Standard2of5(string input)
        {
            Raw_Data = input;
        }//Standard2of5
        /// <summary>
        /// Encode the raw data using the Standard 2 of 5 algorithm.
        /// </summary>
        private string Encode_Standard2of5()
        {
            if (!BarcodeLib.Barcode.CheckNumericOnly(Raw_Data))
                Error("ES25-1: Numeric Data Only");

            string result = "11011010";

            foreach (char c in Raw_Data)
            {
                result += S25_Code[Int32.Parse(c.ToString())];
            }//foreach

            //add ending bars
            result += "1101011";
            return result;
        }//Encode_Standard2of5

        #region IBarcode Members

        public string Encoded_Value
        {
            get { return Encode_Standard2of5(); }
        }

        #endregion
    }
}
