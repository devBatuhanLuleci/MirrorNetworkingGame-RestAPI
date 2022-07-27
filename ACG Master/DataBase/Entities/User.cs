using System.ComponentModel.DataAnnotations;

namespace ACG_Master.DataBase.Entities
{
    public class User : IEntity
    {
        [Key]
        public string MoralisId { get; set; }
        public string Id { get; set; }
        [Required]
        public string NickName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }

    }
}
