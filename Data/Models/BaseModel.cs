using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace StartupProject_Asp.NetCore_PostGRE.Data.Models
{
    //[Table("Product")]
    public class BaseModel
    {
        [HiddenInput(DisplayValue = false), Display(Name = "ID")]
        [Key()]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public Guid? Id { get; set; } = Guid.NewGuid();
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        //[ReadOnly(true)]
        [HiddenInput(DisplayValue = false), Display(Name = "First Entry Time")]
        [Column("CreateTime", TypeName = "TIMESTAMPTZ")]
        [IgnoreDataMember]
        public DateTime? CreateTime { get; set; } = DateTime.UtcNow;

        [HiddenInput(DisplayValue = false), Display(Name = "Last Update Time")]
        [Column("LastUpdateTime", TypeName = "TIMESTAMPTZ")]
        [IgnoreDataMember]
        public DateTime? LastUpdateTime { get; set; }

        [HiddenInput(DisplayValue = false), Display(Name = "Is Item Deleated"), Column("IsDeleted")]
        public bool IsDeleted { get; set; } = false;

        [IgnoreDataMember]
        [HiddenInput(DisplayValue = false)]
        public DateTime? DeletionTime { get; set; }     //DeletionTime not null means the item is deleted

        public void SoftDelete()
        {
            DeletionTime = DateTime.UtcNow;
        }
    }
}
