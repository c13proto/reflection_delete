using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenCvSharp;

namespace 鏡面反射光除去処理
{
    public partial class メイン画面 : Form
    {
        public static IplImage[] 入力画像= new IplImage[4];
        public static IplImage[] Gx = new IplImage[4];
        public static IplImage[] Gy = new IplImage[4];
        public static IplImage SGx;
        public static IplImage SGy;
        public static IplImage Gxx;
        public static IplImage Gyy;

        public static IplImage 出力画像;
        public static Boolean is4Image = false;

        public static int gaussian;
        public static int bright;

        public メイン画面()
        {
            InitializeComponent();
            gaussian = int.Parse(textBox_Gaus.Text);
            bright = int.Parse(textBox_Bright.Text);
        }
        private void 自作プロセス実行()
        {
            Console.WriteLine("自作プロセス開始");
            if (is4Image)
            {
                int width = 入力画像[0].Width;
                int height = 入力画像[0].Height;
                出力画像 = Cv.CreateImage(new CvSize(width, height), BitDepth.U8, 1);//メディアンのみ
                manualCV mCV = new manualCV();//メディアンフィルタかけるためのクラス
                mCV.鏡面反射光除去(入力画像, ref 出力画像);
                if (!(gaussian == 0)) Cv.Smooth(出力画像, 出力画像, SmoothType.Gaussian, gaussian);//ガウシアンフィルタ
                mCV.コントラスト調整(ref 出力画像, (double)trackBar_cont.Value / 10.0);
                mCV.brightness(ref 出力画像, bright);
                pictureBoxIpl1.ImageIpl = 出力画像;
            }
            else Console.WriteLine("no 4 images");
            Console.WriteLine("自作プロセス終了");
 
        }
        private void OnClick自作(object sender, EventArgs e)
        {
            自作プロセス実行();
        }
        private void OnClick実行(object sender, EventArgs e)
        {
            Console.WriteLine("OnClick実行　開始");
            if (is4Image)
            {

                int width = 入力画像[0].Width;
                int height = 入力画像[0].Height;

                SGx = Cv.CreateImage(new CvSize(width, height), BitDepth.U8, 1);
                SGy = Cv.CreateImage(new CvSize(width, height), BitDepth.U8, 1);
                manualCV mCV = new manualCV();//コサイン変換とメディアンフィルタかけるためのクラス

                for (int num = 0; num < 4; num++)
                {
                    Gx[num] = 入力画像[num].Clone();
                    Gy[num] = 入力画像[num].Clone();
                }


                for (int num = 0; num < 4; num++)
                {//infilterX,Y
                    mCV.infilterX(ref Gx[num], 入力画像[num]);
                    mCV.infilterY(ref Gy[num], 入力画像[num]);
                }
                mCV.Median(Gx, ref SGx);
                mCV.Median(Gy, ref SGy);

                //Gxxを作る．とりあえず外周1ピクセルやらない方向で．
                Gxx = Cv.CreateImage(new CvSize(width, height), BitDepth.U8, 1);
                Gyy = Cv.CreateImage(new CvSize(width, height), BitDepth.U8, 1);

                mCV.infilterX(ref Gxx, SGx);
                mCV.infilterY(ref Gyy, SGy);

                //SP作成（仮の出力画像）
                IplImage SP = Cv.CreateImage(new CvSize(width, height), BitDepth.U8, 1);
                for (int x = 0; x < width; x++)
                    for (int y = 0; y < height; y++)
                    {
                        CvScalar cs;
                        cs = Cv.Get2D(Gxx, y, x)+Cv.Get2D(Gyy, y, x);
                        Cv.Set2D(SP, y, x, cs);
 
                    }
                IplImage DCT_dst = Cv.CreateImage(new CvSize(width, height), BitDepth.U8, 1);
                mCV.CvDct(ref DCT_dst, ref SP, 1024);//第3引数使われてない件

                出力画像=DCT_dst.Clone();
                
            }
            else Console.WriteLine("no 4 images");
            Console.WriteLine("OnClick実行　終了");
        }

        private void OnClick開く(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                if(入力画像[i]!=null)入力画像[i].Dispose();
                入力画像[i] = Cv.CreateImage(new CvSize(640, 480), BitDepth.U8, 1);
            }
            if (出力画像 != null)
            {
                出力画像.Dispose();
                出力画像=Cv.CreateImage(new CvSize(640, 480), BitDepth.U8, 1);
            }
            OpenFileDialog dialog = new OpenFileDialog()
            {
                Multiselect = true,  // 複数選択の可否
                Filter =  // フィルタ
                "画像ファイル|*.bmp;*.gif;*.jpg;*.png|全てのファイル|*.*",
            };
            //ダイアログを表示
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {

                //OKボタンがクリックされたとき
                //選択されたファイル名をすべて表示する
                foreach (var file in dialog.FileNames.Select((value, index) => new { value, index }))
                {
                    入力画像[file.index] = new IplImage(file.value, LoadMode.GrayScale);
                }
                if (dialog.FileNames.Length == 4) is4Image = true;
                else is4Image = false;
                // ファイル名をタイトルバーに設定
                this.Text = dialog.FileNames[0];

                pictureBoxIpl1.Size = pictureBoxIplのサイズ調整(入力画像[0]);
                pictureBoxIpl1.ImageIpl = 入力画像[0];
            }
        }

        public static System.Drawing.Size pictureBoxIplのサイズ調整(IplImage sample)
        {
            return new System.Drawing.Size(sample.Width, sample.Height);
        }

        private void TextChanged_x(object sender, EventArgs e)
        {
            カーソル移動操作();
        }

