using System;
using System.Web.Mvc;

namespace ModelExample.Models
{
    public class CustomBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            int StudentId = Convert.ToInt32(controllerContext.HttpContext.Request.Form["StudentId"]);
            string StudentName = controllerContext.HttpContext.Request.Form["StudentName"];
            string DoorNumber = controllerContext.HttpContext.Request.Form["DoorNumber"];
            string Street = controllerContext.HttpContext.Request.Form["Street"];
            string LandMark = controllerContext.HttpContext.Request.Form["LandMark"];
            string City = controllerContext.HttpContext.Request.Form["City"];
            return new Student() { StudentId = StudentId, StudentName = StudentName, Address = $"{DoorNumber},{Street},{LandMark},{City}" };
        }
    }
}