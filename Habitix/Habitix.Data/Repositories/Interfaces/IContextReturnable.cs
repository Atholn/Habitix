using System;
using System.Collections.Generic;
using System.Text;

namespace Habitix.Data.Repositories.Interfaces
{
    public interface IContextReturnable
    {
        /// <summary>
        /// Let you use context for call
        /// </summary>
        /// <returns>Reference to context</returns>
        BaseContext GetContext();
    }
}
