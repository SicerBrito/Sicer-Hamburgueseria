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
    public class HamburgesaController : BaseApiController{
        
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;
        
        public HamburgesaController(IUnitOfWork unitOfWork,IMapper mapper){
            _UnitOfWork = unitOfWork;
            _Mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<HamburgesaDto>>> Get(){
            var hamburgesas = await _UnitOfWork.Hamburgesas!.GetAllAsync();
            return _Mapper.Map<List<HamburgesaDto>>(hamburgesas);
        }

        [HttpGet]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<HamburgesaComplementsDto>>> Get11([FromQuery] Params hamburgesaParams)
        {
            var hamburgesa = await _UnitOfWork.Hamburgesas!.GetAllAsync(hamburgesaParams.PageIndex,hamburgesaParams.PageSize,hamburgesaParams.Search);
            var lstHamburgesasDto = _Mapper.Map<List<HamburgesaComplementsDto>>(hamburgesa.registros);
            return new Pager<HamburgesaComplementsDto>(lstHamburgesasDto,hamburgesa.totalRegistros,hamburgesaParams.PageIndex,hamburgesaParams.PageSize,hamburgesaParams.Search);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<HamburgesaDto>> Get(string id)
        {
            var hamburgesa = await _UnitOfWork.Hamburgesas!.GetByIdAsync(id);
            if (hamburgesa == null){
                return NotFound();
            }
            return _Mapper.Map<HamburgesaDto>(hamburgesa);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Hamburgesa>> Post(HamburgesaDto hamburgesaDto){
            var hamburgesa = _Mapper.Map<Hamburgesa>(hamburgesaDto);
            _UnitOfWork.Hamburgesas!.Add(hamburgesa);
            await _UnitOfWork.SaveAsync();
            if (hamburgesa == null)
            {
                return BadRequest();
            }
            hamburgesaDto.Id = hamburgesa.Id;
            return CreatedAtAction(nameof(Post),new {id= hamburgesaDto.Id}, hamburgesaDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<HamburgesaDto>> Put(string id, [FromBody]HamburgesaDto hamburgesaDto){
            if(hamburgesaDto == null)
                return NotFound();
            var hamburgesas = _Mapper.Map<Hamburgesa>(hamburgesaDto);
            _UnitOfWork.Hamburgesas!.Update(hamburgesas);
            await _UnitOfWork.SaveAsync();
            return hamburgesaDto;
            
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(string id){
            var hamburgesa = await _UnitOfWork.Hamburgesas!.GetByIdAsync(id);
            if(hamburgesa == null){
                return NotFound();
            }
            _UnitOfWork.Hamburgesas.Remove(hamburgesa);
            await _UnitOfWork.SaveAsync();
            return NoContent();
        }

    }
