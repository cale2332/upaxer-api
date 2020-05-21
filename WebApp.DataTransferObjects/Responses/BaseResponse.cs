using WebApp.DataTransferObjects;
using System;

namespace WebApp.Services.DataTransferObjects.Responses
{
    public partial class BaseResponse
    {
        public Guid Id { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public int ErrorId { get; set; }
    }
}
