using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using XPlatInsurance.WebUI.Models;

namespace XPlatInsurance.WebUI.Controllers
{
    public class ClaimsController : Controller
    {
      private api.ClaimsController claims = new api.ClaimsController();
      private api.ClaimDetailsController details = new api.ClaimDetailsController();

        // GET: Claims
        public ActionResult Index()
        {
            return View(claims.Get().ToList());
        }

        // GET: Claims/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Claim claim = claims.Get(id.Value);
            if (claim == null)
            {
                return HttpNotFound();
            }
            return View(claim);
        }

        // GET: Claims/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Claims/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClaimID,CustomerID,IncidentDate,ReportDateTimeUtc,Location,StatusID")] Claim claim)
        {
            if (ModelState.IsValid)
            {
                claims.Post(claim);
                return RedirectToAction("Index");
            }

            return View(claim);
        }

        // GET: Claims/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Claim claim = claims.Get(id.Value);
            if (claim == null)
            {
                return HttpNotFound();
            }
            return View(claim);
        }

        // POST: Claims/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClaimID,CustomerID,IncidentDate,ReportDateTimeUtc,Location,StatusID")] Claim claim)
        {
            if (ModelState.IsValid)
            {
              claims.Put(claim.ClaimID, claim);
                return RedirectToAction("Index");
            }
            return View(claim);
        }

        // GET: Claims/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Claim claim = claims.Get(id.Value);
            if (claim == null)
            {
                return HttpNotFound();
            }
            return View(claim);
        }

        // POST: Claims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            claims.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult AddDetail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Claim claim = claims.Get(id.Value);
            if (claim == null)
            {
                return HttpNotFound();
            }

            ViewBag.Claim = claim;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddDetail([Bind(Include ="ClaimID,VehicleID,Damage")]ClaimDetail detail)
        {

            if (ModelState.IsValid)
            {
                details.Post(detail);
                return RedirectToAction("Details", new { id = detail.ClaimID });
            }

            var claim = claims.Get(detail.ClaimID);
            ViewBag.Claim = claim;
            return View(detail);

        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                claims.Dispose();
                details.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
