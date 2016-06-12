using ActionMailerNext.Mvc5_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Karma.Services.Controllers
{
    public class MailController : MailerBase
    {
        public EmailResult Welcome()
        {
            MailAttributes.From = new MailAddress("onestone.oh@gmail.com", "Kevin Oh");
            MailAttributes.To.Clear();
            MailAttributes.To.Add(new MailAddress("onestone.oh@gmail.com", "Kevin Oh"));
            MailAttributes.Subject = "이것은 테스트 메일";
            MailAttributes.Priority = MailPriority.Normal;

            //MailAttributes.Attachments["attachment.zip"] = File.ReadAllBytes("C:/attachment.zip");

            return Email("TestEmailView");
        }
    }
}