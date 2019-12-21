namespace PredicatesKNF
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
            this.inputText = new System.Windows.Forms.TextBox();
            this.formulaText = new System.Windows.Forms.TextBox();
            this.knfText = new System.Windows.Forms.TextBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.тестыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.тест1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.тест1ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.тест1ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.тест1ToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.тест1ToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // inputText
            // 
            this.inputText.Location = new System.Drawing.Point(14, 56);
            this.inputText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.inputText.Multiline = true;
            this.inputText.Name = "inputText";
            this.inputText.Size = new System.Drawing.Size(613, 52);
            this.inputText.TabIndex = 0;
            this.inputText.TextChanged += new System.EventHandler(this.inputText_TextChanged);
            // 
            // formulaText
            // 
            this.formulaText.Location = new System.Drawing.Point(14, 178);
            this.formulaText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.formulaText.Multiline = true;
            this.formulaText.Name = "formulaText";
            this.formulaText.Size = new System.Drawing.Size(613, 69);
            this.formulaText.TabIndex = 1;
            // 
            // knfText
            // 
            this.knfText.Location = new System.Drawing.Point(14, 278);
            this.knfText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.knfText.Multiline = true;
            this.knfText.Name = "knfText";
            this.knfText.Size = new System.Drawing.Size(613, 62);
            this.knfText.TabIndex = 2;
            this.knfText.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(12, 115);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(615, 32);
            this.buttonStart.TabIndex = 3;
            this.buttonStart.Text = "Получить КНФ";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(177, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(298, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "Введите формулу ИППП в инфиксной форме";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(285, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "Формула";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(297, 253);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "КНФ";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.тестыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(639, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // тестыToolStripMenuItem
            // 
            this.тестыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.тест1ToolStripMenuItem,
            this.тест1ToolStripMenuItem1,
            this.тест1ToolStripMenuItem2,
            this.тест1ToolStripMenuItem3,
            this.тест1ToolStripMenuItem4});
            this.тестыToolStripMenuItem.Name = "тестыToolStripMenuItem";
            this.тестыToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.тестыToolStripMenuItem.Text = "Тесты";
            // 
            // тест1ToolStripMenuItem
            // 
            this.тест1ToolStripMenuItem.Name = "тест1ToolStripMenuItem";
            this.тест1ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.тест1ToolStripMenuItem.Text = "Тест №1";
            this.тест1ToolStripMenuItem.Click += new System.EventHandler(this.тест1ToolStripMenuItem_Click);
            // 
            // тест1ToolStripMenuItem1
            // 
            this.тест1ToolStripMenuItem1.Name = "тест1ToolStripMenuItem1";
            this.тест1ToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.тест1ToolStripMenuItem1.Text = "Тест №2";
            this.тест1ToolStripMenuItem1.Click += new System.EventHandler(this.тест1ToolStripMenuItem1_Click);
            // 
            // тест1ToolStripMenuItem2
            // 
            this.тест1ToolStripMenuItem2.Name = "тест1ToolStripMenuItem2";
            this.тест1ToolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.тест1ToolStripMenuItem2.Text = "Тест №3";
            this.тест1ToolStripMenuItem2.Click += new System.EventHandler(this.тест1ToolStripMenuItem2_Click);
            // 
            // тест1ToolStripMenuItem3
            // 
            this.тест1ToolStripMenuItem3.Name = "тест1ToolStripMenuItem3";
            this.тест1ToolStripMenuItem3.Size = new System.Drawing.Size(180, 22);
            this.тест1ToolStripMenuItem3.Text = "Тест №4";
            this.тест1ToolStripMenuItem3.Click += new System.EventHandler(this.тест1ToolStripMenuItem3_Click);
            // 
            // тест1ToolStripMenuItem4
            // 
            this.тест1ToolStripMenuItem4.Name = "тест1ToolStripMenuItem4";
            this.тест1ToolStripMenuItem4.Size = new System.Drawing.Size(180, 22);
            this.тест1ToolStripMenuItem4.Text = "Тест №5";
            this.тест1ToolStripMenuItem4.Click += new System.EventHandler(this.тест1ToolStripMenuItem4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 353);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.knfText);
            this.Controls.Add(this.formulaText);
            this.Controls.Add(this.inputText);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "КНФ для ИППП";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputText;
        private System.Windows.Forms.TextBox formulaText;
        private System.Windows.Forms.TextBox knfText;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem тестыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem тест1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem тест1ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem тест1ToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem тест1ToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem тест1ToolStripMenuItem4;
    }
}

