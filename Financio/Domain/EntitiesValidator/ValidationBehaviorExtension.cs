using Microsoft.AspNetCore.Mvc;
using System;

namespace Financio.Domain.EntitiesValidator
{
    public static class ValidationBehavior
    {
        public static void UserValidationBehavior(this IApplicationBuilder builder)
        {
            Console.WriteLine("hello world");
        }
    }
}