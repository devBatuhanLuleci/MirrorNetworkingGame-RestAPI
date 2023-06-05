using ACG_Master.DataBase.Entities;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ACG_Master.DataBase.Dtos
{
    public class UserDto
    {
        [EmailAddress]
        public string Email { get; set; }
        public string WalletId { get; set; }
        public string UserName { get; set; }

    }
}
