using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Diagnostics;


namespace EclipsePos.Data
{
    public class TransText : IRelatableSet	
    {
        #region Variables
        private DataSet resultSet;

        private int trans_no;
        private int line_no;
        private int seq_no;


        private string organization_no;
        private string store_no;
        private int pos_no;

        private int text_line_no;
        private string extended_text;

        #endregion

        public TransText()
		{
			resultSet = new DataSet();
		}

        public TransText(DataRow dr)
		{
			this.Trans_no = int.Parse(dr["trans_no"].ToString());
            this.Seq_no = int.Parse(dr["seq_no"].ToString());
			this.extended_text = dr["extended_text"].ToString();
            this.Line_no = int.Parse(dr["line_no"].ToString());
            this.Organization_no = dr["organization_no"].ToString();
            this.Store_no = dr["store_no"].ToString();
            this.text_line_no = int.Parse(dr["text_line_no"].ToString());
			this.Pos_no = int.Parse(dr["pos_no"].ToString());
		}

		#region Properties

		public string Organization_no
		{
			set
			{
				organization_no= value;
			}
			get
			{
				return organization_no;
			}
		}

		public string Store_no
		{
			set
			{
				store_no= value;
			}
			get
			{
				return store_no;
			}
		}

		public string Extended_text
		{
			set
			{
				extended_text = value;
			}
			get
			{
				return extended_text;
			}
		}

        public int Pos_no
        {
            set
            {
                pos_no = value;
            }
            get
            {
                return pos_no;
            }
        }

        public int Text_line_no
        {
            set
            {
                text_line_no = value;
            }
            get
            {
                return text_line_no;
            }
        }

        public int Trans_no
        {
            set
            {
                trans_no = value;
            }
            get
            {
                return trans_no;
            }
        }
        
        public int Seq_no
        {
            set
            {
                seq_no = value;
            }
            get
            {
                return seq_no;
            }
        }

        public int Line_no
        {
            set
            {
                line_no = value;
            }
            get
            {
                return line_no;
            }
        }

		#endregion

		public void Add()
		{
			SqlRelator sr = new SqlRelator();
			sr.Relate(this, "AddRun");

		}

		public DataSet LoadByTransNo()
		{
			SqlRelator sr = new SqlRelator();
            sr.Relate(this, "LoadByTransNo");
			return resultSet;
		}


		
		



		#region IRelatableSet Members

		public DataSet ResultSet
		{
			get
			{
				return resultSet;
			}
			set
			{
				resultSet = value;
			}
		}

		#endregion

    }
}
