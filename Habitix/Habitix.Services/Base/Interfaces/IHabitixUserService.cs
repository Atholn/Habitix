using Habitix.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Habitix.Services.Base.Interfaces
{
    interface IHabitixUserService
    {

        public long Create(HabitixUserRepresentation habitixUserRepresentation);
        public HabitDateRepresentation Get(long id);
      //  Task<IEnumerable<ProductDTO>> GetList(long companyId);
      //  Task<ProductDeleteResponse> Delete(long id, long companyId);
     //   Task<ProductUpdateResponse> Update(ProductCreateRequest request, long productId, long companyId);
    }
}
