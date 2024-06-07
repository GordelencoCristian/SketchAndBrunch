using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Authorization;

namespace SharedData.Infrastructure
{
    public class RequestAuthorizationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        //private readonly IEnumerable<ICurrentApplicationUserProvider> _currentUserProviders;
        //private readonly UserManager<ApplicationUser> _userManager;
        //private readonly IAuthorizationService _authorizationService;
        //private readonly SignInManager<ApplicationUser> _signInManager;

        //public RequestAuthorizationBehaviour(SignInManager<ApplicationUser> signInManager)
        //{
        //    _signInManager = signInManager;
        //}

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            //var isSignedIn = _signInManager.ClaimsFactory;
            //var user = await _userManager.GetUserAsync(HttpContext.User);

            return await next();
        }
    }
}
