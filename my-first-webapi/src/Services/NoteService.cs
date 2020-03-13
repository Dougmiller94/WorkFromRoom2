using src.Persistance.Models;
using src.Persistance.Repsoitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Services
{
    public class NoteService
    {
        private readonly IRepository<Note> _repository;
        private readonly IRepository<NoteBook> _noteBookrepository;
        public NoteService(IRepository<Note> repository, IRepository<NoteBook> noteBookrepository)
        
        {
            _repository = repository;
            _noteBookrepository = noteBookrepository;
        }
        public List<Note> GetAllNotesInNoteBook(int noteBookId)
        {
            NoteBook noteBook = await _noteBookrepository.GetSingleAsync(noteBookId);
            return noteBook.Notes;

        }
        public async Task <Note> AddNoteToNoteBookAsync (int noteBookId, Note note)
            {
            note.NoteBookId = noteBookId;
            _noteBookrepository.AddAnEntityAsync(note);
            await _repository.Save();
            return note; 


        }



        public async Task<List<Note>> GetAllNotesAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Note> GetNoteAsync(int id)
        {
            return await _repository.GetSingleAsync(id);
        }


        public async Task AddNoteToDb(Note note)
        {
            await _repository.AddEntityAsync(note);

        }
        public async Task<int> DeleteNote(int id)
        {
            NoteService note = await _repository.GetSingleAsync(id);
            _repository.Delete(note);
            return await _repository.Save();

        }

        public async Task<int> UpdateNote(Note note)
        {
            _repository.UpdateN(note);
            return await _repository.Save();

        }

    }
}
