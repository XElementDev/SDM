namespace XElement.SDM.UI.Win32.Localization
{
#region not unit-tested
    public class LocalizationForXaml
    {
        static LocalizationForXaml()
        {
            LocalizationForXaml._singletonLocale = null;
        }


        public Locale Locale
        {
            get
            {
                var instance = LocalizationForXaml._singletonLocale ?? new Locale();
                LocalizationForXaml._singletonLocale = instance;
                return instance;
            }
        }


        private static Locale _singletonLocale;
    }
#endregion
}
