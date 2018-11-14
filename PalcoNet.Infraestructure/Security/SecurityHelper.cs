using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Infraestructure.Security
{
    public static class SecurityHelper
    {
        public static String EncodePassword(String clearText, Algorithm hashAlgorithmType = Algorithm.Sha256)
        {
            switch (hashAlgorithmType)
            {
                case Algorithm.Md5:
                    return Checksum.CalculateStringHash(clearText, Algorithm.Md5);

                case Algorithm.Sha1:
                    return Checksum.CalculateStringHash(clearText, Algorithm.Sha1);

                case Algorithm.Sha256:
                    return Checksum.CalculateStringHash(clearText, Algorithm.Sha256);

                case Algorithm.Sha384:
                    return Checksum.CalculateStringHash(clearText, Algorithm.Sha384);

                case Algorithm.Sha512:
                    return Checksum.CalculateStringHash(clearText, Algorithm.Sha512);

                default: throw new Exception("Metodo no implementado");
            }
        }

        public static string CreateRandomPassword(int passwordLength)
        {
            var str = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ23456789";
            var data = new byte[passwordLength];
            new RNGCryptoServiceProvider().GetBytes(data);
            var chArray = new char[passwordLength];
            var length = str.Length;

            for (var i = 0; i < passwordLength; i++)
                chArray[i] = str[data[i] % length];

            return new string(chArray);
        }
    }
}
