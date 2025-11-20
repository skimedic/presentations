// Copyright Information
// ==================================
// AutoLot9 - AutoLot.Api - GlobalUsings.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/20
// ==================================

global using Asp.Versioning;
global using Asp.Versioning.ApplicationModels;
global using Asp.Versioning.ApiExplorer;

global using AutoLot.Api.ApiVersionSupport;
global using AutoLot.Api.Controllers.Base;
global using AutoLot.Api.DataShaping;
global using AutoLot.Api.Filters;
global using AutoLot.Api.Formatters;
global using AutoLot.Api.Swagger;
global using AutoLot.Api.Swagger.Models;
global using AutoLot.Api.Swagger.HideEndpoints;

global using AutoLot.Dal.EfStructures;
global using AutoLot.Dal.Exceptions;
global using AutoLot.Dal.Initialization;
global using AutoLot.Dal.Repos;
global using AutoLot.Dal.Repos.Base;
global using AutoLot.Dal.Repos.Interfaces;
global using AutoLot.Dal.Repos.Interfaces.Base;

global using AutoLot.Models.Entities;
global using AutoLot.Models.Entities.Base;
global using AutoLot.Models.Exceptions.Base;

global using AutoLot.Services.Logging.Configuration;
global using AutoLot.Services.Logging.Interfaces;
global using AutoLot.Services.Utilities;

global using Microsoft.AspNetCore.Authentication;
global using Microsoft.AspNetCore.Authorization;

global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Mvc.ApiExplorer;
global using Microsoft.AspNetCore.Mvc.ApplicationModels;
global using Microsoft.AspNetCore.Mvc.Authorization;
global using Microsoft.AspNetCore.Mvc.Filters;
global using Microsoft.AspNetCore.Mvc.Formatters;

global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Diagnostics;

global using Microsoft.Extensions.DependencyInjection.Extensions;
global using Microsoft.Extensions.Options;

global using Microsoft.OpenApi.Any;
global using Microsoft.OpenApi.Models;

global using Swashbuckle.AspNetCore.Annotations;
global using Swashbuckle.AspNetCore.SwaggerGen;

global using System.Dynamic;
global using System.Net.Http.Headers;
global using System.Reflection;
global using System.Security.Claims;
global using System.Text;
global using System.Text.Encodings.Web;
global using System.Text.Json;
global using System.Text.Json.Serialization;