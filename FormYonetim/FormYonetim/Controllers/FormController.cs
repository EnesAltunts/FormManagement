using DataAccess;
using Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormYonetim.Controllers
{
    [Authorize]
    public class FormController : Controller
    {
        Repository _repository;
        public FormController()
        {
            _repository = new Repository();
        }

        [Route("/Forms/{formId?}")]
        public IActionResult Index(string ara)
        {
            List<Forms> formList = _repository.FormList();

            if (!string.IsNullOrEmpty(ara))
            {
                formList = formList.Where(x=>x.FormName.Contains(ara)).ToList();
            }
            return View(formList);
        }

        [HttpPost]
        [Route("AddForm")]
        public IActionResult AddFormaction(Forms form)
        {

            if (!ModelState.IsValid)
            {
                TempData["register"] = "Kayıt işlemi başarısız!";
                return RedirectToAction("Index");
            }
            string username = HttpContext.User.Identity.Name;

            _repository.AddForm(form,username);
            TempData["register"] = "Kayıt işlemi başarılı";
            return RedirectToAction("Index");
        }


    }
}
