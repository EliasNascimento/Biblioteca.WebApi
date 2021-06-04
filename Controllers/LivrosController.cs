using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Biblioteca.WebAPI.Models;
using Biblioteca.WebAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Biblioteca.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivrosController : ControllerBase
    {
        private readonly ILogger<LivrosController> _logger;
        private readonly LivroRepository _livroRepository;

        public LivrosController(ILogger<LivrosController> logger, LivroRepository livroRepository)
        {
            _logger = logger;
            _livroRepository = livroRepository;
        }

        // GET: Livro
        [HttpGet]
        public ActionResult<IEnumerable<Livro>> GetLivros()
        {

            var livros = _livroRepository.GetLivros();

            return Ok(livros);

        }

        // GET: Livro/Edit/5
        [HttpGet("{id}")]
        public ActionResult<Livro> GetLivroByEdit(int id)
        {
            var livroItem = _livroRepository.GetLivroById(id);
            return Ok(livroItem);
        }


        //POST: Livro/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult CreateLivro(Livro livro)
        {

            _livroRepository.CreateLivro(livro);

            return Ok(livro);

        }


        [HttpPut("{id}")]
        public ActionResult UpdateLivro(int id, Livro livro)
        {
            var livroFromRepo = _livroRepository.GetLivroById(id);

            if(livroFromRepo == null)
            {
                return NotFound();
            }

            livroFromRepo.Codigo = livro.Codigo;
            livroFromRepo.Nome = livro.Nome;
            livroFromRepo.Autor = livro.Autor;
            livroFromRepo.ISBN = livro.ISBN;
            livroFromRepo.AnoLancamento = livro.AnoLancamento;

           _livroRepository.UpdateLivro(livroFromRepo);

            return NoContent();
        }

        // POST: Livro/Delete/5
        [HttpDelete("{id}")]
        public ActionResult DeleteLivro(int id)
        {
            var livroFromRepo = _livroRepository.GetLivroById(id);

            if (livroFromRepo == null)
            {
                return NotFound();
            }

            _livroRepository.DeleteLivro(livroFromRepo);

            return Ok();
        }


    }
}