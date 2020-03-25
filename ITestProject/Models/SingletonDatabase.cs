using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using MoreLinq;
using NUnit.Framework;
using static System.Console;

namespace ITestProject
{
        public interface IDatabase
        {
            int GetPopulation(string name);
        }

        public class SingletonDatabase : IDatabase
        {
            private Dictionary<string, int> capitals;
            
            private SingletonDatabase()
            {
            capitals = File.ReadAllLines(

                Path.Combine(
                      new FileInfo(typeof(IDatabase).Assembly.Location).DirectoryName, "Data/capitals.txt")
                 )

                .Batch(2)
                .ToDictionary(
                    list => list.ElementAt(0).Trim(),
                    list => int.Parse(list.ElementAt(1))
                    );
            }
            
            public int GetPopulation(string name)
            {
                return capitals[name];
            }

            private static SingletonDatabase instance = new SingletonDatabase();

            public static SingletonDatabase getInstance()
            {
                return instance;
            }
        }
    [TestFixture]
    public class SingletonTests
    {
        [Test]
        public void TestSingletonDatabase()
        {
            SingletonDatabase db1 = SingletonDatabase.getInstance();
            SingletonDatabase db2 = SingletonDatabase.getInstance();
            Assert.That(db1, Is.SameAs(db2));
        }
    }
}
