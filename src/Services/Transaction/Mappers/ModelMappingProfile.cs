﻿using Transaction.WebApi.Models;
using AutoMapper;
using Transaction.Framework.Extensions;
using Transaction.Framework.Domain;
using Transaction.Framework.Types;

namespace Transaction.WebApi.Mappers
{
    public class ModelMappingProfile : Profile
    {
        public ModelMappingProfile()
        {
            CreateMap<TransactionModel, AccountTransaction>()
                 .AfterMap<SetIdentityAction>()
                 .ForAllMembers(opts => opts.Ignore());
               
            CreateMap<TransactionResult, TransactionResultModel>()
                .ForMember(dest => dest.Balance, opt => opt.MapFrom(o => o.Balance.Amount.ToString("N")))
                .ForMember(dest => dest.Currency, opt => opt.MapFrom(o => o.Balance.Currency.ToString())); 
        }
    }
}
