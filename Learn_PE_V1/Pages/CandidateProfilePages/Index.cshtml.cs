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
        public int PageSize { get; set; } = 3;
        public int CurrentPage { get; set; } = 1;
        public int TotalPages { get; set; }

        public IActionResult OnGet(int? pageIndex)
        {
            var allCandidates = _candidateProfileRepo.GetCandidates();
            CurrentPage = pageIndex ?? 1;

            TotalPages = (int)Math.Ceiling((double)allCandidates.Count / PageSize);
            CandidateProfile = allCandidates

           .Skip((CurrentPage - 1) * PageSize)
           .Take(PageSize)
           .ToList();

            return Page(); 
        }
    }
}
