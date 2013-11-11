using System.Collections.Generic;
using System.Linq;

namespace Allfacebook.SPA.Example.Repository
{
    public class MessageDataRepository
    {
        public IEnumerable<Message> GetMessages()
        {
            using (var ctx = new ExampleDbContext())
            {
                return ctx.Messages.Take(30).ToList();
            }
        }
    }
}