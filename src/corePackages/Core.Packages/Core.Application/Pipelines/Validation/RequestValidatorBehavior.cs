﻿using Core.CrossCuttingConcerns.Exceptions.Types;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationException = Core.CrossCuttingConcerns.Exceptions.Types.ValidationException;

namespace Core.Application.Pipelines.Validation;
//Pipelines comand ve querylere uygulanan midilewarelerdir
public class RequestValidatorBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public RequestValidatorBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        ValidationContext<object> context = new(request);
        IEnumerable<ValidationExceptionModel> errors=_validators
            .Select(validator=>validator.Validate(context))
            .SelectMany(result=>result.Errors)
            .Where(failure=>failure!=null)
            .GroupBy(
                keySelector: p=>p.PropertyName,
                resultSelector: (PropertyName,errors)=>
                new ValidationExceptionModel
                {
                    Property= PropertyName,Errors=errors.Select(e=>e.ErrorMessage)
                }
            ).ToList();
        if (errors.Any())
            throw new ValidationException(errors);
        TResponse response = await next();
        return response;
    }
}
