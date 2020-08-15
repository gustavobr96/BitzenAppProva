using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BitzenApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BitzenApp.Controllers
{
    [Route("auth")]
    public class AuthController : Controller
    {
        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }
    
        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(Usuario model)
        {
            // validando dados de entrada
            if (model.CEmail == null || model.CSenha == null)
            {
                ModelState.AddModelError(string.Empty, "Usuario e senha são campos obrigatórios!");
                return View(model);
            }

            Usuario user = new Usuario();
            user.CEmail = model.CEmail.Trim();
            user.CSenha = model.CSenha.Trim();

            ConfigApi api = new ConfigApi();
            string url = api.UrlAPI + "auth/login";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.PostAsync(url,
                new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json")).Result;

                string json = response.Content.ReadAsStringAsync().Result;
                Usuario u = JsonConvert.DeserializeObject<Usuario>(json);

                await HttpContext.SignOutAsync();

                if (u == null)
                {
                    ModelState.AddModelError(string.Empty, "Usuario ou senha invalido(s)");
                    return View(model);
                }

                return await SignInAsync(u);
            }

        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        private async Task<IActionResult> SignInAsync(Usuario usuario)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.NCodUsuario),
                new Claim(ClaimTypes.Name, usuario.CNome)
            };

            if (usuario != null)
            {

                var identity = new ClaimsIdentity(claims, "login");
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(principal);

                return RedirectToAction("Index", "Home");

            }
            else
            {
                return await Logout();
            }


        }

    }
}