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
    public class ModelController : ApiController
    {
        private readonly IModelService modelService;

        public ModelController(IModelService modelService)
        {
            this.modelService = modelService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetTopBrandModels(long brandId)
        {
            var result = await modelService.GetTopBrandModels(brandId);
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
        public async Task<IHttpActionResult> GetModels(long brandId)
        {
            var result = await modelService.GetBrandModels(brandId);
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
        public async Task<IHttpActionResult> GetModelById(long modelId)
        {
            var result = await modelService.GetById(modelId);
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