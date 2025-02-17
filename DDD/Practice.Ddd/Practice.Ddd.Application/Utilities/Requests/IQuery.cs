﻿using MediatR;

namespace Practice.Ddd.Application.Utilities.Requests;

/// <summary>
/// Interface of query
/// </summary>
/// <typeparam name="TResponse"></typeparam>
public interface IQuery<TResponse> : IRequest<TResponse> where TResponse : IQueryResult;
