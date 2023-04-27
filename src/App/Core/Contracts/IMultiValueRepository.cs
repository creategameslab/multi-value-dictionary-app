using System.Collections.Immutable;

namespace App.Core.Contracts
{
    public interface IMultiValueRepository
    {
        ICollection<string> Get(string key);
        ICollection<string> GetAllKeys();
        bool DoesSetContainsValue(string key, string value);
        void Add(string key, string value);
        void Add(string key, HashSet<string> values);
        bool Remove(string key, string value);
        void RemoveAll(string key);
        void Clear(string key);
        void ClearAll();
        ImmutableDictionary<string, HashSet<string>> Store();
    }
}
