using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.GlobalExceptionFilter
{
    /// <summary>
    /// This is Logger interface which can be implemented in application to log error with the help of various logging strategies
    /// </summary>
    public interface ILogger
    {
        Task LogException(Exception exception);
    }
}
