namespace Reffindr.Domain.Models;

public class Candidate : BaseModel
{
    public int AplicationId { get; set; }
    public bool SelectedByTenant { get; set; }

    public virtual Application? Aplication { get; set; }
}
