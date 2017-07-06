using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskListApi.Core.Util
{
    public interface IObjectBuilder<To, From>
    {
        IEnumerable<From> ToList(IEnumerable<To> obj);
        IEnumerable<To> ToList(IEnumerable<From> obj);
        To ToObject(From obj);
        From ToObject(To obj);
    }
}