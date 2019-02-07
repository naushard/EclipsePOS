using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EclipsePos.Apps.Views.TableSelect
{
    
    public class TableButtonData
    {
        private int display_row;
        private int display_col;
        private string table_name;
        private string picture_name;
        private int table_no;
        private int pos_no;
        private int trans_no;

        public int Display_row_no
        {
            get
            {
                return display_row;
            }
            set
            {
                display_row = value;
            }
        }

        public int Display_column_no
        {
            get
            {
                return display_col;
            }
            set
            {
                display_col = value;
            }
        }

        public string Table_name
        {
            get
            {
                return table_name;
            }
            set
            {
                table_name = value;
            }
        }


        public int Table_no
        {
            get
            {
                return table_no;
            }
            set
            {
                table_no = value;
            }
        }

        public string Picture_name
        {
            get
            {
                return picture_name;
            }
            set
            {
                picture_name = value;
            }
        }

        public int Trans_no
        {
            get
            {
                return trans_no;
            }
            set
            {
                trans_no = value;
            }
        }

        

        public int Pos_no
        {
            get
            {
                return pos_no;
            }
            set
            {
                pos_no = value;
            }
        }




    }
}
