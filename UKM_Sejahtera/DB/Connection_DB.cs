using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKM_Sejahtera.DB
{
    internal class Connection_DB
    {
        private readonly string cs = "Data Source=MICAEL\\SQLEXPRESS01;" +
            "Initial Catalog=ukm_sejahtera;" +
            "Integrated Security=true;" +
            "TrustServerCertificate=true";

        public string getterConnection()
        {   
            return cs;
        }
        
    }
}
