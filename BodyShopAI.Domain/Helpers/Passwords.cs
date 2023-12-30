﻿using System;
using System.Security.Cryptography;
using System.Text;

namespace Ats.Domain.Library.Helpers
{
    public static class Passwords
    {
        private const int AUTOGENERATED_LENGTH = 10;

        public static string GetAutogenerated()
        {
            var characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            var strBuilder = new StringBuilder();
            var random = new Random();

            for (int i = 0; i < AUTOGENERATED_LENGTH; i++)
                strBuilder.Append(characters[random.Next(characters.Length)]);

            return strBuilder.ToString();
        }

        public static string Encrypt(string password)
        {
            return GetMD5Hash(password);
        }

        public static bool VerifyPassword(string inputPassword, string encryptedActualPassword)
        {
            var encryptedInputPassword = GetMD5Hash(inputPassword);

            var comparer = StringComparer.OrdinalIgnoreCase;

            return (comparer.Compare(encryptedInputPassword, encryptedActualPassword) == 0);
        }

        private static string GetMD5Hash(string input)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                var strBuilder = new StringBuilder();

                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                for (int i = 0; i < data.Length; i++)
                {
                    strBuilder.Append(data[i].ToString("x2"));
                }

                return strBuilder.ToString();
            }
        }
    }
}
