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

    XPlatInsuranceEntities ctx;

    public ClaimsController()
    {
      ctx = new Models.XPlatInsuranceEntities();
    }
    
    // GET api/<controller>
    public IEnumerable<Models.Claim> Get()
    {
      return ctx.Claims;
    }

    // GET api/<controller>/5
    public Models.Claim Get(int id)
    {
      return ctx.Claims.First(c => c.ClaimID == id);
    }

    // POST api/<controller>
    public void Post([FromBody]Models.Claim value)
    {
      ctx.Claims.Add(value);
      ctx.SaveChanges();
    }

    // PUT api/<controller>/5
    public void Put(int id, [FromBody]Models.Claim value)
    {
      ctx.Entry(value).State = EntityState.Modified;
      ctx.SaveChanges();
    }

    // DELETE api/<controller>/5
    public void Delete(int id)
    {
      ctx.Claims.Remove(ctx.Claims.Find(id));
    }
  }

  public class ClaimDetailsController : ApiController
  {

    XPlatInsuranceEntities ctx;

    public ClaimDetailsController()
    {
      ctx = new Models.XPlatInsuranceEntities();
    }

    // GET api/<controller>
    public IEnumerable<Models.ClaimDetail> Get()
    {
      return ctx.ClaimDetails;
    }

    // GET api/<controller>/5
    public Models.ClaimDetail Get(int id)
    {
      return ctx.ClaimDetails.Find(id);
    }

    // POST api/<controller>
    public void Post([FromBody]Models.ClaimDetail value)
    {
      ctx.ClaimDetails.Add(value);
      ctx.SaveChanges();
    }

    // PUT api/<controller>/5
    public void Put(int id, [FromBody]Models.ClaimDetail value)
    {
      ctx.Entry(value).State = EntityState.Modified;
      ctx.SaveChanges();
    }

    // DELETE api/<controller>/5
    public void Delete(int id)
    {
      ctx.ClaimDetails.Remove(ctx.ClaimDetails.Find(id));
    }
  }
}