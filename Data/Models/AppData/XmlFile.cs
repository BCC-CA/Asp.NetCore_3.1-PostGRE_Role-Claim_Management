using StartupProject_Asp.NetCore_PostGRE.Data.Enums;
using StartupProject_Asp.NetCore_PostGRE.Data.Models.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace StartupProject_Asp.NetCore_PostGRE.Data.Models.AppData
{
    public class XmlFile : BaseModel
    {
        /*public XmlFile: private BaseModel()
        {}*/

        public ETableName TableName { get; set; } = ETableName.XmlFile;
        public Guid DbEntryId { get; set; }

        [IgnoreDataMember]
        [ConcurrencyCheck]  //2 file should not be same
        [Column("FileContent", TypeName = "text"), Required(ErrorMessage = "File Content should be given"), MinLength(5), Display(Name = "File Content", Prompt = "Please Give File Content")]
        public string SignedContent { get; set; }

        [IgnoreDataMember]
        [Column("SignerId"), Display(Name = "Signer Id", Prompt = "Please Give Signer Id")]
        public Guid? SignerId { get; set; }
        [ForeignKey("SignerId"), Display(Name = "Previous Signed/Unsigned File", Prompt = "Please Select Previous File")]
        public virtual User Signer { get; set; }
        
        [Column("NextFileId"), Display(Name = "Previous Signed/Unsigned File", Prompt = "Please select Previous File")]
        public Guid? NextFileId { get; set; }
        [ForeignKey("NextFileId"), Display(Name = "Previous Signed/Unsigned File", Prompt = "Please Select Previous File")]
        public virtual XmlFile NextSignedFile { get; set; }

        //public ICollection<DownloadUploadToken> DownloadUploadTokens { get; set; }
    }
}
