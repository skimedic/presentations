// Copyright Information
// ==================================
// AutoLot9 - AutoLot.Services - GlobalUsings.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/08/02
// ==================================

global using AutoLot.Dal.Repos;
global using AutoLot.Dal.Repos.Base;
global using AutoLot.Dal.Repos.Interfaces;
global using AutoLot.Dal.Repos.Interfaces.Base;

global using AutoLot.Services.Logging;
global using AutoLot.Services.Logging.Interfaces;
global using AutoLot.Services.Logging.Settings;
global using AutoLot.Services.Simple;
global using AutoLot.Services.Simple.Interfaces;
global using AutoLot.Services.Validation;
global using AutoLot.Services.ViewModels;
global using AutoLot.Services.ViewModels.Base;

global using Microsoft.AspNetCore.Builder;
global using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.Hosting;
global using Microsoft.Extensions.Logging;

global using Serilog;
global using Serilog.Context;
global using Serilog.Core.Enrichers;
global using Serilog.Events;
global using Serilog.Sinks.MSSqlServer;

global using System.ComponentModel;
global using System.ComponentModel.DataAnnotations;
global using System.Data;
global using System.Diagnostics;
global using System.Reflection;
global using System.Runtime.CompilerServices;

