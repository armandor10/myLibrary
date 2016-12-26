using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;

namespace WebApplication1.Controllers
{
    public class bookController : ApiController
    {
        public IHttpActionResult Get()
        {
            BookBLL bookBLL = new BookBLL();
            return Ok( bookBLL.Get());
        }
    }
}
