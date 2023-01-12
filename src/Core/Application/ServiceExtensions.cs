
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using MediatR;
using AccountOne.Application.Behaviours;

namespace AccountOne.Application;
public static class ServiceExtensions
{
    public static void AddApplication(this IServiceCollection servies){
        servies.AddAutoMapper(Assembly.GetExecutingAssembly());
        servies.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        servies.AddMediatR(Assembly.GetExecutingAssembly());       
        servies.AddTransient(typeof(IPipelineBehavior<,>),typeof(ValidationBehavior<,>));
    }
}
