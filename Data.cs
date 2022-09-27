using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Devnote
{
    internal class Data
    {
        public string parent_namespace;
        public string name;
        public string definition;
        public string assembly;
        public string interface_implement;
        public string description;
        public List<string> tags;               // array? list?
        public string constructor;              // not all classes implements the same structure... we need to dynamically create a class type. but until before then... put this here.
        public List<string> fields;             // would a dictionary be better here? or handle it using query when getting/setting it?
        public List<string> properties;         
        public List<string> methods;
        public List<string> operators;
        public List<string> extension_methods;
        

        public Data(string name)
        {
            parent_namespace = "";
            this.name = name;
        }

        /*
            parent namespace

            parent right above to create a hierarchy

            class name

            definition
                e.g. 
                public abstract class Delegate : ICloneable, System.Runtime.Serialization.ISerializable

            assembly

            interface implements

            description

            ‘Remarks’ in the official documentation

            do not just copy-and-paste but abstract

            tags

            string array

            constructors

            fields

            properties

            methods

            operators

            extension methods
        */

    }
}
