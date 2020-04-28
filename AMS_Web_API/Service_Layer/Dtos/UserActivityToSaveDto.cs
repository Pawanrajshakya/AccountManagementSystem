using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Service_Layer.Dtos
{
    public class UserActivityToSaveDto
    {
        public int UserId { get; set; }
        public DateTime DateRequested { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string Comment { get; set; }
    }
}