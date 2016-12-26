using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.repositories;
using Model;

namespace BLL
{
    public class AuthorBLL
    {
        public List<Model.author> Get()
        {
            using (var ctx = new qualitEntities())
            {
                var bookRepository = new Repository<Model.author>(ctx);

                List<Model.author> books = bookRepository.GetAll();

                return books;

            }
        }
        public Response Add(Model.author b)
        {
            using (var ctx = new qualitEntities())
            {
                Response resp = new Response();
                try
                {
                    var bookRepository = new Repository<Model.author>(ctx);
                    bookRepository.Insert(b);
                    ctx.SaveChanges();
                    resp.Error = false;
                    resp.Message = "Author saved!";
                    return resp;
                }
                catch (Exception e)
                {
                    resp.Error = true;
                    resp.Message = e.Message;
                    return resp;
                }

            }
        }

        public Response Update(Model.author b)
        {
            using (var ctx = new qualitEntities())
            {
                Response resp = new Response();
                try
                {
                    var bookRepository = new Repository<Model.author>(ctx);
                    Model.author author = bookRepository.GetById(b.id);
                    author.name = b.name;
                    author.Nationality = b.Nationality;
                    ctx.SaveChanges();
                    resp.Error = false;
                    resp.Message = "Author updated!";
                    return resp;
                }
                catch (Exception e)
                {
                    resp.Error = true;
                    resp.Message = e.Message;
                    return resp;
                }

            }
        }

        public Response Delete(int id)
        {
            using (var ctx = new qualitEntities())
            {
                Response resp = new Response();
                try
                {
                    var bookRepository = new Repository<Model.author>(ctx);
                    bookRepository.Delete(bookRepository.GetById(id));
                    ctx.SaveChanges();
                    resp.Error = false;
                    resp.Message = "Author deleted!";
                    return resp;
                }
                catch (Exception e)
                {
                    resp.Error = true;
                    resp.Message = e.Message;
                    return resp;
                }

            }
        }

    }
}
