﻿using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Carts.UpdateCart
{
    public record UpdateCartCommand(string userId, List<SaleItem> items, bool finish = false) : IRequest<Cart>;
}
