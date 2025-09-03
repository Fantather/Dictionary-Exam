namespace Dictionary_Exam
{
    partial class Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            CreateDictionary = new Button();
            LoadDictionary = new Button();
            SuspendLayout();
            // 
            // CreateDictionary
            // 
            CreateDictionary.Location = new Point(100, 41);
            CreateDictionary.Name = "CreateDictionary";
            CreateDictionary.Size = new Size(135, 31);
            CreateDictionary.TabIndex = 0;
            CreateDictionary.Text = "Создать словарь";
            CreateDictionary.UseVisualStyleBackColor = true;
            CreateDictionary.Click += CreateDictionary_Click;
            // 
            // LoadDictionary
            // 
            LoadDictionary.Location = new Point(100, 89);
            LoadDictionary.Name = "LoadDictionary";
            LoadDictionary.Size = new Size(135, 31);
            LoadDictionary.TabIndex = 1;
            LoadDictionary.Text = "Загрузить словарь";
            LoadDictionary.UseVisualStyleBackColor = true;
            LoadDictionary.Click += LoadDictionary_Click;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(332, 179);
            Controls.Add(LoadDictionary);
            Controls.Add(CreateDictionary);
            Name = "Menu";
            Text = "Menu";
            ResumeLayout(false);
        }

        #endregion

        private Button CreateDictionary;
        private Button LoadDictionary;
    }
}