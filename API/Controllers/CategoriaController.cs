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
    public class CategoriaController : BaseApiController{
        
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;
        
        public CategoriaController(IUnitOfWork unitOfWork,IMapper mapper){
            _UnitOfWork = unitOfWork;
            _Mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<CategoriaDto>>> Get(){
            var categorias = await _UnitOfWork.Categorias!.GetAllAsync();
            return _Mapper.Map<List<CategoriaDto>>(categorias);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CategoriaDto>> Get(string id)
        {
            var categoria = await _UnitOfWork.Categorias!.GetByIdAsync(id);
            if (categoria == null){
                return NotFound();
            }
            return _Mapper.Map<CategoriaDto>(categoria);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Categoria>> Post(CategoriaDto categoriaDto){
            var categoria = _Mapper.Map<Categoria>(categoriaDto);
            _UnitOfWork.Categorias!.Add(categoria);
            await _UnitOfWork.SaveAsync();
            if (categoria == null)
            {
                return BadRequest();
            }
            categoriaDto.Nombre = categoria.NombreCategoria;
            return CreatedAtAction(nameof(Post),new {id= categoriaDto.Nombre}, categoriaDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CategoriaDto>> Put(string id, [FromBody]CategoriaDto categoriaDto){
            if(categoriaDto == null)
                return NotFound();
            var categorias = _Mapper.Map<Categoria>(categoriaDto);
            _UnitOfWork.Categorias!.Update(categorias);
            await _UnitOfWork.SaveAsync();
            return categoriaDto;
            
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(string id){
            var categoria = await _UnitOfWork.Categorias!.GetByIdAsync(id);
            if(categoria == null){
                return NotFound();
            }
            _UnitOfWork.Categorias.Remove(categoria);
            await _UnitOfWork.SaveAsync();
            return NoContent();
        }

}


