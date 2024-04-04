using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlucoCare.Application.Response;
public class Status400
{
    public string Type { get; set; }
    public string Title { get; set; }
    public int Status { get; set; }
    public string Message { get; set; }

    public Status400(string message)
    {
        Type = "https://tools.ietf.org/html/rfc7231#section-6.3.1";
        Title = "error";
        Status = 400;
        Message = message;
    }
}
