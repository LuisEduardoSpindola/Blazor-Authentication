using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Presentation.Identity.Account;
using Microsoft.AspNetCore.Identity;
using InfraestructureLayer.Areas.Data;

namespace Presentation.Areas.Pages.Account
{
    public class RegisterModel : PageModel
    {

        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public RegisterModel(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [BindProperty]
        public User Input { get; set; }
        public string ReturnUrl { get; set; }
        public int AdmCode { get; set; }
        public string ConfirmPassword { get; set; }

        public void OnGet()
        {
            ReturnUrl = Url.Content("~/");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            ReturnUrl = Url.Content("~/");

            if (ModelState.IsValid)
            {
                if (AdmCode == 2280)
                {
                    Input.ADM = true;
                }

                if (ConfirmPassword != Input.Password)
                {
                    ModelState.AddModelError(string.Empty, "Senhas diferentes :( ");
                    return Page();
                }

                var identity = new User { UserName = Input.Name, Email = Input.Email, Period = Input.Period, ADM = Input.ADM };
                var result = await _userManager.CreateAsync(identity, Input.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(identity, isPersistent: false);
                    return LocalRedirect(ReturnUrl);
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return Page();
        }

    }
}
