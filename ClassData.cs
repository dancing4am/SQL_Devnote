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
    internal class ClassData
    {
        public int ID { get; set; }         // assigned when inserted into DB
        public string parent_ID;            // perhaps namespace ID
        public string name;
        public string definition;
        public string description;
        public Tags tags;

        public string[] additional;         // IDs of additional 

        public ClassData(string name)
        {
            this.name = name;
            this.tags = new Tags();
        }

        public string[] GetFieldInfo()
        {
            FieldInfo[] fieldInfo = this.GetType().GetFields();             // TODO: get "additional" list as well
            return (from field in fieldInfo
                   select field.Name).ToArray() as string[];                // maybe can be used to call different properties from custom data using expression-dynamic functions? should it be returned in FiledInfo type to access?
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
        public string Description { get; set; }
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
