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
    [EnableCors]
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        ICompanyPersonService _companyPersonService;
        ICompanyPersonImgService _companyPersonImgService;
        public PersonController(ICompanyPersonService companyPersonService,ICompanyPersonImgService companyPersonImgService)
        {
            _companyPersonService = companyPersonService;
            _companyPersonImgService = companyPersonImgService;
        }

        [HttpGet("getall_person")]
        public async Task<IActionResult> GetAllPerson()
        {
            var result = await _companyPersonService.GetAllCompanyPerson();
            return Ok(result);
        }

        

        
    }
}