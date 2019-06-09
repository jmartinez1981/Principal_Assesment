using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace TransportManager.Services
{
    public interface IOperationCoordinator
    {
        void Execute();
    }
}
