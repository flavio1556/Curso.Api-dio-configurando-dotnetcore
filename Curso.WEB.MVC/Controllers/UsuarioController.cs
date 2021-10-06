using Curso.WEB.MVC.Models.Usuario;
using Curso.WEB.MVC.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Curso.WEB.MVC.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;
    
        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
          
        }
        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Cadastrar(CadastrarUsuarioViewModelInput registrarUsuarioViewModelInput)
        {
            try
            {

             var usuario = await  _usuarioService.Cadastrar(registrarUsuarioViewModelInput);

                ModelState.AddModelError("", $"os dados foram cadastrado com Sucesso {usuario.Login}");
            }
            catch(ApiException ex)
            {
                ModelState.AddModelError(" ", ex.Message);
            }
            catch(Exception e)
            {
                throw e;
            }
            //HttpClientHandler clientHandler = new HttpClientHandler();
            //clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            //var client = new HttpClient(clientHandler);
            //client.BaseAddress = new Uri("https://localhost:5001/");
            //var jsonInput = JsonConvert.SerializeObject(registrarUsuarioViewModelInput);
            //StringContent httContent = new StringContent(jsonInput, Encoding.UTF8, "application/json");
           
         
            //var httpPost =  client.PostAsync("/api/v1/Usuario/Registrar", httContent).GetAwaiter().GetResult();
            //if(httpPost.StatusCode == HttpStatusCode.Created)
            //{
            //   ModelState.AddModelError("","os dados foram cadastrado com Sucesso");
            //    return View(ModelState);
            //}
            //else
            //{
            //    ModelState.AddModelError(" ",httpPost.StatusCode.ToString());
            //    return View(ModelState);
            //}
            return View();
        }
        public IActionResult Logar()
        {
           

            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Logar(LoginUsuarioViewModelInput loginUsuarioViewModelInput)
        {
            try
            {
                var login = await _usuarioService.Login(loginUsuarioViewModelInput);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier,login.Usuario.Codigo.ToString()),
                    new Claim(ClaimTypes.Name, login.Usuario.Login),
                     new Claim(ClaimTypes.Email, login.Usuario.Email),
                      new Claim("token", login.Token),
                };
                var ClaimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    ExpiresUtc = new DateTimeOffset(DateTime.UtcNow.AddDays(1))
                };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(ClaimsIdentity));

                ModelState.AddModelError(" ", $"O usario estar autenticado {login.Usuario.Login}");
            }
            catch (ApiException ex)
            {
                ModelState.AddModelError(" ", ex.Message);
            }
            catch (Exception e)
            {
                throw e;
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logoff()
        {


            return View();
        }

        [HttpPost]
        public async  Task<IActionResult> LogoffPost()
        {          
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction($"{nameof(Logar)}");
        }
    }
} 
