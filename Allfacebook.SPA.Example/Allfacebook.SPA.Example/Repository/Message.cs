using System;

namespace Allfacebook.SPA.Example.Repository
{
    public class Message
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string MessageText { get; set; }
        public DateTime ReceiveDate { get; set; }
    }
}