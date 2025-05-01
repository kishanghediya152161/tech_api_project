using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tech.Common.ViewModel;

namespace tech.Services.IServices
{
    public interface IBookService
    {
        Task<ApiResponseModel> GetStoryList(bookRequest requestModel);
    }
}
