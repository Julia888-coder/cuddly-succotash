namespace MyWinFormsApp
{
    partial class MainForm
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
            listBoxItems = new ListBox();
            buttonAdd = new Button();
            buttonEdit = new Button();
            buttonRemove = new Button();
            buttonSave = new Button();
            buttonLoad = new Button();
            numericUpDownAgeComparing = new NumericUpDown();
            labelAgeComparing = new Label();
            buttonAgeComparing = new Button();
            listBoxAgeComparing = new ListBox();
            labelPopularCity = new Label();
            buttonPopularCity = new Button();
            textBoxPopularCity = new TextBox();
            ((System.ComponentModel.ISupportInitialize)numericUpDownAgeComparing).BeginInit();
            SuspendLayout();
            // 
            // listBoxItems
            // 
            listBoxItems.FormattingEnabled = true;
            listBoxItems.ItemHeight = 25;
            listBoxItems.Location = new Point(13, 15);
            listBoxItems.Margin = new Padding(3, 4, 3, 4);
            listBoxItems.Name = "listBoxItems";
            listBoxItems.Size = new Size(1010, 354);
            listBoxItems.TabIndex = 0;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(13, 377);
            buttonAdd.Margin = new Padding(3, 4, 3, 4);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(133, 62);
            buttonAdd.TabIndex = 1;
            buttonAdd.Text = "Добавить";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // buttonEdit
            // 
            buttonEdit.Location = new Point(153, 377);
            buttonEdit.Margin = new Padding(3, 4, 3, 4);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(133, 62);
            buttonEdit.TabIndex = 2;
            buttonEdit.Text = "Изменить";
            buttonEdit.UseVisualStyleBackColor = true;
            buttonEdit.Click += buttonEdit_Click;
            // 
            // buttonRemove
            // 
            buttonRemove.Location = new Point(293, 377);
            buttonRemove.Margin = new Padding(3, 4, 3, 4);
            buttonRemove.Name = "buttonRemove";
            buttonRemove.Size = new Size(133, 62);
            buttonRemove.TabIndex = 3;
            buttonRemove.Text = "Удалить";
            buttonRemove.UseVisualStyleBackColor = true;
            buttonRemove.Click += buttonRemove_Click;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(890, 377);
            buttonSave.Margin = new Padding(3, 4, 3, 4);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(133, 62);
            buttonSave.TabIndex = 4;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonLoad
            // 
            buttonLoad.Location = new Point(750, 377);
            buttonLoad.Margin = new Padding(3, 4, 3, 4);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(133, 62);
            buttonLoad.TabIndex = 5;
            buttonLoad.Text = "Загрузить";
            buttonLoad.UseVisualStyleBackColor = true;
            buttonLoad.Click += buttonLoad_Click;
            // 
            // numericUpDownAgeComparing
            // 
            numericUpDownAgeComparing.Location = new Point(169, 694);
            numericUpDownAgeComparing.Name = "numericUpDownAgeComparing";
            numericUpDownAgeComparing.Size = new Size(180, 31);
            numericUpDownAgeComparing.TabIndex = 6;
            // 
            // labelAgeComparing
            // 
            labelAgeComparing.AutoSize = true;
            labelAgeComparing.Location = new Point(13, 694);
            labelAgeComparing.Name = "labelAgeComparing";
            labelAgeComparing.Size = new Size(150, 25);
            labelAgeComparing.TabIndex = 7;
            labelAgeComparing.Text = "Введите возраст:";
            // 
            // buttonAgeComparing
            // 
            buttonAgeComparing.Location = new Point(372, 679);
            buttonAgeComparing.Margin = new Padding(3, 4, 3, 4);
            buttonAgeComparing.Name = "buttonAgeComparing";
            buttonAgeComparing.Size = new Size(133, 62);
            buttonAgeComparing.TabIndex = 8;
            buttonAgeComparing.Text = "Показать";
            buttonAgeComparing.UseVisualStyleBackColor = true;
            buttonAgeComparing.Click += buttonAgeComparing_Click;
            // 
            // listBoxAgeComparing
            // 
            listBoxAgeComparing.FormattingEnabled = true;
            listBoxAgeComparing.ItemHeight = 25;
            listBoxAgeComparing.Location = new Point(12, 468);
            listBoxAgeComparing.Name = "listBoxAgeComparing";
            listBoxAgeComparing.Size = new Size(1012, 204);
            listBoxAgeComparing.TabIndex = 9;
            // 
            // labelPopularCity
            // 
            labelPopularCity.AutoSize = true;
            labelPopularCity.Location = new Point(17, 789);
            labelPopularCity.Name = "labelPopularCity";
            labelPopularCity.Size = new Size(234, 25);
            labelPopularCity.TabIndex = 10;
            labelPopularCity.Text = "Самый популярный город:";
            // 
            // buttonPopularCity
            // 
            buttonPopularCity.Location = new Point(890, 770);
            buttonPopularCity.Margin = new Padding(3, 4, 3, 4);
            buttonPopularCity.Name = "buttonPopularCity";
            buttonPopularCity.Size = new Size(133, 62);
            buttonPopularCity.TabIndex = 11;
            buttonPopularCity.Text = "Узнать";
            buttonPopularCity.UseVisualStyleBackColor = true;
            buttonPopularCity.Click += buttonPopularCity_Click;
            // 
            // textBoxPopularCity
            // 
            textBoxPopularCity.Location = new Point(263, 789);
            textBoxPopularCity.Name = "textBoxPopularCity";
            textBoxPopularCity.ReadOnly = true;
            textBoxPopularCity.Size = new Size(620, 31);
            textBoxPopularCity.TabIndex = 12;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1037, 849);
            Controls.Add(textBoxPopularCity);
            Controls.Add(buttonPopularCity);
            Controls.Add(labelPopularCity);
            Controls.Add(listBoxAgeComparing);
            Controls.Add(buttonAgeComparing);
            Controls.Add(labelAgeComparing);
            Controls.Add(numericUpDownAgeComparing);
            Controls.Add(buttonLoad);
            Controls.Add(buttonSave);
            Controls.Add(buttonRemove);
            Controls.Add(buttonEdit);
            Controls.Add(buttonAdd);
            Controls.Add(listBoxItems);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainForm";
            Text = "Главная";
            ((System.ComponentModel.ISupportInitialize)numericUpDownAgeComparing).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBoxItems;
        private Button buttonAdd;
        private Button buttonEdit;
        private Button buttonRemove;
        private Button buttonSave;
        private Button buttonLoad;
        private NumericUpDown numericUpDownAgeComparing;
        private Label labelAgeComparing;
        private Button buttonAgeComparing;
        private ListBox listBoxAgeComparing;
        private Label labelPopularCity;
        private Button buttonPopularCity;
        private TextBox textBoxPopularCity;
    }
}