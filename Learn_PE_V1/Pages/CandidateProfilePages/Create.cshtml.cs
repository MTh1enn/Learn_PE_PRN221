using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CandidateManagement_BusinessObjects;
using CandidateManagement_Repositories;

namespace Learn_PE_V1.Pages.CandidateProfilePages
{
    public class CreateModel : PageModel
    {
        private readonly ICandidateProfileRepo _candidateProfileRepo;
        private readonly IJobPostingRepo _jobPostingRepo;

        public CreateModel(ICandidateProfileRepo candidateProfileRepo, IJobPostingRepo jobPostingRepo)
        {
            _candidateProfileRepo = candidateProfileRepo;
            _jobPostingRepo = jobPostingRepo;
        }

        public IActionResult OnGet()
        {
        ViewData["PostingId"] = new SelectList(_jobPostingRepo.GetJobPostings(), "PostingId", "JobPostingTitle");
            return Page();
        }

        [BindProperty]
        public CandidateProfile CandidateProfile { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _candidateProfileRepo.GetCandidates == null || CandidateProfile == null)
            {
                return Page();
            }

            _candidateProfileRepo.AddCandidateProfile(CandidateProfile);

            return RedirectToPage("./Index");
        }
    }
}
