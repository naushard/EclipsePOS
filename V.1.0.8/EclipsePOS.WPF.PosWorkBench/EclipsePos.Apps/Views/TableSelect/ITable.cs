using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace EclipsePos.Apps.Views.TableSelect
{
    public interface ITable
    {
       // void SetTableGroupDataContext(IEnumerable data);
        void SetTableDataContext(object data);
    }
}
