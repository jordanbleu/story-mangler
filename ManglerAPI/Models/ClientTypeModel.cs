using ManglerAPI.Entities;

namespace ManglerAPI.Models;

public enum ClientTypeModel
{
    Discord = ClientType.Discord,
    Web = ClientType.Web
}

public static class ClientTypeModelExtensions
{
    public static ClientTypeModel ToModel(this ClientType clientType) =>
        clientType == ClientType.Discord ? ClientTypeModel.Discord : ClientTypeModel.Web;
}