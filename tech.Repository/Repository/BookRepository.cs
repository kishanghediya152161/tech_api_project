using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;
using sample_project_tech.SampleDBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using tech.Common.dbmodel;
using tech.Common.ViewModel;
using tech.Repository.IRepository;
using static System.Collections.Specialized.BitVector32;

namespace tech.Repository.Repository
{

    public class BookRepository : IBookRepository
    {
        private readonly SampleDbContext _context;

        public BookRepository(SampleDbContext context)
        {
            _context = context;
        }
        public async Task<ApiResponseModel> GetStoryList(bookRequest requestModel, RootVM rootVM)
        {
            ApiResponseModel apiResponseModel = new ApiResponseModel();
            try
            {
                Root root = new Root()
                {
                    Status = rootVM.Status,
                    Copyright = rootVM.Copyright,
                    Section = rootVM.Section,
                    LastUpdated = DateTime.Now,
                    NumResults = rootVM.NumResults,
                    Results = rootVM.Results.Select(r => new Result
                    {
                        Section = r.Section,
                        Subsection = r.Subsection,
                        Title = r.Title,
                        Url = r.Url,
                        Uri = r.Uri,
                        Byline = r.Byline,
                        ItemType = r.ItemType,
                        UpdatedDate = r.UpdatedDate,
                        CreatedDate = r.CreatedDate,
                        PublishedDate = r.PublishedDate,
                        MaterialTypeFacet = r.MaterialTypeFacet,
                        Kicker = r.Kicker,
                        ShortUrl = r.ShortUrl,

                        // Facet Lists
                        PerFacets = r.PerFacet.Select(name => new PerFacet
                        {
                            FacetName = name
                        }).ToList(),

                        DesFacets = r.DesFacet.Select(name => new DesFacet
                        {
                            FacetName = name
                        }).ToList(),

                        OrgFacets = r.OrgFacet.Select(name => new OrgFacet
                        {
                            FacetName = name
                        }).ToList(),

                        GeoFacets = r.GeoFacet.Select(name => new GeoFacet
                        {
                            FacetName = name
                        }).ToList(),

                        // Multimedia
                        Multimedia = r.Multimedia.Select(m => new Multimedium
                        {
                            Url = m.url,
                            Format = m.format,
                            Height = m.height.Value,
                            Width = m.width.Value,
                            Type = m.type,
                            Subtype = m.subtype,
                            Caption = m.caption,
                            Copyright = m.copyright
                        }).ToList()

                    }).ToList()
                };

                _context.Roots.Add(root);
                var ans = await _context.SaveChangesAsync();

                var list = await this.GetSroryListBySection(requestModel);

                return list;
            }
            catch (Exception ex)
            {
                apiResponseModel = new ApiResponseModel
                {
                    Message = "Somthng went wrong",
                    Code = (int)HttpStatusCode.BadRequest

                };

            }
            return apiResponseModel;
        }

        public async Task<ApiResponseModel> GetSroryListBySection(bookRequest requestModel)
        {
            ApiResponseModel apiResponseModel = new ApiResponseModel();
            try
            {

                var pageNumber = 1;
                var pageSize = 20;
                if (requestModel.pageNumber != default)
                {
                    pageNumber = (int)requestModel.pageNumber;
                }
                if (requestModel.numberOfElements != default)
                {
                    pageSize = (int)requestModel.numberOfElements;
                }

                // Calculate how many items to skip
                int itemsToSkip = (pageNumber) * pageSize;


                var totlaCount = _context.Results.Where(r => r.Section == requestModel.Section).Count();

                // Assuming you have a DbContext instance named _context
                var books = _context.Results.Where(r => r.Section == requestModel.Section) // Filter by section
                    .OrderByDescending(a => a.ResultId).Select(res => new
                    {
                        res.Section,
                        res.Subsection,
                        res.Title,
                        res.Byline,
                        res.ItemType,
                        res.UpdatedDate,
                        res.CreatedDate,
                        res.PublishedDate,
                        res.MaterialTypeFacet,
                        res.Kicker,
                        res.ShortUrl,
                        Multimedia = res.Multimedia.Select(m => new
                        {
                            m.Url,
                            m.Format,
                            m.Height,
                            m.Width,
                            m.Type,
                            m.Subtype,
                            m.Caption,
                            m.Copyright
                        }).ToList()
                    }).ToList();
                // Assuming only one result for the section

                var resultSet = books.Skip(itemsToSkip).Take(pageSize);
                var filterCount = resultSet.Count();

                if (resultSet != null)
                {
                    apiResponseModel = new ApiResponseModel
                    {
                        Message = "Get Data Successfully",
                        Code = (int)HttpStatusCode.OK,
                        Data = resultSet,
                        recordsTotal = totlaCount,
                        recordsFiltered = filterCount
                    };
                }
                else
                {
                    apiResponseModel = new ApiResponseModel
                    {
                        Message = "No Data found",
                        Code = (int)HttpStatusCode.NotFound,

                    };
                }
            }
            catch (Exception er)
            {

                apiResponseModel = new ApiResponseModel
                {
                    Message = "Somthng went wrong",
                    Code = (int)HttpStatusCode.BadRequest

                };
            }

            return apiResponseModel;
        }
    }
}
