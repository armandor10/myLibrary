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
    public class BookController : ApiController
    {
        public List<Model.book> Get()
        {
            BookBLL bookBLL = new BookBLL();
            return bookBLL.Get();
        }

        public IHttpActionResult Post(Model.book book) {
            BookBLL bookBLL = new BookBLL();
            Response resp = bookBLL.Add(book);
            if (!resp.Error) return Ok(resp);
            return BadRequest();
        }

        public IHttpActionResult Put(Model.book book)
        {
            BookBLL bookBLL = new BookBLL();
            Response resp = bookBLL.Update(book);
            if (!resp.Error) return Ok(resp);
            return BadRequest();
        }

        public IHttpActionResult Delete(int id)
        {
            BookBLL bookBLL = new BookBLL();
            Response resp = bookBLL.Delete(id);
            if (!resp.Error) return Ok(resp);
            return BadRequest();
        }

    }
}
