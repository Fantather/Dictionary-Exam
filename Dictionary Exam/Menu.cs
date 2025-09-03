using Dictionary_Exam.Logic;
using Dictionary_Exam.Logic.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dictionary_Exam
{
    public partial class Menu : Form
    {
        private readonly WordDictionaryFileManager _fileManager = new WordDictionaryFileManager();

        public Menu()
        {
            InitializeComponent();

            // Заполняю ComboBoxes из enum Languages
            var langs = Enum.GetValues(typeof(Languages)).Cast<Languages>().ToList();
            SourceCombo.DataSource = langs;
            TargetCombo.DataSource = langs.ToList();

            // Начальные значения
            SourceCombo.SelectedItem = Languages.Russian;
            TargetCombo.SelectedItem = Languages.English;
        }

        private void CreateConfirm_Click(object sender, EventArgs e)
        {
            if (SourceCombo.SelectedItem is Languages src && TargetCombo.SelectedItem is Languages tgt)
            {
                var dict = new WordDictionary(src, tgt);
                OpenForm1WithDictionary(dict);
            }
        }

        private void LoadDictionary_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
                ofd.Title = "Выберите файл словаря";

                if (ofd.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    WordDictionary loaded = _fileManager.LoadFromFile(ofd.FileName);
                    OpenForm1WithDictionary(loaded);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void OpenForm1WithDictionary(WordDictionary dict)
        {
            // Скрываем меню и показываем Form1 модально. Когда Form1 закроется — показываем меню снова.
            this.Hide();
            using (var f = new Form1(dict))
            {
                f.ShowDialog(this);
            }
            this.Show();
        }
    }
}
