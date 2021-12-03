using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using MDEV.Model;

namespace MDEV.Service
{
    public class ServiceTest
    {
        public static List<Model.Test> tests = new List<Model.Test>();
        public static List<Model.Test> GetTests()
        {

            WebClient client = new WebClient();
            Stream stream = client.OpenRead("https://oybekrustamov.github.io/MDEV/tests.txt");
            StreamReader reader = new StreamReader(stream);
            List<Test> tests = new List<Test>();
            while (!reader.EndOfStream)
            {
                string z = reader.ReadLine();
                string[] tempz = new string[4];
                tempz = z.Split('|');
                Test test = new Test();
                try
                {
                    test.Question = tempz[0];
                    string[] answers = new string[5];
                    answers[0] = tempz[1];
                    answers[1] = tempz[2];
                    answers[2] = tempz[3];
                    answers[3] = tempz[4];
                    test.Answers = answers;
                    tests.Add(test);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            reader.Close();
            return tests;
        }
    }
}
