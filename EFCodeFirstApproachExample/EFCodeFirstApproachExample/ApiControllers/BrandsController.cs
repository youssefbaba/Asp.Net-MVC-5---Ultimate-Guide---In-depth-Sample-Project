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

        [Route("api/Brands/{brandId:long}")]
        [HttpGet]
        // GET: /api/Brands/1
        public IHttpActionResult GetBrandsByBrandId(long brandId)
        {
            Brand brand = _db.Brands.SingleOrDefault(b => b.BrandID == brandId);
            if (brand == null)
            {
                return NotFound();
            }
            return Ok(brand);
        }

        [HttpPost]
        // POST: /api/Brands
        public IHttpActionResult InsertBrand(Brand brand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _db.Brands.Add(brand);
            _db.SaveChanges();
            return Ok(brand);
        }

        [HttpPut]
        // PUT: /api/Brands
        public IHttpActionResult UpdateBrand(Brand brand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var brandInDb = _db.Brands.SingleOrDefault(b => b.BrandID == brand.BrandID);
            if (brandInDb == null)
            {
                return NotFound();
            }
            brandInDb.BrandName = brand.BrandName;
            _db.SaveChanges();
            return Ok();
        }

        [Route("api/Brands/{brandId:long}")]
        [HttpDelete]

        public IHttpActionResult DeleteBrand(long brandId)
        {
            var brandInDb = _db.Brands.SingleOrDefault(b => b.BrandID == brandId);
            if (brandInDb == null)
            {
                return NotFound();
            }
            _db.Brands.Remove(brandInDb);
            _db.SaveChanges();
            return Ok();
        }

    }
}
