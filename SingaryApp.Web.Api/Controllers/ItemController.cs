using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SingrayApp.ApplicationCore.DTOs;
using SingrayApp.ApplicationCore.Interfaces.Services;

namespace SingaryApp.Web.Api.Controllers
{
    [Route("api/Items")]
    [EnableCors("CorsPolicy")]
    public class ItemController : Controller
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = _itemService.GetAll();
            return Ok(new { success = true, data = result });
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateAsync(Item item)
        {
            try
            {
                var result = await _itemService.CreateAsync(item);

                if (result.Success)
                {

                    return Ok(new { success = true, data = new { id = result.Payload }, message = result.Message });

                }
                return Ok(result);
            }
            catch (Exception ex)
            {

                return Ok(new { success = false, message = ex.Message });
            }





        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _itemService.DeleteAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Ok(new { success = false, message = ex.Message });
            }

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
