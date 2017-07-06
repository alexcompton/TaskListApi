using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskListApi.Core.Util
{
    public abstract class ObjectBuilderBase<To, From> : IObjectBuilder<To, From>
    {
        public virtual IEnumerable<From> ToList(IEnumerable<To> obj) => obj.Select(x => ToObject(x)).AsEnumerable();
        public virtual IEnumerable<To> ToList(IEnumerable<From> obj) => obj.Select(x => ToObject(x)).AsEnumerable();
        public abstract To ToObject(From obj);
        public abstract From ToObject(To obj);
    }
}