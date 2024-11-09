using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CandidateManagement_BusinessObjects;
using CandidateManagement_Repositories;

namespace Learn_PE_V1.Pages.CandidateProfilePages
{
    public class DeleteModel : PageModel
    {
        private readonly ICandidateProfileRepo _candidateProfileRepo;

        public DeleteModel(ICandidateProfileRepo candidateProfileRepo)
        {
            _candidateProfileRepo = candidateProfileRepo;
        }

        [BindProperty]
      public CandidateProfile CandidateProfile { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _candidateProfileRepo.GetCandidates() == null)
            {
                return NotFound();
            }

            var candidateprofile =  _candidateProfileRepo.GetCandidateProfileById(id);
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

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null || _candidateProfileRepo.GetCandidates == null)
            {
                return NotFound();
            }
            var candidateprofile = _candidateProfileRepo.GetCandidateProfileById(id);

            if (candidateprofile != null)
            {
                CandidateProfile = candidateprofile;
                _candidateProfileRepo.DeleteCandidateProfile(candidateprofile);
            }

            return RedirectToPage("./Index");
        }
    }
}
