using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagment.DataContext;
using TaskManagment.DTO;
using TaskManagment.Entities;
using TaskManagment.UnitOfWork;


namespace TaskManagment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PersonController(AppDbContext context, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _context = context;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPerson()
        {
            var persons = await _context.Persons.ToListAsync();
            var personDto = _mapper.Map<List<PersonDto>>(persons);
            return Ok(personDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPerson(int id)
        {
            var personDto = await _context.Persons.FindAsync(id);

            if (personDto == null)
            {
                return BadRequest("Id Tapilmadi");
            }

            var personMap = _mapper.Map<PersonDto>(personDto);
            return Ok(personMap);
        }

        [HttpPost]
        public async Task<IActionResult> AddPerson(PersonDto personDto)
        {
            var personAdd = _mapper.Map<Person>(personDto);

            await _context.Persons.AddAsync(personAdd);

           _unitOfWork.CommitAsync();

            var personDtos = _mapper.Map<PersonDto>(personAdd);

            return Ok(personDtos);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePerson(PersonDto personDto)
        {
            var updatePerson = _mapper.Map<Person>(personDto);

            _context.Persons.Update(updatePerson);

            await _context.SaveChangesAsync();

            var personDtoss = _mapper.Map<PersonDto>(personDto);

            return Ok(personDtoss);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var personDelete = await _context.Persons.FindAsync(id);

            if (personDelete == null)
            {
                return BadRequest("Id Yoxdur");
            }

            _context.Persons.Remove(personDelete);
            await _context.SaveChangesAsync();
            return Ok(personDelete);
        }
    }
}
