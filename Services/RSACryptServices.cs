using rsa_cripto_descripto.DTOs;
using rsa_cripto_descripto.Enums;
using System.Security.Cryptography;
using System.Text;
using System;

namespace rsa_cripto_descripto.Services
{
    public class RSACryptServices
    {
        /// <summary>
        /// Método para gerar o XML
        /// </summary>
        /// <returns></returns>
        public XmlDTO GerarChaveXmlRsa()
        {
            RSACryptoServiceProvider provider = new RSACryptoServiceProvider((int)RsaSizeEnum.Rsa1024);

            XmlDTO xmlDTO = new()
            {
                XmlPublico = provider.ToXmlString(false),
                XmlPrivado = provider.ToXmlString(true)
            };

            return xmlDTO; 
        }

        /// <summary>
        /// Método para descritografia com chave publica PEM
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public string EncriptPemRSA(CriptoPemDTO dto)
        {
            using (var rsa = new RSACryptoServiceProvider((int)RsaSizeEnum.Rsa1024))
            {
                try
                {
                    rsa.ImportFromPem(dto.ChavePublicaPem.ToCharArray());
                    var encryptedBytes = rsa.Encrypt(Encoding.UTF8.GetBytes(dto.Texto), RSAEncryptionPadding.Pkcs1);
                    return Convert.ToBase64String(encryptedBytes);
                }
                catch (Exception ex)
                {
                    return ex.ToString();

                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }
            }
        }

        /// <summary>
        /// Método para critografia com chave publica XML
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public string EncriptXmlRSA(CriptoXmlDTO dto)
        {
            using (var rsa = new RSACryptoServiceProvider((int)RsaSizeEnum.Rsa1024))
            {
                try
                {
                    rsa.FromXmlString(dto.XmlPublico);

                    var encryptedData = rsa.Encrypt(Encoding.UTF8.GetBytes(dto.Texto), true);

                    var base64Encrypted = Convert.ToBase64String(encryptedData);

                    return base64Encrypted;
                }
                catch (Exception ex)
                {
                    return ex.ToString();

                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }
            }
        }

        /// <summary>
        /// Método para descritografia com chave privada PEM
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public string DecriptPemRSA(DescriptPemDTO dto)
        {
            using (var rsa = new RSACryptoServiceProvider((int)RsaSizeEnum.Rsa1024))
            {
                try
                {
                    rsa.ImportFromPem(dto.ChavePrivadaPem.ToCharArray());
                    var decryptedBytes = rsa.Decrypt(Convert.FromBase64String(dto.Texto), RSAEncryptionPadding.Pkcs1);
                    return Encoding.UTF8.GetString(decryptedBytes);
                }
                catch (Exception ex)
                {
                    return ex.ToString();

                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }
            }
        }

        /// <summary>
        /// Método para descritografia com chave privada XML
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public string DecriptXmlRSA(DescriptoXmlDTO dto)
        {
            using (var rsa = new RSACryptoServiceProvider((int)RsaSizeEnum.Rsa1024))
            {
                try
                {
                    rsa.FromXmlString(dto.XmlPrivado);

                    var resultBytes = Convert.FromBase64String(dto.Texto);
                    var decryptedBytes = rsa.Decrypt(resultBytes, true);
                    var decryptedData = Encoding.UTF8.GetString(decryptedBytes);
                    return decryptedData.ToString();
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }
            }
        }
    }
}
