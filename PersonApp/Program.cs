
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
            string path = ("persons.txt");
            Controller.PerformPeopleTask(path);
        }
    }
}

       
