using AccountOne.Application.Features.Items.Commands.CreateItem;
using AccountOne.Application.Features.Items.Queries.GetAllItems;
using AccountOne.Domain.Entities;
using AutoMapper;

namespace AccountOne.Application.Mappings;

public class GeneralProfile : Profile{
    public GeneralProfile()
    {
        CreateMap<Item,GetAllItemViewModel>().ReverseMap();
        CreateMap<CreateItemCommand,Item>();
        CreateMap<GetAllItemQuery,GetAllProductsParameter>();
    }
}