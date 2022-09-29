using System;
using System.Collections;
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
        public Tags tags;               // array? list?
        public string constructor;              // not all classes implements the same structure... we need to dynamically create a class type. but until before then... put this here. (Reflection feature)
        public Fields fields;                   // would a dictionary be better here? or handle it using query when getting/setting it?
        public List<string> properties;         // or polymorphism? abstract class?
        public Methods methods;            // have basic structure of class, and allow additional sections?
        public List<string> operators;          // use of generic class?
        public List<string> extension_methods;  // or use of list of lists?
        

        public Data(string name)
        {
            parent_namespace = "";
            this.name = name;
            this.fields = new Fields();
        }

        public string[] GetFieldInfo()
        {
            FieldInfo[] fieldInfo = this.GetType().GetFields();
            return (from field in fieldInfo
                   select field.Name).ToArray() as string[];                // maybe can be used to call different properties from custom data using expression-dynamic functions? should it be returned in FiledInfo type to access?
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


    internal class Tags         // do we need this? is this maintainability good or bad?
    {
        private List<string> list = new List<string>();

        public void Add(string tag) => list.Add(tag);           // expression bodied method
        public void Remove(string tag) => list.Remove(tag);
        public string this[int index] => list[index];           // read-only indexer
    }


    abstract class PotentialMultiple<T> where T : NamedData
    {
        private List<T> list = new List<T>();

        public void Add(T item) => list.Add(item);
        public void Remove(string name)
        {
            T? item = GetItem(name);
            if (item is not null)
            {
                list.Remove(item);
            }
        }
        public string[] GetItemList() => (from item in list
                                           orderby item.Name
                                           select item.Name).ToArray() as string[];

        public T? GetItem(string name) => list.Find(f => f.Name == name);
        public T[] GetAllItems() => list.ToArray();
    }


    interface NamedData
    {
        public string Name { get; set; }
        public string Definition { get; set; }
        public string Remarks { get; set; }
    }


    internal class Fields : PotentialMultiple<Field>
    {
        // do we need this or do we have to use a generic class instead?
    }

    internal class Field : NamedData
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public string Definition { get; set; }
        public string Remarks { get; set; }
        public string Example { get; set; }

        public Field(string name)
        {
            Name = name;
            Value = string.Empty;
            Definition = string.Empty;
            Remarks = string.Empty;
            Example = string.Empty;
        }
    }

    internal class Methods : PotentialMultiple<Method>
    {

    }

    internal class Method : NamedData
    {
        public string Name { get; set; }
        public string Definition { get; set; }
        public Dictionary<string, string> Parameters { get; set; }
        public string Return { get; set; }
        public string Remarks { get; set; }
        public string Example { get; set; }

        public Method(string name)
        {
            Name = name;
            Definition = string.Empty;
            Parameters = new Dictionary<string, string>();
            Remarks = string.Empty;
            Example = string.Empty;
        }
    }
}
