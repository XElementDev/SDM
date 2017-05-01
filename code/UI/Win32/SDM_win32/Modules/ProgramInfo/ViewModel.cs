namespace XElement.SDM.UI.Win32.Modules.ProgramInfo
{
    // TODO
#region not unit-tested
    internal class ViewModel
    {
        public ViewModel( Model model )
        {
            this._model = model;
        }


        //public Icon ApplicationIcon { get; private set; }


        public string ApplicationName { get; private set; }


        private Model _model;
    }
#endregion
}
