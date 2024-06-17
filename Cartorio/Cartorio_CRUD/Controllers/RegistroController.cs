using Cartorio_CRUD.Data;
using Cartorio_CRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cartorio_CRUD.Controllers
{
    public class RegistroController : Controller
    {
        readonly private ApplicatonDbContext _db;
        public RegistroController(ApplicatonDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<RegistroModel> registros = _db.Registros;

            return View(registros);
        } //isso vai no banco e pega todos os registros

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            RegistroModel registro = _db.Registros.FirstOrDefault(x => x.Id == id);

            if (registro == null)
            {
                return NotFound();
            }

            return View(registro);
        }

        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            RegistroModel registro = _db.Registros.FirstOrDefault(x => x.Id == id);

            if (registro == null)
            {
                return NotFound();
            }

            return View(registro);
        }

        [HttpPost]
        public IActionResult Cadastrar(RegistroModel registros) 
        {
            if (ModelState.IsValid)
            {
                _db.Registros.Add(registros);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Editar(RegistroModel registro)
        {
            if(ModelState.IsValid)
            {
                _db.Registros.Update(registro);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(registro);
        }

        [HttpPost]
        public IActionResult Excluir(RegistroModel registro)
        {
            if(registro == null)
            {
                return NotFound();
            }

            _db.Registros.Remove(registro);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
