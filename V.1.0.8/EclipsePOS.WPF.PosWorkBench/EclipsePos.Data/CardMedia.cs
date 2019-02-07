using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace EclipsePos.Data
{
    public class CardMedia : IRelatableSet	
    {

        private DataSet resultSet;

       // private string media_id;
        

        public CardMedia()
        {
            resultSet = new DataSet();
        }

        public void LoadByMediaID()
        {
            SqlRelator sr = new SqlRelator();
            sr.Relate(this, "LoadMeidaByMediaID");

        }

        public DataSet LoadAllMedia()
        {
            SqlRelator sr = new SqlRelator();
            sr.Relate(this, "LoadMediaByOrganizationNo");
            return resultSet;
        }


        #region Properties

        public int Media_id
        {
            get;
            set;
        }

        public String Media_name
        {
            get;
            set;
        }


        public String Organization_no
        {
            get;
            set;
        }

        public String Media_desc
        {
            get;
            set;
        }

        public int Total_type
        {
            get;
            set;
        }

        public string Media_class
        {
            get;
            set;
        }

        public int Media_type
        {
            get;
            set;
        }


        #endregion

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
