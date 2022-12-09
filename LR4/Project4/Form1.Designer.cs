
namespace Project4
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
            this.upButton = new System.Windows.Forms.Button();
            this.downButton = new System.Windows.Forms.Button();
            this.rightButton = new System.Windows.Forms.Button();
            this.leftButton = new System.Windows.Forms.Button();
            this.forwardButton = new System.Windows.Forms.Button();
            this.nearerButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.zoomPlusButton = new System.Windows.Forms.Button();
            this.zoomMinuseButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.flipOXbutton = new System.Windows.Forms.Button();
            this.flipOYbutton = new System.Windows.Forms.Button();
            this.flipOZbutton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.turnOZbutton = new System.Windows.Forms.Button();
            this.turnOYbutton = new System.Windows.Forms.Button();
            this.turnOXbutton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.resetButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // upButton
            // 
            this.upButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.upButton.Location = new System.Drawing.Point(1377, 104);
            this.upButton.Name = "upButton";
            this.upButton.Size = new System.Drawing.Size(100, 100);
            this.upButton.TabIndex = 1;
            this.upButton.Text = "Up";
            this.upButton.UseVisualStyleBackColor = true;
            this.upButton.Click += new System.EventHandler(this.upButton_Click);
            // 
            // downButton
            // 
            this.downButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.downButton.Location = new System.Drawing.Point(1377, 210);
            this.downButton.Name = "downButton";
            this.downButton.Size = new System.Drawing.Size(100, 100);
            this.downButton.TabIndex = 2;
            this.downButton.Text = "Down";
            this.downButton.UseVisualStyleBackColor = true;
            this.downButton.Click += new System.EventHandler(this.downButton_Click);
            // 
            // rightButton
            // 
            this.rightButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rightButton.Location = new System.Drawing.Point(1483, 210);
            this.rightButton.Name = "rightButton";
            this.rightButton.Size = new System.Drawing.Size(100, 100);
            this.rightButton.TabIndex = 3;
            this.rightButton.Text = "Right";
            this.rightButton.UseVisualStyleBackColor = true;
            this.rightButton.Click += new System.EventHandler(this.rightButton_Click);
            // 
            // leftButton
            // 
            this.leftButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leftButton.Location = new System.Drawing.Point(1271, 210);
            this.leftButton.Name = "leftButton";
            this.leftButton.Size = new System.Drawing.Size(100, 100);
            this.leftButton.TabIndex = 4;
            this.leftButton.Text = "Left";
            this.leftButton.UseVisualStyleBackColor = true;
            this.leftButton.Click += new System.EventHandler(this.leftButton_Click);
            // 
            // forwardButton
            // 
            this.forwardButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.forwardButton.Location = new System.Drawing.Point(1483, 104);
            this.forwardButton.Name = "forwardButton";
            this.forwardButton.Size = new System.Drawing.Size(100, 100);
            this.forwardButton.TabIndex = 5;
            this.forwardButton.Text = "Forward";
            this.forwardButton.UseVisualStyleBackColor = true;
            this.forwardButton.Click += new System.EventHandler(this.forwardButton_Click);
            // 
            // nearerButton
            // 
            this.nearerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nearerButton.Location = new System.Drawing.Point(1271, 104);
            this.nearerButton.Name = "nearerButton";
            this.nearerButton.Size = new System.Drawing.Size(100, 100);
            this.nearerButton.TabIndex = 6;
            this.nearerButton.Text = "Nearer";
            this.nearerButton.UseVisualStyleBackColor = true;
            this.nearerButton.Click += new System.EventHandler(this.nearerButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(24, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1191, 902);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // zoomPlusButton
            // 
            this.zoomPlusButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zoomPlusButton.Location = new System.Drawing.Point(1271, 362);
            this.zoomPlusButton.Name = "zoomPlusButton";
            this.zoomPlusButton.Size = new System.Drawing.Size(147, 70);
            this.zoomPlusButton.TabIndex = 8;
            this.zoomPlusButton.Text = "+";
            this.zoomPlusButton.UseVisualStyleBackColor = true;
            this.zoomPlusButton.Click += new System.EventHandler(this.zoomPlusButton_Click);
            // 
            // zoomMinuseButton
            // 
            this.zoomMinuseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zoomMinuseButton.Location = new System.Drawing.Point(1436, 362);
            this.zoomMinuseButton.Name = "zoomMinuseButton";
            this.zoomMinuseButton.Size = new System.Drawing.Size(147, 70);
            this.zoomMinuseButton.TabIndex = 9;
            this.zoomMinuseButton.Text = "-";
            this.zoomMinuseButton.UseVisualStyleBackColor = true;
            this.zoomMinuseButton.Click += new System.EventHandler(this.zoomMinuseButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1394, 324);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 25);
            this.label1.TabIndex = 10;
            this.label1.Text = "Zoom";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1394, 441);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 25);
            this.label2.TabIndex = 11;
            this.label2.Text = "Flip on";
            // 
            // flipOXbutton
            // 
            this.flipOXbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flipOXbutton.Location = new System.Drawing.Point(1271, 469);
            this.flipOXbutton.Name = "flipOXbutton";
            this.flipOXbutton.Size = new System.Drawing.Size(100, 100);
            this.flipOXbutton.TabIndex = 12;
            this.flipOXbutton.Text = "OX";
            this.flipOXbutton.UseVisualStyleBackColor = true;
            this.flipOXbutton.Click += new System.EventHandler(this.flipOXbutton_Click);
            // 
            // flipOYbutton
            // 
            this.flipOYbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flipOYbutton.Location = new System.Drawing.Point(1377, 469);
            this.flipOYbutton.Name = "flipOYbutton";
            this.flipOYbutton.Size = new System.Drawing.Size(100, 100);
            this.flipOYbutton.TabIndex = 13;
            this.flipOYbutton.Text = "OY";
            this.flipOYbutton.UseVisualStyleBackColor = true;
            this.flipOYbutton.Click += new System.EventHandler(this.flipOYbutton_Click);
            // 
            // flipOZbutton
            // 
            this.flipOZbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flipOZbutton.Location = new System.Drawing.Point(1483, 469);
            this.flipOZbutton.Name = "flipOZbutton";
            this.flipOZbutton.Size = new System.Drawing.Size(100, 100);
            this.flipOZbutton.TabIndex = 14;
            this.flipOZbutton.Text = "OZ";
            this.flipOZbutton.UseVisualStyleBackColor = true;
            this.flipOZbutton.Click += new System.EventHandler(this.flipOZbutton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1394, 572);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 25);
            this.label3.TabIndex = 15;
            this.label3.Text = "Turn by";
            // 
            // turnOZbutton
            // 
            this.turnOZbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.turnOZbutton.Location = new System.Drawing.Point(1483, 612);
            this.turnOZbutton.Name = "turnOZbutton";
            this.turnOZbutton.Size = new System.Drawing.Size(100, 100);
            this.turnOZbutton.TabIndex = 18;
            this.turnOZbutton.Text = "OZ";
            this.turnOZbutton.UseVisualStyleBackColor = true;
            this.turnOZbutton.Click += new System.EventHandler(this.turnOZbutton_Click);
            // 
            // turnOYbutton
            // 
            this.turnOYbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.turnOYbutton.Location = new System.Drawing.Point(1377, 612);
            this.turnOYbutton.Name = "turnOYbutton";
            this.turnOYbutton.Size = new System.Drawing.Size(100, 100);
            this.turnOYbutton.TabIndex = 17;
            this.turnOYbutton.Text = "OY";
            this.turnOYbutton.UseVisualStyleBackColor = true;
            this.turnOYbutton.Click += new System.EventHandler(this.turnOYbutton_Click);
            // 
            // turnOXbutton
            // 
            this.turnOXbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.turnOXbutton.Location = new System.Drawing.Point(1271, 612);
            this.turnOXbutton.Name = "turnOXbutton";
            this.turnOXbutton.Size = new System.Drawing.Size(100, 100);
            this.turnOXbutton.TabIndex = 16;
            this.turnOXbutton.Text = "OX";
            this.turnOXbutton.UseVisualStyleBackColor = true;
            this.turnOXbutton.Click += new System.EventHandler(this.turnOXbutton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1405, 715);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 25);
            this.label4.TabIndex = 19;
            this.label4.Text = "On";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(1273, 748);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(312, 89);
            this.textBox1.TabIndex = 20;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // resetButton
            // 
            this.resetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetButton.Location = new System.Drawing.Point(1273, 843);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(312, 71);
            this.resetButton.TabIndex = 21;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(1273, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(328, 56);
            this.label5.TabIndex = 22;
            this.label5.Text = "Use \"Q\", \"W\", \"E\", \"A\", \"S\", \"D\" for moving";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1273, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(248, 25);
            this.label6.TabIndex = 23;
            this.label6.Text = "Use \"Z\" and \"X\" for zoom";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1660, 926);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.turnOZbutton);
            this.Controls.Add(this.turnOYbutton);
            this.Controls.Add(this.turnOXbutton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.flipOZbutton);
            this.Controls.Add(this.flipOYbutton);
            this.Controls.Add(this.flipOXbutton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.zoomMinuseButton);
            this.Controls.Add(this.zoomPlusButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.nearerButton);
            this.Controls.Add(this.forwardButton);
            this.Controls.Add(this.leftButton);
            this.Controls.Add(this.rightButton);
            this.Controls.Add(this.downButton);
            this.Controls.Add(this.upButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button upButton;
        private System.Windows.Forms.Button downButton;
        private System.Windows.Forms.Button rightButton;
        private System.Windows.Forms.Button leftButton;
        private System.Windows.Forms.Button forwardButton;
        private System.Windows.Forms.Button nearerButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button zoomPlusButton;
        private System.Windows.Forms.Button zoomMinuseButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button flipOXbutton;
        private System.Windows.Forms.Button flipOYbutton;
        private System.Windows.Forms.Button flipOZbutton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button turnOZbutton;
        private System.Windows.Forms.Button turnOYbutton;
        private System.Windows.Forms.Button turnOXbutton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}

