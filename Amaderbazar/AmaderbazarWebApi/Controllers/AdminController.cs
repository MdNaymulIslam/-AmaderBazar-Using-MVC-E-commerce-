using AmaderbazarWebApi.Auth;
using BLL;
using BEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace AmaderbazarWebApi.Controllers
{
    [EnableCors("*", "*", "*")]
    [CustomAuth]
    public class AdminController : ApiController
    {
        
        [Route("api/user/userlist")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var d = UserService.Get();
            if (d != null)
                return Request.CreateResponse(HttpStatusCode.OK, d);
            else
                return Request.CreateResponse(HttpStatusCode.NotFound, "Empty");
        }

        [Route("api/user/deliverydetails")]
        [HttpGet]
        public HttpResponseMessage GetDetails()
        {
            var d = DeliveryService.Get();
            if (d != null)
                return Request.CreateResponse(HttpStatusCode.OK, d);
            else
                return Request.CreateResponse(HttpStatusCode.NotFound, "Empty");
        }

        [Route("api/user/productdetails")]
        [HttpGet]
        public HttpResponseMessage GetProductDetails()
        {
            var d = ProductService.Get();
            if (d != null)
                return Request.CreateResponse(HttpStatusCode.OK, d);
            else
                return Request.CreateResponse(HttpStatusCode.NotFound, "Products unavailable");
        }

        [Route("api/user/currentlyLogged")]
        [HttpGet]
        public HttpResponseMessage GetLoginDetails()
        {
            var d = TokenService.Get();
            if (d != null)
                return Request.CreateResponse(HttpStatusCode.OK, d);
            else
                return Request.CreateResponse(HttpStatusCode.NotFound, "No Active Users");
        }

        [Route("api/user/{uid}")]
        [HttpGet]
        public HttpResponseMessage Get(string uid)
        {
            var d = UserService.Get(uid);
            if (d != null)
                return Request.CreateResponse(HttpStatusCode.OK, d);
            else
                return Request.CreateResponse(HttpStatusCode.NotFound, "User unavailable");
        }



        [Route("api/product/delete/{id}")]
        [HttpPost]
        public HttpResponseMessage DeleteProduct(int id)
        {
            if(ProductService.Delete(id))
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Product Deleted");
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Product Deletion Failed");
        }

        [Route("api/user/adminProfile/edit")]
        [HttpPost]
        public HttpResponseMessage EditProfile(UserModel user)
        {
            if(UserService.Edit(user))
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Profile Edited Successfully");
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Profile Edit Failed");
        }

   

       

        


    }
}
