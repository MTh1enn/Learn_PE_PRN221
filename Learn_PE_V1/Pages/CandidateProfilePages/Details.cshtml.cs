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
    public class DetailsModel : PageModel
    {
        private readonly ICandidateProfileRepo _candidateProfile;

        public DetailsModel(ICandidateProfileRepo candidateProfile)
        {
            _candidateProfile = candidateProfile;
        }

      public CandidateProfile CandidateProfile { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null || _candidateProfile.GetCandidates() == null)
            {
                return NotFound();
            }

            var candidateprofile = _candidateProfile.GetCandidateProfileById(id);
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
