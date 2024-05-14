using Microsoft.AspNetCore.Mvc;
using rsa_cripto_descripto.DTOs;
using rsa_cripto_descripto.Services;
using System.Collections.Generic;

namespace rsa_cripto_descripto.Controllers
{
    /// <summary>
    /// Controller para criptografia e descriptografia com RSA
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class RsaCriptoController : ControllerBase
    {
        
        /// <summary>
        /// Lista de sites de referencia, documentação microsoft e gerador de chaves PEM online
        /// </summary>
        /// <returns></returns>
        [HttpGet("listarsitesreferencias")]
        public IActionResult ListarSitesReferencias()
        {
            List<string> sites = new()
            {
                "https://github.com/jrnker/CSharp-easy-RSA-PEM",
                "https://cryptotools.net/rsagen",
                "https://learn.microsoft.com/pt-br/dotnet/api/system.security.cryptography.rsa?view=net-8.0"

            };

            return Ok(sites);
        }

        /// <summary>
        /// Gerando o Xml chave privada
        /// </summary>
        /// <param name="recebe"></param>
        /// <returns>Retorna</returns>
        [HttpGet("gerarchavexmlrsa")]
        public IActionResult GerarChaveXmlRsa()
        {
            RSACryptServices rSA = new RSACryptServices();

            return Ok(rSA.GerarChaveXmlRsa());
        }

        /// <summary>
        /// Criptografia com XML
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("criptoxml")]
        public IActionResult CriptoXml([FromBody] CriptoXmlDTO dto)
        {
            RSACryptServices rSA = new RSACryptServices();

            return Ok(rSA.EncriptXmlRSA(dto));
        }

        /// <summary>
        /// Descriptografia com XML
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("descriptoxml")]
        public IActionResult DescriptoXml([FromBody] DescriptoXmlDTO dto)
        {
            RSACryptServices rSA = new RSACryptServices();

            return Ok(rSA.DecriptXmlRSA(dto));
        }

        /// <summary>
        /// Criptografia com chave PEM
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("criptopem")]
        public IActionResult CriptoPem([FromBody] CriptoPemDTO dto)
        {
            RSACryptServices rSA = new RSACryptServices();

            return Ok(rSA.EncriptPemRSA(dto));
        }

        /// <summary>
        /// Descriptografia com chave PEM
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost("descriptopem")]
        public IActionResult DescriptoPem([FromBody] DescriptPemDTO dto)
        {
            RSACryptServices rSA = new RSACryptServices();

            return Ok(rSA.DecriptPemRSA(dto));
        }
    }
}