        private void TextChanged_y(object sender, EventArgs e)
        {
            カーソル移動操作();
        }
        private void カーソル移動操作()
        {
            if (pictureBoxIpl1.ImageIpl != null)
            {
                double isnumber_x, isnumber_y;
                if (double.TryParse(textBox_x.Text, out isnumber_x) && double.TryParse(textBox_y.Text, out isnumber_y))
                    if ((isnumber_x >= 0 && isnumber_x <= pictureBoxIpl1.ImageIpl.Width) && (isnumber_y >= 0 && isnumber_y <= pictureBoxIpl1.ImageIpl.Height))
                    {
                        //CvColor c = pictureBoxIpl1.ImageIpl[(int)isnumber_y, (int)isnumber_x];
                        //label_color.Text = "" + c.B;
                        label_color.Text = (Cv.Get2D(pictureBoxIpl1.ImageIpl, (int)isnumber_y, (int)isnumber_x)).ToString();
                        //クライアント座標を画面座標に変換する
                        System.Drawing.Point mp = this.PointToScreen(new System.Drawing.Point((int)isnumber_x + pictureBoxIpl1.Location.X, (int)isnumber_y + pictureBoxIpl1.Location.Y));
                        //マウスポインタの位置を設定する
                        System.Windows.Forms.Cursor.Position = mp;
                    }
            }
        }

        private void MouseMove_pictureBoxIpl1(object sender, MouseEventArgs e)
        {
            System.Drawing.Point sp = System.Windows.Forms.Cursor.Position;
            System.Drawing.Point cp = this.PointToClient(sp);
            label_座標.Text = "(" + (cp.X - pictureBoxIpl1.Location.X) + "," + (cp.Y - pictureBoxIpl1.Location.Y) + ")";
        }

        private void OnClick_pictureBoxIpl1(object sender, MouseEventArgs e)
        {
            if (pictureBoxIpl1.ImageIpl != null)
            {
                System.Drawing.Point sp = System.Windows.Forms.Cursor.Position;
                System.Drawing.Point cp = this.PointToClient(sp);

                label_color.Text = (Cv.Get2D(pictureBoxIpl1.ImageIpl, cp.Y - pictureBoxIpl1.Location.Y, cp.X - pictureBoxIpl1.Location.X)).ToString();
                textBox_x.Text = "" + (cp.X - pictureBoxIpl1.Location.X);
                textBox_y.Text = "" + (cp.Y - pictureBoxIpl1.Location.Y);
            }
        }

        private void OnScroll_trackBar_選択(object sender, EventArgs e)
        {
            int val = trackBar_選択.Value;
            if (val < 4)
            {
                if (入力画像[val] != null) pictureBoxIpl1.ImageIpl = 入力画像[val];
                if (checkBox_Gx.Checked) pictureBoxIpl1.ImageIpl = Gx[val];
                if (checkBox_Gy.Checked) pictureBoxIpl1.ImageIpl = Gy[val];
                if (checkBox_SG.Checked)
                {
                    if (val == 0) pictureBoxIpl1.ImageIpl = SGx;
                    else if (val == 1) pictureBoxIpl1.ImageIpl = SGy;
                }
                if (checkBox_G2.Checked) 
                {
                    if (val == 0) pictureBoxIpl1.ImageIpl = Gxx;
                    else if (val == 1) pictureBoxIpl1.ImageIpl = Gyy;
                }
            }
            else
            {
                if (出力画像 != null) pictureBoxIpl1.ImageIpl = 出力画像;
            }
            

        }

        private void OnClick保存(object sender, EventArgs e)
        {
            System.IO.Directory.CreateDirectory(@"result");//resultフォルダの作成
            SaveFileDialog sfd = new SaveFileDialog();//SaveFileDialogクラスのインスタンスを作成
            sfd.FileName = gaussian.ToString()+"_"+bright.ToString();//はじめのファイル名を指定する
            sfd.InitialDirectory = @"result\";//はじめに表示されるフォルダを指定する
            sfd.Filter ="画像ファイル|*.bmp;*.gif;*.jpg;*.png|全てのファイル|*.*";//[ファイルの種類]に表示される選択肢を指定する
            sfd.FilterIndex = 1;//[ファイルの種類]ではじめに「画像ファイル」が選択されているようにする
            sfd.Title = "保存先のファイルを選択してください";//タイトルを設定する
            sfd.RestoreDirectory = true;//ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
            sfd.OverwritePrompt = true;//既に存在するファイル名を指定したとき警告する．デフォルトでTrueなので指定する必要はない
            sfd.CheckPathExists = true;//存在しないパスが指定されたとき警告を表示する．デフォルトでTrueなので指定する必要はない

            //ダイアログを表示する
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //OKボタンがクリックされたとき
                //選択されたファイル名を表示する
                Console.WriteLine(sfd.FileName);
                pictureBoxIpl1.ImageIpl.SaveImage(sfd.FileName);
            }
        }

        private void TextChanged_Gaus(object sender, EventArgs e)
        {
            gaussian = int.Parse(textBox_Gaus.Text);
        }

        private void TextChanged_Bright(object sender, EventArgs e)
        {
            bright = int.Parse(textBox_Bright.Text);
        }

        private void ValueChanged_cont(object sender, EventArgs e)
        {
            textBox_cont.Text = (trackBar_cont.Value / 10.0).ToString();
            自作プロセス実行();
        }

        private void TectChanged_cont(object sender, EventArgs e)
        {
            double isnumber;
            if (double.TryParse(textBox_cont.Text, out isnumber))
                if (isnumber >= trackBar_cont.Minimum*10 && isnumber <= trackBar_cont.Maximum*10)
                    trackBar_cont.Value = (int)isnumber*10;
        }




    }
}
