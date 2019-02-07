using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Diagnostics;

namespace EclipsePos.Data
{
    public class Surcharge : IRelatableSet
    {
        #region Variables
        private DataSet resultSet;
        private string organization_no;
        private string surcharge_code;
        private string surcharge_desc;
        private double amount;
        private int method;
        private string surcharge_acct;
        private string tax_group_id;
        private int tax_inclusive;
        private int tax_exempt;
        private int surcharge_key_id;

        #endregion

        public Surcharge()
        {
            resultSet = new DataSet();
        }

        #region Properties

        public string Organization_no
        {
            set
            {
                organization_no = value;
            }
            get
            {
                return organization_no;
            }
        }

        public string Surcharge_code
        {
            set
            {
                surcharge_code = value;
            }
            get
            {
                return surcharge_code;
            }
        }

        public string Surcharge_desc
        {
            set
            {
                surcharge_desc = value;
            }
            get
            {
                return surcharge_desc;
            }
        }

        public double Amount
        {
            set
            {
                amount = value;
            }
            get
            {
                return amount;
            }
        }

        public int Method
        {
            set
            {
                method = value;
            }
            get
            {
                return method;
            }
        }

        public string Surcharge_acct
        {
            set
            {
                surcharge_acct = value;
            }
            get
            {
                return surcharge_acct;
            }
        }

        public string Tax_group_id
        {
            set
            {
                tax_group_id = value;
            }
            get
            {
                return tax_group_id;
            }
        }

        
        public int Tax_inclusive
        {
            set
            {
                tax_inclusive = value;
            }
            get
            {
                return tax_inclusive;
            }
        }

        public int Tax_exempt
        {
            set
            {
                tax_exempt = value;
            }
            get
            {
                return tax_exempt;
            }
        }

        public int Surcharge_key_id
        {
            set
            {
                this.surcharge_key_id = value;
            }
            get
            {
                return this.surcharge_key_id;
            }
        }
        #endregion

        

        public void LoadByKeyId()
        {
            SqlRelator sr = new SqlRelator();
            sr.Relate(this, "LoadSurchargeBySurchargeKey");
        }


        public void LoadBySurchargeCode()
        {
            SqlRelator sr = new SqlRelator();
            sr.Relate(this, "LoadSurchargeBySurchargeCode");
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
