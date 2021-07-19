using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace LinkKisaltma
{
    class SqlBaglantisi
    {
          public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-Q0J7R6D\\SQLEXPRESS;Initial Catalog=LinkKisaltma;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
     
}
