using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace EclipsePos.Apps.Views.Progress
{
    public interface IProgress
    {
        void ShowProgressDialog();
        void CloseDialog();
        void SetProgressStep(int value, string progressText);
        void SetMaximum(int value);
       
    }
}
