using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CandidateManagement_BusinessObjects;

namespace Learn_PE_V1.Pages.CandidateProfilePages
{
    public class CreateModel : PageModel
    {
        private readonly CandidateManagement_BusinessObjects.CandidateManagementContext _context;

        public CreateModel(CandidateManagement_BusinessObjects.CandidateManagementContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["PostingId"] = new SelectList(_context.JobPostings, "PostingId", "PostingId");
            return Page();
        }

        [BindProperty]
        public CandidateProfile CandidateProfile { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.CandidateProfiles == null || CandidateProfile == null)
            {
                return Page();
            }

            _context.CandidateProfiles.Add(CandidateProfile);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
