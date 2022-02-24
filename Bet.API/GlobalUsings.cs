﻿global using Bet.Domain.Service;
global using Bet.Infrastructure.Context;
global using Bet.Infrastructure.Models;
global using Bet.Infrastructure.Repository;
global using Bet.API.Application.Commands;
global using MediatR;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.AspNetCore.Builder;
global using Microsoft.AspNetCore.Hosting;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Hosting;
global using Microsoft.IdentityModel.Tokens;
global using Microsoft.OpenApi.Models;
global using System;
global using System.Collections.Generic;
global using System.Reflection;
global using System.Text;
global using System.Text.Json.Serialization;
global using System.Threading.Tasks;
global using FluentValidation.AspNetCore;
global using Bet.API.Validators;
global using Bet.Domain.Models;
global using Bet.Domain.Models.Entities;
global using Microsoft.AspNetCore.Http;
global using System.Threading;
global using System.Security.Claims;
global using System.Security.Principal;
global using Microsoft.AspNetCore.Mvc;
global using System.IdentityModel.Tokens.Jwt;
global using Bet.API.Application.Queries;
global using Bet.API.Auth;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.Extensions.Logging;
global using FluentValidation;
global using Autofac.Extensions.DependencyInjection;
global using Autofac;
