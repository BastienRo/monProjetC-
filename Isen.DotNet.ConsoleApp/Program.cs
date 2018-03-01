using System;
using Isen.DotNet.Library;
using Isen.DotNet.Library.Models.Implementation;
using Isen.DotNet.Library.Repositories.InMemory;

namespace Isen.DotNet.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var cityRepo = new InMemoryCityRepository();
            Console.WriteLine(cityRepo.Single(3));
            Console.WriteLine(cityRepo.Single("Toulon"));
            var allCities = cityRepo.GetAll();
            foreach(var c in allCities) Console.WriteLine(c);
        }
    }
}
