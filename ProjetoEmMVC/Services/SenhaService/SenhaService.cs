﻿using System.Security.Cryptography;

namespace ProjetoEmMVC.Services.SenhaService
{
    public class SenhaService : ISenhaInterface
    {
        public void CriarSenhaHash(string senha, out byte[] senhaHash, out byte[] senhaSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                senhaSalt = hmac.Key;
                senhaHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(senha));

            }
        }

        public bool VerificaSenha(string senha, byte[] senhaHash, byte[] senhaSalt)
        {
            using (var hmac = new HMACSHA512(senhaSalt)) 
            {
                var computerdHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(senha));
                return computerdHash.SequenceEqual(senhaHash);
            
            }
        }
    }
}
