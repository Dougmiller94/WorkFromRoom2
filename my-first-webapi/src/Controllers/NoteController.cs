using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using src.Data;
using src.Dto;
using src.Persistance.Models;
using src.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace src.Controllers
{
    [ApiController]
    [Route("/note")]
    public class NoteController : ControllerBase
    {

        
        private readonly IMapper _mapper;
        private readonly ILogger<NoteController> _logger;
        private readonly NoteService _noteService;
            

        public NoteController(ILogger<NoteController> logger, IMapper mapper, NoteService noteService)
        {
            _logger = logger;
            _mapper = mapper;
            _noteService = noteService;
        }

        [HttpPost] /*- Dto*/

        public async Task PostAsync([FromBody] NoteTextDto noteDto)
        {
            Note note = _mapper.Map<Note>(noteDto);
            await _noteService.AddNoteToDb(note);
        }

        //[HttpPost] /*- normal*/
        //[Route("withoutAutomapper")]

        //public async Task<int> Posty([FromBody] NoteDtoWithoutId noteDto)
        //{
        //    Note note = new Note();
        //    note.Text = noteDto.Text;
        //    _noteService.Note.Add(note);
        //    return await _context.SaveChangesAsync();

        //}

        [HttpPost] /*- normal*/
        [Route("postingEntity")]
        public async Task Posty([FromBody] Note note)
        {
            await _noteService.AddNoteToDb(note);
      
        }

       
        [HttpGet]  /*- Dto*/
        [Route("{id}")]
        public async Task<NoteWithoutNoteBookDto> Getasyncy([FromRoute]int id)
        {
            Note note = await _noteService.GetNoteAsync(id);
            return _mapper.Map<NoteWithoutNoteBookDto>(note);
        }

        [HttpGet]  /*- Dto*/
        [Route("/note")]

        public class 



        [HttpPut]
        public async Task<int> Putty([FromBody] NoteWithoutNoteBookDto noteDto)
        {
            Note note = _mapper.Map<Note>(noteDto);
            return await _noteService.UpdateNote(note);
        }



        [HttpDelete] /*- normal*/
        [Route("{id}")]

        public async Task<int> DeleteAsync([FromRoute]int id)
        {

            return await _noteService.DeleteNote(id);
        }









        //[HttpGet] /*- normal*/
        //[Route("{id}")]
        //public async Task<Note> Getasync([FromRoute]int id)
        //{
        //    return await _context.Note.FindAsync(id);
        //}





        //[HttpPut]  /*- normal*/

        //public async Task<Note> Putty([FromBody] Note note)
        //{
        //    Note found = await _context.Note.FindAsync(note.Id);
        //    found.Text = note.Text;
        //    await _context.SaveChangesAsync();
        //    return found;           
        //}



        //[HttpPut]

        // public async Task<Note> Putnote([FromBody] Note note3)
        // {
        //     Note entity = await _context.Note.FindAsync(note3.Id);
        //     _context.Note.Update(note3);
        //     await _context.SaveChangesAsync();
        //     return note3;

        // }















    }












}