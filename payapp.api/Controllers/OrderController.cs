using Microsoft.AspNetCore.Mvc;
using payapp.data.Models;
using payapp.message.send.OrderSender;
using payapp.services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace payapp.api.Controllers
{
    [Route("api/orders")]
    public class OrderController : Controller
    {
        //private IOrderSender sender;
        private IClientPayService service;

        public OrderController(/*IOrderSender sender,*/ IClientPayService service)
        {
            //this.sender = sender;
            this.service = service;
        }
        /// <summary>
        /// Провести операцию клиента
        /// </summary>
        /// <param name="operation"></param>
        /// <returns></returns>
        //[HttpPost]
        //public IActionResult Add(ClientOperation operation)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            sender.SendClientOperation(operation);
        //            return Ok(operation);
        //        }
        //        catch(Exception ex)
        //        {
        //            return BadRequest("Ошибка проведения операции");
        //        }
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //}

        [HttpGet]
        [Route("{clientId}operations")]
        [Route("{clientId}/operations/{operationId}")]
        public IActionResult Get([FromRoute] Guid clientId, Guid? operationId)
        {
            try
            {
                if (operationId.HasValue)
                {
                    return Ok(service.GetClientOperation(clientId, operationId.Value));
                }
                return Ok(service.GetClientOperations(clientId));
            }
            catch(Exception ex)
            {
                return BadRequest("Ошибка при получении данных клиента.");
            }
        }
    }
}
