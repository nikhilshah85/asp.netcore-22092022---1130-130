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
    public class accountsController : Controller
    {
        private readonly bankingMangementDBContext _context = new bankingMangementDBContext();

        //public accountsController(bankingMangementDBContext context)
        //{
        //    _context = context;
        //}

        // GET: accounts
        public async Task<IActionResult> Index()
        {
            var bankingMangementDBContext = _context.AccountsInfos.Include(a => a.AccBranchNavigation);
            return View(await bankingMangementDBContext.ToListAsync());
        }

        // GET: accounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AccountsInfos == null)
            {
                return NotFound();
            }

            var accountsInfo = await _context.AccountsInfos
                .Include(a => a.AccBranchNavigation)
                .FirstOrDefaultAsync(m => m.AccNo == id);
            if (accountsInfo == null)
            {
                return NotFound();
            }

            return View(accountsInfo);
        }

        // GET: accounts/Create
        public IActionResult Create()
        {
            ViewData["AccBranch"] = new SelectList(_context.BranchInfos, "BranchNo", "BranchNo");
            return View();
        }

        // POST: accounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccNo,AccName,AccType,AccBalance,AccBranch")] AccountsInfo accountsInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accountsInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccBranch"] = new SelectList(_context.BranchInfos, "BranchNo", "BranchNo", accountsInfo.AccBranch);
            return View(accountsInfo);
        }

        // GET: accounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AccountsInfos == null)
            {
                return NotFound();
            }

            var accountsInfo = await _context.AccountsInfos.FindAsync(id);
            if (accountsInfo == null)
            {
                return NotFound();
            }
            ViewData["AccBranch"] = new SelectList(_context.BranchInfos, "BranchNo", "BranchNo", accountsInfo.AccBranch);
            return View(accountsInfo);
        }

        // POST: accounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AccNo,AccName,AccType,AccBalance,AccBranch")] AccountsInfo accountsInfo)
        {
            if (id != accountsInfo.AccNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accountsInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountsInfoExists(accountsInfo.AccNo))
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
            ViewData["AccBranch"] = new SelectList(_context.BranchInfos, "BranchNo", "BranchNo", accountsInfo.AccBranch);
            return View(accountsInfo);
        }

        // GET: accounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AccountsInfos == null)
            {
                return NotFound();
            }

            var accountsInfo = await _context.AccountsInfos
                .Include(a => a.AccBranchNavigation)
                .FirstOrDefaultAsync(m => m.AccNo == id);
            if (accountsInfo == null)
            {
                return NotFound();
            }

            return View(accountsInfo);
        }

        // POST: accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AccountsInfos == null)
            {
                return Problem("Entity set 'bankingMangementDBContext.AccountsInfos'  is null.");
            }
            var accountsInfo = await _context.AccountsInfos.FindAsync(id);
            if (accountsInfo != null)
            {
                _context.AccountsInfos.Remove(accountsInfo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountsInfoExists(int id)
        {
          return _context.AccountsInfos.Any(e => e.AccNo == id);
        }
    }
}
