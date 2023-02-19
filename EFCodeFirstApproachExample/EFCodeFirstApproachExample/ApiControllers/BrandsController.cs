using DataLayer;
using DomainModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;


namespace EFCodeFirstApproachExample.ApiControllers
{
    public class BrandsController : ApiController
    {
        private CompanyDbContext _db;

        public BrandsController()
        {
            _db = new CompanyDbContext();
        }

        [HttpGet]
        // GET: /api/Brands
        public IHttpActionResult GetBrands()
        {
            List<Brand> brands = _db.Brands.ToList();
            return Ok(brands);
        }

    }
}
