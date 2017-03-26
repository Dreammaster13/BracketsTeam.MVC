using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Firefrog.Crypto
{
    /// <summary>
    /// 
    /// </summary>
    public class Crypter
    {
        private byte[] Hash { get; set; }
        private string SaltedHash { get; set; }
        private byte[] SaltedHashBytes { get; set; }
        private byte[] Salt { get; set; }
        private string Password { get; set; }
        private int Iterations { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pass"></param>
        /// <param name="isCrypted"></param>
        public Crypter(string pass, bool isCrypted)
        {
            this.Salt = new byte[16];
            this.Hash = new byte[20];
            this.Iterations = 10000;
            this.SaltedHashBytes = new byte[this.Salt.GetLength(0) + this.Hash.GetLength(0)];

            if (isCrypted)
            {
                var saltLength = this.Salt.GetLength(0);
                var hashLength = this.Hash.GetLength(0);
                this.SaltedHashBytes = Convert.FromBase64String(pass);

                Array.Copy(this.SaltedHashBytes, 0, this.Salt, 0, saltLength);
                Array.Copy(this.SaltedHashBytes, 0, this.Hash, saltLength, hashLength);
                this.SaltedHash = pass;
            }
            else
            {
                this.Password = pass;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pass"></param>
        /// <param name="isCrypted"></param>
        /// <param name="numIterations"></param>
        public Crypter(string pass, bool isCrypted, int numIterations)
        {
            this.Salt = new byte[16];
            this.Hash = new byte[20];
            this.Iterations = numIterations;
            this.SaltedHashBytes = new byte[this.Salt.GetLength(0) + this.Hash.GetLength(0)];

            if (isCrypted)
            {
                var saltLength = this.Salt.GetLength(0);
                var hashLength = this.Hash.GetLength(0);
                this.SaltedHashBytes = Convert.FromBase64String(pass);

                Array.Copy(this.SaltedHashBytes, 0, this.Salt, 0, saltLength);
                Array.Copy(this.SaltedHashBytes, 0, this.Hash, saltLength, hashLength);
                this.SaltedHash = pass;
            }
            else
            {
                this.Password = pass;
            }
        }

        public bool CompareSaltedHash(string plainPass)
        {
            var returnValue = true;
            var pbkdf2 = new Rfc2898DeriveBytes(plainPass, this.Salt, this.Iterations);
            this.Hash = pbkdf2.GetBytes(this.Hash.GetLength(0));

            for (int i = 0; i < this.Hash.GetLength(0); i++)
            {
                if (this.SaltedHashBytes[i + this.Salt.GetLength(0)] != this.Hash[i])
                {
                    returnValue = false;
                    break;
                }
            }
            return returnValue;
        }

        private void GenerateSalt()
        {
            new RNGCryptoServiceProvider().GetBytes(this.Salt);
        }

        private void GenerateHash()
        {
            var pbkdf2 = new Rfc2898DeriveBytes(this.Password, this.Salt, this.Iterations);
            this.Hash = pbkdf2.GetBytes(this.Hash.GetLength(0));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GenerateNewSaltedHash()
        {
            this.GenerateSalt();
            this.GenerateHash();

            var saltLength = this.Salt.GetLength(0);
            var hashLength = this.Hash.GetLength(0);

            Array.Copy(this.SaltedHashBytes, 0, this.Salt, 0, saltLength);
            Array.Copy(this.SaltedHashBytes, 0, this.Hash, saltLength, hashLength);

            this.SaltedHash = Convert.ToBase64String(this.SaltedHashBytes);
            return this.SaltedHash;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetGeneratedSaltedHash()
        {
            return this.SaltedHash;
        }
    }

}
