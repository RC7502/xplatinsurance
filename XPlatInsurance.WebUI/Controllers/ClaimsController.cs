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
        private XPlatInsuranceEntities db = new XPlatInsuranceEntities();

        // GET: Claims
        public ActionResult Index()
        {
            return View(db.Claims.ToList());
        }

        // GET: Claims/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Claim claim = await db.Claims.FindAsync(id);
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
        public async Task<ActionResult> Create([Bind(Include = "ClaimID,CustomerID,IncidentDate,ReportDateTimeUtc,Location,StatusID")] Claim claim)
        {
            if (ModelState.IsValid)
            {
                db.Claims.Add(claim);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(claim);
        }

        // GET: Claims/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Claim claim = await db.Claims.FindAsync(id);
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
        public async Task<ActionResult> Edit([Bind(Include = "ClaimID,CustomerID,IncidentDate,ReportDateTimeUtc,Location,StatusID")] Claim claim)
        {
            if (ModelState.IsValid)
            {
                db.Entry(claim).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(claim);
        }

        // GET: Claims/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Claim claim = await db.Claims.FindAsync(id);
            if (claim == null)
            {
                return HttpNotFound();
            }
            return View(claim);
        }

        // POST: Claims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Claim claim = await db.Claims.FindAsync(id);
            db.Claims.Remove(claim);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> AddDetail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Claim claim = await db.Claims.FindAsync(id);
            if (claim == null)
            {
                return HttpNotFound();
            }

            ViewBag.Claim = claim;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddDetail([Bind(Include ="ClaimID,VehicleID,Damage")]ClaimDetail detail)
        {

            if (ModelState.IsValid)
            {
                db.ClaimDetails.Add(detail);
                await db.SaveChangesAsync();
                return RedirectToAction("Details", new { id = detail.ClaimID });
            }

            var claim = db.Claims.FindAsync(detail.ClaimID);
            ViewBag.Claim = claim;
            return View(detail);

        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
