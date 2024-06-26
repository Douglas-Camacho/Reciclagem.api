﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reciclagem.api.Services;
using Reciclagem.api.Models;
using Reciclagem.api.ViewModel;
using AutoMapper;


namespace Reciclagem.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CidadaoController : ControllerBase
    {
        private readonly ICidadaoService _cidadaoService;
        private readonly IMapper _mapper;

        public CidadaoController(ICidadaoService cidadaoService, IMapper _mapper)
        {
            _cidadaoService = cidadaoService;
            _mapper = mapper1;
        }


        //busca por todos os cidadãos cadastrados
        [HttpGet]
        public ActionResult<IEnumerable<CidadaoViewModel>> Get()
        {
            var lista = _cidadaoService.ListarCidadaos();
            var viewModelList = _mapper.Map<IEnumerable<CidadaoViewModel>>(lista);

            if (viewModelList == null) 
            {
                return NoContent();
            }
            return Ok(viewModelList);
        }

        //busca por um único cidadão
        [HttpGet("{id}")]
        public ActionResult<CidadaoViewModel> Get([FromRoute]int id)
        {
            var model = _cidadaoService.ObterCidadaoPorId(id);
            

            if (model == null)
            {
                return NotFound();
            }
            else 
            {
                var viewModel = _mapper.Map<IEnumerable<CidadaoViewModel>>(model);
                return Ok(viewModel);
            }
        }

        //Cria um cidadão
        [HttpPost]
        public ActionResult Post([FromBody]CidadaoViewModel viewModel)
        {
            var model = _mapper.Map<CidadaoViewModel>(viewModel);
            _cidadaoService.CriarCidadao(model);

            return CreatedAtAction(nameof(Get), new {id = model.CidadaoId}, model);
        }

        //Deleta um cidadão
        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id) 
        {
            _cidadaoService.DeletarCidadao(id);
            return NoContent();
        }
    }
}