using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.Services.ViewModels
{
    /// <summary>
    /// REST Error message
    /// </summary>
    public class ErrorMessage
    {
        /// <summary>
        /// Status : 401 400 404 500
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Error Message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Addtional Error code
        /// </summary>
        public string code { get; set; }

        /// <summary>
        /// more info
        /// </summary>
        public string MoreInfo { get; set; }
    }
}
