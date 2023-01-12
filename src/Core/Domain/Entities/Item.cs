using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AccountOne.Domain.Common;

namespace AccountOne.Domain.Entities;

public class Item : AuditableBaseEntity {
    [Required]
    [MaxLength(250)]
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? Unit { get; set; }
    [Required,DefaultValue("Goods")]
    public string ItemType { get; set; }
    [DefaultValue(0)]
    [Column(TypeName = "decimal(18,3)")]
    public decimal? SellingPrice { get; set; }
    [DefaultValue(0)]
    [Column(TypeName = "decimal(18,3)")]
    public decimal? CostPrice { get; set; }    
}