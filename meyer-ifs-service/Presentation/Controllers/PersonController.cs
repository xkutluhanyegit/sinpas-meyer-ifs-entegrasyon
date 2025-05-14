using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    //[Authorize]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        ICompanyPersonService _companyPersonService;
        public PersonController(ICompanyPersonService companyPersonService)
        {
            _companyPersonService = companyPersonService;
        }

        [HttpGet("getall_person")]
        public async Task<IActionResult> GetAllPerson()
        {
            var result = await _companyPersonService.GetAllCompanyPerson();
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        

        
    }
}