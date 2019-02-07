using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Composite.Modularity;
using Microsoft.Practices.Composite.Regions;
using Microsoft.Practices.Unity;
using System.Data.Linq;


namespace EclipsePOS.WPF.SystemManager.Data
{
    public class DataModule:IModule
    {
       private IUnityContainer _container;
       public DataModule(IUnityContainer container)
        {
            _container = container;
        }

        public void Initialize()
        {

            RegisterServices();
           

        }

        private void RegisterServices()
        {
            _container.RegisterType<DataContext, DataClasses1DataContext>();
            
        }

      
        

    }
}
