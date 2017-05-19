namespace XElement.SDM.UI.Win32.Serialization
{
    public interface ISerializationManager
    {
        IData Deserialize();


        void Serialize( IData target );
    }
}
