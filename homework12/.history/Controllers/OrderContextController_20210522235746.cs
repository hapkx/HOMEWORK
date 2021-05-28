using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using homework12.Models;

namespace homework12.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderContextController : ControllerBase
    {
        private readonly OrderContext orderDb;

        public OrderContextController(OrderContext context){
            this.orderDb=context;
        }


        [HttpGet]
        public ActionResult<List<Goods>> GetGoods(){
            IQueryable<Goods> query=orderDb.Goods;
            return query.ToList();
        }

        [HttpGet("Id")]
        public ActionResult<Goods> GetGoods(string Id){
            var Goods=orderDb.Goods.FirstOrDefault(t=>t.Id==Id);
            if(Goods==null) return NotFound();
            return Goods;
        }

        [HttpPost]
        public ActionResult<Goods> PostGoods(Goods good){
            try{
                orderDb.Goods.Add(good);
                orderDb.SaveChanges();
            }catch(Exception e){
                return BadRequest(e.InnerException.Message);
            }
            return good;
        }

        [HttpDelete("Id")]
        public ActionResult DeleteGoods(string id){
            
        }
    }
}
