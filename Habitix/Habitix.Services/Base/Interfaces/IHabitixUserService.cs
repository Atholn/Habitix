using Habitix.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Habitix.Services.Base.Interfaces
{
    public interface IHabitixUserService
    {
        Task<HabitixUserRepresentation> Create(HabitixUserRepresentation habitixUserRepresentation);
        Task<HabitixUserRepresentation> Get(long id);
        Task<IEnumerable<HabitixUserRepresentation>> GetList();
      //  Task<ProductDeleteResponse> Delete(long id, long companyId);
      //  Task<ProductUpdateResponse> Update(ProductCreateRequest request, long productId, long companyId);
    }
}
