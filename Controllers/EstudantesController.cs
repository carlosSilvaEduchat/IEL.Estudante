using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IEL.Estudantes.Data;
using IEL.Estudantes.Models;
using IEL.Estudantes.Services;

namespace IEL.Estudantes.Controllers
{
    public class EstudantesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ICpfService _cpfService;

        public EstudantesController(AppDbContext context, ICpfService cpfService)
        {
            _context = context;
            _cpfService = cpfService;
        }

        [AcceptVerbs("GET", "POST")]
        public async Task<IActionResult> VerifyCpf(string cpf, int id = 0)
        {
            var exists = await _cpfService.CpfExistsAsync(cpf, id == 0 ? null : id);
            return Json(!exists);
        }

        // GET: Estudantes
        public async Task<IActionResult> Index(string searchString)
        {
            var estudantes = from e in _context.Estudantes
                           select e;

            if (!string.IsNullOrEmpty(searchString))
            {
                string cpfSemMascara = searchString.Replace(".", "").Replace("-", "").ToLower();
                string searchLower = searchString.ToLower();

                estudantes = estudantes.Where(e =>
                    e.Nome.ToLower().Contains(searchLower) ||
                    e.CPF.Replace(".", "").Replace("-", "").Contains(cpfSemMascara) ||
                    e.CPF.Contains(searchLower)
                );
            }

            return View(await estudantes.ToListAsync());
        }

        // GET: Estudantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudante = await _context.Estudantes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estudante == null)
            {
                return NotFound();
            }

            return View(estudante);
        }

        // GET: Estudantes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Estudantes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,CPF,Endereco,DataConclusao")] Estudante estudante)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estudante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estudante);
        }

        // GET: Estudantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudante = await _context.Estudantes.FindAsync(id);
            if (estudante == null)
            {
                return NotFound();
            }
            return View(estudante);
        }

        // POST: Estudantes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,CPF,Endereco,DataConclusao")] Estudante estudante)
        {
            if (id != estudante.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estudante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstudanteExists(estudante.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(estudante);
        }

        // GET: Estudantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudante = await _context.Estudantes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estudante == null)
            {
                return NotFound();
            }

            return View(estudante);
        }

        // POST: Estudantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estudante = await _context.Estudantes.FindAsync(id);
            if (estudante != null)
            {
                _context.Estudantes.Remove(estudante);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool EstudanteExists(int id)
        {
            return _context.Estudantes.Any(e => e.Id == id);
        }
    }
}