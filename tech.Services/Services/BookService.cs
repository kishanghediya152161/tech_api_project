using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using tech.Common.dbmodel;
using tech.Common.Helper;
using tech.Common.ViewModel;
using tech.Repository.IRepository;
using tech.Services.IServices;

namespace tech.Services.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IApiHelper _apiHelper;
        public BookService(IBookRepository bookRepository, IApiHelper apiHelper)
        {
            _bookRepository = bookRepository;
            _apiHelper = apiHelper;
        }
        public async Task<ApiResponseModel> GetStoryList(bookRequest requestModel)
        {
            ApiResponseModel apiResponseModel = new ApiResponseModel();

            if (requestModel.key == null)
            {
                return await _bookRepository.GetSroryListBySection(requestModel);
            }
            else
            {
                var resutl = _apiHelper.Get("svc/topstories/v2/" + requestModel.Section + ".json?api-key=" + requestModel.key, null);
                if (resutl.Data != null)
                {
                    if (resutl.Code == 200)
                    {
                        var rootVM = JsonConvert.DeserializeObject<RootVM>(resutl.Data);

                        if (rootVM != null)
                        {
                            return await _bookRepository.GetStoryList(requestModel, rootVM);
                        }
                        else
                        {
                            return apiResponseModel = new ApiResponseModel()
                            {
                                Message = "Datat not found",
                                Code = (int)HttpStatusCode.BadRequest,
                            };
                        }
                    }
                    else
                    {
                        return resutl;
                    }
                }
            }
            return apiResponseModel = new ApiResponseModel()
            {
                Message = "Datat not found",
                Code = (int)HttpStatusCode.BadRequest,
            };
        }
    }
}
