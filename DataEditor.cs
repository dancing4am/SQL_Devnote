using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SQL_Devnote
{
    internal sealed class DataEditor
    {
        internal static readonly DataEditor Instance = new DataEditor();

        private DataEditor()
        {

        }

        internal void Add()
        {
            DBManager.Instance.Connect();
            //string query = "insert into devnote."
        }

        internal void Update()
        {

        }

        internal void Remove()
        {

        }

        private void CheckExists()
        {

        }
    }
}
