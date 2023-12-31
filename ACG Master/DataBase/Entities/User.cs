﻿using System.ComponentModel.DataAnnotations;

namespace ACG_Master.DataBase.Entities
{
    /// <summary>
    /// User Enitity
    /// </summary>
    public class User : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string WalletId { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string AccessToken { get; set; }
        public int Coins { get; set; }
    }
}
