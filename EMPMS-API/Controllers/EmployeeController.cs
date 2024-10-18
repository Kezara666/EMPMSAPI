using AutoMapper;
using EMPMS_API.IRepository;
using EMPMS_API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EMPMS_API.Data.Employee;
using EMPMS_API.Models.Emails;
namespace EMPMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public EmployeeController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetLocation()
        {
            try
            {
                var employees = await _unitOfWork.Employees.GetAll();
                var results = _mapper.Map<IList<EmployeeDTO>>(employees);
               
                return Ok(results);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, $"Internal Server Error. Please Try Again Later. {ex}");
            }
        }

        // GET: api/employee/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            try
            {
                var employee = await _unitOfWork.Employees.Get(e => e.ID == id);
                if (employee == null) return NotFound();
                var result = _mapper.Map<EmployeeDTO>(employee);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // POST: api/employee
        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeDTO employeeDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var employee = _mapper.Map<EmployeeData>(employeeDTO);
                await _unitOfWork.Employees.Insert(employee);
                await _unitOfWork.Save();
                return StatusCode(201, employee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // PUT: api/employee/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] EmployeeDTO employeeDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var employee = await _unitOfWork.Employees.Get(e => e.ID == id);
                if (employee == null) return NotFound();

                _mapper.Map(employeeDTO, employee);
                _unitOfWork.Employees.Update(employee);
                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        // DELETE: api/employee/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                var employee = await _unitOfWork.Employees.Get(e => e.ID == id);
                if (employee == null) return NotFound();

                _unitOfWork.Employees.Delete(employee);
                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

    }
}
