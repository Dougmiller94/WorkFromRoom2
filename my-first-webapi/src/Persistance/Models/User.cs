using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace src.Persistance.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }


        /// <summary>
        /// collection navigation property 
        /// </summary>


        public List<NoteBook> NoteBook { get; set; } = new List<NoteBook>();



    }
}
