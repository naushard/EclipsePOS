using System;
using System.Collections.Generic;
using System.Text;

namespace EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.BarcodeLib.Symbologies
{
    class ITF14 : BarcodeCommon, IBarcode
    {
        private string[] ITF14_Code = { "NNWWN", "WNNNW", "NWNNW", "WWNNN", "NNWNW", "WNWNN", "NWWNN", "NNNWW", "WNNWN", "NWNWN" };

        public ITF14(string input)
        {
            Raw_Data = input;

            CheckDigit();
        }
        /// <summary>
        /// Encode the raw data using the ITF-14 algorithm.
        /// </summary>
        private string Encode_ITF14()
        {
            //check length of input
            if (Raw_Data.Length > 14 || Raw_Data.Length < 13)
                Error("EITF14-1: Data length invalid. (Length must be 13 or 14)");

            if (!BarcodeLib.Barcode.CheckNumericOnly(Raw_Data))
                Error("EITF14-2: Numeric data only.");

            string result = "1010";

            for (int i = 0; i < Raw_Data.Length; i += 2)
            {
                bool bars = true;
                string patternbars = ITF14_Code[Int32.Parse(Raw_Data[i].ToString())];
                string patternspaces = ITF14_Code[Int32.Parse(Raw_Data[i + 1].ToString())];
                string patternmixed = "";

                //interleave
                while (patternbars.Length > 0)
                {
                    patternmixed += patternbars[0].ToString() + patternspaces[0].ToString();
                    patternbars = patternbars.Substring(1);
                    patternspaces = patternspaces.Substring(1);
                }//while

                foreach (char c1 in patternmixed)
                {
                    if (bars)
                    {
                        if (c1 == 'N')
                            result += "1";
                        else
                            result += "11";
                    }//if
                    else
                    {
                        if (c1 == 'N')
                            result += "0";
                        else
                            result += "00";
                    }//else
                    bars = !bars;
                }//foreach
            }//foreach

            //add ending bars
            result += "1101";
            return result;
        }//Encode_ITF14
        private void CheckDigit()
        {
            //calculate and include checksum if it is necessary
            if (Raw_Data.Length == 13)
            {
                int even = 0;
                int odd = 0;

                //odd
                for (int i = 0; i <= 10; i += 2)
                {
                    odd += Int32.Parse(Raw_Data.Substring(i, 1));
                }//for

                //even
                for (int i = 1; i <= 11; i += 2)
                {
                    even += Int32.Parse(Raw_Data.Substring(i, 1)) * 3;
                }//for

                int total = even + odd;
                int cs = total % 10;
                cs = 10 - cs;
                if (cs == 10)
                    cs = 0;

                this.Raw_Data += cs.ToString();
            }//if
        }

        #region IBarcode Members

        public string Encoded_Value
        {
            get { return this.Encode_ITF14(); }
        }

        #endregion
    }
}
