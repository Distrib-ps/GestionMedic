using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMedic.model
{
    public class categories
    {
        [Key]
        public int id { get; set; }
        [MaxLength(50)]
        public string categorie { get; set; }
        public ICollection<medicaments> medicaments { get; set; }
        public categories(int id, string categorie)
        {
            this.id = id;
            this.categorie = categorie;
        }
    }
}
