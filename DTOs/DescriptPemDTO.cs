namespace rsa_cripto_descripto.DTOs
{
    /// <summary>
    /// DTO para descritografar com chave PEM
    /// </summary>
    public class DescriptPemDTO
    {
        public string Texto { get; set; }
        public string ChavePrivadaPem { get; set; }
    }
}
