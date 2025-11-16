using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.ViewModels;
using System.Threading.Tasks;

namespace SportsStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager,
                                 SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: /Account/Login
        public ViewResult Login(string returnUrl)
        {
            return View(new LoginModel
            {
                ReturnUrl = returnUrl
            });
        }

        // POST: /Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await _userManager.FindByNameAsync(loginModel.Name);

                if (user != null)
                {
                    await _signInManager.SignOutAsync();
                    var result = await _signInManager.PasswordSignInAsync(user, loginModel.Password, false, false);

                    if (result.Succeeded)
                    {
                        // ✅ Kiểm tra Role để điều hướng đúng
                        if (await _userManager.IsInRoleAsync(user, "Admin"))
                        {
                            return Redirect(loginModel?.ReturnUrl ?? "/Admin");
                        }
                        else
                        {
                            // Không phải admin → logout ngay và báo lỗi
                            await _signInManager.SignOutAsync();
                            ModelState.AddModelError("", "Bạn không có quyền truy cập trang quản trị.");
                            return View(loginModel);
                        }
                    }

                }

                ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng.");
            }

            return View(loginModel);
        }

        // GET: /Account/Logout
        [Authorize]
        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await _signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }
    }
}
