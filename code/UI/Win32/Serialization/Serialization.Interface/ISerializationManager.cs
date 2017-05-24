namespace XElement.SDM.UI.Win32.Serialization
{
    public interface ISerializationManager
    {
        IData Deserialize();


        string FilePath { get; }


        void Serialize( IData target );
    }
}
