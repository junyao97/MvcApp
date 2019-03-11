using MyMvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMvcApp.Controllers
{
    public class TestsController:Controller
    {
        [Route("hello-world")]
        public ActionResult HelloWorld()
        {
            return View("~/Views/HelloWorld.cshtml");
        }

        [Route("bye")]
        public ActionResult goodbye()
        {
            return View("~/Views/GoodBye.cshtml");
        }

        [Route("hello")]
        public ActionResult hello()
        {
            var person = new Person()
            {
                Name = "Jun Yao",
                Age = 22
            };
            return View("~/Views/HelloPerson.cshtml",person);
        }
    }
}