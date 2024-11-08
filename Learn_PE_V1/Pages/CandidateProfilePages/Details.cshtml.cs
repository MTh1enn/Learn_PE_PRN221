using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CandidateManagement_BusinessObjects;

namespace Learn_PE_V1.Pages.CandidateProfilePages
{
    public class DetailsModel : PageModel
    {
        private readonly CandidateManagement_BusinessObjects.CandidateManagementContext _context;

        public DetailsModel(CandidateManagement_BusinessObjects.CandidateManagementContext context)
        {
            _context = context;
        }

      public CandidateProfile CandidateProfile { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _context.CandidateProfiles == null)
            {
                return NotFound();
            }

            var candidateprofile = await _context.CandidateProfiles.FirstOrDefaultAsync(m => m.CandidateId == id);
            if (candidateprofile == null)
            {
                return NotFound();
            }
            else 
            {
                CandidateProfile = candidateprofile;
            }
            return Page();
        }
    }
}
