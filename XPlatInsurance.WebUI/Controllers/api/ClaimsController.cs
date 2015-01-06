using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using XPlatInsurance.WebUI.Models;

namespace XPlatInsurance.WebUI.Controllers.api
{
  public class ClaimsController : ApiController
  {

    internal static readonly List<Claim> db = new List<Claim>();

    // GET api/<controller>
    public IEnumerable<Models.Claim> Get()
    {
      return db;
    }

    // GET api/<controller>/5
    public Models.Claim Get(int id)
    {
      return db.First(c => c.ClaimID == id);
    }

    // POST api/<controller>
    public void Post([FromBody]Models.Claim value)
    {
      if (db.Count > 0)
        value.ClaimID = db.Max(c => c.ClaimID) + 1;
      else
        value.ClaimID = 1;

      db.Add(value);
    }

    // PUT api/<controller>/5
    public void Put(int id, [FromBody]Models.Claim value)
    {
      db.Remove(db.First(c => c.ClaimID == id));
      db.Add(value);
    }

    // DELETE api/<controller>/5
    public void Delete(int id)
    {
      db.Remove(db.First(c => c.ClaimID == id));
    }
  }

  public class ClaimDetailsController : ApiController
  {

    // GET api/<controller>
    public IEnumerable<Models.ClaimDetail> Get()
    {
      return null;
    }

    // GET api/<controller>/5
    public Models.ClaimDetail Get(int id)
    {

      var theClaim = ClaimsController.db.First(c => c.ClaimDetails.Any(d => d.ClaimDetailID == id));
      return theClaim != null ? theClaim.ClaimDetails.First(d => d.ClaimDetailID == id) : null;
    }

    // POST api/<controller>
    public void Post([FromBody]Models.ClaimDetail value)
    {
      var theClaim = ClaimsController.db.First(c => c.ClaimID == value.ClaimID);
      theClaim.ClaimDetails.Add(value);
    }

    // PUT api/<controller>/5
    public void Put(int id, [FromBody]Models.ClaimDetail value)
    {
      var theClaim = ClaimsController.db.First(c => c.ClaimID == value.ClaimID);
      theClaim.ClaimDetails.Remove(theClaim.ClaimDetails.First(d => d.ClaimDetailID == id));
      theClaim.ClaimDetails.Add(value);
    }

    // DELETE api/<controller>/5
    public void Delete(int id)
    {
      var theClaim = ClaimsController.db.First(c => c.ClaimDetails.Any(d => d.ClaimDetailID == id));
      theClaim.ClaimDetails.Remove(theClaim.ClaimDetails.First(d => d.ClaimDetailID == id));
    }
  }
}