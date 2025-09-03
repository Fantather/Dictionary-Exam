using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Я знаю, что кеш мне нафиг не упал, но мне было интересно его реализовать

namespace Dictionary_Exam.Logic
{
    /// <summary>
    /// Класс обёртка которая не позволяет изменять значения массива
    /// </summary>
    internal class ChacingReadOnlyDictionaryWrapper : IReadOnlyDictionary<string, IReadOnlyList<string>>
    {
        private readonly Dictionary<string, List<string>> _sourceDictionary;                    // Ссылка на оригинальный Словарь
        private readonly ConcurrentDictionary<string, IReadOnlyList<string>> _cache = new();    // Кеш

        // Конструктор
        public ChacingReadOnlyDictionaryWrapper(Dictionary<string, List<string>> sourceDictionary)
        {
            _sourceDictionary = sourceDictionary ?? throw new ArgumentNullException(nameof(sourceDictionary));
        }

        public static implicit operator ChacingReadOnlyDictionaryWrapper(Dictionary<string, List<string>> dictionary)
        {
            return new ChacingReadOnlyDictionaryWrapper(dictionary);
        }


        // Свойства интерфейса
        public int Count => _sourceDictionary.Count;
        public IEnumerable<string> Keys => _sourceDictionary.Keys;
        public IEnumerable<IReadOnlyList<string>> Values => Keys.Select(key => this[key]);


        public IReadOnlyList<string> this[string key]
        {
            get
            {
                if (_cache.TryGetValue(key, out var cached))
                    return cached;

                if (_sourceDictionary.TryGetValue(key, out List<string> sourseList))
                {
                    IReadOnlyList<string> readOnlyList = sourseList.AsReadOnly();
                    _cache[key] = readOnlyList;
                    return readOnlyList;
                }

                throw new KeyNotFoundException($"Key {key} not found.");
            }
        }

        // Методы интерфейса
        public bool TryGetValue(string key, out IReadOnlyList<string>? value)
        {
            if( _cache.TryGetValue(key, out value))
                return true;

            if (_sourceDictionary.TryGetValue(key, out List<string> list))
            {
                value = list.AsReadOnly();
                _cache[key] = value;
                return true;
            }

            value = null;
            return false;
        }

        public bool ContainsKey(string key) => _sourceDictionary.ContainsKey(key);

        public IEnumerator<KeyValuePair<string, IReadOnlyList<string>>> GetEnumerator()
        {
            foreach(var key in Keys)
                yield return new KeyValuePair<string, IReadOnlyList<string>>(key, this[key]);
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();


        // --- Методы для управления Кешем ---

        // Удалить конкретный ключ из Кеша
        public void Invalidate(string key) => _cache.TryRemove(key, out _);

        // Полностью очистить Кеш
        public void Clear() => _cache.Clear();
    }
}
