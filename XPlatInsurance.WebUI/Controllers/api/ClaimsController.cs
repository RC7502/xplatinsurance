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

    public static List<Claim> _MyClaims = new List<Claim>() {
      new Claim {
        ClaimID=1, 
        CustomerID="4567",
        IncidentDate=new DateTime(2015,1,2),
        ReportDateTimeUtc = DateTime.UtcNow,
        Location = "Kalahari parking lot",
        StatusID = 1,
        ClaimDetails = new List<ClaimDetail> {
          new ClaimDetail() {
            ClaimDetailID = 1,
            ClaimID=1234,
            VehicleID = "Blue Subaru Sedan",
            Damage = "Cracked Windshield"
          }
        }
      }
    };


    public ClaimsController()
    {
    }
    
    // GET api/<controller>
    public IEnumerable<Models.Claim> Get()
    {
      return _MyClaims;
    }

    // GET api/<controller>/5
    public Models.Claim Get(int id)
    {
      return _MyClaims.First(c => c.ClaimID==id);
    }

    // POST api/<controller>
    public void Post([FromBody]Models.Claim value)
    {
      _MyClaims.Add(value);
    }

    // PUT api/<controller>/5
    public void Put(int id, [FromBody]Models.Claim value)
    {
      _MyClaims.Remove(_MyClaims.First(c => c.ClaimID == id));
      _MyClaims.Add(value);
    }

    // DELETE api/<controller>/5
    public void Delete(int id)
    {
      _MyClaims.Remove(_MyClaims.First(c => c.ClaimID == id));
    }
  }

  public class ClaimDetailsController : ApiController
  {

    public ClaimDetailsController()
    {
    }

    // POST api/<controller>
    public void Post([FromBody]Models.ClaimDetail value)
    {
      var claims = ClaimsController._MyClaims;
     var thisClaim = claims.First(c => c.ClaimID == value.ClaimID);
      thisClaim.ClaimDetails.Add(value);
    }

    // PUT api/<controller>/5
    public void Put(int id, [FromBody]Models.ClaimDetail value)
    {
      var claims = ClaimsController._MyClaims;
      var thisClaim = claims.First(c => c.ClaimID == value.ClaimID);
      thisClaim.ClaimDetails.Remove(thisClaim.ClaimDetails.First(d => d.ClaimDetailID == value.ClaimDetailID));
      thisClaim.ClaimDetails.Add(value);
    }

  }
}