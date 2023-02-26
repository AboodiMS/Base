using Base.Modules.Companies.Domain.DTO.Company;
using Base.Modules.Companies.Domain.IServices;
using Base.Shared.Controllers;
using Base.Shared.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Transactions;
using Dtmcli;

namespace Base.Modules.Companies.Api.Controllers
{
    [ApiController]
    [Route(Extensions.BasePath+"/[controller]")]
    [ApiExplorerSettings(GroupName = Extensions.BasePath)]
    public class CompanyController : MasterController
    {
        private readonly ICompaniesService _companiesService;

        public CompanyController(ICompaniesService companiesService)
        {
            _companiesService = companiesService;
        }
       
        [HttpGet]
        [Route("GetAll")]
        [AllowAnonymous]
        public async Task<ActionResult<List<GetCompanyResponseDto>>> GetAll()
            => await _companiesService.GetAll();


        //يجب التحقق من الصلاحيات
        //[HttpGet]
        //[Route("GetById")]
        //[AllowAnonymous]
        //public async Task<ActionResult<GetCompanyDetailsResponseDto>> GetById([FromForm][Required] Guid id)
        //    => await _companiesService.GetById(id);


        //تفعيل هذه الخدمة في المستقبل
        //[HttpPost]
        //[Route("Create")]
        //public async Task<ActionResult> Create([FromForm] CreateCompanyRequestDto dto)
        //{
        //    dto.Id = Guid.NewGuid();
        //    dto.UserId = _userId;
        //    await _companiesService.Create(dto);
        //    return Ok(dto.Id);
        //}


        //[HttpPost]
        //[Route("TestTransaction")]
        //public async Task<ActionResult> TestTransaction([FromForm] object dto)
        //{
        //    //TransactionManager.DistributedTransactionStarted += (sender, eventArgs) =>
        //    //{
        //    //    Console.WriteLine("Promoted to distributed transaction!");
        //    //};

        //    var saga = new Saga(dtmClient, gid)
        //.Add(outApi + "/TransOut", outApi + "/TransOutCompensate", userOutReq)
        //.Add(inApi + "/TransIn", inApi + "/TransInCompensate", userInReq)
        //.EnableWaitResult()
        //;
        //    return Ok();
        //}

        [HttpPut]
        [Route("Update")]
        [AuthorizationAction]
        public async Task<ActionResult> Update([FromForm] UpdateCompanyRequestDto dto)
        {



            dto.UserId = _userId;
            await _companiesService.Update(dto);
            return Ok();
        }

        [HttpPatch]
        [Route("UpdateActiveSections")]
        [AuthorizationAction]
        public async Task<ActionResult> UpdateActiveSections([FromForm] UpdateActiveSectionsCompanyRequestDto dto)
        {
            dto.UserId = _userId;
            await _companiesService.UpdateActiveSections(dto);
            return Ok();
        }

        //تفعيل هذه الخدمة في المستقبل
        //[HttpDelete]
        //[Route("Delete")]
        //[AuthorizationAction]
        //public async Task<ActionResult> Delete([FromForm][Required] Guid id)
        //{
        //    await _companiesService.Delete(id,_userId);
        //    return Ok();
        //}

    }
}
