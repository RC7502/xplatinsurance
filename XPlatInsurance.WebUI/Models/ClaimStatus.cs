using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XPlatInsurance.WebUI.Models
{
    public enum ClaimStatus
    {

        Opened          = 1,
        InitialReview   = 2,
        FactFinding     = 3,
        SettingValue    = 4,
        Closed          = 5

    }
}