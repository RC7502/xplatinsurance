using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XPlatInsurance.WebUI.Models
{
  public enum ClaimStatus
  {

    Opened = 1,
    InitialReview = 2,
    FactFinding = 3,
    SettingValue = 4,
    Closed = 5

  }

  public class Claim
  {
    public Claim()
    {
      this.ClaimDetails = new HashSet<ClaimDetail>();
    }

    public int ClaimID { get; set; }
    public string CustomerID { get; set; }
    public System.DateTime IncidentDate { get; set; }
    public System.DateTime ReportDateTimeUtc { get; set; }
    public string Location { get; set; }
    public int StatusID { get; set; }

    public virtual ICollection<ClaimDetail> ClaimDetails { get; set; }


  }

  public partial class ClaimDetail
  {
    public int ClaimDetailID { get; set; }
    public int ClaimID { get; set; }
    public string VehicleID { get; set; }
    public string Damage { get; set; }

  }
}