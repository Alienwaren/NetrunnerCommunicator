using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
namespace ARDSQL_GUI
{
    class SQLCon
    {
        SqlConnection tempBase1 = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=E:\\DB\\Dropbox\\Repozytoria\\ARDSQL GUI\\Data\\ArdSQLDB.mdf;Integrated Security=True");
    }
}
