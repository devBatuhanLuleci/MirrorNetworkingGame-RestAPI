using System.ComponentModel.DataAnnotations;

namespace ACG_Master.DataBase.Entities
{
    /// <summary>
    /// User Enitity
    /// </summary>
    public class User : IEntity
    {
        [Key]
        public string MoralisId { get; set; }
        public string Email { get; set; }

    }
}
