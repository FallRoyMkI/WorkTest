﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkTest.Models.Entity;

[Table("OrderLine")]
public class OrderLineEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public Guid OrderId { get; set; }

    [ForeignKey(nameof(OrderId))]
    public OrderEntity Order { get; set; }

    [Required]
    public Guid OrderLineId { get; set; }

    [Required]
    public int Qty { get; set; }
}