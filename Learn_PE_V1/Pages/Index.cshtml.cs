using CandidateManagement_BusinessObjects;
using CandidateManagement_Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Learn_PE_V1.Pages
{
    public class IndexModel : PageModel
    {
        private IHRAccountRepo _hRAccountRepo;
        public IndexModel(IHRAccountRepo hRAccountRepo)
        {
            _hRAccountRepo = hRAccountRepo;
        }
        [BindProperty]
        public string? Message { get; set; }
        public void OnGet()
        {
            Message = null;
        }

        public void OnPost()
        {
            string? email = Request.Form["txtEmail"];
            string? password = Request.Form["txtPassword"];
            if (email != null && password != null)
            {
                Hraccount account = _hRAccountRepo.GetHraccountByEmail(email);
                if (account != null && account.Password.Equals(password) && account.MemberRole == 1)
                {
                    string? RoleID = account.MemberRole.ToString() ?? "";
                    HttpContext.Session.SetString("RoleId", RoleID);
                    Response.Redirect("/CandidateProfilePages/Index");
                }
                else
                {
                    Message = "You are not allowed to do this function!";
                }
            }
        }
    }
}

