using API.Dtos;
using API.Helpers;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    public class IngredienteController : BaseApiController{

        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;
        
        public IngredienteController(IUnitOfWork unitOfWork,IMapper mapper){
            _UnitOfWork = unitOfWork;
            _Mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<IngredienteDto>>> Get(){
            var ingredientes = await _UnitOfWork.Ingredientes!.GetAllAsync();
            return _Mapper.Map<List<IngredienteDto>>(ingredientes);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IngredienteDto>> Get(string id)
        {
            var ingrediente = await _UnitOfWork.Ingredientes!.GetByIdAsync(id);
            if (ingrediente == null){
                return NotFound();
            }
            return _Mapper.Map<IngredienteDto>(ingrediente);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Ingrediente>> Post(IngredienteDto ingredienteDto){
            var ingrediente = _Mapper.Map<Ingrediente>(ingredienteDto);
            _UnitOfWork.Ingredientes!.Add(ingrediente);
            await _UnitOfWork.SaveAsync();
            if (ingrediente == null)
            {
                return BadRequest();
            }
            ingredienteDto.Id = ingrediente.Id;
            return CreatedAtAction(nameof(Post),new {id= ingredienteDto.Id}, ingredienteDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IngredienteDto>> Put(string id, [FromBody]IngredienteDto ingredienteDto){
            if(ingredienteDto == null)
                return NotFound();
            var ingredientes = _Mapper.Map<Ingrediente>(ingredienteDto);
            _UnitOfWork.Ingredientes!.Update(ingredientes);
            await _UnitOfWork.SaveAsync();
            return ingredienteDto;
            
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(string id){
            var ingrediente = await _UnitOfWork.Ingredientes!.GetByIdAsync(id);
            if(ingrediente == null){
                return NotFound();
            }
            _UnitOfWork.Ingredientes.Remove(ingrediente);
            await _UnitOfWork.SaveAsync();
            return NoContent();
        }

    }
