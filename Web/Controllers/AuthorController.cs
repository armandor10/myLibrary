using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using Model;

namespace Web.Controllers
{
    public class AuthorController : ApiController
    {
        public List<Model.author> Get()
        {
            AuthorBLL authorBLL = new AuthorBLL();
            return authorBLL.Get();
        }

        public IHttpActionResult Post(Model.author a)
        {
            AuthorBLL ABLL = new AuthorBLL();
            Response resp = ABLL.Add(a);
            if (!resp.Error) return Ok(resp);
            return BadRequest();
        }

        public IHttpActionResult Put(Model.author a)
        {
            AuthorBLL ABLL = new AuthorBLL();
            Response resp = ABLL.Update(a);
            if (!resp.Error) return Ok(resp);
            return BadRequest();
        }

        public IHttpActionResult Delete(int id)
        {
            AuthorBLL ABLL = new AuthorBLL();
            Response resp = ABLL.Delete(id);
            if (!resp.Error) return Ok(resp);
            return BadRequest();
        }

    }
}
