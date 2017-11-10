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
            this.Robots = new System.Windows.Forms.Label();
            this.Rob = new System.Windows.Forms.TextBox();
            this.X = new System.Windows.Forms.TextBox();
            this.Y = new System.Windows.Forms.TextBox();
            this.Location = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Grafon)).BeginInit();
            this.SuspendLayout();
            // 
            // Grafon
            // 
            this.Grafon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grafon.Location = new System.Drawing.Point(12, 12);
            this.Grafon.Name = "Grafon";
            this.Grafon.Size = new System.Drawing.Size(688, 320);
            this.Grafon.TabIndex = 0;
            this.Grafon.TabStop = false;
            // 
            // StartEm
            // 
            this.StartEm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
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
            this.MapShose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
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
            this.LoadMap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LoadMap.Location = new System.Drawing.Point(418, 338);
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
            this.MapInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MapInput.Location = new System.Drawing.Point(13, 12);
            this.MapInput.Multiline = true;
            this.MapInput.Name = "MapInput";
            this.MapInput.Size = new System.Drawing.Size(688, 320);
            this.MapInput.TabIndex = 4;
            this.MapInput.Text = "Введите карту";
            this.MapInput.Visible = false;
            // 
            // NoLOadMap
            // 
            this.NoLOadMap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.NoLOadMap.Location = new System.Drawing.Point(562, 338);
            this.NoLOadMap.Name = "NoLOadMap";
            this.NoLOadMap.Size = new System.Drawing.Size(138, 48);
            this.NoLOadMap.TabIndex = 5;
            this.NoLOadMap.Text = "Отмена";
            this.NoLOadMap.UseVisualStyleBackColor = true;
            this.NoLOadMap.Visible = false;
            this.NoLOadMap.Click += new System.EventHandler(this.NoLOadMap_Click);
            // 
            // Robots
            // 
            this.Robots.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Robots.AutoSize = true;
            this.Robots.Location = new System.Drawing.Point(27, 349);
            this.Robots.Name = "Robots";
            this.Robots.Size = new System.Drawing.Size(110, 13);
            this.Robots.TabIndex = 6;
            this.Robots.Text = "Количество роботов";
            // 
            // Rob
            // 
            this.Rob.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Rob.Location = new System.Drawing.Point(143, 346);
            this.Rob.Name = "Rob";
            this.Rob.Size = new System.Drawing.Size(252, 20);
            this.Rob.TabIndex = 7;
            // 
            // X
            // 
            this.X.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.X.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.X.Location = new System.Drawing.Point(162, 373);
            this.X.Name = "X";
            this.X.Size = new System.Drawing.Size(83, 20);
            this.X.TabIndex = 8;
            this.X.Text = "X";
            this.X.Visible = false;
            // 
            // Y
            // 
            this.Y.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Y.Location = new System.Drawing.Point(270, 373);
            this.Y.Name = "Y";
            this.Y.Size = new System.Drawing.Size(83, 20);
            this.Y.TabIndex = 9;
            this.Y.Text = "Y";
            this.Y.Visible = false;
            // 
            // Location
            // 
            this.Location.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Location.AutoSize = true;
            this.Location.Location = new System.Drawing.Point(27, 376);
            this.Location.Name = "Location";
            this.Location.Size = new System.Drawing.Size(117, 13);
            this.Location.TabIndex = 10;
            this.Location.Text = "Точка старта (тупик) :";
            this.Location.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 402);
            this.Controls.Add(this.Location);
            this.Controls.Add(this.Y);
            this.Controls.Add(this.X);
            this.Controls.Add(this.Rob);
            this.Controls.Add(this.Robots);
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
        private System.Windows.Forms.Label Robots;
        private System.Windows.Forms.TextBox Rob;
        private System.Windows.Forms.TextBox X;
        private System.Windows.Forms.TextBox Y;
        private System.Windows.Forms.Label Location;
    }
}

