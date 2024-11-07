using CandidateManagement_BusinessObjects;
using CandidateManagement_Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Learn_PE_V1.Pages.Login
{
    public class LoginModel : PageModel
    {
        private IHRAccountService _hrAccountService;
        public LoginModel(IHRAccountService hrAccountService)
        {
            _hrAccountService = hrAccountService;
        }
        public void OnGet()
        {
        }

        public void OnPost()
        {
            string? email = Request.Form["txtEmail"];
            string? password = Request.Form["txtPassword"];
            if (email != null && password != null)
            {
                Hraccount account = _hrAccountService.GetHraccountByEmail(email);
                if (account != null && account.Password.Equals(password))
                {
                    string? RoleID = account.MemberRole.ToString() ?? "";
                    HttpContext.Session.SetString("RoleId", RoleID);
                    Response.Redirect("/Index");
                }
                else
                {
                    Response.Redirect("/Error");
                }
            }
        }
    }
}
