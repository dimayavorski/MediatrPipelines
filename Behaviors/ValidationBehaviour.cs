using System;
using FluentValidation;
using LanguageExt.Common;
using MediatR;

namespace MideiatrPipelinesApi.Behaviors
{
	public class ValidationBehaviour<TRequest, TResult>: IPipelineBehavior<TRequest,TResult> where TRequest : IRequest<TResult>
    {
        private readonly IValidator<TRequest> _validator;
        public ValidationBehaviour(IValidator<TRequest> validator)
        {
            _validator = validator;
        }
            
        public async Task<TResult> Handle(TRequest request, RequestHandlerDelegate<TResult> next, CancellationToken cancellationToken)
        {   
            await _validator.ValidateAndThrowAsync(request);
           
            return await next();
        }
    }
}

