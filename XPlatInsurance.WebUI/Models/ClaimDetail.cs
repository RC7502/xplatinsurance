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
    
    public partial class ClaimDetail
    {
        public int ClaimDetailID { get; set; }
        public int ClaimID { get; set; }
        public string VehicleID { get; set; }
        public string Damage { get; set; }
    
        public virtual Claim Claim { get; set; }
    }
}