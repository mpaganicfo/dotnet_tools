﻿using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;

namespace Application.Bootstrap;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());

        return services;
    }
}