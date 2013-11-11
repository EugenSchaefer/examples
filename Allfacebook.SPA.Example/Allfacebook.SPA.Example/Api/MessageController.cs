using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Allfacebook.SPA.Example.Models;
using Allfacebook.SPA.Example.Repository;
using AutoMapper;

namespace Allfacebook.SPA.Example.Api
{
    public class MessageController : ApiController
    {
        public HttpResponseMessage Get()
        {
            var repository = new MessageDataRepository();
            IEnumerable<Message> data = repository.GetMessages();

            IList<MessageModel> result = Mapper.Map<IEnumerable<Message>, IList<MessageModel>>(data);

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}