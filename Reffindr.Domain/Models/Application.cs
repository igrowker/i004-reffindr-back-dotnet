using Reffindr.Domain.Models.UserModels;

namespace Reffindr.Domain.Models;

public class Application : BaseModel
{
    public int PropertyId { get; set; }
    public int UserId { get; set; }
    public string? Status { get; set; } // Pending, Accepted, Rejected


    public virtual Property? Property { get; set; }
    public virtual User? User { get; set; }
}
