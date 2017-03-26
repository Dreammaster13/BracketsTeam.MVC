using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Firefrog.Crypto
{
    public class CrypterSimple
    {
        public byte[] Hash { get; private set; }
        public byte[] Salt { get; private set; }
        public byte[] HashedPwdBytes { get; private set; }
        public string HashedPwd { get; private set; }
        public int Iterations { get; private set; }
        private string PlainPwd { get; set; }
        private int SaltLength { get; set; }
        private int HashLength { get; set; }
        public bool IsHashed { get; private set; }

        public CrypterSimple(string plainText, bool isHashed)
        {
            IsHashed = IsHashed;
            SaltLength = DefaultValues.SaltLength;
            HashLength = DefaultValues.HashLength;
            Iterations = DefaultValues.Iterations;

            Salt = new byte[SaltLength];
            Hash = new byte[HashLength];
            HashedPwdBytes = new byte[SaltLength + HashLength];

            if (isHashed)
            {
                HashedPwdBytes = Convert.FromBase64String(plainText);
                Array.Copy(HashedPwdBytes, 0, Salt, 0, SaltLength);
                Array.Copy(HashedPwdBytes, 0, Hash, SaltLength, HashLength);
                HashedPwd = plainText;
            }
            else
            {
                PlainPwd = plainText;
            }
        }

        public CrypterSimple(string plainText, bool isHashed, int iterations)
        {
            IsHashed = IsHashed;
            SaltLength = DefaultValues.SaltLength;
            HashLength = DefaultValues.HashLength;
            Iterations = iterations;

            Salt = new byte[SaltLength];
            Hash = new byte[HashLength];
            HashedPwdBytes = new byte[SaltLength + HashLength];

            if (isHashed)
            {
                HashedPwdBytes = Convert.FromBase64String(plainText);
                Array.Copy(HashedPwdBytes, 0, Salt, 0, SaltLength);
                Array.Copy(HashedPwdBytes, SaltLength, Hash, SaltLength, HashLength);
                HashedPwd = plainText;
            }
            else
            {
                PlainPwd = plainText;
            }
        }

        public CrypterSimple(string plainText, bool isHashed, int iterations, int saltLength)
        {
            IsHashed = IsHashed;
            SaltLength = saltLength;
            HashLength = DefaultValues.HashLength;
            Iterations = iterations;

            Salt = new byte[SaltLength];
            Hash = new byte[HashLength];
            HashedPwdBytes = new byte[SaltLength + HashLength];

            if (isHashed)
            {
                HashedPwdBytes = Convert.FromBase64String(plainText);
                Array.Copy(HashedPwdBytes, 0, Salt, 0, SaltLength);
                Array.Copy(HashedPwdBytes, SaltLength, Hash, SaltLength, HashLength);
                HashedPwd = plainText;
            }
            else
            {
                PlainPwd = plainText;
            }
        }

        public CrypterSimple(string plainText, bool isHashed, int iterations, int saltLength, int hashLength)
        {
            IsHashed = IsHashed;
            SaltLength = saltLength;
            HashLength = hashLength;
            Iterations = iterations;

            Salt = new byte[SaltLength];
            Hash = new byte[HashLength];
            HashedPwdBytes = new byte[SaltLength + HashLength];

            if (isHashed)
            {
                HashedPwdBytes = Convert.FromBase64String(plainText);
                Array.Copy(HashedPwdBytes, 0, Salt, 0, SaltLength);
                Array.Copy(HashedPwdBytes, SaltLength, Hash, SaltLength, HashLength);
                HashedPwd = plainText;
            }
            else
            {
                PlainPwd = plainText;
            }
        }

        public string HashMe()
        {
            if (!IsHashed)
            {
                new RNGCryptoServiceProvider().GetBytes(Salt);
                Hash = new Rfc2898DeriveBytes(PlainPwd, Salt, Iterations).GetBytes(HashLength);
                Array.Copy(Salt, 0, HashedPwdBytes, 0, SaltLength);
                Array.Copy(Hash, 0, HashedPwdBytes, SaltLength, HashLength);

                HashedPwd = Convert.ToBase64String(HashedPwdBytes);
            }

            return HashedPwd;
        }

        public bool CompareMe(string plainPwd)
        {
            bool samePwd = false;
            if (IsHashed)
            {

            }
            return samePwd;
        }
    }
}
