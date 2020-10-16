
using System;
using System.Collections;
using System.Net.Http.Headers;
using System.Text;

namespace PersonApp
{
    class Program
    {
        static void Main(string[] args)
        {
            PerformPeopleTask();
        }

        private static void PerformPeopleTask() {
            string[] myPeople = GetAllPeopleFromFileToArray();

            ArrayList people = CreatePersonObjectFromFile(myPeople);

            ExtendPeopleJob(people);

            WritePeopleToNewFile(people);
        }


        private static string[] GetAllPeopleFromFileToArray()
        {
            string[] myFileContent = System.IO.File.ReadAllLines("persons.txt");
            return myFileContent;
        }

        private static ArrayList CreatePersonObjectFromFile(string[] myFileContent)
        {
            ArrayList people = new ArrayList();

            for (int i = 0; i < myFileContent.Length; i++)
            {
                string[] temp = myFileContent[i].Split(";");
                people.Add(new Person(temp[0], Int32.Parse(temp[1]), temp[2])); ;
            }
            return people;
        }

        private static void ExtendPeopleJob(ArrayList people)
        {
            for(int i = 0; i < people.Count; i++)
            {
                Person currentPerson = (Person)people[i];

                if (currentPerson.Name.Contains("Hans") || currentPerson.Name.Contains("Helga"))
                {
                    currentPerson.Job = "Coder";
                }
                else
                {
                    currentPerson.Job = "Officer";
                }
            }
        }

        private static void WritePeopleToNewFile(ArrayList people)
        {
            string[] peopleTextArray = new string[people.Count];

            for (int i = 0; i < people.Count; i++)
            {
                peopleTextArray[i] = people[i].ToString();
            }

            System.IO.File.WriteAllLines("peopleWithJob.txt", peopleTextArray, Encoding.UTF8);
        }

        private static void PrintPeopleToConsole(ArrayList people)
        {
            foreach (Person currentPerson in people)
            {
                Console.WriteLine(currentPerson.ToString());
            }
        }
    }
}
