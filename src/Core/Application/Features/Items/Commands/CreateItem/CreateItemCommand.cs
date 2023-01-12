using AccountOne.Application.Interfaces.Repositories;
using AccountOne.Application.ResponseWrappers;
using AccountOne.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AccountOne.Application.Features.Items.Commands.CreateItem;

public partial class CreateItemCommand :IRequest<Response<int>>{
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? Unit { get; set; }
    public string ItemType { get; set; }
    public decimal SellingPrice { get; set; }
    public decimal CostPrice { get; set; } 
}


public class CreateItemCommandHandeler : IRequestHandler<CreateItemCommand, Response<int>>
{
    private readonly IItemRepositoryAsync _itemRepository;
    private readonly IMapper _mapper;
    public CreateItemCommandHandeler(IItemRepositoryAsync itemRepository,IMapper mapper)
    {
        _itemRepository = itemRepository;
        _mapper = mapper;
    }

    public async Task<Response<int>> Handle(CreateItemCommand request, CancellationToken cancellationToken)
    {
        var item = _mapper.Map<Item>(request);
        await _itemRepository.AddAsync(item);
        return new Response<int>(item.Id);
    }
}