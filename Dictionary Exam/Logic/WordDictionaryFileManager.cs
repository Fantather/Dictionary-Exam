using Dictionary_Exam.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Windows.Forms.Design.AxImporter;

namespace Dictionary_Exam.Logic
{
    internal class WordDictionaryFileManager : IFileManager
    {
        public void SaveToFile(string filePath, WordDictionary dict)
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true,
                IncludeFields = true
            };

            string json = JsonSerializer.Serialize(dict, options);
            File.WriteAllText(filePath, json);
        }

        public WordDictionary LoadFromFile(string filePath)
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true,
                IncludeFields = true
            };
            string json = File.ReadAllText(filePath);

            WordDictionary? wordDictionary = JsonSerializer.Deserialize<WordDictionary>(json, options);
            return wordDictionary ?? throw new InvalidDataException($"Файл на пути {filePath} повреждён");
        }

        public void SaveTranslateToFile(string filePath, KeyValuePair<string, IReadOnlyList<string>> pair)
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            string json = JsonSerializer.Serialize(pair, options);
            File.WriteAllText(filePath, json);
        }

        public KeyValuePair<string, List<string>> LoadTranslateFromFile(string filePath)
        {
            if (File.Exists(filePath) == false)
                throw new FileNotFoundException($"Пути {filePath} не существует");

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string json = File.ReadAllText(filePath);
            KeyValuePair<string, List<string>>? pair = JsonSerializer.Deserialize<KeyValuePair<string, List<string>>>(json, options);

            return pair ?? throw new InvalidDataException($"Файл на пути {filePath} повреждён");
        }
    }
}
