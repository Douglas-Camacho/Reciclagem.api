﻿namespace Reciclagem.api.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Senha { get; set; }  
        public string? Role { get; set; }
    }
}
