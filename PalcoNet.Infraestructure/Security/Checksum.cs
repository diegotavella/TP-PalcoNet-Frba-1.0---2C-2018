using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Infraestructure.Security
{
    public class Checksum
    {
        /// <summary>
        /// Devuelve un string hash aplicando a la cadena el algoritmo provisto
        /// </summary>
        /// <param name="cadena"></param>
        /// <param name="alg"></param>
        /// <returns></returns>
        public static string CalculateStringHash(string cadena, Algorithm alg)
        {
            HashAlgorithm hashProvider = GetHashProvider(alg);
            byte[] bytes = Encoding.ASCII.GetBytes(cadena);
            return ArrayToString(hashProvider.ComputeHash(bytes));
        }

        /// <summary>
        /// Devuelve el provider correspondiente segun el algoritmo pedido limitado por el enum
        /// </summary>
        /// <param name="alg"></param>
        /// <returns></returns>
        private static HashAlgorithm GetHashProvider(Algorithm alg)
        {
            switch (alg)
            {
                case Algorithm.Md5:
                    return new MD5CryptoServiceProvider();

                case Algorithm.Sha1:
                    return new SHA1Managed();

                case Algorithm.Sha256:
                    return new SHA256Managed();

                case Algorithm.Sha384:
                    return new SHA384Managed();

                case Algorithm.Sha512:
                    return new SHA512Managed();
            }
            throw new Exception("Provider invalido");
        }

        /// <summary>
        /// Convierte el array a string en formato hexadecimal
        /// </summary>
        /// <param name="byteArray"></param>
        /// <returns></returns>
        private static string ArrayToString(byte[] byteArray)
        {
            StringBuilder builder = new StringBuilder(byteArray.Length);
            for (int i = 0; i < byteArray.Length; i++)
            {
                builder.Append(byteArray[i].ToString("X2"));
            }
            return builder.ToString();
        }
    }
}
