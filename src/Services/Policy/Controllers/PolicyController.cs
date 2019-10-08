namespace Policy.WebApi.Controllers
{
    using Policy.WebApi.Models;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using Policy.Framework.Domain;
    using Policy.Framework.Services.Interface;
    using Policy.WebApi.Services;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    [Route("api/policy")]
    [ApiController]
    public class PolicyController : ControllerBase
    {
        private readonly IPolicyService _policyService;

        private readonly IVehicleService _vehicleService;

        private readonly IIdentityService _identityService;

        private readonly IServiceService _serviceService;
        private readonly IMapper _mapper;
        

        public PolicyController(IPolicyService transactionService, IIdentityService identityService, IVehicleService vehicleService, IServiceService serviceService, IMapper mapper)
        {
            _policyService = transactionService;
            _identityService = identityService;
            _vehicleService = vehicleService;
            _serviceService = serviceService;
            _mapper = mapper;
        }

        [HttpGet("services")]
        public async Task<ContentResult> GetServices()
        {
            var  serviceList = await _serviceService.List();
            return Content(JsonConvert.SerializeObject(_mapper.Map<ICollection<Service>, ICollection<ServiceModel>>(serviceList)), "application/json");
        }

        [HttpPost("vehicle")]
        public async Task<IActionResult> CreateVehicle([FromBody] VehicleModel vehicleModel)
        {
            var accountTransaction = _mapper.Map<Vehicle>(vehicleModel);
            var result = _vehicleService.Create(accountTransaction);
            return Created(string.Empty, _mapper.Map<VehicleModel>(result));
        }

         [HttpPost("policy")]
        public async Task<IActionResult> CreatePolicy([FromBody] PolicyModel policyModel)
        {
            var accountTransaction = _mapper.Map<Policy>(policyModel);
            var result = await _policyService.Create(accountTransaction);
            return Created(string.Empty, _mapper.Map<PolicyModel>(result));
        }

    }
}
