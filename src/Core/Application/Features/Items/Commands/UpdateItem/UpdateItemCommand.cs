using AccountOne.Application.Exceptions;
using AccountOne.Application.Interfaces.Repositories;
using AccountOne.Application.ResponseWrappers;
using AutoMapper;
using MediatR;

namespace AccountOne.Application.Features.Items.Commands.UpdateItem;

public partial class UpdateItemCommand :IRequest<Response<int>>{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? Unit { get; set; }
    public string ItemType { get; set; }
    public decimal SellingPrice { get; set; }
    public decimal CostPrice { get; set; } 
}


public class UpdateItemCommandHandeler : IRequestHandler<UpdateItemCommand, Response<int>>
{
    private readonly IItemRepositoryAsync _itemRepository;
    public UpdateItemCommandHandeler(IItemRepositoryAsync itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public async Task<Response<int>> Handle(UpdateItemCommand command, CancellationToken cancellationToken)
    {
        var item = await _itemRepository.GetByIdAsync(command.Id);
        if(item==null){
            throw new ApiException("Item not found.");
        }else{
            item.CostPrice = command.CostPrice;
            item.Description = command.Description;
            item.ItemType = command.ItemType;
            item.Name = command.Name;
            item.SellingPrice = command.SellingPrice;
            item.Unit = command.Unit;
            await _itemRepository.UpdateAsync(item);
            return new Response<int>(item.Id);
        }
    }
}