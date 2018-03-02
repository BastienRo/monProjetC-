using System;
using Isen.DotNet.Library;
using Isen.DotNet.Library.Models.Implementation;
using Isen.DotNet.Library.Repositories.InMemory;
using Isen.DotNet.Library.Repositories.Interfaces;

namespace Isen.DotNet.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ICityRepository cityRepo = new InMemoryCityRepository();
            IPersonRepository personRepository = new InMemoryPersonRepository(cityRepo);
            // Toutes les villes
            Console.WriteLine("Toutes les villes");
            foreach(var c in cityRepo.GetAll()) Console.WriteLine(c);
            Console.WriteLine("--------------------------");
            // Toutes les personnes
            Console.WriteLine("Toutes les personnes");
            foreach(var p in personRepository.GetAll()) Console.WriteLine(p);
            Console.WriteLine("--------------------------");
            // Toutes les personnes nées apres 1970
            Console.WriteLine("Toutes les personnes nées apres 1970");
            var personBornAfter = personRepository.Find(p =>
                p.BirthDate.HasValue &&
                p.BirthDate.Value.Year >= 1970);
            foreach (var p in personBornAfter)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine("--------------------------");
            
            //Toutes les personne de plus de 40 ans
            Console.WriteLine("Personne ayant plus de 40 ans");
            var personOlderThan = personRepository
                .Find(p =>
                    p.Age.HasValue &&
                    p.Age.Value >= 40);
            foreach (var p in personOlderThan)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine("--------------------------");
            
            // Toutes les villes qui contiennent un "e"
            Console.WriteLine("Toute les villes qui contiennent un \"e\"");
            var citiesWithE = cityRepo
                .Find(c =>
                    c.Name.IndexOf("e",
                        StringComparison.CurrentCultureIgnoreCase) >= 0);
            Console.WriteLine("--------------------------");
            foreach (var c in citiesWithE)
            {
                Console.WriteLine(c);
                
            }
            Console.WriteLine("--------------------------");
            
            //Effacer une ville
            var epinal = cityRepo.Single("Epinal");
            cityRepo.Delete(epinal);
            foreach (var c in cityRepo.GetAll())
            {
                Console.WriteLine(c);
            }
            Console.WriteLine("--------------------------");

        }
    }
}