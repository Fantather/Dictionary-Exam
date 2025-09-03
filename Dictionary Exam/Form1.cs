using Dictionary_Exam.Logic;
using Dictionary_Exam.Logic.Enums;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Dictionary_Exam
{
    internal partial class Form1 : Form
    {
        private WordDictionary _dictionary;
        private readonly WordDictionaryFileManager _fileManager = new WordDictionaryFileManager();
        private string _keyWord = string.Empty;
        private string _valueWord = string.Empty;

        // Существующий конструктор оставляем для совместимости (создаёт default словарь)
        public Form1()
        {
            InitializeComponent();
            _dictionary = new WordDictionary(Languages.Russian, Languages.English);
            InitAfterDictionarySet();
        }

        // Конструктор по языкам
        public Form1(Languages source, Languages target)
        {
            InitializeComponent();
            _dictionary = new WordDictionary(source, target);
            InitAfterDictionarySet();
        }

        // Конструктор, который принимает уже загруженный словарь
        public Form1(WordDictionary dict)
        {
            if (dict == null) throw new ArgumentNullException(nameof(dict));
            InitializeComponent();
            _dictionary = dict;
            InitAfterDictionarySet();
        }

        // Общая инициализация, которая должна выполняться после установки _dictionary
        private void InitAfterDictionarySet()
        {
            KeyList.DataSource = _dictionary.ReadOnlyWrapper.Keys.ToList();
        }

        private void KeyList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (KeyList.SelectedItem is string selectedKey)
            {
                ValueList.DataSource = _dictionary.ReadOnlyWrapper[selectedKey];


                _keyWord = selectedKey;

                if (ValueList.SelectedItem is string selectedValue)
                    _valueWord = selectedValue;

                // Устанавливаю значения в полях для ввода, на выбранные пользователем
                WordForChangeOld.Text = _keyWord;
                ExistingWord.Text = _keyWord;
                KeyForChangeTranslate.Text = _keyWord;
                WordToDelete.Text = _keyWord;
                WordForDeleteTranslate.Text = _keyWord;

                OldTranslate.Text = _valueWord;
                DeletingTranslate.Text = _valueWord;
            }
        }

        private void ValueList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ValueList.SelectedItem is string selectedValue)
                _valueWord = selectedValue;

            OldTranslate.Text = _valueWord;
            DeletingTranslate.Text = _valueWord;
        }

        private void AddWord_Click(object sender, EventArgs e)
        {
            _dictionary.AddWord(SourseWord.Text, TranslateWord.Text);

            UpdateKeyList();

            // Очищаем поля ввода
            SourseWord.Text = "";
            TranslateWord.Text = "";
        }

        private void ChangeWord_Click(object sender, EventArgs e)
        {
            _dictionary.ChangeWord(WordForChangeOld.Text, WordForChangeNew.Text);

            UpdateKeyList();
            WordForChangeOld.Text = _keyWord;
            WordForChangeNew.Text = "";
        }

        private void DeleteWord_Click(object sender, EventArgs e)
        {
            _dictionary.DeleteWord(WordToDelete.Text);

            UpdateKeyList();
            WordToDelete.Text = _keyWord;
        }

        private void AddTranslate_Click(object sender, EventArgs e)
        {
            _dictionary.AddTranslate(ExistingWord.Text, AddedTranslate.Text);

            UpdateKeyList();
            ExistingWord.Text = _keyWord;
            AddedTranslate.Text = "";
        }

        private void ChangeTranslate_Click(object sender, EventArgs e)
        {
            _dictionary.ChangeTranslate(KeyForChangeTranslate.Text, OldTranslate.Text, NewTranslate.Text);

            UpdateKeyList();
            KeyForChangeTranslate.Text = _keyWord;
            OldTranslate.Text = _valueWord;
            NewTranslate.Text = "";
        }

        private void DeleteTranslate_Click(object sender, EventArgs e)
        {
            _dictionary.DeleteTranslate(WordForDeleteTranslate.Text, DeletingTranslate.Text);

            UpdateKeyList();
            WordForDeleteTranslate.Text = _keyWord;
            DeletingTranslate.Text = _valueWord;
        }

        private void SaveSelectedTranslate_Click(object sender, EventArgs e)
        {
            // Проверяем выбранный ключ
            if (KeyList.SelectedItem is not string selectedKey)
            {
                MessageBox.Show("Сначала выберите слово в левом списке.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Сохраняем все переводы для выбранного слова
            IReadOnlyList<string> translationsToSave = _dictionary.ReadOnlyWrapper[selectedKey];

            // Открываем диалог сохранения файла
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                sfd.FileName = $"{selectedKey}_{DateTime.Now:yyyyMMdd_HHmmss}.json";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var pair = new KeyValuePair<string, IReadOnlyList<string>>(selectedKey, translationsToSave);
                        _fileManager.SaveTranslateToFile(sfd.FileName, pair);
                        MessageBox.Show("Перевод успешно сохранён.", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void SaveDictionary_Click(object sender, EventArgs e)
        {
            // Открываем диалог сохранения файла
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                sfd.FileName = $"{_dictionary.SourceLanguage}-{_dictionary.TargetLanguage} dictionary.json";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _fileManager.SaveToFile(sfd.FileName, _dictionary);
                        MessageBox.Show("Словарь успешно сохранён.", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void LoadSelectedTranslate_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                ofd.Title = "Выберите файл с переводом";

                if (ofd.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    // Загружаем пару (слово -> список переводов) из файла
                    var pair = _fileManager.LoadTranslateFromFile(ofd.FileName); // KeyValuePair<string, List<string>>
                    string key = pair.Key;
                    List<string> translations = pair.Value ?? new List<string>();

                    // Если нет переводов в файле — просто уведомляем и выходим
                    if (translations.Count == 0)
                    {
                        MessageBox.Show("Файл не содержит переводов.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    if (_dictionary.ReadOnlyWrapper.Keys.Contains(key))
                        _dictionary.AddTranslate(key, translations);

                    else
                        _dictionary.AddWord(key, translations);

                    UpdateKeyList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        // Обновляем KeyList
        private void UpdateKeyList()
        {
            KeyList.DataSource = null;
            KeyList.DataSource = _dictionary.ReadOnlyWrapper.Keys.ToList();
        }  
    }
}
