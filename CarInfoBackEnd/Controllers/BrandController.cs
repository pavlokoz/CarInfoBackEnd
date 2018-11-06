using CarInfoServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CarInfoBackEnd.Controllers
{
    public class BrandController : ApiController
    {
        private readonly IBrandService brandService;

        public BrandController(IBrandService brandService)
        {
            this.brandService = brandService;
        }

        [HttpGet]
        public async Task <IHttpActionResult> GetBrandById(long brandId)
        {
            var brand = await brandService.GetById(brandId);
            if(brand != null)
            {
                return Ok(brand);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetTopFourBrands()
        {
            var result = await brandService.GetTopFourBrands();
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetBrands()
        {
            var result = await brandService.GetBrands();
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}