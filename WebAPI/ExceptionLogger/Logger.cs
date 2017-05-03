using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebAPI.GlobalExceptionFilter;

namespace WebAPI.ExceptionLogger
{
    public class Logger : ILogger
    {
        /// <summary>
        /// This method is used to log exception
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public async Task LogException(Exception exception)
        {
            //Implement logging strategy here like log 4 net / msel/ Tracing etc
            await Task.FromResult(0);
        }
    }
}