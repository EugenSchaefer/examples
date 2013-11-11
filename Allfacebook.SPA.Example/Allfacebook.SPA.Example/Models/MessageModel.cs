using System;

namespace Allfacebook.SPA.Example.Models
{
    public class MessageModel
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string MessageText { get; set; }
        public DateTime ReceiveDate { get; set; }
    }
}