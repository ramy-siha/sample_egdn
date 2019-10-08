namespace Policy.Framework.Services
{
    using AutoMapper;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Threading.Tasks;
    using Policy.Framework.Data.Entities;
    using Policy.Framework.Data.Interface;
    using Policy.Framework.Domain;
    using Policy.Framework.Services.Interface;
    using Policy.Framework.Extensions;
    using Newtonsoft.Json;

    public class PolicyService : IPolicyService
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IPolicyRepository _policyRepository;

        private readonly IServiceRepository _serviceRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public PolicyService(IVehicleRepository vehicleRepository, IPolicyRepository policyRepository, IServiceRepository serviceRepository, IMapper mapper, ILogger<PolicyService> logger)
        {
            _vehicleRepository = vehicleRepository ?? throw new ArgumentNullException(nameof(vehicleRepository));
            _policyRepository = policyRepository ?? throw new ArgumentNullException(nameof(policyRepository));
            _serviceRepository = serviceRepository ?? throw new ArgumentNullException(nameof(serviceRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Domain.Policy> Create(Policy policy)
        {
            var policyResult = await _policyRepository.Create(_mapper.Map<PolicyEntity>(policy));
            return _mapper.Map<Domain.Policy>(policyResult);
        }
    }
}
