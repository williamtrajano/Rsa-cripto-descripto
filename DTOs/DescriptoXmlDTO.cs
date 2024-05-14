namespace rsa_cripto_descripto.DTOs
{
    /// <summary>
    /// DTO para descriptografar o texto com chave XML privada
    /// </summary>
    public class DescriptoXmlDTO
    {
        public string Texto { get; set; }
        public string XmlPrivado { get; set; }
    }
}
