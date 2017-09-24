using Prism.Events;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using Telerik.JustMock;
using XElement.DesignPatterns.CreationalPatterns.FactoryMethod;
using XElement.DotNet.System.Environment.Startup;
using XElement.SDM.DelayLogic;
using XElement.SDM.ManagementLogic;
using XElement.SDM.UI.Win32.Bootstrapping;

namespace XElement.SDM.UI.Win32
{
    internal static class MefTestUtils
    {
        public static ComposablePartCatalog CreateMefCatalog()
        {
            var assembly = typeof( App ).Assembly;
            return new AssemblyCatalog( assembly );
        }


        public static CompositionContainer CreateMefContainer()
        {
            var catalog = CreateMefCatalog();
            var container = new CompositionContainer( catalog );

            container.ComposeExportedValue( Mock.Create<IDelayManager>() );
            container.ComposeExportedValue<IEventAggregator>( new EventAggregator() );
            container.ComposeExportedValue( Mock.Create<IFactory<IProgramLogic, IProgramInfo>>() );
            container.ComposeExportedValue( Mock.Create<IStartupInfo>() );

            return container;
        }



        public class ImportTestHelper<TViewModel, TWindow>
        {
            [Import( AllowDefault = true )]
            public IFactory<TWindow> Target { get; private set; }


            [Import]
            public TViewModel ViewModel { get; private set; }
        }
    }
}
