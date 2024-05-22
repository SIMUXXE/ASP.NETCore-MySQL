using ASP.NETCore_MySQL.Models;
using Microsoft.AspNetCore.Mvc;
using Progetto_Tipsit___Gestione_Persona.Models;
using System.Diagnostics;

namespace Progetto_Tipsit___Gestione_Persona.Controllers
{
    public class HomeController : Controller
    {
        DAO DAO = new DAO();
        public IActionResult Index()
        {
            return View(DAO.Read());
        }

        [Route("Delete/{id}")]
        public IActionResult DeletePerson(int id)
        {
            if (DAO.Delete(id))
                return RedirectToAction("Index");
            else
                return RedirectToAction("Error");

        }

        public IActionResult FormInsert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPerson(Person data)
        {
            DAO.Create(data);
            return RedirectToAction("Index");
        }

        [Route("Update/{PersonaId}")]
        public IActionResult UpdateForm(int PersonaId)
        {
            UpdateModel x = new UpdateModel();
            x.PId = PersonaId;
            return RedirectToAction("FormUpdate", "Home", x);
        }
        public IActionResult EditPerson(UpdateModel a)
        {
            DAO.Update(a);
            return RedirectToAction("Index");
        }
        public IActionResult FormUpdate(UpdateModel a)
        {
            return View(a);

        }

        [Route("ConfirmDelete/{PersonaId}")]
        public IActionResult ConfirmDelete(int PersonaId)
        {
            return View(new DeleteModel(PersonaId));
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
