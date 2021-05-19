﻿using System;
using System.Text;

namespace EducationPortal.Infrastructure.Data.Hasher
{
    public static class PasswordHasher
    {
        public static string Encode(string decodedPassword)
        {

            return Convert.ToBase64String(Encoding.UTF8.GetBytes(decodedPassword));
           
        }
        public static string Decode(string encodedPassword)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(encodedPassword));
        }
    }
}