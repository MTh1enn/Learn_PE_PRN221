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
    public class IndexModel : PageModel
    {
        private readonly ICandidateProfileRepo _candidateProfileRepo;

        public IndexModel(ICandidateProfileRepo candidateProfileRepo)
        {
            _candidateProfileRepo = candidateProfileRepo;
        }

        public IList<CandidateProfile> CandidateProfile { get;set; } = default!;

        public IActionResult OnGet()
        {
            CandidateProfile = _candidateProfileRepo.GetCandidates(); // Set the property
            return Page(); // Return the page to display the results
        }
    }
}
