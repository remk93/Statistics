using FluentValidation;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Statistics.Core.Behaviours
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IValidator<TRequest> _validator;
        public ValidationBehaviour(IValidator<TRequest> validator)
        {
            _validator = validator;
        }
        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
            {
                var message = validationResult.Errors.Select(x => x.ErrorMessage).First();
                throw new Exceptions.ValidationException(message);
            }

            return next();
        }
    }
}
