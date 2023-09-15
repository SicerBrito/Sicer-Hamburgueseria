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
    public class ChefController : BaseApiController{
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;
        
        public ChefController(IUnitOfWork unitOfWork,IMapper mapper){
            _UnitOfWork = unitOfWork;
            _Mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ChefDto>>> Get(){
            var chefs = await _UnitOfWork.Chefs!.GetAllAsync();
            return _Mapper.Map<List<ChefDto>>(chefs);
        }

        [HttpGet]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<ChefComplementsDto>>> Get11([FromQuery] Params chefParams)
        {
            var chef = await _UnitOfWork.Chefs!.GetAllAsync(chefParams.PageIndex,chefParams.PageSize,chefParams.Search);
            var lstChefsDto = _Mapper.Map<List<ChefComplementsDto>>(chef.registros);
            return new Pager<ChefComplementsDto>(lstChefsDto,chef.totalRegistros,chefParams.PageIndex,chefParams.PageSize,chefParams.Search);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ChefDto>> Get(string id)
        {
            var chef = await _UnitOfWork.Chefs!.GetByIdAsync(id);
            if (chef == null){
                return NotFound();
            }
            return _Mapper.Map<ChefDto>(chef);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Chef>> Post(ChefDto ChefDto){
            var chef = _Mapper.Map<Chef>(ChefDto);
            _UnitOfWork.Chefs!.Add(chef);
            await _UnitOfWork.SaveAsync();
            if (chef == null)
            {
                return BadRequest();
            }
            ChefDto.Id = chef.Id;
            return CreatedAtAction(nameof(Post),new {id= ChefDto.Id}, ChefDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ChefDto>> Put(string id, [FromBody]ChefDto ChefDto){
            if(ChefDto == null)
                return NotFound();
            var chefs = _Mapper.Map<Chef>(ChefDto);
            _UnitOfWork.Chefs!.Update(chefs);
            await _UnitOfWork.SaveAsync();
            return ChefDto;
            
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(string id){
            var chef = await _UnitOfWork.Chefs!.GetByIdAsync(id);
            if(chef == null){
                return NotFound();
            }
            _UnitOfWork.Chefs.Remove(chef);
            await _UnitOfWork.SaveAsync();
            return NoContent();
        }
    }
