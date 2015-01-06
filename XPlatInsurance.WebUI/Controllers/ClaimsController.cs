using System;
using System.Collections.Generic;
using System.Data;
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
    private static readonly List<Models.Claim> db = new List<Claim>();

    static ClaimsController()
    {

    }

    // GET: Claims
    public ActionResult Index()
    {
      return View(db);
    }

    // GET: Claims/Details/5
    public ActionResult Details(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Claim claim = db.FirstOrDefault(c => c.ClaimID == id);
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

        if (db.Count > 0)
          claim.ClaimID = db.Max(c => c.ClaimID) + 1;
        else
          claim.ClaimID = 1;
        
        db.Add(claim);
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
      Claim claim = db.FirstOrDefault(c => c.ClaimID == id);
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
        db.Remove(db.First(c => c.ClaimID == claim.ClaimID));
        db.Add(claim);
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
      Claim claim = db.FirstOrDefault(c => c.ClaimID == id);
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
      db.Remove(db.First(c => c.ClaimID == id));
      return RedirectToAction("Index");
    }

    public ActionResult AddDetail(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Claim claim = db.FirstOrDefault(c => c.ClaimID == id);
      if (claim == null)
      {
        return HttpNotFound();
      }

      ViewBag.Claim = claim;
      return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult AddDetail([Bind(Include = "ClaimID,VehicleID,Damage")]ClaimDetail detail)
    {

      var claim = db.First(c => c.ClaimID == detail.ClaimID);

      if (ModelState.IsValid)
      {
        claim.ClaimDetails.Add(detail);
        return RedirectToAction("Details", new { id = detail.ClaimID });
      }

      ViewBag.Claim = claim;
      return View(detail);

    }

  }
}
