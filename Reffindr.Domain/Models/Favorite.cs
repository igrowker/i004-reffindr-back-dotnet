using Reffindr.Domain.Models.UserModels;

namespace Reffindr.Domain.Models
{
    public class Favorite : BaseModel
    {
        public int? PropertyId { get; set; }
        public int? UserId { get; set; }

        #region Navigation Properties
        public virtual Property? Property { get; set; } = default!;
        public virtual User? User { get; set; } = default!;
        #endregion
    }
}
