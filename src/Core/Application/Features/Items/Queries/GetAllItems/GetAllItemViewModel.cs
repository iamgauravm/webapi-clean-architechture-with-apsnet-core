namespace AccountOne.Application.Features.Items.Queries.GetAllItems;

public class GetAllItemViewModel{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? Unit { get; set; }
    public string ItemType { get; set; }
    public decimal SellingPrice { get; set; }
    public decimal CostPrice { get; set; } 
}