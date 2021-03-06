using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.Composition;
using XElement.DesignPatterns.CreationalPatterns.FactoryMethod;

namespace XElement.SDM.UI.Win32.Modules.About
{
    [TestClass]
    public class Test_WindowFactory
    {
        [TestMethod]
        public void AboutWindowFactory_IsExportedViaMef()
        {
            var container = MefTestUtils.CreateMefContainer();
            var mefImport = new MefImportTestHelper();

            container.ComposeParts( mefImport );

            Assert.IsNotNull( mefImport.Target );
        }

        [TestMethod]
        public void AboutWindowFactory_ImplementsFactoryT1Interface()
        {
            var container = MefTestUtils.CreateMefContainer();
            var mefImport = new MefImportTestHelper();

            container.ComposeParts( mefImport );

            Assert.IsNotNull( mefImport.Target );
            Assert.IsInstanceOfType( mefImport.Target, typeof( IFactory<AboutWindow> ) );
        }


        [TestMethod]
        public void AboutWindowFactory_Get_DoesNotReturnNull()
        {
            var container = MefTestUtils.CreateMefContainer();
            var mefImport = new MefImportTestHelper();
            container.ComposeParts( mefImport );

            var instance = mefImport.Target.Get();

            Assert.IsNotNull( instance );
        }

        [TestMethod]
        public void AboutWindowFactory_Get_HasExpectedDataContext()
        {
            var container = MefTestUtils.CreateMefContainer();
            var mefImport = new MefImportTestHelper();
            container.ComposeParts( mefImport );
            var expected = mefImport.ViewModel;

            var instance = mefImport.Target.Get();

            var actual = instance.DataContext as AboutViewModel;
            Assert.IsNotNull( actual );
            Assert.AreSame( expected, actual );
        }

        [TestMethod]
        public void AboutWindowFactory_Get_Max1UniqueInstance()
        {
            var container = MefTestUtils.CreateMefContainer();
            var mefImport = new MefImportTestHelper();
            container.ComposeParts( mefImport );

            var expected = mefImport.Target.Get();
            var actual = mefImport.Target.Get();

            Assert.AreSame( expected, actual );
        }

        [TestMethod]
        public void AboutWindowFactory_Get_ReturnsNewInstanceIfWindowWasClosed()
        {
            var container = MefTestUtils.CreateMefContainer();
            var mefImport = new MefImportTestHelper();
            container.ComposeParts( mefImport );
            var notExpected = mefImport.Target.Get();
            notExpected.Close();

            var actual = mefImport.Target.Get();

            Assert.AreNotSame( notExpected, actual );
            Assert.IsNotNull( notExpected );
            Assert.IsNotNull( actual );
        }



        private class MefImportTestHelper : 
            MefTestUtils.ImportTestHelper<AboutViewModel, AboutWindow>
        { }
    }
}
