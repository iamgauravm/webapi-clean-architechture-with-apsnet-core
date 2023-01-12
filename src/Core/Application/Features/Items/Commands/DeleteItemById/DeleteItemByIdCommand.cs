using AccountOne.Application.Exceptions;
using AccountOne.Application.Interfaces.Repositories;
using AccountOne.Application.ResponseWrappers;
using AutoMapper;
using MediatR;

namespace AccountOne.Application.Features.Items.Commands.DeleteItemById;

public partial class DeleteItemByIdCommand :IRequest<Response<int>>{
    public int Id { get; set; }
}


public class DeleteItemByIdCommandHandeler : IRequestHandler<DeleteItemByIdCommand, Response<int>>
{
    private readonly IItemRepositoryAsync _itemRepository;
    public DeleteItemByIdCommandHandeler(IItemRepositoryAsync itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public async Task<Response<int>> Handle(DeleteItemByIdCommand command, CancellationToken cancellationToken)
    {
        var item = await _itemRepository.GetByIdAsync(command.Id);
        if(item==null) throw new ApiException("Item not found.");
        await _itemRepository.DeleteAsync(item);
        return new Response<int>(item.Id);
    }
}