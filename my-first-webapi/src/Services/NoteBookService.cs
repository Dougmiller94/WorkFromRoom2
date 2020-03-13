using src.Persistance.Models;
using src.Persistance.Repsoitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Services
{
    public class NoteBookService
    {
        private readonly IRepository<NoteBook> _repository;
        public NoteBookService(IRepository<NoteBook> repository)
        {
            _repository = repository;
        }

        public async Task<NoteBook> CreateNoteBook(NoteBook noteBook)
        {
            _repository.AddAnEntityAsync(noteBook);
            await _repository.Save();
            return noteBook;
         }
        public async Task<int> DeleteNoteBook(int id)
        {
            NoteService noteBook = await _repository.GetSingleAsync(id);
            _repository.Delete(noteBook);
            return await _repository.Save();
        }
        public async Task<NoteBook> PatchNotebookTitle(NoteBook noteBook)
        {
            NoteBook foundnoteBook = await GetnoteBookAsync(noteBook.Id)


        }




        public async Task<List<NoteBook>> GetAllNoteBooks(int id)
        {
            
            return await _repository.GetAllAsync();
        }






    }
}
