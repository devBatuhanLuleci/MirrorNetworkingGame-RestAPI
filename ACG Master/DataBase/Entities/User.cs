﻿using System.ComponentModel.DataAnnotations;

namespace ACG_Master.DataBase.Entities
{
    /// <summary>
    /// User Enitity
    /// </summary>
    public class User : IEntity
    {
        [Key]
        public string MoralisId { get; set; }
        public string NickName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

    }
}