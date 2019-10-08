using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Policy.Framework.Domain;
using Policy.WebApi.Models;
using Policy.WebApi.Services;
using Policy.Framework.Extensions;

namespace Policy.WebApi.Mappers
{
    public class SetIdentityAction : IMappingAction<PolicyModel, Policy.Framework.Domain.Policy>
    {
        private readonly IIdentityService _identityService;

        public SetIdentityAction(IIdentityService identityService)
        {
            _identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
        }

        public void Process(PolicyModel source, Policy.Framework.Domain.Policy destination)
        {
            var identity = _identityService.GetIdentity();

            // destination.AccountNumber = identity.AccountNumber;
            // destination.Amount = new Money(source.Amount, identity.Currency.TryParseEnum<Currency>());
        }
    }
}
