using AccountOne.Application.Exceptions;
using AccountOne.Application.Interfaces.Repositories;
using AccountOne.Application.ResponseWrappers;
using AccountOne.Domain.Entities;
using MediatR;

namespace AccountOne.Application.Features.Items.Queries.GetItemById;
public class GetItemByIdQuery : IRequest<Response<Item>>{
    public int Id { get; set; }
}

public class GetItemByIdQueryHandler : IRequestHandler<GetItemByIdQuery, Response<Item>>
{
    private readonly IItemRepositoryAsync _itemRepository;
    public GetItemByIdQueryHandler(IItemRepositoryAsync itemRepository)
    {
        _itemRepository = itemRepository;
    }
    public async Task<Response<Item>> Handle(GetItemByIdQuery request, CancellationToken cancellationToken)
    {
        var item = await _itemRepository.GetByIdAsync(request.Id);
        if(item==null) throw new ApiException("Item not found.");        
        return new Response<Item>(item);
    }
}