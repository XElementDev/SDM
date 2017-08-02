using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    [TestClass]
    public class Test_ManagementWindowFactory
    {
        [TestMethod]
        public void ManagementWindowFactory_IsExportedViaMef()
        {
            var container = CreateMefContainer();
            var mefImport = new MefImportTestHelper();

            container.ComposeParts( mefImport );

            Assert.IsNotNull( mefImport.Target );
        }

        [TestMethod]
        public void ManagementWindowFactory_ImplementsFactoryT1Interface()
        {
            var container = CreateMefContainer();
            var mefImport = new MefImportTestHelper();

            container.ComposeParts( mefImport );

            Assert.IsNotNull( mefImport.Target );
            Assert.IsInstanceOfType( mefImport.Target, typeof( IFactory<ManagementWindow> ) );
        }


        [TestMethod]
        public void ManagementWindowFactory_Get_DoesNotReturnNull()
        {
            var container = CreateMefContainer();
            var mefImport = new MefImportTestHelper();
            container.ComposeParts( mefImport );

            var instance = mefImport.Target.Get();

            Assert.IsNotNull( instance );
        }

        [TestMethod]
        public void ManagementWindowFactory_Get_HasExpectedDataContext()
        {
            var container = CreateMefContainer();
            var mefImport = new MefImportTestHelper();
            container.ComposeParts( mefImport );
            var expected = mefImport.MainVM;

            var instance = mefImport.Target.Get();

            var actual = instance.DataContext as Modules.Main.ViewModel;
            Assert.IsNotNull( actual );
            Assert.AreSame( expected, actual );
        }

        [TestMethod]
        public void ManagementWindowFactory_Get_Max1UniqueInstance()
        {
            var container = CreateMefContainer();
            var mefImport = new MefImportTestHelper();
            container.ComposeParts( mefImport );

            var expected = mefImport.Target.Get();
            var actual = mefImport.Target.Get();

            Assert.AreSame( expected, actual );
        }

        [TestMethod]
        public void ManagementWindowFactory_Get_ReturnsNewInstanceIfWindowWasClosed()
        {
            var container = CreateMefContainer();
            var mefImport = new MefImportTestHelper();
            container.ComposeParts( mefImport );
            var notExpected = mefImport.Target.Get();
            notExpected.Close();

            var actual = mefImport.Target.Get();

            Assert.AreNotSame( notExpected, actual );
            Assert.IsNotNull( notExpected );
            Assert.IsNotNull( actual );
        }



        private static ComposablePartCatalog CreateMefCatalog()
        {
            var assembly = typeof( App ).Assembly;
            return new AssemblyCatalog( assembly );
        }


        private static CompositionContainer CreateMefContainer()
        {
            var catalog = CreateMefCatalog();
            var container = new CompositionContainer( catalog );

            container.ComposeExportedValue( Mock.Create<IDelayManager>() );
            container.ComposeExportedValue<IEventAggregator>( new EventAggregator() );
            container.ComposeExportedValue( Mock.Create<IFactory<IProgramLogic, IProgramInfo>>() );
            container.ComposeExportedValue( Mock.Create<IStartupInfo>() );

            return container;
        }



        private class MefImportTestHelper
        {
            [Import]
            public Modules.Main.ViewModel MainVM { get; private set; }


            [Import( AllowDefault = true )]
            public IFactory<ManagementWindow> Target { get; private set; }
        }
    }
}
