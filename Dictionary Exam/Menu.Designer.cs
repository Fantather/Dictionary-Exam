using Dictionary_Exam.Logic;

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
            SourceCombo = new ComboBox();
            TargetCombo = new ComboBox();
            labelSource = new Label();
            labelTarget = new Label();
            CreateConfirm = new Button();
            SuspendLayout();
            // 
            // CreateDictionary
            // 
            CreateDictionary.Location = new Point(0, 0);
            CreateDictionary.Name = "CreateDictionary";
            CreateDictionary.Size = new Size(75, 23);
            CreateDictionary.TabIndex = 0;
            // 
            // LoadDictionary
            // 
            LoadDictionary.Location = new Point(176, 133);
            LoadDictionary.Name = "LoadDictionary";
            LoadDictionary.Size = new Size(120, 34);
            LoadDictionary.TabIndex = 1;
            LoadDictionary.Text = "Загрузить словарь";
            LoadDictionary.UseVisualStyleBackColor = true;
            LoadDictionary.Click += LoadDictionary_Click;
            // 
            // SourceCombo
            // 
            SourceCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            SourceCombo.Location = new Point(20, 40);
            SourceCombo.Name = "SourceCombo";
            SourceCombo.Size = new Size(200, 23);
            SourceCombo.TabIndex = 1;
            // 
            // TargetCombo
            // 
            TargetCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            TargetCombo.Location = new Point(259, 40);
            TargetCombo.Name = "TargetCombo";
            TargetCombo.Size = new Size(200, 23);
            TargetCombo.TabIndex = 3;
            // 
            // labelSource
            // 
            labelSource.AutoSize = true;
            labelSource.Location = new Point(20, 20);
            labelSource.Name = "labelSource";
            labelSource.Size = new Size(115, 15);
            labelSource.TabIndex = 0;
            labelSource.Text = "Переводимый язык";
            // 
            // labelTarget
            // 
            labelTarget.AutoSize = true;
            labelTarget.Location = new Point(259, 20);
            labelTarget.Name = "labelTarget";
            labelTarget.Size = new Size(160, 15);
            labelTarget.TabIndex = 2;
            labelTarget.Text = "Язык на который переводят";
            // 
            // CreateConfirm
            // 
            CreateConfirm.Location = new Point(176, 79);
            CreateConfirm.Name = "CreateConfirm";
            CreateConfirm.Size = new Size(120, 34);
            CreateConfirm.TabIndex = 0;
            CreateConfirm.Text = "Создать словарь";
            CreateConfirm.UseVisualStyleBackColor = true;
            CreateConfirm.Click += CreateConfirm_Click;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(471, 195);
            Controls.Add(labelSource);
            Controls.Add(SourceCombo);
            Controls.Add(labelTarget);
            Controls.Add(TargetCombo);
            Controls.Add(CreateConfirm);
            Controls.Add(LoadDictionary);
            Name = "Menu";
            Text = "Menu";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button CreateDictionary;
        private Button LoadDictionary;
        private Button CreateConfirm;
        private ComboBox SourceCombo;
        private ComboBox TargetCombo;
        private Label labelSource;
        private Label labelTarget;
    }
}