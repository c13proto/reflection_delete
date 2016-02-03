namespace 鏡面反射光除去処理
{
    partial class 照度差ステレオ法
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
            this.pictureBoxIpl1 = new OpenCvSharp.UserInterface.PictureBoxIpl();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox_0 = new System.Windows.Forms.TextBox();
            this.textBox_1 = new System.Windows.Forms.TextBox();
            this.textBox_2 = new System.Windows.Forms.TextBox();
            this.textBox_3 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButton_R = new System.Windows.Forms.RadioButton();
            this.radioButton_B = new System.Windows.Forms.RadioButton();
            this.radioButton_G = new System.Windows.Forms.RadioButton();
            this.radioButton_gray = new System.Windows.Forms.RadioButton();
            this.radioButton_color = new System.Windows.Forms.RadioButton();
            this.textBox_camera = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
            this.checkBox_mirror = new System.Windows.Forms.CheckBox();
            this.trackBar_mirror = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIpl1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_mirror)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxIpl1
            // 
            this.pictureBoxIpl1.Location = new System.Drawing.Point(83, 2);
            this.pictureBoxIpl1.Name = "pictureBoxIpl1";
            this.pictureBoxIpl1.Size = new System.Drawing.Size(344, 323);
            this.pictureBoxIpl1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxIpl1.TabIndex = 0;
            this.pictureBoxIpl1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "実行";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Click_実行);
            // 
            // textBox_0
            // 
            this.textBox_0.Location = new System.Drawing.Point(12, 80);
            this.textBox_0.Name = "textBox_0";
            this.textBox_0.Size = new System.Drawing.Size(65, 19);
            this.textBox_0.TabIndex = 2;
            this.textBox_0.Text = "-45,60";
            // 
            // textBox_1
            // 
            this.textBox_1.Location = new System.Drawing.Point(12, 105);
            this.textBox_1.Name = "textBox_1";
            this.textBox_1.Size = new System.Drawing.Size(65, 19);
            this.textBox_1.TabIndex = 3;
            this.textBox_1.Text = "45,60";
            // 
            // textBox_2
            // 
            this.textBox_2.Location = new System.Drawing.Point(12, 130);
            this.textBox_2.Name = "textBox_2";
            this.textBox_2.Size = new System.Drawing.Size(65, 19);
            this.textBox_2.TabIndex = 4;
            this.textBox_2.Text = "-135,45";
            // 
            // textBox_3
            // 
            this.textBox_3.Location = new System.Drawing.Point(12, 155);
            this.textBox_3.Name = "textBox_3";
            this.textBox_3.Size = new System.Drawing.Size(65, 19);
            this.textBox_3.TabIndex = 5;
            this.textBox_3.Text = "135,45";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioButton_R);
            this.panel1.Controls.Add(this.radioButton_B);
            this.panel1.Controls.Add(this.radioButton_G);
            this.panel1.Controls.Add(this.radioButton_gray);
            this.panel1.Controls.Add(this.radioButton_color);
            this.panel1.Location = new System.Drawing.Point(12, 181);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(65, 115);
            this.panel1.TabIndex = 6;
            // 
            // radioButton_R
            // 
            this.radioButton_R.AutoSize = true;
            this.radioButton_R.Location = new System.Drawing.Point(3, 91);
            this.radioButton_R.Name = "radioButton_R";
            this.radioButton_R.Size = new System.Drawing.Size(44, 16);
            this.radioButton_R.TabIndex = 4;
            this.radioButton_R.TabStop = true;
            this.radioButton_R.Text = "R(z)";
            this.radioButton_R.UseVisualStyleBackColor = true;
            this.radioButton_R.Click += new System.EventHandler(this.Click_R);
            // 
            // radioButton_B
            // 
            this.radioButton_B.AutoSize = true;
            this.radioButton_B.Location = new System.Drawing.Point(3, 69);
            this.radioButton_B.Name = "radioButton_B";
            this.radioButton_B.Size = new System.Drawing.Size(45, 16);
            this.radioButton_B.TabIndex = 3;
            this.radioButton_B.TabStop = true;
            this.radioButton_B.Text = "G(y)";
            this.radioButton_B.UseVisualStyleBackColor = true;
            this.radioButton_B.Click += new System.EventHandler(this.Click_G);
            // 
            // radioButton_G
            // 
            this.radioButton_G.AutoSize = true;
            this.radioButton_G.Location = new System.Drawing.Point(3, 47);
            this.radioButton_G.Name = "radioButton_G";
            this.radioButton_G.Size = new System.Drawing.Size(45, 16);
            this.radioButton_G.TabIndex = 2;
            this.radioButton_G.TabStop = true;
            this.radioButton_G.Text = "B(x)";
            this.radioButton_G.UseVisualStyleBackColor = true;
            this.radioButton_G.Click += new System.EventHandler(this.Click_B);
            // 
            // radioButton_gray
            // 
            this.radioButton_gray.AutoSize = true;
            this.radioButton_gray.Location = new System.Drawing.Point(3, 25);
            this.radioButton_gray.Name = "radioButton_gray";
            this.radioButton_gray.Size = new System.Drawing.Size(45, 16);
            this.radioButton_gray.TabIndex = 1;
            this.radioButton_gray.TabStop = true;
            this.radioButton_gray.Text = "gray";
            this.radioButton_gray.UseVisualStyleBackColor = true;
            this.radioButton_gray.Click += new System.EventHandler(this.Click_gray);
            // 
            // radioButton_color
            // 
            this.radioButton_color.AutoSize = true;
            this.radioButton_color.Location = new System.Drawing.Point(3, 3);
            this.radioButton_color.Name = "radioButton_color";
            this.radioButton_color.Size = new System.Drawing.Size(48, 16);
            this.radioButton_color.TabIndex = 0;
            this.radioButton_color.TabStop = true;
            this.radioButton_color.Text = "color";
            this.radioButton_color.UseVisualStyleBackColor = true;
            this.radioButton_color.Click += new System.EventHandler(this.Click_color);
            // 
            // textBox_camera
            // 
            this.textBox_camera.Location = new System.Drawing.Point(15, 43);
            this.textBox_camera.Name = "textBox_camera";
            this.textBox_camera.Size = new System.Drawing.Size(65, 19);
            this.textBox_camera.TabIndex = 7;
            this.textBox_camera.Text = "3";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "カメラy軸周り";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "光源";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(0, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "2";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(0, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "3";
            // 
            // directorySearcher1
            // 
            this.directorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
            // 
            // checkBox_mirror
            // 
            this.checkBox_mirror.AutoSize = true;
            this.checkBox_mirror.Location = new System.Drawing.Point(2, 302);
            this.checkBox_mirror.Name = "checkBox_mirror";
            this.checkBox_mirror.Size = new System.Drawing.Size(79, 16);
            this.checkBox_mirror.TabIndex = 16;
            this.checkBox_mirror.Text = "mirror_num";
            this.checkBox_mirror.UseVisualStyleBackColor = true;
            // 
            // trackBar_mirror
            // 
            this.trackBar_mirror.AutoSize = false;
            this.trackBar_mirror.Location = new System.Drawing.Point(2, 321);
            this.trackBar_mirror.Margin = new System.Windows.Forms.Padding(0);
            this.trackBar_mirror.Maximum = 3;
            this.trackBar_mirror.Name = "trackBar_mirror";
            this.trackBar_mirror.Size = new System.Drawing.Size(75, 19);
            this.trackBar_mirror.TabIndex = 17;
            this.trackBar_mirror.TabStop = false;
            // 
            // 照度差ステレオ法
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(439, 337);
            this.Controls.Add(this.trackBar_mirror);
            this.Controls.Add(this.checkBox_mirror);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_camera);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBox_3);
            this.Controls.Add(this.textBox_2);
            this.Controls.Add(this.textBox_1);
            this.Controls.Add(this.textBox_0);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBoxIpl1);
            this.Name = "照度差ステレオ法";
            this.Text = "照度差ステレオ法";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIpl1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_mirror)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenCvSharp.UserInterface.PictureBoxIpl pictureBoxIpl1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox_0;
        private System.Windows.Forms.TextBox textBox_1;
        private System.Windows.Forms.TextBox textBox_2;
        private System.Windows.Forms.TextBox textBox_3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButton_R;
        private System.Windows.Forms.RadioButton radioButton_B;
        private System.Windows.Forms.RadioButton radioButton_G;
        private System.Windows.Forms.RadioButton radioButton_gray;
        private System.Windows.Forms.RadioButton radioButton_color;
        private System.Windows.Forms.TextBox textBox_camera;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.DirectoryServices.DirectorySearcher directorySearcher1;
        private System.Windows.Forms.CheckBox checkBox_mirror;
        private System.Windows.Forms.TrackBar trackBar_mirror;
    }
}