namespace labirint
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
            this.Grafon = new System.Windows.Forms.PictureBox();
            this.StartEm = new System.Windows.Forms.Button();
            this.MapShose = new System.Windows.Forms.Button();
            this.LoadMap = new System.Windows.Forms.Button();
            this.MapInput = new System.Windows.Forms.TextBox();
            this.NoLOadMap = new System.Windows.Forms.Button();
            this.infoLabel = new System.Windows.Forms.Label();
            this.InpRobMap = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Grafon)).BeginInit();
            this.SuspendLayout();
            // 
            // Grafon
            // 
            this.Grafon.Location = new System.Drawing.Point(12, 12);
            this.Grafon.Name = "Grafon";
            this.Grafon.Size = new System.Drawing.Size(689, 320);
            this.Grafon.TabIndex = 0;
            this.Grafon.TabStop = false;
            // 
            // StartEm
            // 
            this.StartEm.Location = new System.Drawing.Point(563, 338);
            this.StartEm.Name = "StartEm";
            this.StartEm.Size = new System.Drawing.Size(138, 48);
            this.StartEm.TabIndex = 1;
            this.StartEm.Text = "Начать эмуляцию";
            this.StartEm.UseVisualStyleBackColor = true;
            this.StartEm.Click += new System.EventHandler(this.StartEm_Click);
            // 
            // MapShose
            // 
            this.MapShose.Location = new System.Drawing.Point(419, 338);
            this.MapShose.Name = "MapShose";
            this.MapShose.Size = new System.Drawing.Size(138, 48);
            this.MapShose.TabIndex = 2;
            this.MapShose.Text = "Выбрать карту";
            this.MapShose.UseVisualStyleBackColor = true;
            this.MapShose.Click += new System.EventHandler(this.MapShose_Click);
            // 
            // LoadMap
            // 
            this.LoadMap.Location = new System.Drawing.Point(419, 338);
            this.LoadMap.Name = "LoadMap";
            this.LoadMap.Size = new System.Drawing.Size(138, 48);
            this.LoadMap.TabIndex = 3;
            this.LoadMap.Text = "Загрузить карту";
            this.LoadMap.UseVisualStyleBackColor = true;
            this.LoadMap.Visible = false;
            this.LoadMap.Click += new System.EventHandler(this.LoadMap_Click);
            // 
            // MapInput
            // 
            this.MapInput.Location = new System.Drawing.Point(12, 12);
            this.MapInput.Multiline = true;
            this.MapInput.Name = "MapInput";
            this.MapInput.Size = new System.Drawing.Size(689, 320);
            this.MapInput.TabIndex = 4;
            this.MapInput.Text = "Введите карту";
            this.MapInput.Visible = false;
            // 
            // NoLOadMap
            // 
            this.NoLOadMap.Location = new System.Drawing.Point(563, 338);
            this.NoLOadMap.Name = "NoLOadMap";
            this.NoLOadMap.Size = new System.Drawing.Size(138, 48);
            this.NoLOadMap.TabIndex = 5;
            this.NoLOadMap.Text = "Отмена";
            this.NoLOadMap.UseVisualStyleBackColor = true;
            this.NoLOadMap.Visible = false;
            this.NoLOadMap.Click += new System.EventHandler(this.NoLOadMap_Click);
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Location = new System.Drawing.Point(27, 349);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(110, 13);
            this.infoLabel.TabIndex = 6;
            this.infoLabel.Text = "Количество роботов";
            // 
            // InpRobMap
            // 
            this.InpRobMap.Location = new System.Drawing.Point(143, 346);
            this.InpRobMap.Name = "InpRobMap";
            this.InpRobMap.Size = new System.Drawing.Size(252, 20);
            this.InpRobMap.TabIndex = 7;
            this.InpRobMap.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 395);
            this.Controls.Add(this.InpRobMap);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.NoLOadMap);
            this.Controls.Add(this.MapInput);
            this.Controls.Add(this.LoadMap);
            this.Controls.Add(this.MapShose);
            this.Controls.Add(this.StartEm);
            this.Controls.Add(this.Grafon);
            this.Name = "Form1";
            this.Text = "Допили чтоб все красиво было там... И че нить патриотическое напиши";
            ((System.ComponentModel.ISupportInitialize)(this.Grafon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Grafon;
        private System.Windows.Forms.Button StartEm;
        private System.Windows.Forms.Button MapShose;
        private System.Windows.Forms.Button LoadMap;
        private System.Windows.Forms.TextBox MapInput;
        private System.Windows.Forms.Button NoLOadMap;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.TextBox InpRobMap;
    }
}

