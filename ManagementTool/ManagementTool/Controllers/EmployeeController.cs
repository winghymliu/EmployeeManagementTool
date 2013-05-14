using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ManagementTool.Models;

namespace ManagementTool.Controllers
{
    [HandleError]
    public class EmployeeController : Controller
    {
        private readonly CompanyDBContext _db;

        public EmployeeController(CompanyDBContext db)
        {
            _db = db;
        }

        private List<Team> GetTeams()
        {
            return _db.Teams!=null ? _db.Teams.ToList() : null;
        }

        private bool NoTeams()
        {
            if (GetTeams() == null || !GetTeams().Any())
                return true;
            return false;
        }

        private Employee FindEmployee(int id)
        {
            if (id < 0)
            {
                return null;
            }

            return _db.Employees.Find(id);
        }
        
        //
        // GET: /Employee/

        public ActionResult Index()
        {
            
            ViewBag.NoTeams = NoTeams();
            return View(_db.Employees.ToList());
        }
                
        //
        // GET: /Employee/Details/5

        public ActionResult Details(int id =-1)
        {
            Employee employee = FindEmployee(id);
            if (employee == null)
            {
                return EmployeeNotFound();
            }
            return View(employee);
        }

        //
        // GET: /Employee/Create

        public ActionResult Create()
        {            
            if (NoTeams())
            {                
                return View("Index");
            }
            ViewBag.Teams = GetTeams();
            return View();
        }

        //
        // POST: /Employee/Create

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if (NoTeams())
                return View("Index");
            if (ModelState.IsValid)
            {
                _db.Employees.Add(employee);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        //
        // GET: /Employee/Edit/5

        public ActionResult Edit(int id = -1)
        {
            Employee employee = FindEmployee(id);
            if (employee == null)
            {
                return EmployeeNotFound();
            }
            ViewBag.Teams = GetTeams();
            return View(employee);
        }

        //
        // POST: /Employee/Edit/5

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(employee).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        //
        // GET: /Employee/Delete/5

        public ActionResult Delete(int id =-1)
        {            
            Employee employee = FindEmployee(id);
            if (employee == null)
            {
                return EmployeeNotFound();
            }
            return View(employee);
        }

        public ActionResult EmployeeNotFound()
        {
            return View();
        }

        //
        // POST: /Employee/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = _db.Employees.Find(id);
            _db.Employees.Remove(employee);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}