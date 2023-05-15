using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CursoSBP.Common.Models.ViewModels;

namespace CursoSBP.Common.Services
{
    public interface IApiServices
    {
       Response GetApi(string url, string controller, string endpoint);
        Response PostApi(string url, string controller, string endpoint);
        Response PutApi(string url, string controller, string endpoint);
        Response DeleteApi(string url, string controller, string endpoint);
    }
}
