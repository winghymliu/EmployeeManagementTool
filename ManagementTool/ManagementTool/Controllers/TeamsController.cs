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
    public class TeamsController : Controller
    {
        private readonly CompanyDBContext _db;

        public TeamsController(CompanyDBContext db)
        {
            _db = db;
        }

        private Team FindTeam(int id)
        {
            if (id < 0)
            {
                return null;
            }
            Team team = _db.Teams.Find(id);

            return team;
        }

        //
        // GET: /Teams/

        public ActionResult Index()
        {   
            return View(_db.Teams.ToList());
        }

        //
        // GET: /Teams/Details/5

        public ActionResult Details(int id = -1)
        {
            var team = FindTeam(id);
            if (team == null)
            {
                return View("TeamNotFound");
            }
            return View(team);
        }

        //
        // GET: /Teams/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Teams/Create

        [HttpPost]
        public ActionResult Create(Team team)
        {
            if (ModelState.IsValid)
            {
                team.CreationTime = DateTime.Now;
                _db.Teams.Add(team);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(team);
        }

        //
        // GET: /Teams/Edit/5

        public ActionResult Edit(int id = -1)
        {

            Team team = FindTeam(id);
            if (team == null)
            {
                return View("TeamNotFound");
            }
            return View(team);
        }

        //
        // POST: /Teams/Edit/5

        [HttpPost]
        public ActionResult Edit(Team team)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(team).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(team);
        }

        //
        // GET: /Teams/Delete/5

        public ActionResult Delete(int id = -1)
        {
            Team team = FindTeam(id);
            if (team == null)
            {
                return View("TeamNotFound");
            }
                      
            return View(team);
        }

        public ActionResult DeleteFail()
        {
            return View();
        }

        public ActionResult TeamNotFound()
        {
            return View();
        }

        //
        // POST: /Teams/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var noOfEmployees = _db.Employees.Count(x => x.TeamID.Equals(id));
            if (noOfEmployees > 0)
            {
                return View("DeleteFail");
            }
            Team team = _db.Teams.Find(id);
            _db.Teams.Remove(team);
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