using System.Collections.Generic;

namespace BusinessLib.DataModel
{
    /// <summary>
    /// A simple data transfer object (DTO) that contains raw data about a person.
    /// </summary>
    public class Person
    {
        readonly List<Person> _children = new List<Person>();
        public IList<Person> Children
        {
            get { return _children; }
        }

        public string Name { get; set; }
    }
}