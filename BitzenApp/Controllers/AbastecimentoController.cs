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
    [Route("cadastro/abastecimento")]
    public class AbastecimentoController : Controller
    {
        [Route("obtertodosporusuario")]
        [HttpGet]
        public IActionResult ObterTodosPorUsuario()
        {
            string user = HttpContext.User.Claims.FirstOrDefault().Value;

            ConfigApi api = new ConfigApi();
            string url = api.UrlAPI + "abastecimento/obtertodosporusuario";
            using (HttpClient client = new HttpClient())
            {

                HttpResponseMessage response = client.PostAsync(url,
                new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json")).Result;

                string json = response.Content.ReadAsStringAsync().Result;
                List<Abastecimento> result = JsonConvert.DeserializeObject<List<Abastecimento>>(json);

                var jsettings = new JsonSerializerSettings();

                return Json(result, jsettings);

            }
        }


        [Route("obterTodosPosto")]
        [HttpGet]
        public async Task<IEnumerable<Posto>> ObterTodosPosto()
        {

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    ConfigApi api = new ConfigApi();
                    string url = api.UrlAPI + "abastecimento/obterTodosPosto";
                    var response = await client.GetStringAsync(url);
                    var marcas = JsonConvert.DeserializeObject<IEnumerable<Posto>>(response);
                    return marcas;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }

        }


        [Route("remover")]
        [HttpPost]
        public JsonResult Remover([FromBody] int codigo)
        {
            ConfigApi api = new ConfigApi();
            string url = api.UrlAPI + "abastecimento/remover";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.PostAsync(url,
                new StringContent(JsonConvert.SerializeObject(codigo), Encoding.UTF8, "application/json")).Result;

                string json = response.Content.ReadAsStringAsync().Result;
                int result = JsonConvert.DeserializeObject<int>(json);

                var jsettings = new JsonSerializerSettings();

                return Json(result, jsettings);
            }

        }

        [Route("adicionar")]
        [HttpPost]
        public JsonResult Adicionar([FromBody] Abastecimento abastecimento)
        {
            ConfigApi api = new ConfigApi();


            abastecimento.NCodUsuarioInc = HttpContext.User.Claims.FirstOrDefault().Value;
            string url = api.UrlAPI + "abastecimento/adicionar";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.PostAsync(url,
                new StringContent(JsonConvert.SerializeObject(abastecimento), Encoding.UTF8, "application/json")).Result;

                string json = response.Content.ReadAsStringAsync().Result;
                int result = JsonConvert.DeserializeObject<int>(json);

                var jsettings = new JsonSerializerSettings();

                return Json(result, jsettings);
            }

        }

        [Route("alterar")]
        [HttpPost]
        public JsonResult Alterar([FromBody] Abastecimento abastecimento)
        {
            ConfigApi api = new ConfigApi();
            string url = api.UrlAPI + "abastecimento/alterar";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.PostAsync(url,
                new StringContent(JsonConvert.SerializeObject(abastecimento), Encoding.UTF8, "application/json")).Result;

                string json = response.Content.ReadAsStringAsync().Result;
                int result = JsonConvert.DeserializeObject<int>(json);

                var jsettings = new JsonSerializerSettings();

                return Json(result, jsettings);
            }

        }

        [Route("obterporid/{id}")]
        [HttpGet]
        public JsonResult Obterporid(int id)
        {
            ConfigApi api = new ConfigApi();
            string url = api.UrlAPI + "abastecimento/obterporid";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.PostAsync(url,
                new StringContent(JsonConvert.SerializeObject(id), Encoding.UTF8, "application/json")).Result;

                string json = response.Content.ReadAsStringAsync().Result;
                Abastecimento result = JsonConvert.DeserializeObject<Abastecimento>(json);

                var jsettings = new JsonSerializerSettings();

                return Json(result, jsettings);
            }

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}