using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlucoCare.Application.Response;
public class Status200<T>
{
    public string Type { get; set; }
    public string Title { get; set; }
    public int Status { get; set; }
    public string Message { get; set; }
    public T Data { get; set; }
    public Status200(string message)
    {
        Type = "https://tools.ietf.org/html/rfc7231#section-6.3.1";
        Title = "Success";
        Status = 200;
        Message = message;
    }

    public Status200(string message, T data)
    {
        Type = "https://tools.ietf.org/html/rfc7231#section-6.3.1";
        Title = "Success";
        Status = 200;
        Message = message;
        Data = data;
    }
}
