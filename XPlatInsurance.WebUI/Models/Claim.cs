//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace XPlatInsurance.WebUI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Claim
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
}
