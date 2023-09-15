using API.Dtos;
using API.Helpers;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

    [ApiVersion("1.0")]
    public class EjemploController{

        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;

        public EjemploController (IUnitOfWork unitOfWork,IMapper mapper){
            _UnitOfWork = unitOfWork;
            _Mapper = mapper;
        }

        [HttpGet]
        //[Authorize]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Ejemplo>>> Get(){
            var records = await _UnitOfWork.EjemploInterfaces!.GetAllAsync();
            return Ok(records);
        }

    private ActionResult<IEnumerable<Ejemplo>> Ok(IEnumerable<Ejemplo> records)
    {
        throw new NotImplementedException();
    }

    [HttpGet("{id}")]
        //[Authorize]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EjemploDto>> Get(int id){
            var record = await _UnitOfWork.EjemploInterfaces!.GetByIdAsync(id);
            return _Mapper.Map<EjemploDto>(record);
        }

        [HttpGet]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<EjemploDto>>> Get11([FromQuery] PageParam param){
            IPager<ContactType> pager = await _UnitOfWork.EjemploInterfaces!.Find(param);
            pager.Records = (IEnumerable<ContactType>)_Mapper.Map<List<EjemploDto>>(pager.Records);        
            return CreatedAtAction("ContactType",pager);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EjemploDto>> Post(EjemploDto recordDto){
        var record = _Mapper.Map<ContactType>(recordDto);
        _UnitOfWork.EjemploInterfaces!.Add(record);
        await _UnitOfWork.SaveChanges();
        return CreatedAtAction(nameof(Post),new {id= record.IdPk, recordDto});
        }

        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EjemploDto>> Put(int id, [FromBody]EjemploDto? recordDto){
        if(recordDto == null)
            return NotFound();
        var record = _Mapper.Map<ContactType>(recordDto);
        record.IdPk = id;
        _UnitOfWork.EjemploInterfaces!.Update(record);
        await _UnitOfWork.SaveChanges();
        return recordDto;
        }

        [HttpDelete("{id}")]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id){
        var record = await _UnitOfWork.EjemploInterfaces!.FindByIntId(id);
        if(record == null){
            return NotFound();
        }
        _UnitOfWork.EjemploInterfaces.Remove(record);
        await _UnitOfWork.SaveChanges();
        return NoContent();
        }
    }






// Trata de unir ambas, pero la verdad no pude, trata mañana

    // // [GET]
    // [HttpGet]
    // [ProducesResponseType(StatusCodes.Status200OK)]
    // [ProducesResponseType(StatusCodes.Status400BadRequest)]
    // public async Task<ActionResult<IEnumerable<Contact>>> Get()
    // {
    //     var contacts = await _unitOfWork.Contacts.GetAllAsync();
    //     return Ok(contacts);
    // }
    // [HttpGet("{id}")]
    // [ProducesResponseType(StatusCodes.Status200OK)]
    // [ProducesResponseType(StatusCodes.Status400BadRequest)]
    // public async Task<IActionResult> GetId(int id)
    // {
    //     var contacts = await _unitOfWork.Contacts.GetByIdAsync(id);
    //     return Ok(contacts);
    // }
    // // [POST]
    // [HttpPost]
    // [ProducesResponseType(StatusCodes.Status201Created)]
    // [ProducesResponseType(StatusCodes.Status400BadRequest)]
    // public async Task<ActionResult<Contact>> Post(Contact contact){
    //     this._unitOfWork.Contacts.Add(contact);
    //     await _unitOfWork.SaveAsync();
    //     if (contact == null)
    //     {
    //         return BadRequest();
    //     }
    //     return CreatedAtAction(nameof(Post), new {id = contact.Id}, contact); 
    // }
    // // [PUT]
    // [HttpPut("{id}")]
    // [ProducesResponseType(StatusCodes.Status200OK)]
    // [ProducesResponseType(StatusCodes.Status404NotFound)]
    // [ProducesResponseType(StatusCodes.Status400BadRequest)]
    // public async Task<ActionResult<Contact>> Put(int id, [FromBody]Contact contact){
    //     if(contact == null)
    //         return NotFound();
    //     _unitOfWork.Contacts.Update(contact);
    //     await _unitOfWork.SaveAsync();
    //     return contact;
    // }
    // // [DELETE]
    // [HttpDelete("{id}")]
    // [ProducesResponseType(StatusCodes.Status204NoContent)]
    // [ProducesResponseType(StatusCodes.Status404NotFound)]
    // public async Task<IActionResult> Delete(int id){
    //     var contact = await _unitOfWork.Contacts.GetByIdAsync(id);
    //     if(contact == null){
    //         return NotFound();
    //     }
    //     _unitOfWork.Contacts.Remove(contact);
    //     await _unitOfWork.SaveAsync();
    //     return NoContent();
    // }