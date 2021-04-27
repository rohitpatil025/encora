using EncoraApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EncoraApp.Controllers
{
    //Authorize keyword make sure that only authenticated user will access it
    //If any annonymous user tries to access it redirects to login page, setting in web config file
    [Authorize]
    public class NotesController : Controller
    {

        public ActionResult Index()
        {
            entity.encoraEntities entity = new entity.encoraEntities();

            //All notes records are taken here 
            var data = entity.notes;
            return View(data.ToList());

        }


        [HttpGet]
        public ActionResult Add(int? id)
        {
            //if id has value then make edit the record
            if (id.HasValue)
            {
                entity.encoraEntities context = new entity.encoraEntities();

                var data = context.notes.Where(x => x.id == id).FirstOrDefault();

                return View(new NotesModel()
                {
                    ID = data.id,
                    Created = data.created,
                    Modified = data.modified,
                    Description = data.description,
                    isArchived = data.isArchived.Value,
                    UserID = data.userID
                });
            }
            return View();
        }

        [HttpPost]
        public ActionResult Add(NotesModel model)
        {
            //if model contains value for ID then edit record or create new record 
            using (entity.encoraEntities context = new entity.encoraEntities())
            {
                entity.note note = null;
                if (model.ID > 0)
                {
                    note = context.notes.Where(o => o.id == model.ID).FirstOrDefault();
                    note.description = model.Description;
                    note.isArchived = model.isArchived;
                    note.modified = DateTime.Now;
                    ViewBag.Message = "Data updated successfully";
                }
                else
                {
                    note = context.notes.Create();

                    note.description = model.Description;
                    note.userID = Convert.ToInt32(Session["UserID"]);
                    note.created = DateTime.Now;
                    note.modified = DateTime.Now;
                    note.isArchived = model.isArchived;
                    context.notes.Add(note);
                    ViewBag.Message = "Data insert successfully";
                }

                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            entity.encoraEntities context = new entity.encoraEntities();

            var data = context.notes.Where(x => x.id == id).FirstOrDefault();
            context.notes.Remove(data);
            context.SaveChanges();

            ViewBag.Messsage = "Record delete successfully";
            return RedirectToAction("Index");
        }

        //Excption handling, any unhandled exception will be catched and redircted to erro page
        protected override void OnException(ExceptionContext filterContext)
        {
            string action = filterContext.RouteData.Values["action"].ToString();
            Exception e = filterContext.Exception;
            filterContext.ExceptionHandled = true;
            filterContext.Result = new ViewResult()
            {
                ViewName = "Error"
            };
            filterContext.ExceptionHandled = true;
            
        }
    }
}