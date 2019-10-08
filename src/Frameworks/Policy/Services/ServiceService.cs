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
    using System.Collections.Generic;

    public class ServiceService : IServiceService
    {

        private readonly IServiceRepository _serviceRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public ServiceService(IServiceRepository serviceRepository, IMapper mapper, ILogger<PolicyService> logger)
        {
            _serviceRepository = serviceRepository ?? throw new ArgumentNullException(nameof(serviceRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<ICollection<Domain.Service>> List()
        {
            var serviceResult = await _serviceRepository.List();
            return _mapper.Map<ICollection<Domain.Service>>(serviceResult);
        }
    }
}
