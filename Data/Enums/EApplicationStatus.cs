using System.ComponentModel.DataAnnotations;

namespace StartupProject_Asp.NetCore_PostGRE.Data.Enums
{
    public enum EApplicationStatus
    {
        [Display(Name = "Application is Started")]
        Started = 0,
        [Display(Name = "Application is Processing")]
        Processing,
        [Display(Name = "Application Forwarded")]
        Forwarded,
        [Display(Name = "Application Rejected")]
        Rejected,
        [Display(Name = "Application Approved")]
        Approved
    }
}
