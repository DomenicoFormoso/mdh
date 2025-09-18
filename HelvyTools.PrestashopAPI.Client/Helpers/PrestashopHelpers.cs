using HelvyTools.PrestashopAPI.Client.Data;

namespace HelvyTools.PrestashopAPI.Client.Helpers
{
    /// <summary>
    /// Helper class for working with multilingual fields
    /// </summary>
    public static class MultilingualHelper
    {
        /// <summary>
        /// Create a Languages collection from a dictionary of language ID and values
        /// </summary>
        public static Languages CreateLanguages(Dictionary<long, string> languageValues)
        {
            var languages = new Languages();
            foreach (var kvp in languageValues)
            {
                languages.Items.Add(new Language
                {
                    Id = kvp.Key,
                    Value = kvp.Value
                });
            }
            return languages;
        }

        /// <summary>
        /// Create a single language item
        /// </summary>
        public static Languages CreateSingleLanguage(long languageId, string value)
        {
            return new Languages
            {
                Items = new List<Language>
                {
                    new Language { Id = languageId, Value = value }
                }
            };
        }

        /// <summary>
        /// Get value for a specific language ID from a Languages collection
        /// </summary>
        public static string? GetLanguageValue(Languages? languages, long languageId)
        {
            return languages?.Items?.FirstOrDefault(l => l.Id == languageId)?.Value;
        }

        /// <summary>
        /// Get all language values as a dictionary
        /// </summary>
        public static Dictionary<long, string> GetAllLanguageValues(Languages? languages)
        {
            if (languages?.Items == null)
                return new Dictionary<long, string>();

            return languages.Items.ToDictionary(l => l.Id, l => l.Value ?? string.Empty);
        }

        /// <summary>
        /// Update or add a language value in a Languages collection
        /// </summary>
        public static void SetLanguageValue(Languages languages, long languageId, string value)
        {
            var existingLanguage = languages.Items?.FirstOrDefault(l => l.Id == languageId);
            if (existingLanguage != null)
            {
                existingLanguage.Value = value;
            }
            else
            {
                languages.Items ??= new List<Language>();
                languages.Items.Add(new Language { Id = languageId, Value = value });
            }
        }
    }

    /// <summary>
    /// Helper class for working with associations
    /// </summary>
    public static class AssociationHelper
    {
        /// <summary>
        /// Create an association collection from a list of IDs
        /// </summary>
        public static AssociationCollection<T> CreateAssociationCollection<T>(IEnumerable<long> ids) 
            where T : Association, new()
        {
            var collection = new AssociationCollection<T>();
            foreach (var id in ids)
            {
                collection.Items.Add(new T { Id = id });
            }
            return collection;
        }

        /// <summary>
        /// Get all IDs from an association collection
        /// </summary>
        public static List<long> GetAssociationIds<T>(AssociationCollection<T>? collection) 
            where T : Association
        {
            return collection?.Items?.Select(a => a.Id).ToList() ?? new List<long>();
        }
    }
}