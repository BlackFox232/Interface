namespace Interface
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
            this.button1 = new System.Windows.Forms.Button();
            this.outputText = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textArg = new System.Windows.Forms.Label();
            this.b1 = new System.Windows.Forms.Label();
            this.b2 = new System.Windows.Forms.Label();
            this.us1 = new System.Windows.Forms.Label();
            this.us2 = new System.Windows.Forms.Label();
            this.us3 = new System.Windows.Forms.Label();
            this.us4 = new System.Windows.Forms.Label();
            this.b3 = new System.Windows.Forms.Label();
            this.b4 = new System.Windows.Forms.Label();
            this.b5 = new System.Windows.Forms.Label();
            this.b6 = new System.Windows.Forms.Label();
            this.b7 = new System.Windows.Forms.Label();
            this.b8 = new System.Windows.Forms.Label();
            this.byte1 = new System.Windows.Forms.TextBox();
            this.byte2 = new System.Windows.Forms.TextBox();
            this.ushort1 = new System.Windows.Forms.TextBox();
            this.ushort2 = new System.Windows.Forms.TextBox();
            this.ushort3 = new System.Windows.Forms.TextBox();
            this.ushort4 = new System.Windows.Forms.TextBox();
            this.byte3 = new System.Windows.Forms.TextBox();
            this.byte4 = new System.Windows.Forms.TextBox();
            this.byte5 = new System.Windows.Forms.TextBox();
            this.byte6 = new System.Windows.Forms.TextBox();
            this.byte7 = new System.Windows.Forms.TextBox();
            this.byte8 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // availablePorts
            // 
            this.availablePorts.FormattingEnabled = true;
            this.availablePorts.Location = new System.Drawing.Point(105, 9);
            this.availablePorts.Name = "availablePorts";
            this.availablePorts.Size = new System.Drawing.Size(53, 21);
            this.availablePorts.TabIndex = 0;
            this.availablePorts.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            this.availablePorts.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AvailablePorts_MouseClick);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Доступные COM :\r\n";
            // 
            // command
            // 
            this.command.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.command.BackColor = System.Drawing.SystemColors.Window;
            this.command.ForeColor = System.Drawing.Color.Black;
            this.command.FormattingEnabled = true;
            this.command.Items.AddRange(new object[] {
            "2.Считать состояние двоичных сигналов",
            "3.Считать состояние регистров управления",
            "4.Считать состояние регистров данных",
            "5.Подать управляющий сигнал",
            "6.Изменить состояние регистра управления",
            "7.Считать слово состояния",
            "8.Диагностика",
            "9.Считать выборку спектра из энергонезависимой памяти",
            "10.Записать выборку спектра в энергонезависимую память",
            "11.Считать выборку накапливаемого спектра",
            "16.Изменить состояние регистров управления",
            "17.Считать идентификационный код блока детектирования",
            "18.Считать выборку калибровочных данных",
            "19.Записать выборку калибровочных данных"});
            this.command.Location = new System.Drawing.Point(222, 56);
            this.command.Name = "command";
            this.command.Size = new System.Drawing.Size(566, 21);
            this.command.TabIndex = 2;
            this.command.SelectedValueChanged += new System.EventHandler(this.Command_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(165, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Команда :";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(642, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Статус порта :";
            // 
            // portStatus
            // 
            this.portStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.portStatus.ForeColor = System.Drawing.Color.Crimson;
            this.portStatus.Location = new System.Drawing.Point(727, 1);
            this.portStatus.Multiline = true;
            this.portStatus.Name = "portStatus";
            this.portStatus.Size = new System.Drawing.Size(61, 49);
            this.portStatus.TabIndex = 5;
            this.portStatus.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(5, 56);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(153, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Выполнить команду";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click_1);
            // 
            // outputText
            // 
            this.outputText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputText.Location = new System.Drawing.Point(222, 140);
            this.outputText.Name = "outputText";
            this.outputText.ReadOnly = true;
            this.outputText.Size = new System.Drawing.Size(566, 194);
            this.outputText.TabIndex = 8;
            this.outputText.Text = "";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(5, 115);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Закрыть порт";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(5, 85);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "Открыть порт";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // textArg
            // 
            this.textArg.AutoSize = true;
            this.textArg.Location = new System.Drawing.Point(102, 99);
            this.textArg.Name = "textArg";
            this.textArg.Size = new System.Drawing.Size(121, 13);
            this.textArg.TabIndex = 13;
            this.textArg.Text = "Аргументы команды : ";
            this.textArg.Visible = false;
            // 
            // b1
            // 
            this.b1.AutoSize = true;
            this.b1.Location = new System.Drawing.Point(219, 80);
            this.b1.Name = "b1";
            this.b1.Size = new System.Drawing.Size(36, 13);
            this.b1.TabIndex = 14;
            this.b1.Text = "byte 1";
            this.b1.Visible = false;
            // 
            // b2
            // 
            this.b2.AutoSize = true;
            this.b2.Location = new System.Drawing.Point(261, 80);
            this.b2.Name = "b2";
            this.b2.Size = new System.Drawing.Size(36, 13);
            this.b2.TabIndex = 15;
            this.b2.Text = "byte 2";
            this.b2.Visible = false;
            // 
            // us1
            // 
            this.us1.AutoSize = true;
            this.us1.Location = new System.Drawing.Point(303, 80);
            this.us1.Name = "us1";
            this.us1.Size = new System.Drawing.Size(45, 13);
            this.us1.TabIndex = 16;
            this.us1.Text = "ushort 1";
            this.us1.Visible = false;
            // 
            // us2
            // 
            this.us2.AutoSize = true;
            this.us2.Location = new System.Drawing.Point(354, 80);
            this.us2.Name = "us2";
            this.us2.Size = new System.Drawing.Size(45, 13);
            this.us2.TabIndex = 17;
            this.us2.Text = "ushort 2";
            this.us2.Visible = false;
            // 
            // us3
            // 
            this.us3.AutoSize = true;
            this.us3.Location = new System.Drawing.Point(405, 80);
            this.us3.Name = "us3";
            this.us3.Size = new System.Drawing.Size(45, 13);
            this.us3.TabIndex = 18;
            this.us3.Text = "ushort 3";
            this.us3.Visible = false;
            // 
            // us4
            // 
            this.us4.AutoSize = true;
            this.us4.Location = new System.Drawing.Point(456, 80);
            this.us4.Name = "us4";
            this.us4.Size = new System.Drawing.Size(45, 13);
            this.us4.TabIndex = 19;
            this.us4.Text = "ushort 4";
            this.us4.Visible = false;
            // 
            // b3
            // 
            this.b3.AutoSize = true;
            this.b3.Location = new System.Drawing.Point(507, 80);
            this.b3.Name = "b3";
            this.b3.Size = new System.Drawing.Size(36, 13);
            this.b3.TabIndex = 20;
            this.b3.Text = "byte 3";
            this.b3.Visible = false;
            // 
            // b4
            // 
            this.b4.AutoSize = true;
            this.b4.Location = new System.Drawing.Point(549, 80);
            this.b4.Name = "b4";
            this.b4.Size = new System.Drawing.Size(36, 13);
            this.b4.TabIndex = 21;
            this.b4.Text = "byte 4";
            this.b4.Visible = false;
            // 
            // b5
            // 
            this.b5.AutoSize = true;
            this.b5.Location = new System.Drawing.Point(591, 80);
            this.b5.Name = "b5";
            this.b5.Size = new System.Drawing.Size(36, 13);
            this.b5.TabIndex = 22;
            this.b5.Text = "byte 5";
            this.b5.Visible = false;
            // 
            // b6
            // 
            this.b6.AutoSize = true;
            this.b6.Location = new System.Drawing.Point(633, 80);
            this.b6.Name = "b6";
            this.b6.Size = new System.Drawing.Size(36, 13);
            this.b6.TabIndex = 23;
            this.b6.Text = "byte 6";
            this.b6.Visible = false;
            // 
            // b7
            // 
            this.b7.AutoSize = true;
            this.b7.Location = new System.Drawing.Point(675, 80);
            this.b7.Name = "b7";
            this.b7.Size = new System.Drawing.Size(36, 13);
            this.b7.TabIndex = 24;
            this.b7.Text = "byte 7";
            this.b7.Visible = false;
            // 
            // b8
            // 
            this.b8.AutoSize = true;
            this.b8.Location = new System.Drawing.Point(717, 80);
            this.b8.Name = "b8";
            this.b8.Size = new System.Drawing.Size(36, 13);
            this.b8.TabIndex = 25;
            this.b8.Text = "byte 8";
            this.b8.Visible = false;
            // 
            // byte1
            // 
            this.byte1.Location = new System.Drawing.Point(222, 96);
            this.byte1.Name = "byte1";
            this.byte1.Size = new System.Drawing.Size(33, 20);
            this.byte1.TabIndex = 26;
            this.byte1.Visible = false;
            // 
            // byte2
            // 
            this.byte2.Location = new System.Drawing.Point(264, 96);
            this.byte2.Name = "byte2";
            this.byte2.Size = new System.Drawing.Size(33, 20);
            this.byte2.TabIndex = 27;
            this.byte2.Visible = false;
            // 
            // ushort1
            // 
            this.ushort1.Location = new System.Drawing.Point(306, 96);
            this.ushort1.Name = "ushort1";
            this.ushort1.Size = new System.Drawing.Size(42, 20);
            this.ushort1.TabIndex = 28;
            this.ushort1.Visible = false;
            // 
            // ushort2
            // 
            this.ushort2.Location = new System.Drawing.Point(357, 96);
            this.ushort2.Name = "ushort2";
            this.ushort2.Size = new System.Drawing.Size(42, 20);
            this.ushort2.TabIndex = 29;
            this.ushort2.Visible = false;
            // 
            // ushort3
            // 
            this.ushort3.Location = new System.Drawing.Point(408, 96);
            this.ushort3.Name = "ushort3";
            this.ushort3.Size = new System.Drawing.Size(42, 20);
            this.ushort3.TabIndex = 30;
            this.ushort3.Visible = false;
            // 
            // ushort4
            // 
            this.ushort4.Location = new System.Drawing.Point(459, 96);
            this.ushort4.Name = "ushort4";
            this.ushort4.Size = new System.Drawing.Size(42, 20);
            this.ushort4.TabIndex = 31;
            this.ushort4.Visible = false;
            // 
            // byte3
            // 
            this.byte3.Location = new System.Drawing.Point(510, 96);
            this.byte3.Name = "byte3";
            this.byte3.Size = new System.Drawing.Size(33, 20);
            this.byte3.TabIndex = 32;
            this.byte3.Visible = false;
            // 
            // byte4
            // 
            this.byte4.Location = new System.Drawing.Point(552, 96);
            this.byte4.Name = "byte4";
            this.byte4.Size = new System.Drawing.Size(33, 20);
            this.byte4.TabIndex = 33;
            this.byte4.Visible = false;
            // 
            // byte5
            // 
            this.byte5.Location = new System.Drawing.Point(594, 96);
            this.byte5.Name = "byte5";
            this.byte5.Size = new System.Drawing.Size(33, 20);
            this.byte5.TabIndex = 34;
            this.byte5.Visible = false;
            // 
            // byte6
            // 
            this.byte6.Location = new System.Drawing.Point(636, 96);
            this.byte6.Name = "byte6";
            this.byte6.Size = new System.Drawing.Size(33, 20);
            this.byte6.TabIndex = 35;
            this.byte6.Visible = false;
            // 
            // byte7
            // 
            this.byte7.Location = new System.Drawing.Point(678, 96);
            this.byte7.Name = "byte7";
            this.byte7.Size = new System.Drawing.Size(33, 20);
            this.byte7.TabIndex = 36;
            this.byte7.Visible = false;
            // 
            // byte8
            // 
            this.byte8.Location = new System.Drawing.Point(717, 96);
            this.byte8.Name = "byte8";
            this.byte8.Size = new System.Drawing.Size(33, 20);
            this.byte8.TabIndex = 37;
            this.byte8.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.DarkRed;
            this.label4.Location = new System.Drawing.Point(338, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(205, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "АРГУМЕНТЫ ВВОДЯТСЯ В 10тичке !!!";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.byte8);
            this.Controls.Add(this.byte7);
            this.Controls.Add(this.byte6);
            this.Controls.Add(this.byte5);
            this.Controls.Add(this.byte4);
            this.Controls.Add(this.byte3);
            this.Controls.Add(this.ushort4);
            this.Controls.Add(this.ushort3);
            this.Controls.Add(this.ushort2);
            this.Controls.Add(this.ushort1);
            this.Controls.Add(this.byte2);
            this.Controls.Add(this.byte1);
            this.Controls.Add(this.b8);
            this.Controls.Add(this.b7);
            this.Controls.Add(this.b6);
            this.Controls.Add(this.b5);
            this.Controls.Add(this.b4);
            this.Controls.Add(this.b3);
            this.Controls.Add(this.us4);
            this.Controls.Add(this.us3);
            this.Controls.Add(this.us2);
            this.Controls.Add(this.us1);
            this.Controls.Add(this.b2);
            this.Controls.Add(this.b1);
            this.Controls.Add(this.textArg);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.outputText);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.portStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.command);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.availablePorts);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox outputText;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label textArg;
        private System.Windows.Forms.Label b1;
        private System.Windows.Forms.Label b2;
        private System.Windows.Forms.Label us1;
        private System.Windows.Forms.Label us2;
        private System.Windows.Forms.Label us3;
        private System.Windows.Forms.Label us4;
        private System.Windows.Forms.Label b3;
        private System.Windows.Forms.Label b4;
        private System.Windows.Forms.Label b5;
        private System.Windows.Forms.Label b6;
        private System.Windows.Forms.Label b7;
        private System.Windows.Forms.Label b8;
        private System.Windows.Forms.TextBox byte1;
        private System.Windows.Forms.TextBox byte2;
        private System.Windows.Forms.TextBox ushort1;
        private System.Windows.Forms.TextBox ushort2;
        private System.Windows.Forms.TextBox ushort3;
        private System.Windows.Forms.TextBox ushort4;
        private System.Windows.Forms.TextBox byte3;
        private System.Windows.Forms.TextBox byte4;
        private System.Windows.Forms.TextBox byte5;
        private System.Windows.Forms.TextBox byte6;
        private System.Windows.Forms.TextBox byte7;
        private System.Windows.Forms.TextBox byte8;
        private System.Windows.Forms.Label label4;
    }
}

