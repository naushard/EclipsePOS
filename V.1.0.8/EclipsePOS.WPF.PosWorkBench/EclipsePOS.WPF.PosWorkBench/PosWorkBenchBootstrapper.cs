using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Composite.UnityExtensions;
using System.Windows;
using Microsoft.Practices.Composite.Modularity;
using Microsoft.Practices.Composite.Logging;
using EclipsePos.Apps;
using EclipsePos.Apps.Context;
using EclipsePos.Apps.Views.Progress;



namespace EclipsePOS.WPF.PosWorkBench
{
    public class PosWorkBenchBootstrapper: UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            PosWorkBenchShell shell = Container.Resolve<PosWorkBenchShell>();
            shell.Show();
            return shell;
        }

       /* protected override IModuleEnumerator GetModuleEnumerator()
        {
            //return new ConfigurationModuleEnumerator();
            return new StaticModuleEnumerator()
        .AddModule(typeof(EclipsePos.Apps.EclipsePosAppsModule));
            PosWorkBenchShell shell = Container.Resolve<PosWorkBenchShell>();
            //PosContext.Instance.PosExplorer.cl.SynchronizingObject = shell;


        }
        * */

        protected override IModuleCatalog GetModuleCatalog()
        {
            return new ModuleCatalog()
                .AddModule(typeof(EclipsePos.Apps.EclipsePosAppsModule))
                //.AddModule(typeof(ModuleB))
                ;
        }



    }
}
