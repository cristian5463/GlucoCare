using GlucoCare.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlucoCare.Application.Interfaces
{
    public interface IConfigService
    {
        ConfigDto GetConfigurationById(int id);
        ConfigDto CreateConfiguration(ConfigDto configDto);
        ConfigDto UpdateConfiguration(int id, ConfigDto configDto);
        void DeleteConfiguration(int id);
    }
}