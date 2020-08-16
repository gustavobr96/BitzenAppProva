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
    [Route("cadastro/veiculo")]
    public class VeiculoController : Controller
    {
        [Route("obtertodosporusuario")]
        [HttpGet]
        public IActionResult ObterTodosPorUsuario()
        {
            string user = HttpContext.User.Claims.FirstOrDefault().Value;
           
            ConfigApi api = new ConfigApi();
            string url = api.UrlAPI + "veiculo/listarContratosPendente";
            using (HttpClient client = new HttpClient())
            {

                HttpResponseMessage response = client.PostAsync(url,
                new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json")).Result;

                string json = response.Content.ReadAsStringAsync().Result;
                List<Veiculo> result = JsonConvert.DeserializeObject<List<Veiculo>>(json);

                var jsettings = new JsonSerializerSettings();

                return Json(result, jsettings);

            }
        }


        [Route("remover")]
        [HttpPost]
        public JsonResult Remover([FromBody] int codigo)
        {
            ConfigApi api = new ConfigApi();
            string url = api.UrlAPI + "veiculo/remover";
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


        [Route("obterTodasMarca")]
        [HttpGet]
        public async Task<IEnumerable<Marca>> ObterTodasMarca()
        {

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    ConfigApi api = new ConfigApi();
                    string url = api.UrlAPI + "veiculo/obterTodasMarca";
                    var response = await client.GetStringAsync(url);
                    var marcas = JsonConvert.DeserializeObject<IEnumerable<Marca>>(response);
                    return marcas;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }

        }

        [Route("obterTodosModeloxMarca/{codMarca}")]
        [HttpGet]
        public async Task<IEnumerable<Modelo>> ObterTodosModeloxMarca(int codMarca)
        {
            ConfigApi api = new ConfigApi();
            string url = api.UrlAPI + "veiculo/obterTodosModeloxMarca";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.PostAsync(url,
                    new StringContent(JsonConvert.SerializeObject(codMarca), Encoding.UTF8, "application/json"));

                string json = response.Content.ReadAsStringAsync().Result;
                IEnumerable<Modelo> modelos = JsonConvert.DeserializeObject<IEnumerable<Modelo>>(json);

                return modelos;
            }


        }
        [Route("obterTodosTipoVeiculo")]
        [HttpGet]
        public async Task<IEnumerable<TipoVeiculo>> ObterTodosTipoVeiculo()
        {

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    ConfigApi api = new ConfigApi();
                    string url = api.UrlAPI + "veiculo/obterTodosTipoVeiculo";
                    var response = await client.GetStringAsync(url);
                    var tipoVeiculos = JsonConvert.DeserializeObject<IEnumerable<TipoVeiculo>>(response);
                    return tipoVeiculos;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }

        }

        [Route("obterTodosTipoCombustivel")]
        [HttpGet]
        public async Task<IEnumerable<TipoCombustivel>> ObterTodosTipoCombustivel()
        {

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    ConfigApi api = new ConfigApi();
                    string url = api.UrlAPI + "veiculo/obterTodosTipoCombustivel";
                    var response = await client.GetStringAsync(url);
                    var tipoCombustivel = JsonConvert.DeserializeObject<IEnumerable<TipoCombustivel>>(response);
                    return tipoCombustivel;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }

        }

        [Route("adicionar")]
        [HttpPost]
        public JsonResult Adicionar([FromBody] Veiculo veiculo)
        {
            ConfigApi api = new ConfigApi();
     

            veiculo.NCodUsuarioResp = HttpContext.User.Claims.FirstOrDefault().Value;
            string url = api.UrlAPI + "veiculo/adicionar";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.PostAsync(url,
                new StringContent(JsonConvert.SerializeObject(veiculo), Encoding.UTF8, "application/json")).Result;

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
            string url = api.UrlAPI + "veiculo/obterporid";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.PostAsync(url,
                new StringContent(JsonConvert.SerializeObject(id), Encoding.UTF8, "application/json")).Result;

                string json = response.Content.ReadAsStringAsync().Result;
                Veiculo result = JsonConvert.DeserializeObject<Veiculo>(json);

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