using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

// https://learn.microsoft.com/en-us/ef/ef6/modeling/code-first/migrations/
namespace SQL_Devnote
{
    //enum AdditionalType
    //{
    //    Fields,
    //    Methods,
    //    Properties,
    //    Operators,
    //    ExtensionMethods,
    //    Interfaces
    //    // Assembly ----> is this supposed to be here?
    //}

    internal class ClassData
    {
        public int ID { get; set; }         // assigned when inserted into DB
        public string name;
        public string parent_ID;            // perhaps namespace ID
        public string definition;
        public string description;
        public Tags tags;
        public Additionals additionals;         // IDs of additional 

        public ClassData(string name)
        {
            this.name = name;
            parent_ID = string.Empty;
            definition = string.Empty;
            description = string.Empty;
            tags = new Tags();
            additionals = new Additionals();
        }

        public string[] GetFieldInfo()
        {
            FieldInfo[] fieldInfo = this.GetType().GetFields();             // TODO: get "additional" list as well
            return (from field in fieldInfo
                   select field.Name).ToArray() as string[];                // maybe can be used to call different properties from custom data using expression-dynamic functions? should it be returned in FiledInfo type to access?
        }




        /*  
         *  the existence of this method suggests that creating data should be step by step directly
         *  connected to the DB, not filling all data in and then inserting it into DB at once . . .
         *  need to reconsider the design
         *  - do I still need the "Additional" class to proceed this?
         *  - 
        */
        public void AddAdditional()
        {
            // get data class object or the class type info and name
                // if info: create class instance and add name
            
            // call corresponding method to create the instance
                // run until user decides to insert data
            
            // if user completes inserting data info, ask DB to generate appropriate ID
                // DB side: get ID and insert data
                    // return the ID

            // store the ID, add to "additionals" list
                // both instance and DB
        }
    }


    internal class Tags         // do we need this? is this maintainability good or bad?
    {
        public int Id;
        private List<string> list = new List<string>();

        public void Add(string tag) => list.Add(tag);           // expression bodied method
        public void Remove(string tag) => list.Remove(tag);
        public string this[int index] => list[index];           // read-only indexer
    }


    abstract class PotentialMultiple<T> where T : BaseData
    {
        private List<T> list = new List<T>();

        public virtual void Add(T item) => list.Add(item);
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

    interface BaseData
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }


    interface NamedData : BaseData
    {
        public string Definition { get; set; }
        public string Description { get; set; }
    }

    internal class Additionals : PotentialMultiple<Additional>
    {

    }

    internal class Additional : BaseData
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Additional(string name)      // pass class's name
        {
            Name = name;
        }
    }

    internal class Assembly
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Assembly(string name)
        {
            Name = name;
        }
    }

    internal class Fields : PotentialMultiple<Field>
    {
        // do we need this or do we have to use a generic class instead?
        // I guess this is a better way for extensibility & flexibility
    }

    internal class Field : NamedData
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Definition { get; set; }
        public string Description { get; set; }
        public string Example { get; set; }

        public Field(string name)
        {
            Name = name;
            Value = string.Empty;
            Definition = string.Empty;
            Description = string.Empty;
            Example = string.Empty;
        }
    }

    internal class Methods : PotentialMultiple<Method>
    {

    }

    internal class Method : NamedData
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Definition { get; set; }
        public Parameters Parameters { get; set; }
        public string Return { get; set; }
        public string Description { get; set; }
        public string Example { get; set; }

        public Method(string name)
        {
            Name = name;
            Definition = string.Empty;
            Parameters = new Parameters();
            Return = string.Empty;
            Description = string.Empty;
            Example = string.Empty;
        }
    }

    internal class Property : NamedData
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Definition { get; set; }
        public string Description { get; set; }

        public Property(string name)
        {
            Name = name;
            Value = string.Empty;
            Definition = string.Empty;
            Description = string.Empty;
        }
    }

    internal class Parameters : PotentialMultiple<Parameter>
    {

    }

    internal class Parameter : NamedData
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Definition { get; set; }
        public string Description { get; set; }
        public Parameter(string name)
        {
            Name = name;
            Definition = string.Empty;
            Description = string.Empty;
        }
    }

    internal class Constructor : NamedData
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Definition { get; set; }
        public string Description { get; set; }
        public Parameters Parameters { get; set; }
        public Constructor(string name)
        {
            Name = name;
            Definition = string.Empty;
            Description = string.Empty;
            Parameters = new Parameters();
        }
    }
}
