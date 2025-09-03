using Dictionary_Exam.Logic.Enums;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

//Задание 1
// Создать приложение «Словари»
// Основная задача проекта: хранить словари на разных языках и разрешать пользователю находить перевод нужного слова или фразы

// Интерфейс приложения должен предоставлять такие возможности:

// ■ Создавать словарь
// При создании нужно указать тип словаря
// Например, англо-русский или русско-английский

// ■ Добавлять слово и его перевод в уже существующий словарь
// Так как у слова может быть несколько переводов, необходимо поддерживать возможность создания нескольких вариантов перевода

// ■ Заменять слово или его перевод в словаре

// ■ Удалять слово или перевод
// Если удаляется слово, все его переводы удаляются вместе с ним
// Нельзя удалить перевод слова, если это последний вариант перевода

// ■ Искать перевод слова

// ■ Словари должны храниться в файлах

// ■ Слово и варианты его переводов можно экспортировать в отдельный файл результата

// ■ При старте программы необходимо показывать меню для работы с программой

// Если выбор пункта меню открывает подменю, то тогда в нем требуется предусмотреть возможность возврата в предыдущее меню



// AddWord - добавить события для CheckPair
namespace Dictionary_Exam.Logic
{
    internal class WordDictionary
    {
        /* ==== Поля и Свойства ==== */

        [JsonInclude]
        private readonly Dictionary<string, List<string>> _dictionary;          // Сам словарь, хранит слово из переводимого языка в виде ключа и список слов из языка, на который переводят
        [JsonIgnore]
        public readonly ChacingReadOnlyDictionaryWrapper ReadOnlyWrapper;     // Публичное, неизменяемое представление словаря

        public Languages SourceLanguage { get; }        // Язык с которого переводят
        public Languages TargetLanguage { get; }        // Язык на который переводят


        /* ==== Конструкторы ==== */
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceLanguage">Язык с которого переводят</param>
        /// <param name="targetLanguage">Язык на который переводят</param>
        public WordDictionary(Languages sourceLanguage, Languages targetLanguage)
        {
            _dictionary = new Dictionary<string, List<string>>();
            ReadOnlyWrapper = new(_dictionary);
            SourceLanguage = sourceLanguage;
            TargetLanguage = targetLanguage;
        }

        [JsonConstructor]
        public WordDictionary(Languages sourceLanguage, Languages targetLanguage, Dictionary<string, List<string>> dictionary)
        {
            _dictionary = dictionary ?? new Dictionary<string, List<string>>();
            ReadOnlyWrapper = new ChacingReadOnlyDictionaryWrapper(_dictionary);
            SourceLanguage = sourceLanguage;
            TargetLanguage = targetLanguage;
        }


        /* ==== Методы ==== */

        /// <summary>
        /// Добавление нового слова и перевода для него
        /// </summary>
        /// <param name="sourceWord"></param>
        /// <param name="targetWord"></param>
        public void AddWord(string sourceWord, string targetWord)
        {
            CheckPairNull(sourceWord, targetWord);

            if (_dictionary.TryAdd(sourceWord, [targetWord]) == false)
            {
                AddTranslate(sourceWord, targetWord);
            }
        }

        public void ChangeWord(string oldKey, string newKey)
        {
            CheckPairNull(oldKey, newKey);

            if (oldKey == newKey)
                return;

            if(_dictionary.ContainsKey(oldKey) == true && _dictionary.ContainsKey(newKey) == false)
            {
                _dictionary[newKey] = _dictionary[oldKey];
                _dictionary.Remove(oldKey);
                ReadOnlyWrapper.Invalidate(oldKey);
                ReadOnlyWrapper.Invalidate(newKey);
            }
        }

        public void DeleteWord(string key)
        {
            if(_dictionary.Remove(key) == false)
            {
                throw new ArgumentException(nameof(key));
            }
        }

        /// <summary>
        /// Добавление нового перевода для существующего слова
        /// </summary>
        /// <param name="sourceWord"></param>
        /// <param name="newWord"></param>
        public void AddTranslate(string sourceWord, string newWord)
        {
            CheckPairNull(sourceWord, newWord);
            CheckKey(sourceWord);

            var list = _dictionary[sourceWord];

            if (list.Contains(newWord) ==false)
            {
                list.Add(newWord);
                ReadOnlyWrapper.Invalidate(sourceWord);
            }
        }

        public void AddTranslate(string sourceWord, IReadOnlyList<string> listNewWords)
        {
            CheckKey(sourceWord);

            List<string> list = _dictionary[sourceWord];
            
            foreach (string newWord in listNewWords)
            {
                if (list.Contains(newWord) == false)
                {
                    list.Add(newWord);
                }
            }

            ReadOnlyWrapper.Invalidate(sourceWord);
        }

        /// <summary>
        /// Изменяет перевод по ключу
        /// </summary>
        /// <param name="sourceWord"></param>
        /// <param name="oldWord"></param>
        public void ChangeTranslate(string sourceWord, string oldWord, string newWord)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(nameof(sourceWord));
            ArgumentNullException.ThrowIfNullOrEmpty(nameof(oldWord));
            ArgumentNullException.ThrowIfNullOrEmpty(nameof(newWord));
            CheckKey(sourceWord);
            if (_dictionary.TryGetValue(sourceWord, out List<string>? list))
            {
                int oldIndex = list.IndexOf(oldWord);
                if (oldIndex != -1)
                {
                    list[oldIndex] = newWord;
                    ReadOnlyWrapper.Invalidate(sourceWord);
                }
                else
                    throw new ArgumentException($"Слово {oldWord} в переводах не найдено");
            }
        }

        public void DeleteTranslate(string keyWord, string translateToDelete)
        {
            CheckPairNull(keyWord, translateToDelete);
            CheckKey(keyWord);
            if ( _dictionary.TryGetValue(keyWord, out List<string>? list))
            {
                if (list.Count > 1)
                {
                    if (list.Remove(translateToDelete))
                        ReadOnlyWrapper.Invalidate(keyWord);
                    else throw new ArgumentException($"У слова {keyWord} перевод {translateToDelete} не найден");
                }

                else throw new InvalidOperationException($"Нельзя удалить {translateToDelete}, потому что это последний перевод у слова {keyWord}");
            }
        }

        // Ну, он оказался не нужен
        public IReadOnlyList<string> FindTranslate(string sourceWord)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(sourceWord);

            if(_dictionary.TryGetValue(sourceWord, out List<string> list))
                return list.AsReadOnly();
            else
                throw new KeyNotFoundException($"Ключ {sourceWord} не найден");
        }


        /* ==== Вспомогательные методы ==== */
        // ---- Проверка корректности переданных слов ----
        protected void CheckPairNull(string sourceWord, string targetWord)
        {
            if (string.IsNullOrEmpty(sourceWord))
            {
                throw new ArgumentNullException(nameof(sourceWord));
            }

            if (string.IsNullOrEmpty(targetWord))
            {
                throw new ArgumentNullException(nameof(targetWord));
            }
        }

        // ---- Поиск ключа в словаре ----
        protected void CheckKey(string sourceWord)
        {
            if(_dictionary.ContainsKey(sourceWord) == false)
            {
                throw new KeyNotFoundException($"Не удалось найти слово {sourceWord} в словаре");
            }
        }
    }
}
