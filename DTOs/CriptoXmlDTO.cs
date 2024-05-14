namespace rsa_cripto_descripto.DTOs
{
    /// <summary>
    /// DTO para encriptar o texto com chave XML publica
    /// </summary>
    public class CriptoXmlDTO
    {
        public string Texto { get; set; }
        public string XmlPublico { get; set; }
    }
}
