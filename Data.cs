using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Devnote
{
    internal class Data
    {
        public string Id { get; set; } // ?
        public string parent_namespace;
        public string name;
        public string definition;
        public string assembly;
        public string interface_implement;
        public string description;
        public List<string> tags;               // array? list?
        public string constructor;              // not all classes implements the same structure... we need to dynamically create a class type. but until before then... put this here. (Reflection feature)
        public List<string> fields;             // would a dictionary be better here? or handle it using query when getting/setting it?
        public List<string> properties;         // or polymorphism? abstract class?
        public List<string> methods;            // have basic structure of class, and allow additional sections?
        public List<string> operators;          // use of generic class?
        public List<string> extension_methods;  // or use of list of lists?
        

        public Data(string name)
        {
            parent_namespace = "";
            this.name = name;
        }

        public string[] GetFieldInfo()
        {
            FieldInfo[] fieldInfo = this.GetType().GetFields();
            return (from field in fieldInfo
                   select field.Name).ToArray();
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


    internal class Tags
    {
        private List<string> list = new List<string>();

        public void Add(string tag) => list.Add(tag);           // expression bodied method
        public void Remove(string tag) => list.Remove(tag);

        public int Capacity() => list.Capacity;                 // this is read-only
        public string this[int index] => list[index];           // read-only indexer

    }
}
