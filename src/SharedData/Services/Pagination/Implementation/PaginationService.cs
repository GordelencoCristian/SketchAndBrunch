﻿using AutoMapper;
using SharedData.Models.Pagination;
using System.Linq.Expressions;

namespace SharedData.Services.Pagination.Implementation
{
    public partial class PaginationService : IPaginationService
    {
        private readonly IMapper _mapper;
        public PaginationService(IMapper mapper)
        {
            _mapper = mapper;
        }

        //public PaginatedList<T> PaginatedResults<T>(IQueryable<T> queryableList, PaginatedQueryParameter pagedQuery, Expression<Func<T, string>>[] membersToSearch = null)
        //{
        //    //queryableList = queryableList.FilterAndSort(pagedQuery, membersToSearch);

        //    return PaginatedList<T>.Create(queryableList, pagedQuery.Page, pagedQuery.ItemsPerPage);
        //}

        //public PaginatedList<TSource, TDestination> PaginatedResults<TSource, TDestination>(IQueryable<TSource> queryableList, PaginatedQueryParameter pagedQuery, Expression<Func<TSource, string>>[] membersToSearch = null)
        //{
        //    //queryableList = queryableList.FilterAndSort(pagedQuery, membersToSearch);

        //    return PaginatedList<TSource, TDestination>.Create(queryableList, pagedQuery.Page, pagedQuery.ItemsPerPage);
        //}

        //public Task<PaginatedModel<TDestination>> MapAndPaginateDistinctModelAsync<TSource, TDestination>(IQueryable<TSource> list, PaginatedQueryParameter query,
        //    Expression<Func<TSource, string>>[] membersToSearch = null)
        //{
        //    throw new NotImplementedException();
        //}

        //public PaginatedModel<TSource> MapAndPaginateModel<TSource>(List<TSource> list, PaginatedQueryParameter pagedQuery, Expression<Func<TSource, string>>[] membersToSearch = null)
        //{
        //    var paginatedList = PaginatedList<TSource>.Create(list, pagedQuery.Page, pagedQuery.ItemsPerPage);

        //    return new PaginatedModel<TSource>(paginatedList);
        //}

        //public Task<PaginatedModel<TDestination>> MapPageAsync<TSource, TDestination>(IQueryable<TSource> queryableList, PaginatedQueryParameter pagedQuery, int count)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<PaginatedModel<TDestination>> MapAndPaginateModelAsync<TSource, TDestination>(IQueryable<TSource> queryableList, PaginatedQueryParameter pagedQuery, Expression<Func<TSource, string>>[] membersToSearch = null)
        //{
        //    //queryableList = queryableList.FilterAndSort(pagedQuery, membersToSearch);

        //    //var paginatedList = await Create<TSource, TDestination>(queryableList, pagedQuery.Page, pagedQuery.ItemsPerPage);

        //    return new PaginatedModel<TDestination>(paginatedList);
        //}

        //public async Task<PaginatedModel<TDestination>> MapAndPaginateDistinctModelAsync<TSource, TDestination>(IQueryable<TSource> queryableList, PaginatedQueryParameter pagedQuery, Expression<Func<TSource, string>>[] membersToSearch = null)
        //{
        //    queryableList = queryableList.FilterAndSort(pagedQuery, membersToSearch);

        //    var paginatedList = await CreateDistict<TSource, TDestination>(queryableList, pagedQuery.Page, pagedQuery.ItemsPerPage);

        //    return new PaginatedModel<TDestination>(paginatedList);
        //}

        //public async Task<PaginatedModel<TDestination>> MapPageAsync<TSource, TDestination>(IQueryable<TSource> queryableList, PaginatedQueryParameter pagedQuery, int count)
        //{
        //    var paginatedList = await CreatePage<TSource, TDestination>(queryableList, pagedQuery.Page, pagedQuery.ItemsPerPage, count);

        //    return new PaginatedModel<TDestination>(paginatedList);
        //}

        //public async Task<PaginatedList<TDestination>> Create<TSource, TDestination>(IQueryable<TSource> source, int pageNumber, int pageSize)
        //{
        //    var count = source.CountAsync();
        //    var skipCount = (pageNumber - 1) * pageSize;

        //    await count;

        //    var items = source.Skip(skipCount).Take(pageSize).ToListAsync();
        //    var mappedItems = _mapper.Map<List<TDestination>>(items.Result).ToList();

        //    return new PaginatedList<TDestination>(mappedItems, count.Result, pageNumber, pageSize);
        //}
    }
}
