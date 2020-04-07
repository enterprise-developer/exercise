using System;
using System.Configuration;

namespace TinyERP.Common.Configurations
{
    public class UserManagement : ConfigurationElement
    {
        [ConfigurationProperty("mode")]
        public ModuleDeploymentMode Mode
        {
            get
            {
                return (ModuleDeploymentMode)Enum.Parse(typeof(ModuleDeploymentMode), this["mode"].ToString());
            }
        }

        [ConfigurationProperty("endPoint")]
        public EndPoint EndPoint
        {
            get
            {
                return (EndPoint)this["endPoint"];
            }
        }
    }
}
