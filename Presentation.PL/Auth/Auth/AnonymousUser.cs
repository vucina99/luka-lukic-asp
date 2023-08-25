﻿using Application;

namespace Presentation.PL.Auth.Auth
{
    public class AnonymousUser : IApplicationUser
    {
        public string Identity => "Anonymous";

        public int Id => 0;

        public IEnumerable<int> UseCaseIds => new List<int> { 4 };

        public string Email => "anonymous@asp.com";
    }
}
