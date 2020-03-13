using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace src.Persistance.Models
{
    public class NoteBook
    {
       
        /// Princaple Key
       

        [Key]
        public int Id { get; set; }

        public string Title { get; set; }


        /// <summary>
        /// collection navigation property 
        /// </summary>


        public List<Note> Notes { get; set; } = new List<Note>();
    }
}
