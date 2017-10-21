using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Subway.ProvaTecnica.Models;

namespace Subway.ProvaTecnica.Controllers
{
    public class ComprasController : Controller
    {
        private readonly SubwayProvaTecnicaContext _context;

        public ComprasController(SubwayProvaTecnicaContext context)
        {
            _context = context;
        }

        // GET: Compras
        public async Task<IActionResult> Index(string produtoBusca)
        {
            var subwayProvaTecnicaContext = _context.Compras.Include(c => c.Conta);

            if (string.IsNullOrEmpty(produtoBusca))
                return View(await subwayProvaTecnicaContext.ToListAsync());
            else
                return View(await subwayProvaTecnicaContext.Where(compra => compra.Produtos.ToUpper().Contains(produtoBusca) || compra.Conta.Nome.ToUpper().Contains(produtoBusca)).ToListAsync());
        }

        // GET: Compras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compra = await _context.Compras
                .Include(c => c.Conta)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (compra == null)
            {
                return NotFound();
            }

            return View(compra);
        }

        // GET: Compras/Create
        public IActionResult Create()
        {
            ViewData["ContaId"] = new SelectList(_context.Contas, "ID", "Nome");
            return View();
        }

        // POST: Compras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ContaId,Produtos,Valor,Ativo")] Compra compra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(compra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContaId"] = new SelectList(_context.Contas, "ID", "Nome", compra.ContaId);
            return View(compra);
        }

        // GET: Compras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compra = await _context.Compras.SingleOrDefaultAsync(m => m.ID == id);
            if (compra == null)
            {
                return NotFound();
            }
            ViewData["ContaId"] = new SelectList(_context.Contas, "ID", "Nome", compra.ContaId);
            return View(compra);
        }

        // POST: Compras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ContaId,Produtos,Valor,Ativo")] Compra compra)
        {
            if (id != compra.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(compra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompraExists(compra.ID))
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
            ViewData["ContaId"] = new SelectList(_context.Contas, "ID", "Nome", compra.ContaId);
            return View(compra);
        }

        // GET: Compras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compra = await _context.Compras
                .Include(c => c.Conta)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (compra == null)
            {
                return NotFound();
            }

            return View(compra);
        }

        // POST: Compras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var compra = await _context.Compras.SingleOrDefaultAsync(m => m.ID == id);
            compra.Ativo = false;
            _context.Update(compra);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompraExists(int id)
        {
            return _context.Compras.Any(e => e.ID == id);
        }
    }
}
