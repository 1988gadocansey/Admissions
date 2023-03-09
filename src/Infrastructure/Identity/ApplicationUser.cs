using Microsoft.AspNetCore.Identity;

namespace OnlineApplicationSystem.Infrastructure.Identity;

public class ApplicationUser : IdentityUser
{
    public virtual string FormNo { get; set; }
    public virtual int Started { get; set; }
    public virtual string FullName { get; set; }
    public virtual string Type { get; set; }
    public virtual string Category { get; set; }
    public virtual int Sold { set; get; }
    public string SoldBy { set; get; }
    public virtual string Branch { set; get; }
    public string Teller { set; get; }
    public string TellerPhone { set; get; }
    public virtual int FormCompleted { set; get; }
    public virtual int PictureUploaded { set; get; }
    public virtual int Finalized { set; get; }
    public virtual string Year { get; set; }
    public virtual bool ResultUploaded { get; set; }
    public virtual bool Admitted { get; set; }
    public virtual string Pin { get; set; }
    public virtual DateTime LastLogin { set; get; }

}
