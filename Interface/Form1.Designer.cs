﻿namespace Interface
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
            this.availablePorts = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.command = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.portStatus = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // availablePorts
            // 
            this.availablePorts.FormattingEnabled = true;
            this.availablePorts.Location = new System.Drawing.Point(105, 1);
            this.availablePorts.Name = "availablePorts";
            this.availablePorts.Size = new System.Drawing.Size(53, 21);
            this.availablePorts.TabIndex = 0;
            this.availablePorts.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Доступные COM :\r\n";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // command
            // 
            this.command.FormattingEnabled = true;
            this.command.Location = new System.Drawing.Point(222, 1);
            this.command.Name = "command";
            this.command.Size = new System.Drawing.Size(438, 21);
            this.command.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(158, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Команда :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(666, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Статус порта :";
            // 
            // portStatus
            // 
            this.portStatus.Location = new System.Drawing.Point(742, 4);
            this.portStatus.Name = "portStatus";
            this.portStatus.Size = new System.Drawing.Size(54, 20);
            this.portStatus.TabIndex = 5;
            this.portStatus.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.portStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.command);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.availablePorts);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox availablePorts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox command;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox portStatus;
    }
}

