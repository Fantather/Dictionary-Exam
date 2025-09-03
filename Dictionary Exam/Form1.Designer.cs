namespace Dictionary_Exam
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            KeyList = new ListBox();
            ValueList = new ListBox();
            AddWord = new Button();
            SourseWord = new TextBox();
            TranslateWord = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            WordForChangeNew = new TextBox();
            WordForChangeOld = new TextBox();
            ChangeWord = new Button();
            label5 = new Label();
            WordToDelete = new TextBox();
            DeleteWord = new Button();
            label6 = new Label();
            label7 = new Label();
            AddedTranslate = new TextBox();
            ExistingWord = new TextBox();
            AddTranslate = new Button();
            label8 = new Label();
            label9 = new Label();
            KeyForChangeTranslate = new TextBox();
            ChangeTranslate = new Button();
            OldTranslate = new TextBox();
            NewTranslate = new TextBox();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            DeletingTranslate = new TextBox();
            WordForDeleteTranslate = new TextBox();
            DeleteTranslate = new Button();
            SaveSelectedTranslate = new Button();
            SaveDictionary = new Button();
            LoadSelectedTranslate = new Button();
            SuspendLayout();
            // 
            // KeyList
            // 
            KeyList.FormattingEnabled = true;
            KeyList.Location = new Point(10, 12);
            KeyList.Name = "KeyList";
            KeyList.Size = new Size(184, 409);
            KeyList.TabIndex = 0;
            KeyList.SelectedIndexChanged += KeyList_SelectedIndexChanged;
            // 
            // ValueList
            // 
            ValueList.FormattingEnabled = true;
            ValueList.Location = new Point(200, 13);
            ValueList.Name = "ValueList";
            ValueList.Size = new Size(308, 409);
            ValueList.TabIndex = 1;
            ValueList.SelectedIndexChanged += ValueList_SelectedIndexChanged;
            // 
            // AddWord
            // 
            AddWord.Location = new Point(592, 56);
            AddWord.Name = "AddWord";
            AddWord.Size = new Size(118, 25);
            AddWord.TabIndex = 2;
            AddWord.Text = "Добавить слово";
            AddWord.UseVisualStyleBackColor = true;
            AddWord.Click += AddWord_Click;
            // 
            // SourseWord
            // 
            SourseWord.Location = new Point(545, 27);
            SourseWord.Name = "SourseWord";
            SourseWord.Size = new Size(104, 23);
            SourseWord.TabIndex = 3;
            // 
            // TranslateWord
            // 
            TranslateWord.Location = new Point(655, 27);
            TranslateWord.Name = "TranslateWord";
            TranslateWord.Size = new Size(104, 23);
            TranslateWord.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(574, 9);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 5;
            label1.Text = "Слово";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(676, 9);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 6;
            label2.Text = "Перевод";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(668, 95);
            label3.Name = "label3";
            label3.Size = new Size(78, 15);
            label3.TabIndex = 11;
            label3.Text = "Новое слово";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(537, 95);
            label4.Name = "label4";
            label4.Size = new Size(112, 15);
            label4.TabIndex = 10;
            label4.Text = "Заменяемое слово";
            // 
            // WordForChangeNew
            // 
            WordForChangeNew.Location = new Point(655, 113);
            WordForChangeNew.Name = "WordForChangeNew";
            WordForChangeNew.Size = new Size(104, 23);
            WordForChangeNew.TabIndex = 9;
            // 
            // WordForChangeOld
            // 
            WordForChangeOld.Location = new Point(537, 113);
            WordForChangeOld.Name = "WordForChangeOld";
            WordForChangeOld.Size = new Size(112, 23);
            WordForChangeOld.TabIndex = 8;
            // 
            // ChangeWord
            // 
            ChangeWord.Location = new Point(584, 142);
            ChangeWord.Name = "ChangeWord";
            ChangeWord.Size = new Size(118, 25);
            ChangeWord.TabIndex = 7;
            ChangeWord.Text = "Изменить слово";
            ChangeWord.UseVisualStyleBackColor = true;
            ChangeWord.Click += ChangeWord_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(40, 437);
            label5.Name = "label5";
            label5.Size = new Size(103, 15);
            label5.TabIndex = 14;
            label5.Text = "Удаляемое слово";
            // 
            // WordToDelete
            // 
            WordToDelete.Location = new Point(40, 455);
            WordToDelete.Name = "WordToDelete";
            WordToDelete.Size = new Size(103, 23);
            WordToDelete.TabIndex = 13;
            // 
            // DeleteWord
            // 
            DeleteWord.Location = new Point(40, 484);
            DeleteWord.Name = "DeleteWord";
            DeleteWord.Size = new Size(103, 25);
            DeleteWord.TabIndex = 12;
            DeleteWord.Text = "Удалить слово";
            DeleteWord.UseVisualStyleBackColor = true;
            DeleteWord.Click += DeleteWord_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(661, 225);
            label6.Name = "label6";
            label6.Size = new Size(93, 15);
            label6.TabIndex = 19;
            label6.Text = "Новый перевод";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(574, 225);
            label7.Name = "label7";
            label7.Size = new Size(42, 15);
            label7.TabIndex = 18;
            label7.Text = "Слово";
            // 
            // AddedTranslate
            // 
            AddedTranslate.Location = new Point(655, 243);
            AddedTranslate.Name = "AddedTranslate";
            AddedTranslate.Size = new Size(104, 23);
            AddedTranslate.TabIndex = 17;
            // 
            // ExistingWord
            // 
            ExistingWord.Location = new Point(545, 243);
            ExistingWord.Name = "ExistingWord";
            ExistingWord.Size = new Size(104, 23);
            ExistingWord.TabIndex = 16;
            // 
            // AddTranslate
            // 
            AddTranslate.Location = new Point(592, 272);
            AddTranslate.Name = "AddTranslate";
            AddTranslate.Size = new Size(118, 25);
            AddTranslate.TabIndex = 15;
            AddTranslate.Text = "Добавить перевод";
            AddTranslate.UseVisualStyleBackColor = true;
            AddTranslate.Click += AddTranslate_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(706, 313);
            label8.Name = "label8";
            label8.Size = new Size(93, 15);
            label8.TabIndex = 24;
            label8.Text = "Новый перевод";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(533, 313);
            label9.Name = "label9";
            label9.Size = new Size(42, 15);
            label9.TabIndex = 23;
            label9.Text = "Слово";
            // 
            // KeyForChangeTranslate
            // 
            KeyForChangeTranslate.Location = new Point(512, 331);
            KeyForChangeTranslate.Name = "KeyForChangeTranslate";
            KeyForChangeTranslate.Size = new Size(88, 23);
            KeyForChangeTranslate.TabIndex = 21;
            // 
            // ChangeTranslate
            // 
            ChangeTranslate.Location = new Point(592, 360);
            ChangeTranslate.Name = "ChangeTranslate";
            ChangeTranslate.Size = new Size(118, 25);
            ChangeTranslate.TabIndex = 20;
            ChangeTranslate.Text = "Изменить перевод";
            ChangeTranslate.UseVisualStyleBackColor = true;
            ChangeTranslate.Click += ChangeTranslate_Click;
            // 
            // OldTranslate
            // 
            OldTranslate.Location = new Point(606, 331);
            OldTranslate.Name = "OldTranslate";
            OldTranslate.Size = new Size(94, 23);
            OldTranslate.TabIndex = 25;
            // 
            // NewTranslate
            // 
            NewTranslate.Location = new Point(706, 331);
            NewTranslate.Name = "NewTranslate";
            NewTranslate.Size = new Size(93, 23);
            NewTranslate.TabIndex = 26;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(606, 313);
            label10.Name = "label10";
            label10.Size = new Size(97, 15);
            label10.TabIndex = 27;
            label10.Text = "Старый перевод";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(338, 437);
            label11.Name = "label11";
            label11.Size = new Size(118, 15);
            label11.TabIndex = 32;
            label11.Text = "Удаляемый перевод";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(257, 437);
            label12.Name = "label12";
            label12.Size = new Size(42, 15);
            label12.TabIndex = 31;
            label12.Text = "Слово";
            // 
            // DeletingTranslate
            // 
            DeletingTranslate.Location = new Point(338, 455);
            DeletingTranslate.Name = "DeletingTranslate";
            DeletingTranslate.Size = new Size(118, 23);
            DeletingTranslate.TabIndex = 30;
            // 
            // WordForDeleteTranslate
            // 
            WordForDeleteTranslate.Location = new Point(228, 455);
            WordForDeleteTranslate.Name = "WordForDeleteTranslate";
            WordForDeleteTranslate.Size = new Size(104, 23);
            WordForDeleteTranslate.TabIndex = 29;
            // 
            // DeleteTranslate
            // 
            DeleteTranslate.Location = new Point(289, 484);
            DeleteTranslate.Name = "DeleteTranslate";
            DeleteTranslate.Size = new Size(118, 25);
            DeleteTranslate.TabIndex = 28;
            DeleteTranslate.Text = "Удалить перевод";
            DeleteTranslate.UseVisualStyleBackColor = true;
            DeleteTranslate.Click += DeleteTranslate_Click;
            // 
            // SaveSelectedTranslate
            // 
            SaveSelectedTranslate.Location = new Point(564, 461);
            SaveSelectedTranslate.Name = "SaveSelectedTranslate";
            SaveSelectedTranslate.Size = new Size(166, 23);
            SaveSelectedTranslate.TabIndex = 33;
            SaveSelectedTranslate.Text = "Сохранить перевод в файл";
            SaveSelectedTranslate.UseVisualStyleBackColor = true;
            SaveSelectedTranslate.Click += SaveSelectedTranslate_Click;
            // 
            // SaveDictionary
            // 
            SaveDictionary.Location = new Point(564, 420);
            SaveDictionary.Name = "SaveDictionary";
            SaveDictionary.Size = new Size(166, 23);
            SaveDictionary.TabIndex = 34;
            SaveDictionary.Text = "Сохранить словарь в файл";
            SaveDictionary.UseVisualStyleBackColor = true;
            SaveDictionary.Click += SaveDictionary_Click;
            // 
            // LoadSelectedTranslate
            // 
            LoadSelectedTranslate.Location = new Point(555, 490);
            LoadSelectedTranslate.Name = "LoadSelectedTranslate";
            LoadSelectedTranslate.Size = new Size(185, 23);
            LoadSelectedTranslate.TabIndex = 35;
            LoadSelectedTranslate.Text = "Загрузить перевод из файла";
            LoadSelectedTranslate.UseVisualStyleBackColor = true;
            LoadSelectedTranslate.Click += LoadSelectedTranslate_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(813, 540);
            Controls.Add(LoadSelectedTranslate);
            Controls.Add(SaveDictionary);
            Controls.Add(label11);
            Controls.Add(label12);
            Controls.Add(DeletingTranslate);
            Controls.Add(WordForDeleteTranslate);
            Controls.Add(DeleteTranslate);
            Controls.Add(label10);
            Controls.Add(NewTranslate);
            Controls.Add(OldTranslate);
            Controls.Add(label8);
            Controls.Add(label9);
            Controls.Add(KeyForChangeTranslate);
            Controls.Add(ChangeTranslate);
            Controls.Add(label6);
            Controls.Add(label7);
            Controls.Add(AddedTranslate);
            Controls.Add(ExistingWord);
            Controls.Add(AddTranslate);
            Controls.Add(label5);
            Controls.Add(WordToDelete);
            Controls.Add(DeleteWord);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(WordForChangeNew);
            Controls.Add(WordForChangeOld);
            Controls.Add(ChangeWord);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(TranslateWord);
            Controls.Add(SourseWord);
            Controls.Add(AddWord);
            Controls.Add(ValueList);
            Controls.Add(KeyList);
            Controls.Add(SaveSelectedTranslate);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox KeyList;
        private ListBox ValueList;
        private Button AddWord;
        private TextBox SourseWord;
        private TextBox TranslateWord;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox WordForChangeNew;
        private TextBox WordForChangeOld;
        private Button ChangeWord;
        private Label label5;
        private TextBox WordToDelete;
        private Button DeleteWord;
        private Label label6;
        private Label label7;
        private TextBox AddedTranslate;
        private TextBox ExistingWord;
        private Button AddTranslate;
        private Label label8;
        private Label label9;
        private TextBox KeyForChangeTranslate;
        private Button ChangeTranslate;
        private TextBox OldTranslate;
        private TextBox NewTranslate;
        private Label label10;
        private Label label11;
        private Label label12;
        private TextBox DeletingTranslate;
        private TextBox WordForDeleteTranslate;
        private Button DeleteTranslate;
        private Button SaveSelectedTranslate;
        private Button SaveDictionary;
        private Button LoadSelectedTranslate;
    }
}
