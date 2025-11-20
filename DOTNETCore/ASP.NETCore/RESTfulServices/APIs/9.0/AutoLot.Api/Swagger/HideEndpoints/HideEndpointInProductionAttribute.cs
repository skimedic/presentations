// Copyright Information
// ==================================
// AutoLot9 - AutoLot.Api - HideEndpointInProductionAttribute.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/11/20
// ==================================

namespace AutoLot.Api.Swagger.HideEndpoints;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
public class HideEndpointInProductionAttribute : Attribute
{
}