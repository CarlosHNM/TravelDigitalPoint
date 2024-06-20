using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TravelDigiatlPoint.Models;
using TravelDigiatlPoint.ViewModels;
using System.Threading.Tasks;
using TravelDigiatlPoint.Context;
using Microsoft.AspNetCore.Authorization;

namespace TravelDigiatlPoint.Controllers
{
    [Authorize(Roles = "Admin")]
    public class FuncionariosController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppDbContext _context;

        public FuncionariosController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var funcionario = new Funcionario
                {
                    NumeroDeCracha = model.NumeroDeCracha,
                    Pis = model.Pis,
                    Endereco = model.Endereco,
                    Complemento = model.Complemento,
                    Cidade = model.Cidade,
                    Estado = model.Estado,
                    CPF = model.CPF,
                    Nome = model.Nome,
                    Cargo = model.Cargo
                };

                _context.Funcionarios.Add(funcionario);
                await _context.SaveChangesAsync();

                var user = new IdentityUser
                {
                    UserName = model.Email,
                    Email = model.Email
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    // Assign a role if needed
                    if (!await _roleManager.RoleExistsAsync("Employee"))
                    {
                        var role = new IdentityRole("Employee");
                        await _roleManager.CreateAsync(role);
                    }

                    await _userManager.AddToRoleAsync(user, "Employee");

                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }
    }
}

