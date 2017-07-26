using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;

namespace XElement.SDM.UI.Win32.Localization
{
    [TestClass]
    public class testLocalization
    {
        [TestMethod]
        public void testLocalization_DictionariesAreEquivalent_DefaultVsDe()
        {
            var default_resourceSet = GetResourceSet();
            var deDE_resourceSet = GetResourceSet( CULTURE_GERMAN );
            var default_dictionaryEntries = GetDictionaryEntriesFrom( default_resourceSet );
            var deDE_dictionaryEntries = GetDictionaryEntriesFrom( deDE_resourceSet );
            var default_keys = default_dictionaryEntries.Select( entry => (string)entry.Key ).ToList();
            var deDE_keys = deDE_dictionaryEntries.Select( entry => (string)entry.Key ).ToList();
            CollectionAssert.AreEquivalent( default_keys, deDE_keys );
        }


        [TestMethod]
        public void testLocalization_default_NotEmptyNoneNullNoneEmpty()
        {
            var resourceSet = testLocalization.GetResourceSet();

            var dictionaryEntries = GetDictionaryEntriesFrom( resourceSet );
            var values = dictionaryEntries.Select( entry => (string)entry.Value ).ToList();
            Assert.IsTrue( values.Count > 0 );
            CollectionAssert.AllItemsAreNotNull( values );
            CollectionAssert.DoesNotContain( values, String.Empty, NOT_NONE_EMPTY_MESSAGE );
        }


        [TestMethod]
        public void testLocalization_deDE_NotEmptyNoneNullNoneEmpty()
        {
            var resourceSet = testLocalization.GetResourceSet( CULTURE_GERMAN );

            var dictionaryEntries = GetDictionaryEntriesFrom( resourceSet );
            var values = dictionaryEntries.Select( entry => (string)entry.Value ).ToList();
            Assert.IsTrue( values.Count > 0 );
            CollectionAssert.AllItemsAreNotNull( values );
            CollectionAssert.DoesNotContain( values, String.Empty, NOT_NONE_EMPTY_MESSAGE );
        }



        private static IEnumerable<DictionaryEntry> GetDictionaryEntriesFrom( ResourceSet resourceSet )
        {
            var dictionaryEntries = new List<DictionaryEntry>();

            foreach ( DictionaryEntry dictEntry in resourceSet )
            {
                dictionaryEntries.Add( dictEntry );
            }

            return dictionaryEntries;
        }


        private static ResourceSet GetResourceSet( string cultureName, bool inheritFromParents )
        {
            bool createIfNotExists = true;
            var culture = new CultureInfo( cultureName );
            var resourceSet = Locale.ResourceManager.GetResourceSet( culture, 
                                                                     createIfNotExists, 
                                                                     inheritFromParents );
            return resourceSet;
        }

        private static ResourceSet GetResourceSet( string cultureName )
        {
            return testLocalization.GetResourceSet( cultureName, inheritFromParents: false );
        }

        private static ResourceSet GetResourceSet()
        {
            string defaultCulture = String.Empty;
            bool isDefault = true;
            return testLocalization.GetResourceSet( defaultCulture, isDefault );
        }


        private const string CULTURE_GERMAN = "de-DE";

        private const string NOT_NONE_EMPTY_MESSAGE = "At least one entry is equals to 'String.Empty'.";
    }
}
