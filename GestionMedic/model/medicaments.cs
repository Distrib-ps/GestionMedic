using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMedic.model
{
    public class medicaments
    {
        [Key]
        public int id { get; set; }
        [MaxLength(250)]
        public string nom { get; set; }
        [MaxLength(250)]
        public string image { get; set; }
        [MaxLength(50)]
        public string prix { get; set; }
        public int id_categorie { get; set; }
        public categories categories { get; set; }
        public medicaments(int id, string nom, string image, string prix, int id_categorie)
        {
            this.id = id;
            this.nom = nom;
            this.image = image;
            this.prix = prix;
            this.id_categorie = id_categorie;
        }
    }
}
