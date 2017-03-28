using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Firefrog.Crypto
{
    /// <summary>
    /// Simple Crypter Class
    /// </summary>
    public class CrypterSimple
    {
        /// <summary>
        /// Hashed Password without salt
        /// </summary>
        public byte[] Hash { get; private set; }
        /// <summary>
        /// Salt to use in Password
        /// </summary>
        public byte[] Salt { get; private set; }
        /// <summary>
        /// Salted Hash
        /// </summary>
        public byte[] HashedPwdBytes { get; private set; }
        /// <summary>
        /// String for the Hashed Password
        /// </summary>
        public string HashedPwd { get; private set; }
        /// <summary>
        /// Number of iterations for the Hashing
        /// </summary>
        public int Iterations { get; private set; }
        /// <summary>
        /// Plain Password
        /// </summary>
        private string PlainPwd { get; set; }
        /// <summary>
        /// Salt Length
        /// </summary>
        private int SaltLength { get; set; }
        /// <summary>
        /// Hash Length
        /// </summary>
        private int HashLength { get; set; }
        /// <summary>
        /// Is the password already Hashed?
        /// </summary>
        public bool IsHashed { get; private set; }

        /// <summary>
        /// Creates an object to apply cryptographic hashing. Uses some default values for easy usage.<para/>
        /// <para>Salt Length: 16</para>
        /// <para>Hash Length: 20</para>
        /// <para>Iterations: 10000</para>
        /// </summary>
        /// <param name="plainText">Plain password, or hashed password.</param>
        /// <param name="isHashedPass">If the previous parameter is hashed, this is true.</param>
        public CrypterSimple(string plainText, bool isHashedPass)
        {
            IsHashed = isHashedPass;
            SaltLength = DefaultValues.SaltLength;
            HashLength = DefaultValues.HashLength;
            Iterations = DefaultValues.Iterations;

            Salt = new byte[SaltLength];
            Hash = new byte[HashLength];
            HashedPwdBytes = new byte[SaltLength + HashLength];

            if (isHashedPass)
            {
                HashedPwdBytes = Convert.FromBase64String(plainText);
                Array.Copy(HashedPwdBytes, 0, Salt, 0, SaltLength);
                Array.Copy(HashedPwdBytes, SaltLength, Hash, 0, HashLength);
                HashedPwd = plainText;
            }
            else
            {
                PlainPwd = plainText;
            }
        }

        /// <summary>
        /// Creates an object to apply cryptographic hashing. Uses some default values for easy usage.
        /// <para>Salt Length: 16</para>
        /// <para>Hash Length: 20</para>
        /// </summary>
        /// <param name="plainText">Plain password, or hashed password.</param>
        /// <param name="isHashedPass">If the previous parameter is hashed, this is true.</param>
        /// <param name="iterations">Number of iterations to do on the password</param>
        public CrypterSimple(string plainText, bool isHashedPass, int iterations)
        {
            IsHashed = isHashedPass;
            SaltLength = DefaultValues.SaltLength;
            HashLength = DefaultValues.HashLength;
            Iterations = iterations;

            Salt = new byte[SaltLength];
            Hash = new byte[HashLength];
            HashedPwdBytes = new byte[SaltLength + HashLength];

            if (isHashedPass)
            {
                HashedPwdBytes = Convert.FromBase64String(plainText);
                Array.Copy(HashedPwdBytes, 0, Salt, 0, SaltLength);
                Array.Copy(HashedPwdBytes, SaltLength, Hash, 0, HashLength);
                HashedPwd = plainText;
            }
            else
            {
                PlainPwd = plainText;
            }
        }

        /// <summary>
        /// Creates an object to apply cryptographic hashing. Uses some default values for easy usage.<para/>
        /// <para>Hash Length: 20</para>
        /// </summary>
        /// <param name="plainText">Plain password, or hashed password.</param>
        /// <param name="isHashedPass">If the previous parameter is hashed, this is true.</param>
        /// <param name="iterations">Number of iterations to do on the password</param>
        /// <param name="saltLength">Salt Length (in bytes)</param>
        public CrypterSimple(string plainText, bool isHashedPass, int iterations, int saltLength)
        {
            IsHashed = isHashedPass;
            SaltLength = saltLength;
            HashLength = DefaultValues.HashLength;
            Iterations = iterations;

            Salt = new byte[SaltLength];
            Hash = new byte[HashLength];
            HashedPwdBytes = new byte[SaltLength + HashLength];

            if (isHashedPass)
            {
                HashedPwdBytes = Convert.FromBase64String(plainText);
                Array.Copy(HashedPwdBytes, 0, Salt, 0, SaltLength);
                Array.Copy(HashedPwdBytes, SaltLength, Hash, 0, HashLength);
                HashedPwd = plainText;
            }
            else
            {
                PlainPwd = plainText;
            }
        }

        /// <summary>
        /// Creates an object to apply cryptographic hashing.
        /// </summary>
        /// <param name="plainText">Plain password, or hashed password.</param>
        /// <param name="isHashedPass">If the previous parameter is hashed, this is true.</param>
        /// <param name="iterations">Number of iterations to do on the password</param>
        /// <param name="saltLength">Salt Length (in bytes)</param>
        /// <param name="hashLength">Hash Length (in bytes)</param>
        public CrypterSimple(string plainText, bool isHashedPass, int iterations, int saltLength, int hashLength)
        {
            IsHashed = isHashedPass;
            SaltLength = saltLength;
            HashLength = hashLength;
            Iterations = iterations;

            Salt = new byte[SaltLength];
            Hash = new byte[HashLength];
            HashedPwdBytes = new byte[SaltLength + HashLength];

            if (isHashedPass)
            {
                HashedPwdBytes = Convert.FromBase64String(plainText);
                Array.Copy(HashedPwdBytes, 0, Salt, 0, SaltLength);
                Array.Copy(HashedPwdBytes, SaltLength, Hash, 0, HashLength);
                HashedPwd = plainText;
            }
            else
            {
                PlainPwd = plainText;
            }
        }

        /// <summary>
        /// Hashes the password provided on the constructor
        /// </summary>
        /// <returns>Hashed password as string</returns>
        public string HashMe()
        {
            if (!IsHashed)
            {
                new RNGCryptoServiceProvider().GetBytes(Salt);
                Hash = new Rfc2898DeriveBytes(PlainPwd, Salt, Iterations).GetBytes(HashLength);
                Array.Copy(Salt, 0, HashedPwdBytes, 0, SaltLength);
                Array.Copy(Hash, 0, HashedPwdBytes, SaltLength, HashLength);

                HashedPwd = Convert.ToBase64String(HashedPwdBytes);
                IsHashed = true;
            }
            else
            {
                throw new CryptographicException("You can't 'Hash' twice your password.");
            }

            return HashedPwd;
        }

        /// <summary>
        /// Compares a given (plain) Password to the given in the constructor
        /// <para>If no Hashed Password was given on the constructor, you have to Hash your plain Password first</para>
        /// <para>A.K.A. use HashMe() method first.</para>
        /// <para> </para>
        /// </summary>
        /// <param name="plainPass">Plain Password to comapare to.</param>
        /// <returns>True if both passwords successfully compare.</returns>
        public bool CompareMe(string plainPass)
        {
            bool samePwd = true;
            if (IsHashed)
            {
                var pbkdf2 = new Rfc2898DeriveBytes(plainPass, Salt, Iterations);
                var tempHash = pbkdf2.GetBytes(HashLength);

                for (int i = 0; i < HashLength; i++)
                {
                    if (tempHash[i] != Hash[i])
                    {
                        samePwd = false;
                        break;
                    }
                }
            }
            else
            {
                throw new CryptographicException("You need a 'Hashed' password on the object, before comparing it. Use HashMe method first or give the constructor a hashed password.");
            }

            return samePwd;
        }
    }
}
