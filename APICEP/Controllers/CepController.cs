﻿using APICEP.Integracao.Interfaces;
using APICEP.Integracao.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APICEP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CepController : ControllerBase
    {
        private readonly IViaCepIntegracao _viaCepIntegracao;
        public CepController(IViaCepIntegracao viaCepIntegracao) 
        {
            _viaCepIntegracao = viaCepIntegracao;
        }

        [HttpGet("{cep}")]
        public async Task<ActionResult<ViaCepResponse>> ListarDadosEndereco(string cep)
        {
           var responseData = await  _viaCepIntegracao.ObterDadosViaCep(cep);

            if (responseData == null) 
            {
                return BadRequest("Cep não Encontrado !");
            }

            return Ok(responseData);
        }
    }
}
