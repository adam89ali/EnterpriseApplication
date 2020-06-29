using EnterpriseApplication.UI.Models;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace EnterpriseApplication.UI.Filters
{
    public class GlobalExceptionHandler : ExceptionFilterAttribute//IExceptionFilter
    {

        private readonly IDictionary<Type, Action<ExceptionContext>> _exceptionHandlers;

        public GlobalExceptionHandler()
        {
            // Register known exception types and handlers.
            _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>
            {
                { typeof(ValidationException), HandleValidationException },
              //  { typeof(NotFoundException), HandleNotFoundException },
            };
        }

        public override void OnException(ExceptionContext context)
        {
            HandleException(context);

            base.OnException(context);
        }

        private void HandleException(ExceptionContext context)
        {
            Type type = context.Exception.GetType();
            if (_exceptionHandlers.ContainsKey(type))
            {
                _exceptionHandlers[type].Invoke(context);
                return;
            }

            HandleUnknownException(context);
        }

        private void HandleUnknownException(ExceptionContext context)
        {
            var details = new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "An error occurred while processing your request.",
                Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1"
            };

            context.Result = new ObjectResult(details)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };

            context.ExceptionHandled = true;
        }

        private void HandleValidationException(ExceptionContext context)
        {
         const string RequestedWithHeader = "X-Requested-With";
         const string XmlHttpRequest = "XMLHttpRequest";
         var exception = context.Exception as ValidationException;

            // in case of ajax request we need to cater exception handling in json 
            if(context.HttpContext.Request.Headers[RequestedWithHeader] == XmlHttpRequest)
            {
                List<ErrorViewModel> errors = new List<ErrorViewModel>(exception.Errors.Count());
                foreach(var error in exception.Errors) 
                { 
                    errors.Add(new ErrorViewModel { errorMessage = error.ErrorMessage });
                }
                context.Result = new JsonResult(errors)
                {
                    StatusCode = (int) HttpStatusCode.BadRequest
                };
            }
            else
            {
                foreach (var error in exception.Errors)
                {
                    context.ModelState.AddModelError(string.Empty, error.ErrorMessage);
                }
                context.Result = new ViewResult(){};
            }
           // context.Result = new BadRequestObjectResult(details);
            context.ExceptionHandled = true;
        }

        //private void HandleNotFoundException(ExceptionContext context)
        //{
        //    var exception = context.Exception as NotFoundException;

        //    var details = new ProblemDetails()
        //    {
        //        Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4",
        //        Title = "The specified resource was not found.",
        //        Detail = exception.Message
        //    };

        //    context.Result = new NotFoundObjectResult(details);

        //    context.ExceptionHandled = true;
        //}
        
        
        
        //public void OnException(ExceptionContext context)
        //{

        //    if(context.Exception is ValidationException)
        //    {
        //        var ex = context.Exception as ValidationException;
        //        foreach (var error in ex.Errors)
        //        {
        //            context.ModelState.AddModelError(string.Empty, error.ErrorMessage);
        //            context.Result = new ViewResult()
        //            {

        //            };
        //        }
        //    }
        //    context.ExceptionHandled = true;
        //    //context.ModelState.AddModelError(string.Empty, "test");
        //}
    }
}
