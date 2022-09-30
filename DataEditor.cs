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

        internal void Add(int type, ref ClassData data)
        {
            try
            {
                DBManager.Instance.Connect();
                do
                {
                    // switch case and select type of the data to create
                    // receive as parameters of the type and the data
                    // sanitize the string here


                } while (!CheckExists());
            }
            catch
            {
                throw;
            }
        }

        internal void Update()
        {

        }

        internal void Remove()
        {

        }

        private bool  CheckExists()
        {
            // if exact match found, display it and ask for different name.
            // if not, and if similar data is found,
            // display brief summary of the similar data,
            // and ask if the user wants to proceed to add new data
            // and give a selection to edit the similar data (and choose one of them)
            return true;
        }

        private void CreateClass(ref List<string> data)
        {

        }
    }
}
