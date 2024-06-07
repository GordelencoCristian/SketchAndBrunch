using FluentValidation;
using MediatR;
using SharedData.Infrastructure.Exceptions;

namespace SharedData.Infrastructure
{
    public class RequestValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public RequestValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);

            var failures = _validators.Select(x => new { Name = x.ToString(), Validator = x })
                .GroupBy(vObj => vObj.Name)
                .Select(vDist => vDist.First())
                .Select(v => v.Validator.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToList();

            if (failures.Count != 0)
            {
                throw new ApplicationRequestValidationException(failures.Select(f =>
                    new ValidationMessage
                    {
                        MessageText = f.ErrorMessage,
                        Code = f.ErrorCode
                    }).ToList());
            }

            return await next();
        }
    }
}
