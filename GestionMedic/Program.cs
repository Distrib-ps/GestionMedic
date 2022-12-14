using GestionMedic.DATA;
using GestionMedic.model;
using System;
using System.IO;

namespace GestionMedic
{
    class Program
    {
        private void AjoutCategorie()
        {
            var dbContext = new MyDbContext();
            try
            {
                var file = Path.Combine(@"C:\Users\Wallon\source\repos\GestionMedic\GestionMedic\ressources\categories.csv");
                using (var streamReader = System.IO.File.OpenText(file))
                {
                    while (!streamReader.EndOfStream)
                    {
                        var line = streamReader.ReadLine();

                        var data = line.Split(';');
                        var cat = new categories(Convert.ToInt32(data[0]), data[1].Replace("\"", ""));
                        dbContext.Add(cat);
                    }

                    dbContext.SaveChanges();
                    Console.WriteLine("Nouvelle valeur (CATEGORIE) ajouter à la table");
                }
            }
            catch (Exception ex)
            {
                dbContext.UpdateRange();
                Console.WriteLine("Valeur (CATEGORIE) update à la table");
            }
        }

        private void Ajoutmedicament()
        {
            var dbContext = new MyDbContext();
            try { 
                var file2 = Path.Combine(@"C:\Users\Wallon\source\repos\GestionMedic\GestionMedic\ressources\medicaments.csv");
                using (var streamReader = System.IO.File.OpenText(file2))
                {
                    while (!streamReader.EndOfStream)
                    {
                        var line = streamReader.ReadLine();

                        var data = line.Split(';');
                        var medicament = new medicaments(Convert.ToInt32(data[0]), data[1].Replace("\"", ""), data[2], data[3], Convert.ToInt32(data[4]));
                        dbContext.Add(medicament);
                    }

                    dbContext.SaveChanges();
                    Console.WriteLine("Nouvelle valeur (MEDICAMENT) ajouter à la table");
                }
            }
            catch (Exception ex)
            {

                dbContext.UpdateRange();
                Console.WriteLine("Valeur (MEDICAMENT) update à la table");
            }
        }
        static void Main(string[] args)
        {
            var program = new Program();
            program.AjoutCategorie();
            program.Ajoutmedicament();
        }
    }
}
