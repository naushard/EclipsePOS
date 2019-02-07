using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EclipsePos.Apps.Devices
{
    public interface PosPanel
    {
        void LoadAccessKeys();
        
        void AccessKeyEvent(int accessKeyId);
    
    }
}
