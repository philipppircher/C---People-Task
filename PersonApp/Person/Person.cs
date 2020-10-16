using System;
using System.Threading.Tasks.Dataflow;

namespace PersonApp
{
    public class Person
    {
        public Person()
        {

        }

        public Person(string name, int age, string city)
        {
            Name = name;
            Age = age;
            City = city;
        }

        public int Age { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Job { get; set; }

        public override string ToString()
        {
            return (Name + ";" + Age + ";" + City + ";" + Job);
        }
    }
}
