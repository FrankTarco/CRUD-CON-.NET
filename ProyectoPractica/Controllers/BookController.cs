using ProyectoPractica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoPractica.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            using (DbModels context = new DbModels())
            {
                return View(context.BOOK.ToList());
            }

            
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            using (DbModels context = new DbModels())
            {
                return View(context.BOOK.Where(x => x.idBook == id));
            }

        }

        // GET: Book/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(BOOK obj)
        {
            try
            {
               using(DbModels context = new DbModels())
                {
                    context.BOOK.Add(obj);
                    context.SaveChanges();
                }

                return RedirectToAction("index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            using (DbModels context = new DbModels()) { 
            
                return View(context.BOOK.Where(x => x.idBook == id).FirstOrDefault());

            }
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, BOOK obj)
        {
            try
            {
                using(DbModels contexT = new DbModels())
                {
                    contexT.Entry(obj).State = System.Data.EntityState.Modified;
                    contexT.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            using (DbModels context = new DbModels())
            {

                return View(context.BOOK.Where(x => x.idBook == id).FirstOrDefault());

            }
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, BOOK obj)
        {
            try
            {
                using (DbModels context = new DbModels())
                {
                    BOOK objeto = context.BOOK.Where(x => x.idBook == id).FirstOrDefault();
                    context.BOOK.Remove(objeto);
                    context.SaveChanges();
                }
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
