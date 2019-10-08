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

    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IPolicyRepository _policyRepository;

        private readonly IServiceRepository _serviceRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public VehicleService(IVehicleRepository vehicleRepository, IPolicyRepository policyRepository, IServiceRepository serviceRepository, IMapper mapper, ILogger<PolicyService> logger)
        {
            _vehicleRepository = vehicleRepository ?? throw new ArgumentNullException(nameof(vehicleRepository));
            _policyRepository = policyRepository ?? throw new ArgumentNullException(nameof(policyRepository));
            _serviceRepository = serviceRepository ?? throw new ArgumentNullException(nameof(serviceRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Vehicle Create(Vehicle vehicle)
        {
           VehicleEntity result = _vehicleRepository.Create(_mapper.Map<VehicleEntity>(vehicle));
           return _mapper.Map<Vehicle>(result);
        }
    }
}
