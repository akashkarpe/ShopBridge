using BusinessLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShopBridge.Controllers
{
    public class ProductController : ApiController
    {
        ProductMaster productMaster; 
        public ProductController()
        {
            productMaster = new ProductMaster();
        }

        public Response Get()
        {
            Response res = new Response();
            try
            {
                var ProdList = productMaster.GetProductList();
                res.Data = ProdList;
                res.Status = "S";
                res.Message = "Success";
            }
            catch (Exception ex)
            {
                res.Status = "F";
                res.Message = ex.Message;
            }

            return res;
        }


        // POST api/values
        public Response Post([FromBody] Product product)
        {
            Response res = new Response();
            try
            {
                if (ModelState.IsValid)
                {
                    var result = productMaster.InsertProduct(product);
                    res.Data = result;
                    res.Status = "S";
                    res.Message = "Success";
                }
                else
                {
                    res.Data = ModelState.Values.ToList();
                    res.Status = "F";
                    res.Message = "Validation Failed";
                }
            }
            catch (Exception ex)
            {
                res.Status = "F";
                res.Message = ex.Message;
            }

            return res;
        }

        // PUT api/values/5
        public Response Put([FromBody] Product product)
        {
            Response res = new Response();
            try
            {
                if (ModelState.IsValid)
                {
                    var result = productMaster.UpdateProduct(product);
                    res.Data = result;
                    res.Status = "S";
                    res.Message = "Success";
                }
                else
                {
                    res.Data = ModelState.Values.ToList();
                    res.Status = "F";
                    res.Message = "Validation Failed";
                }
            }
            catch (Exception ex)
            {
                res.Status = "F";
                res.Message = ex.Message;
            }

            return res;
        }

        // DELETE api/values/5
        public Response Delete(int Id)
        {
            Response res = new Response();
            try
            {
                var result = productMaster.DeleteProduct(Id);
                res.Data = result;
                res.Status = "S";
                res.Message = "Success";
            }
            catch (Exception ex)
            {
                res.Status = "F";
                res.Message = ex.Message;
            }

            return res;
        }
    }
}
