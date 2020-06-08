using System;
using System.Windows.Forms;

namespace Генератор_задач
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.generateButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label_filename = new System.Windows.Forms.Label();
            this.label_filepath = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.filepath = new System.Windows.Forms.ComboBox();
            this.filename = new System.Windows.Forms.TextBox();
            this.numberVars = new System.Windows.Forms.TextBox();
            this.filepathButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.item1 = new System.Windows.Forms.ToolStripMenuItem();
            this.item2 = new System.Windows.Forms.ToolStripMenuItem();
            this.item3 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // generateButton
            // 
            this.generateButton.BackColor = System.Drawing.Color.Aquamarine;
            this.generateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.generateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.generateButton.Location = new System.Drawing.Point(257, 374);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(179, 44);
            this.generateButton.TabIndex = 0;
            this.generateButton.Text = "Сгенерировать";
            this.generateButton.UseVisualStyleBackColor = false;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label1.Location = new System.Drawing.Point(20, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Количество вариантов";
            // 
            // label_filename
            // 
            this.label_filename.AutoSize = true;
            this.label_filename.BackColor = System.Drawing.Color.Transparent;
            this.label_filename.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_filename.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label_filename.Location = new System.Drawing.Point(20, 80);
            this.label_filename.Name = "label_filename";
            this.label_filename.Size = new System.Drawing.Size(121, 25);
            this.label_filename.TabIndex = 2;
            this.label_filename.Text = "Имя файла";
            // 
            // label_filepath
            // 
            this.label_filepath.AutoSize = true;
            this.label_filepath.BackColor = System.Drawing.Color.Transparent;
            this.label_filepath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_filepath.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label_filepath.Location = new System.Drawing.Point(20, 160);
            this.label_filepath.Name = "label_filepath";
            this.label_filepath.Size = new System.Drawing.Size(138, 25);
            this.label_filepath.TabIndex = 3;
            this.label_filepath.Text = "Путь к файлу";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.filepath);
            this.panel1.Controls.Add(this.filename);
            this.panel1.Controls.Add(this.numberVars);
            this.panel1.Controls.Add(this.filepathButton);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label_filepath);
            this.panel1.Controls.Add(this.label_filename);
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Location = new System.Drawing.Point(150, 100);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 250);
            this.panel1.TabIndex = 4;
            // 
            // filepath
            // 
            this.filepath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.filepath.FormattingEnabled = true;
            this.filepath.Location = new System.Drawing.Point(25, 190);
            this.filepath.MaxDropDownItems = 5;
            this.filepath.Name = "filepath";
            this.filepath.Size = new System.Drawing.Size(260, 28);
            this.filepath.TabIndex = 10;
            this.filepath.TextChanged += new System.EventHandler(this.filepath_TextChanged);
            // 
            // filename
            // 
            this.filename.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.filename.Location = new System.Drawing.Point(165, 80);
            this.filename.Name = "filename";
            this.filename.Size = new System.Drawing.Size(210, 27);
            this.filename.TabIndex = 8;
            this.filename.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.filename_KeyPress);
            // 
            // numberVars
            // 
            this.numberVars.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numberVars.Location = new System.Drawing.Point(265, 30);
            this.numberVars.Name = "numberVars";
            this.numberVars.Size = new System.Drawing.Size(110, 27);
            this.numberVars.TabIndex = 7;
            this.numberVars.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numberVars_KeyPress);
            // 
            // filepathButton
            // 
            this.filepathButton.BackColor = System.Drawing.Color.MediumTurquoise;
            this.filepathButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.filepathButton.Location = new System.Drawing.Point(295, 190);
            this.filepathButton.Name = "filepathButton";
            this.filepathButton.Size = new System.Drawing.Size(80, 28);
            this.filepathButton.TabIndex = 5;
            this.filepathButton.Text = "Обзор";
            this.filepathButton.UseVisualStyleBackColor = false;
            this.filepathButton.Click += new System.EventHandler(this.filepathButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Impact", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(234, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(218, 35);
            this.label2.TabIndex = 5;
            this.label2.Text = "Генератор задач";
            // 
            // menu
            // 
            this.menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.item1,
            this.item2,
            this.item3});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(702, 28);
            this.menu.TabIndex = 6;
            this.menu.Text = "menu";
            // 
            // item1
            // 
            this.item1.Name = "item1";
            this.item1.Size = new System.Drawing.Size(197, 24);
            this.item1.Text = "Очистить историю ввода";
            this.item1.Click += new System.EventHandler(this.item1_Click);
            // 
            // item2
            // 
            this.item2.Name = "item2";
            this.item2.Size = new System.Drawing.Size(81, 24);
            this.item2.Text = "Справка";
            this.item2.Click += new System.EventHandler(this.item2_Click);
            // 
            // item3
            // 
            this.item3.Name = "item3";
            this.item3.Size = new System.Drawing.Size(118, 24);
            this.item3.Text = "О программе";
            this.item3.Click += new System.EventHandler(this.item3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackgroundImage = global::Генератор_задач.Properties.Resources.wallpapers_1280x1024;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(702, 493);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Генератор задач";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.form_closing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_filename;
        private System.Windows.Forms.Label label_filepath;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox filename;
        private System.Windows.Forms.TextBox numberVars;
        private System.Windows.Forms.Button filepathButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Label label2;
        private ComboBox filepath;
        private MenuStrip menu;
        private ToolStripMenuItem item1;
        private ToolStripMenuItem item2;
        private ToolStripMenuItem item3;
    }
}

