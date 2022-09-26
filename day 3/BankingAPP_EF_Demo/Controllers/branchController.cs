using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BankingAPP_EF_Demo.Models.EF;

namespace BankingAPP_EF_Demo.Controllers
{
    public class branchController : Controller
    {
        private readonly bankingMangementDBContext _context = new bankingMangementDBContext();

        //public branchController(bankingMangementDBContext context)
        //{
        //    _context = context;
        //}

        // GET: branch
        public async Task<IActionResult> Index()
        {
              return View(await _context.BranchInfos.ToListAsync());
        }

        // GET: branch/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BranchInfos == null)
            {
                return NotFound();
            }

            var branchInfo = await _context.BranchInfos
                .FirstOrDefaultAsync(m => m.BranchNo == id);
            if (branchInfo == null)
            {
                return NotFound();
            }

            return View(branchInfo);
        }

        // GET: branch/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: branch/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BranchNo,BranchName,BranchCity")] BranchInfo branchInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(branchInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(branchInfo);
        }

        // GET: branch/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BranchInfos == null)
            {
                return NotFound();
            }

            var branchInfo = await _context.BranchInfos.FindAsync(id);
            if (branchInfo == null)
            {
                return NotFound();
            }
            return View(branchInfo);
        }

        // POST: branch/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BranchNo,BranchName,BranchCity")] BranchInfo branchInfo)
        {
            if (id != branchInfo.BranchNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(branchInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BranchInfoExists(branchInfo.BranchNo))
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
            return View(branchInfo);
        }

        // GET: branch/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BranchInfos == null)
            {
                return NotFound();
            }

            var branchInfo = await _context.BranchInfos
                .FirstOrDefaultAsync(m => m.BranchNo == id);
            if (branchInfo == null)
            {
                return NotFound();
            }

            return View(branchInfo);
        }

        // POST: branch/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BranchInfos == null)
            {
                return Problem("Entity set 'bankingMangementDBContext.BranchInfos'  is null.");
            }
            var branchInfo = await _context.BranchInfos.FindAsync(id);
            if (branchInfo != null)
            {
                _context.BranchInfos.Remove(branchInfo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BranchInfoExists(int id)
        {
          return _context.BranchInfos.Any(e => e.BranchNo == id);
        }
    }
}
