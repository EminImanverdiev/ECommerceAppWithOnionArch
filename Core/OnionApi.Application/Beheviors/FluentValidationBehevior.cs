using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApi.Application.Beheviors
{
    public class FluentValidationBeheviorz<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TResponse : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator> _validator;

        public FluentValidationBeheviorz(IEnumerable<IValidator> validator)
        {
            _validator = validator;
        }
        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);
            var failtures = _validator
                .Select(v => v.Validate(context))
                .SelectMany(result => result.Errors)
                .GroupBy(x => x.ErrorMessage)
                .Select(x => x.First())
                .Where(f => f != null)
                .ToList();
            if (failtures.Any())
            {
                throw new ValidationException(failtures);
            }
            return next();

        }
    }
}
