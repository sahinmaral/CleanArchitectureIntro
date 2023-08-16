
using CleanArchitectureIntro.Application.Abstractions;
using CleanArchitectureIntro.Application.Behaviors;
using CleanArchitectureIntro.Application.Services;
using CleanArchitectureIntro.Domain.Entities;
using CleanArchitectureIntro.Domain.Repositories;
using CleanArchitectureIntro.Infrastructure.Authentication;
using CleanArchitectureIntro.Infrastructure.Repositories;
using CleanArchitectureIntro.Infrastructure.Services;
using CleanArchitectureIntro.Persistance.Context;
using CleanArchitectureIntro.Persistance.Services;
using CleanArchitectureIntro.WebAPI.Configurations;
using CleanArchitectureIntro.WebAPI.Extensions;
using CleanArchitectureIntro.WebAPI.Middlewares;
using CleanArchitectureIntro.WebAPI.OptionsSetup;

using FluentValidation;

using MediatR;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace CleanArchitectureIntro.WebAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services
            .InstallServices(
            builder.Configuration,
            builder.Host,
            typeof(IServiceInstaller).Assembly);
        

        var app = builder.Build();

        app.UseCors("CorsPolicy");

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseMiddlewareExtensions();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}