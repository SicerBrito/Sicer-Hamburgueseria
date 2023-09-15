using API.Dtos;
using AutoMapper;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    public class ConsultasController : BaseApiController{
        
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;
        
        public ConsultasController(IUnitOfWork unitOfWork,IMapper mapper){
            _UnitOfWork = unitOfWork;
            _Mapper = mapper;
        }


        // [HttpGet("menorStock")]
        // [Authorize]
        // [MapToApiVersion("1.0")]
        // [ProducesResponseType(StatusCodes.Status200OK)]
        // [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // public async Task<ActionResult<IEnumerable<IngredienteDto>>> MenorStock(){
        // var stocks = await _UnitOfWork.Ingredientes!.GetAllAsync(x => x.Stock < 400);
        //     return _Mapper.Map<List<IngredienteDto>>(stocks);
        // }

        [HttpGet]
        [Authorize]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<IngredienteDto>>> Get(){
            var stock = await _UnitOfWork.Ingredientes!.GetAllAsync();
            if (true){
                return _Mapper.Map<List<IngredienteDto>>(stock);
            }
            }
        

        // [HttpGet("vegetariana")]
        // [Authorize]
        // [MapToApiVersion("1.0")]
        // [ProducesResponseType(StatusCodes.Status200OK)]
        // [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // public async Task<IEnumerable<HamburgesaDto>> Vegetariana(){
        //     var vegetariana = await _UnitOfWork.Hamburgesas!.GetAllAsync(x => x.Descripcion == "Vegetariana");
        //     return _Mapper.Map<List<HamburgesaDto>>(vegetariana);
        // }

        // [HttpGet("especialidad-carne")]
        // [Authorize]
        // [MapToApiVersion("1.0")]
        // [ProducesResponseType(StatusCodes.Status200OK)]
        // [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // public async Task<IEnumerable<HamburgesaDto>> Especialidad(){
        //     var vegetariana = await _UnitOfWork.Hamburgesas!.GetAllAsync(x => x.Categoria.Descripcion == "Carnes");
        //     return _Mapper.Map<List<HamburgesaDto>>(vegetariana);
        // }
            

    }

    
