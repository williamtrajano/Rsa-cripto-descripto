namespace rsa_cripto_descripto.DTOs
{
    /// <summary>
    /// DTO para criptografar com chave PEM
    /// </summary>
    public class CriptoPemDTO
    {
        public string Texto { get; set; }
        public string ChavePublicaPem { get; set; }
    }
}
