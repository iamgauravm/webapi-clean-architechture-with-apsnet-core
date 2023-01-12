using AccountOne.Application.Exceptions;
using AccountOne.Application.Interfaces.Repositories;
using AccountOne.Application.ResponseWrappers;
using AccountOne.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AccountOne.Application.Features.Items.Queries.GetAllItems;
public class GetAllItemQuery : IRequest<PagedResponse<IEnumerable<GetAllItemViewModel>>>{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}

public class GetAllItemQueryHandler : IRequestHandler<GetAllItemQuery, PagedResponse<IEnumerable<GetAllItemViewModel>>>
{
    private readonly IItemRepositoryAsync _itemRepository;
    private readonly IMapper _mapper;
    public GetAllItemQueryHandler(IItemRepositoryAsync itemRepository,IMapper mapper)
    {
        _itemRepository = itemRepository;
        _mapper = mapper;
    }
    public async Task<PagedResponse<IEnumerable<GetAllItemViewModel>>> Handle(GetAllItemQuery request, CancellationToken cancellationToken)
    {
        var validFilter = _mapper.Map<GetAllProductsParameter>(request);
        var items = await _itemRepository.GetPagedReponseAsync(validFilter.PageNumber,validFilter.PageSize);
        var result =  _mapper.Map<IEnumerable<GetAllItemViewModel>>(request);
        return new PagedResponse<IEnumerable<GetAllItemViewModel>>(result,validFilter.PageNumber,validFilter.PageSize);
    }
}