﻿namespace 鏡面反射光除去処理
{
    partial class メイン画面
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxIpl1 = new OpenCvSharp.UserInterface.PictureBoxIpl();
            this.button_開く = new System.Windows.Forms.Button();
            this.textBox_x = new System.Windows.Forms.TextBox();
            this.textBox_y = new System.Windows.Forms.TextBox();
            this.label_color = new System.Windows.Forms.Label();
            this.label_座標 = new System.Windows.Forms.Label();
            this.trackBar_選択 = new System.Windows.Forms.TrackBar();
            this.button_再現 = new System.Windows.Forms.Button();
            this.checkBox_Gx = new System.Windows.Forms.CheckBox();
            this.checkBox_Gy = new System.Windows.Forms.CheckBox();
            this.checkBox_SG = new System.Windows.Forms.CheckBox();
            this.checkBox_G2 = new System.Windows.Forms.CheckBox();
            this.button_自作 = new System.Windows.Forms.Button();
            this.button_保存 = new System.Windows.Forms.Button();
            this.textBox_Gaus = new System.Windows.Forms.TextBox();
            this.textBox_Bright = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.trackBar_cont = new System.Windows.Forms.TrackBar();
            this.textBox_Cont = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button_照度差 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIpl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_選択)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_cont)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxIpl1
            // 
            this.pictureBoxIpl1.Location = new System.Drawing.Point(96, 1);
            this.pictureBoxIpl1.Name = "pictureBoxIpl1";
            this.pictureBoxIpl1.Size = new System.Drawing.Size(411, 421);
            this.pictureBoxIpl1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxIpl1.TabIndex = 0;
            this.pictureBoxIpl1.TabStop = false;
            this.pictureBoxIpl1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnClick_pictureBoxIpl1);
            this.pictureBoxIpl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove_pictureBoxIpl1);
            // 
            // button_開く
            // 
            this.button_開く.Location = new System.Drawing.Point(3, 1);
            this.button_開く.Name = "button_開く";
            this.button_開く.Size = new System.Drawing.Size(81, 23);
            this.button_開く.TabIndex = 1;
            this.button_開く.Text = "開く";
            this.button_開く.UseVisualStyleBackColor = true;
            this.button_開く.Click += new System.EventHandler(this.OnClick開く);
            // 
            // textBox_x
            // 
            this.textBox_x.Location = new System.Drawing.Point(3, 30);
            this.textBox_x.Name = "textBox_x";
            this.textBox_x.Size = new System.Drawing.Size(30, 19);
            this.textBox_x.TabIndex = 2;
            this.textBox_x.Text = "x";
            this.textBox_x.TextChanged += new System.EventHandler(this.TextChanged_x);
            // 
            // textBox_y
            // 
            this.textBox_y.Location = new System.Drawing.Point(39, 30);
            this.textBox_y.Name = "textBox_y";
            this.textBox_y.Size = new System.Drawing.Size(30, 19);
            this.textBox_y.TabIndex = 3;
            this.textBox_y.Text = "y";
            this.textBox_y.TextChanged += new System.EventHandler(this.TextChanged_y);
            // 
            // label_color
            // 
            this.label_color.AutoSize = true;
            this.label_color.Location = new System.Drawing.Point(4, 52);
            this.label_color.Name = "label_color";
            this.label_color.Size = new System.Drawing.Size(10, 12);
            this.label_color.TabIndex = 4;
            this.label_color.Text = "?";
            // 
            // label_座標
            // 
            this.label_座標.AutoSize = true;
            this.label_座標.Location = new System.Drawing.Point(1, 64);
            this.label_座標.Name = "label_座標";
            this.label_座標.Size = new System.Drawing.Size(27, 12);
            this.label_座標.TabIndex = 5;
            this.label_座標.Text = "(x,y)";
            // 
            // trackBar_選択
            // 
            this.trackBar_選択.AutoSize = false;
            this.trackBar_選択.Location = new System.Drawing.Point(-3, 79);
            this.trackBar_選択.Maximum = 4;
            this.trackBar_選択.Name = "trackBar_選択";
            this.trackBar_選択.Size = new System.Drawing.Size(81, 23);
            this.trackBar_選択.TabIndex = 6;
            this.trackBar_選択.Scroll += new System.EventHandler(this.OnScroll_trackBar_選択);
            // 
            // button_再現
            // 
            this.button_再現.Location = new System.Drawing.Point(3, 152);
            this.button_再現.Name = "button_再現";
            this.button_再現.Size = new System.Drawing.Size(80, 23);
            this.button_再現.TabIndex = 7;
            this.button_再現.Text = "再現";
            this.button_再現.UseVisualStyleBackColor = true;
            this.button_再現.Click += new System.EventHandler(this.OnClick再現);
            // 
            // checkBox_Gx
            // 
            this.checkBox_Gx.AutoSize = true;
            this.checkBox_Gx.Location = new System.Drawing.Point(3, 108);
            this.checkBox_Gx.Name = "checkBox_Gx";
            this.checkBox_Gx.Size = new System.Drawing.Size(38, 16);
            this.checkBox_Gx.TabIndex = 8;
            this.checkBox_Gx.Text = "Gx";
            this.checkBox_Gx.UseVisualStyleBackColor = true;
            // 
            // checkBox_Gy
            // 
            this.checkBox_Gy.AutoSize = true;
            this.checkBox_Gy.Location = new System.Drawing.Point(46, 108);
            this.checkBox_Gy.Name = "checkBox_Gy";
            this.checkBox_Gy.Size = new System.Drawing.Size(38, 16);
            this.checkBox_Gy.TabIndex = 9;
            this.checkBox_Gy.Text = "Gy";
            this.checkBox_Gy.UseVisualStyleBackColor = true;
            // 
            // checkBox_SG
            // 
            this.checkBox_SG.AutoSize = true;
            this.checkBox_SG.Location = new System.Drawing.Point(3, 130);
            this.checkBox_SG.Name = "checkBox_SG";
            this.checkBox_SG.Size = new System.Drawing.Size(39, 16);
            this.checkBox_SG.TabIndex = 10;
            this.checkBox_SG.Text = "SG";
            this.checkBox_SG.UseVisualStyleBackColor = true;
            // 
            // checkBox_G2
            // 
            this.checkBox_G2.AutoSize = true;
            this.checkBox_G2.Location = new System.Drawing.Point(45, 130);
            this.checkBox_G2.Name = "checkBox_G2";
            this.checkBox_G2.Size = new System.Drawing.Size(38, 16);
            this.checkBox_G2.TabIndex = 11;
            this.checkBox_G2.Text = "G2";
            this.checkBox_G2.UseVisualStyleBackColor = true;
            // 
            // button_自作
            // 
            this.button_自作.Location = new System.Drawing.Point(3, 181);
            this.button_自作.Name = "button_自作";
            this.button_自作.Size = new System.Drawing.Size(80, 23);
            this.button_自作.TabIndex = 12;
            this.button_自作.Text = "自作";
            this.button_自作.UseVisualStyleBackColor = true;
            this.button_自作.Click += new System.EventHandler(this.OnClick自作);
            // 
            // button_保存
            // 
            this.button_保存.Location = new System.Drawing.Point(8, 332);
            this.button_保存.Name = "button_保存";
            this.button_保存.Size = new System.Drawing.Size(66, 23);
            this.button_保存.TabIndex = 13;
            this.button_保存.Text = "保存";
            this.button_保存.UseVisualStyleBackColor = true;
            this.button_保存.Click += new System.EventHandler(this.OnClick保存);
            // 
            // textBox_Gaus
            // 
            this.textBox_Gaus.Location = new System.Drawing.Point(5, 243);
            this.textBox_Gaus.Name = "textBox_Gaus";
            this.textBox_Gaus.Size = new System.Drawing.Size(30, 19);
            this.textBox_Gaus.TabIndex = 14;
            this.textBox_Gaus.Text = "0";
            // 
            // textBox_Bright
            // 
            this.textBox_Bright.Location = new System.Drawing.Point(5, 268);
            this.textBox_Bright.Name = "textBox_Bright";
            this.textBox_Bright.Size = new System.Drawing.Size(30, 19);
            this.textBox_Bright.TabIndex = 15;
            this.textBox_Bright.Text = "100";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 246);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 12);
            this.label1.TabIndex = 16;
            this.label1.Text = "Gaus";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 271);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 12);
            this.label2.TabIndex = 17;
            this.label2.Text = "Bright";
            // 
            // trackBar_cont
            // 
            this.trackBar_cont.AutoSize = false;
            this.trackBar_cont.Location = new System.Drawing.Point(-1, 307);
            this.trackBar_cont.Maximum = 80;
            this.trackBar_cont.Minimum = 10;
            this.trackBar_cont.Name = "trackBar_cont";
            this.trackBar_cont.Size = new System.Drawing.Size(53, 16);
            this.trackBar_cont.TabIndex = 18;
            this.trackBar_cont.Value = 40;
            this.trackBar_cont.ValueChanged += new System.EventHandler(this.ValueChanged_cont);
            // 
            // textBox_Cont
            // 
            this.textBox_Cont.Location = new System.Drawing.Point(58, 307);
            this.textBox_Cont.Name = "textBox_Cont";
            this.textBox_Cont.Size = new System.Drawing.Size(28, 19);
            this.textBox_Cont.TabIndex = 19;
            this.textBox_Cont.Text = "4.0";
            this.textBox_Cont.TextChanged += new System.EventHandler(this.TextChanged_cont);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 290);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 12);
            this.label3.TabIndex = 20;
            this.label3.Text = "コントラスト";
            // 
            // button_照度差
            // 
            this.button_照度差.Location = new System.Drawing.Point(3, 210);
            this.button_照度差.Name = "button_照度差";
            this.button_照度差.Size = new System.Drawing.Size(80, 23);
            this.button_照度差.TabIndex = 21;
            this.button_照度差.Text = "照度差";
            this.button_照度差.UseVisualStyleBackColor = true;
            this.button_照度差.Click += new System.EventHandler(this.Click_照度差ステレオ);
            // 
            // メイン画面
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(498, 366);
            this.Controls.Add(this.button_照度差);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_Cont);
            this.Controls.Add(this.trackBar_cont);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_Bright);
            this.Controls.Add(this.textBox_Gaus);
            this.Controls.Add(this.button_保存);
            this.Controls.Add(this.button_自作);
            this.Controls.Add(this.checkBox_G2);
            this.Controls.Add(this.checkBox_SG);
            this.Controls.Add(this.checkBox_Gy);
            this.Controls.Add(this.checkBox_Gx);
            this.Controls.Add(this.button_再現);
            this.Controls.Add(this.trackBar_選択);
            this.Controls.Add(this.label_座標);
            this.Controls.Add(this.label_color);
            this.Controls.Add(this.textBox_y);
            this.Controls.Add(this.textBox_x);
            this.Controls.Add(this.button_開く);
            this.Controls.Add(this.pictureBoxIpl1);
            this.Name = "メイン画面";
            this.Text = "メイン画面";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIpl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_選択)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_cont)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenCvSharp.UserInterface.PictureBoxIpl pictureBoxIpl1;
        private System.Windows.Forms.Button button_開く;
        private System.Windows.Forms.TextBox textBox_x;
        private System.Windows.Forms.TextBox textBox_y;
        private System.Windows.Forms.Label label_color;
        private System.Windows.Forms.Label label_座標;
        private System.Windows.Forms.TrackBar trackBar_選択;
        private System.Windows.Forms.Button button_再現;
        private System.Windows.Forms.CheckBox checkBox_Gx;
        private System.Windows.Forms.CheckBox checkBox_Gy;
        private System.Windows.Forms.CheckBox checkBox_SG;
        private System.Windows.Forms.CheckBox checkBox_G2;
        private System.Windows.Forms.Button button_自作;
        private System.Windows.Forms.Button button_保存;
        private System.Windows.Forms.TextBox textBox_Gaus;
        private System.Windows.Forms.TextBox textBox_Bright;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trackBar_cont;
        private System.Windows.Forms.TextBox textBox_Cont;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_照度差;
    }
}

