using App.Core.Contracts;
using System.Collections.Immutable;

namespace App.Core;

public sealed class MultiValueRepository : IMultiValueRepository
{
    /// <summary>
    /// Hack to simulate persisted storage
    /// </summary>
    public static Dictionary<string, HashSet<string>> _store = new Dictionary<string, HashSet<string>>();

    public ICollection<string> Get(string key) => _store[key];

    public void Add(string key, string value)
    {
        if (_store.ContainsKey(key))
            _store[key].Add(value);
        else
            _store.Add(key, new HashSet<string>() { value });
    }

    public void Add(string key, HashSet<string> values)
    {
        if (_store.ContainsKey(key))
        {
            // We can come back and add better logic to implement this better
            foreach (var v in values)
                _store[key].Add(v);
        }
        else
            _store.Add(key, values);
    }

    public bool Remove(string key, string value)
    {
        if (_store[key].Contains(value))
        {
            _store[key].Remove(value);

            return true;
        }

        return false;
    }

    public void RemoveAll(string key)
    {
        _store[key].Clear();
    }

    public bool DoesSetContainsValue(string key, string value)
    {
        if (_store.ContainsKey(key))
        {
            return _store[key].Contains(value);
        }

        return false;
    }

    public void Clear(string key) => _store.Remove(key);
    public void ClearAll() => _store.Clear();

    public ICollection<string> GetAllKeys() => _store.Keys;
    public ImmutableDictionary<string, HashSet<string>> Store() => _store.ToImmutableDictionary();

}
