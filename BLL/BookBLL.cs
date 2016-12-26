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
    public class BookBLL
    {
        public List<Model.book> Get()
        {
            using (var ctx = new qualitEntities())
            {
                var bookRepository = new Repository<Model.book>(ctx);

                List<Model.book> books = bookRepository.GetAll();

                return books;

            }
        }

        public Response Add(Model.book b)
        {
            using (var ctx = new qualitEntities())
            {
                Response resp = new Response();
                try {
                    var bookRepository = new Repository<Model.book>(ctx);
                    bookRepository.Insert(b);
                    ctx.SaveChanges();
                    resp.Error = false;
                    resp.Message = "Book saved!";
                    return resp;
                } catch(Exception e) {
                    resp.Error = true;
                    resp.Message = e.Message;
                    return resp;
                }

            }
        }

        public Response Update(Model.book b)
        {
            using (var ctx = new qualitEntities())
            {
                Response resp = new Response();
                try {
                    var bookRepository = new Repository<Model.book>(ctx);
                    Model.book book = bookRepository.GetById(b.id);
                    book.author = b.author;
                    book.description = b.description;
                    book.title = b.title;
                    book.image = b.image;
                    ctx.SaveChanges();
                    resp.Error = false;
                    resp.Message = "Book updated!";
                    return resp;
                } catch(Exception e) {
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
                    var bookRepository = new Repository<Model.book>(ctx);
                    bookRepository.Delete(bookRepository.GetById(id));
                    ctx.SaveChanges();
                    resp.Error = false;
                    resp.Message = "Book deleted!";
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
