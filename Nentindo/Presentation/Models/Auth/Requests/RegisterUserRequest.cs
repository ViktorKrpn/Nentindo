﻿namespace Nentindo.Presentation.Models.Auth.Requests
{
    public class RegisterUserRequest
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public int CompanyId { get; set; }  
    }
}
