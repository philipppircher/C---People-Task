using System;
using System.Collections;
using System.Text;

namespace PersonApp
{
    internal static class Controller
    {
        internal static void PerformPeopleTask(string path)
        {
            string[] myPeople = GetAllPeopleFromFileToArray(path);

            ArrayList people = CreatePersonObjectFromFile(myPeople);

            ExtendPeopleJob(people);

            WritePeopleToNewFile(people);

            PrintPeopleToConsole(people);
        }


        private static string[] GetAllPeopleFromFileToArray(string path)
        {
            Console.WriteLine("File " + path + " wird gelesen und als string-Array angelegt\n");

            string[] myFileContent = System.IO.File.ReadAllLines(path);
            return myFileContent;
        }

        private static ArrayList CreatePersonObjectFromFile(string[] myFileContent)
        {
            Console.WriteLine("Erzeuge Personen Objekte aus den string-Array Elementen\n");

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
            Console.WriteLine("Ein Job wird den Personen hinzugefügt\n");

            for (int i = 0; i < people.Count; i++)
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
            Console.WriteLine("Eine neue .txt Datei wird erstellt\n");

            string[] peopleTextArray = new string[people.Count];

            for (int i = 0; i < people.Count; i++)
            {
                peopleTextArray[i] = people[i].ToString();
            }

            System.IO.File.WriteAllLines("peopleWithJob.txt", peopleTextArray, Encoding.UTF8);
        }

        private static void PrintPeopleToConsole(ArrayList people)
        {
            Console.WriteLine("Direkte Ausgabe aller Personen\n\n");

            foreach (Person currentPerson in people)
            {
                Console.WriteLine(currentPerson.ToString());
            }
        }
    }
}