﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Application.Features.Hotel.Queries.GetListHotels
{
    public class GetHotelsListQuery : IRequest<List<HotelsVm>>
    {

    }
}
