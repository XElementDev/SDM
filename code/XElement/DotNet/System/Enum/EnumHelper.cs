using System;

namespace XElement.DotNet.System
{
#region not unit-tested
    public static class EnumHelper
    {
        //  --> https://stackoverflow.com/questions/79126/create-generic-method-constraining-t-to-an-enum
        public static T GetEnumFromString<T>( string toParse ) where T : struct, IConvertible
        {
            if (!typeof( T ).IsEnum)
            {
                throw new ArgumentException();
            }
            var parsed = Enum.Parse( typeof( T ), toParse );
            return (T)parsed;
        }


        public static string GetStringFromEnum<T>( T value ) where T : struct, IConvertible
        {
            if (!typeof( T ).IsEnum)
            {
                throw new ArgumentException();
            }
            return Enum.GetName( typeof( T ), value );
        }
    }
#endregion
}
