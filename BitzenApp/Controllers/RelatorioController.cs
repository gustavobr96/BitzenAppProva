using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BitzenApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BitzenApp.Controllers
{
    [Route("cadastro/relatorio")]
    public class RelatorioController : Controller
    {
        [Route("abastecimento/ObterRelatorioPorUsuarioTipos/{tipo}")]
        [HttpGet]
        public IActionResult ObterRelatorioPorUsuarioTipos(int tipo)
        {
            Relatorio r = new Relatorio();
            r.usuario = HttpContext.User.Claims.FirstOrDefault().Value;
            r.Tipo = tipo;

            ConfigApi api = new ConfigApi();
            string url = api.UrlAPI + "relatorio/obterrelatorioporusuariotipos";
            using (HttpClient client = new HttpClient())
            {

                HttpResponseMessage response = client.PostAsync(url,
                new StringContent(JsonConvert.SerializeObject(r), Encoding.UTF8, "application/json")).Result;

                string json = response.Content.ReadAsStringAsync().Result;
                Relatorio result = JsonConvert.DeserializeObject<Relatorio>(json);

                var jsettings = new JsonSerializerSettings();

                return Json(result, jsettings);

            }
        }
        [Route("pagamento/ObterRelatorioPorUsuarioTipos/{tipo}")]
        [HttpGet]
        public IActionResult ObterRelatorioPorUsuarioTiposAbastecimento(int tipo)
        {
            Relatorio r = new Relatorio();
            r.usuario = HttpContext.User.Claims.FirstOrDefault().Value;
            r.Tipo = tipo;

            ConfigApi api = new ConfigApi();
            string url = api.UrlAPI + "relatorio/obterrelatorioporusuariotipos";
            using (HttpClient client = new HttpClient())
            {

                HttpResponseMessage response = client.PostAsync(url,
                new StringContent(JsonConvert.SerializeObject(r), Encoding.UTF8, "application/json")).Result;

                string json = response.Content.ReadAsStringAsync().Result;
                Relatorio result = JsonConvert.DeserializeObject<Relatorio>(json);

                var jsettings = new JsonSerializerSettings();

                return Json(result, jsettings);

            }
        }

        [Route("pagamento")]
        public IActionResult Pagamento()
        {
            return View("Pagamento");
        }
        [Route("abastecimento")]
        public IActionResult Abastecimento()
        {
            return View("Abastecimento");
        }
    }
}