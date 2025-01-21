using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Commands.Delete;
using Application.Features.Brands.Commands.Update;
using Application.Features.Brands.Queries.GetById;
using Application.Features.Brands.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Profiles;

public class MappingProfiles:Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateBrandCommand,Brand>().ReverseMap();
        CreateMap<CreatedBrandResponse,Brand>().ReverseMap();
        CreateMap<UpdatedBrandResponse, Brand>().ReverseMap();
        CreateMap<UpdateBrandCommand, Brand>().ReverseMap();
        CreateMap<DeletedBrandResponse, Brand>().ReverseMap();
        CreateMap<DeletedBrandCommand, Brand>().ReverseMap();
        CreateMap<GetListBrandListItemDto, Brand>().ReverseMap();
        CreateMap<GetByIdBrandResponse, Brand>().ReverseMap();
        CreateMap<Paginate<Brand>,GetListResponse<GetListBrandListItemDto>>().ReverseMap();

    }
}
