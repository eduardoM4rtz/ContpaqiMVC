using ContpaqiMVC.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace ContpaqiMVC.Controllers
{
    public class EmpleadoController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            var _empleados = await API.GetEmpleadosAsync();
            return View(_empleados);
            
        }

        public async Task<IActionResult> GetEmpleadosAsync()
        {
            var _empleados = await API.GetEmpleadosAsync();
            return View(_empleados);
        }

        [HttpPost]
        public async Task<IActionResult> IndexAsync(string Nombre, string RFC, string Estatus)
        {
            var _empleados = await API.GetEmpleadosAsync();
            if (!String.IsNullOrEmpty(Estatus) && Estatus != "0")
            {
                if(Estatus == "1")
                    _empleados = _empleados.Where(s => s.FechaBaja == null);
                else
                    _empleados = _empleados.Where(s => s.FechaBaja != null);
            }

            if (!String.IsNullOrEmpty(Nombre))
                _empleados = _empleados.Where(s => s.NombreCompleto!.Contains(Nombre));

            if (!String.IsNullOrEmpty(RFC))
                _empleados = _empleados.Where(s => s.RFC!.Contains(RFC));

            return View(_empleados);

        }

        [HttpGet]
        public async Task<IActionResult> FindAsync()
        {
           
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddAsync()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(EmpleadoAdd empleado)
        {
            if (ModelState.IsValid)
            {
                await API.AddEmpleadoAsync(empleado);
                return RedirectToAction(nameof(Index));
            }
            else
                return View();
        }


        [HttpGet]
        public async Task<IActionResult> UpdateAsync(int EmpleadoId)
        {
            var _empleado = await API.GetEmpleadoAsync(EmpleadoId);
            var jsonParent = JsonConvert.SerializeObject(_empleado);
            EmpleadoUpdate empup = JsonConvert.DeserializeObject<EmpleadoUpdate>(jsonParent);
            return View(empup);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAsync(EmpleadoUpdate empleado)
        {
            if (ModelState.IsValid)
            {
                await API.UpdateEmpleadoAsync(empleado);
                return RedirectToAction(nameof(Index));
            }
            else
                return View();
        }

        [HttpGet]
        public async Task<IActionResult> DeleteAsync(int EmpleadoId)
        {
            await API.DeleteEmpleadoAsync(EmpleadoId);
            return RedirectToAction(nameof(Index));
        }
    }

    class API
    {
        public static async Task<IEnumerable<Empleado>> GetEmpleadosAsync()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:59709/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            IEnumerable<Empleado> empleados = new List<Empleado>();
            HttpResponseMessage response = await client.GetAsync($"api/empleado");
            if (response.IsSuccessStatusCode)
            {
                empleados = await response.Content.ReadAsAsync<IEnumerable<Empleado>>();
            }
            return empleados;
        }

        public static async Task<Empleado> GetEmpleadoAsync(int EmpleadoId)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:59709/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            Empleado empleado = new Empleado();
            HttpResponseMessage response = await client.GetAsync($"api/empleado/{EmpleadoId}");
            if (response.IsSuccessStatusCode)
            {
                empleado = await response.Content.ReadAsAsync<Empleado>();
            }
            return empleado;
        }

        public static async Task<Uri> AddEmpleadoAsync(EmpleadoAdd empleado)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:59709/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            IEnumerable<Empleado> empleados = new List<Empleado>();
            HttpResponseMessage response = await client.PostAsJsonAsync($"api/empleado", empleado);
            if (response.IsSuccessStatusCode)
                return response.Headers.Location;
            else
                throw new Exception("Ocurrio un error");
        }

        public static async Task<Uri> UpdateEmpleadoAsync(EmpleadoUpdate empleado)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:59709/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            IEnumerable<Empleado> empleados = new List<Empleado>();
            HttpResponseMessage response = await client.PutAsJsonAsync($"api/empleado", empleado);
            if (response.IsSuccessStatusCode)
                return response.Headers.Location;
            else
                throw new Exception("Ocurrio un error");
        }

        public static async Task<Uri> DeleteEmpleadoAsync(int EmpleadoId)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:59709/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            IEnumerable<Empleado> empleados = new List<Empleado>();
            HttpResponseMessage response = await client.DeleteAsync($"api/empleado/{EmpleadoId}");
            if (response.IsSuccessStatusCode)
                return response.Headers.Location;
            else
                throw new Exception("Ocurrio un error");
        }

       
    }
    }
