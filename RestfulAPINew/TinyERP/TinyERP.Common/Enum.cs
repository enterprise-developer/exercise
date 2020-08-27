﻿namespace TinyERP.Common
{
    public enum ContainerType
    {
        Windsor = 1,
        Unity = 2
    }

    public enum ModuleDeploymentMode
    {
        Remote = 1,
        InApp = 2
    }

    public enum ConnectorType
    {
        Json = 1
    }
    public enum ApplicationLoggerType
    {
        File = 1,
        Api = 2
    }

    public enum ContextMode
    {
        Write = 1,
        Read = 2
    }

    public enum EventPriority
    {
        Low = 10,
        Normal = 50,
        High = 100
    }
}
