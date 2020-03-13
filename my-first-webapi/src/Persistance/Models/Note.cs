using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace src.Persistance.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Text { get; set; }



        public int NotebookId { get; set; }

        [ForeignKey("NoteBookId")]

        public NoteBook NoteBook { get; set; }
    }
}
