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
    public partial class 照度差ステレオ法 : Form
    {
        private static 照度差ステレオ法 _instance;


        public static IplImage 表面ベクトル分布;
        public static IplImage 表面ベクトル分布_gray;
        public static IplImage 表面ベクトル分布_x;
        public static IplImage 表面ベクトル分布_y;
        public static IplImage 表面ベクトル分布_z;
        public static IplImage 表示中;
        double[,] light_v;//光源の向いてる方向のベクトル
        double[] camera_light_v = new double[4];//カメラとライトのなす角度(rad)

        public 照度差ステレオ法()
        {
            InitializeComponent();
            表面ベクトル分布 = Cv.CreateImage(new CvSize(メイン画面.入力画像[0].Width, メイン画面.入力画像[0].Height), BitDepth.U8, 3);
            表面ベクトル分布_x = Cv.CreateImage(new CvSize(表面ベクトル分布.Width, 表面ベクトル分布.Height), BitDepth.U8, 1);
            表面ベクトル分布_y = Cv.CreateImage(new CvSize(表面ベクトル分布.Width, 表面ベクトル分布.Height), BitDepth.U8, 1);
            表面ベクトル分布_z = Cv.CreateImage(new CvSize(表面ベクトル分布.Width, 表面ベクトル分布.Height), BitDepth.U8, 1);
            表面ベクトル分布_gray = Cv.CreateImage(new CvSize(表面ベクトル分布.Width, 表面ベクトル分布.Height), BitDepth.U8, 1);
            ベクトル格納();
            表面角度計算();
        }

        public static 照度差ステレオ法 Instance
        {
            get
            {
                //_instanceがnullまたは破棄されているときは、
                //新しくインスタンスを作成する
                if (_instance == null || _instance.IsDisposed)
                    _instance = new 照度差ステレオ法();
                return _instance;
            }
        }
        void ベクトル格納()
        {
            var deg2rad = Math.PI / 180.0;

            light_v = new double[,] 
            {   
                {   -Math.Cos(deg2rad*double.Parse(textBox_0.Text.Split(',')[0])*Math.Cos(deg2rad*double.Parse(textBox_0.Text.Split(',')[1]))),
                    -Math.Sin(deg2rad*double.Parse(textBox_0.Text.Split(',')[0]))*Math.Cos(deg2rad*double.Parse(textBox_0.Text.Split(',')[1])), 
                     Math.Sin(deg2rad*double.Parse(textBox_0.Text.Split(',')[1]))
                },

                {   -Math.Cos(deg2rad*double.Parse(textBox_1.Text.Split(',')[0])*Math.Cos(deg2rad*double.Parse(textBox_1.Text.Split(',')[1]))),
                    -Math.Sin(deg2rad*double.Parse(textBox_1.Text.Split(',')[0]))*Math.Cos(deg2rad*double.Parse(textBox_1.Text.Split(',')[1])), 
                     Math.Sin(deg2rad*double.Parse(textBox_1.Text.Split(',')[1]))
                },

                {   -Math.Cos(deg2rad*double.Parse(textBox_2.Text.Split(',')[0])*Math.Cos(deg2rad*double.Parse(textBox_2.Text.Split(',')[1]))),
                    -Math.Sin(deg2rad*double.Parse(textBox_2.Text.Split(',')[0]))*Math.Cos(deg2rad*double.Parse(textBox_2.Text.Split(',')[1])), 
                     Math.Sin(deg2rad*double.Parse(textBox_2.Text.Split(',')[1]))
                },

                {   -Math.Cos(deg2rad*double.Parse(textBox_3.Text.Split(',')[0])*Math.Cos(deg2rad*double.Parse(textBox_3.Text.Split(',')[1]))),
                    -Math.Sin(deg2rad*double.Parse(textBox_3.Text.Split(',')[0]))*Math.Cos(deg2rad*double.Parse(textBox_3.Text.Split(',')[1])), 
                     Math.Sin(deg2rad*double.Parse(textBox_3.Text.Split(',')[1]))
                },
            };
            //for (int i = 0; i < 4; i++) Console.WriteLine("{0},{1},{2}", light_v[i, 0], light_v[i, 1], light_v[i, 2]);
            //カメラの回転角度を，光源ベクトルのy軸周りの逆回転とみなして調整
            var camera_num = double.Parse(textBox_camera.Text);
            double cos = Math.Cos(-deg2rad * camera_num),
                    sin = Math.Sin(-deg2rad * camera_num);
            for (int r = 0; r < 4; r++)
            {
                double x = light_v[r, 0],
                        z = light_v[r, 2];
                light_v[r, 0] = x * cos-z*sin;
                light_v[r, 2] = x * sin + z * cos;
            }
            for (int r = 0; r < 4; r++)//一1以上の数字に調整
                for (int c = 0; c < 3; c++) light_v[r, c] *= 10;

        }
        void 表面角度計算()
        {
            
            表面ベクトル分布.Zero();
            Console.WriteLine("表面角度計算開始");
            for (int y = 0; y < 表面ベクトル分布.Height; y++)
            {
                for (int x = 0; x < 表面ベクトル分布.Width; x++)
                {
                        var 表面角度ベクトル=画素値行列取得(x, y, 鏡面反射番号取得(x, y));

                        CvScalar color = new CvScalar(表面角度ベクトル[0], 表面角度ベクトル[1], 表面角度ベクトル[2]);
                        表面ベクトル分布.Set2D(y, x, color);
                }
            }
            Console.WriteLine("表面角度計算終了");
            pictureBoxIpl1.ImageIpl = 表面ベクトル分布;
            Cv.Split(表面ベクトル分布, 表面ベクトル分布_x, 表面ベクトル分布_y, 表面ベクトル分布_z,null);
            表面ベクトル分布.CvtColor(表面ベクトル分布_gray, ColorConversion.BgrToGray);
        }
        int 鏡面反射番号取得(int x, int y)
        {
            double max_val = 0;
            int max_num = 0;
            for (int i = 0; i < 4; i++)
            {
                var val = Cv.Get2D(メイン画面.入力画像[i], y, x).Val0;
                if (val > max_val)
                {
                    max_val = val;
                    max_num = i;//一番輝度値の大きい画像の番号
                }
            }
            return max_num;
        }
        double[] 画素値行列取得(int x, int y,int 鏡面反射画像番号)
        {
            double[] I = new double[3];//輝度値ベクトル
            double[,] S = new double[3, 3];//光源ベクトル
            double[,] S_;//光源ベクトルの逆行列
            double detS;//Sの行列式
            double[] N = new double[3];//法線ベクトル
            int num = 0;
            for (int i = 0; i < 4; i++)
            {
                if (i != 鏡面反射画像番号)
                {
                    I[num] = Cv.Get2D(メイン画面.入力画像[i], y, x).Val0;
                    for (int c = 0; c < 3; c++) S[num, c] = light_v[i, c];
                    num++;
                }
            }
            //detA=a11a22a33+a21a32a13+a31a12a23-a11a32a23-a31a22a13-a21a12a33
            detS = S[0, 0] * S[1, 1] * S[2, 2] + S[1, 0] * S[2, 1] * S[0, 2] + S[2, 0] * S[0, 1] * S[1, 2]
                 - S[0, 0] * S[2, 1] * S[1, 2] - S[2, 0] * S[1, 1] * S[0, 2] - S[1, 0] * S[0, 1] * S[2, 2];
            //Console.WriteLine("detS={0}",detS);
            S_ = new double[3, 3] 
                {   { S[1,1]*S[2,2]-S[1,2]*S[2,1], S[0,2]*S[2,1]-S[0,1]*S[2,2], S[0,1]*S[1,2]-S[0,2]*S[1,1]},
                    { S[1,2]*S[2,0]-S[1,0]*S[2,2], S[0,0]*S[2,2]-S[0,2]*S[2,0], S[0,2]*S[1,0]-S[0,0]*S[1,2]},
                    { S[1,0]*S[2,1]-S[1,1]*S[2,0], S[0,1]*S[2,0]-S[0,0]*S[2,1], S[0,0]*S[1,1]-S[0,1]*S[1,0]}
                };
            for (int r = 0; r < 3; r++)
                for (int c = 0; c < 3; c++) S_[r, c] /= detS;

            //逆行列をかけて法線ベクトル計算
            for (int r = 0; r < 3; r++)
            {
                N[r] = 0;
                for (int c = 0; c < 3; c++) N[r] += S_[r, c] * I[c];
            }
            行列の正規化(ref N, 255);
            return N;
        }
        void 行列の正規化(ref double[] array, double val)
        {
            double norm = Math.Sqrt(array[0] * array[0] + array[1] * array[1] + array[2] * array[2]);
            for (int i = 0; i < 3; i++)
            {
                array[i] = val / 2.0 + array[i] * val / (2.0 * norm);
                if (array[i] < 0) array[i] = 0;
                if (array[i] > val) array[i] = val;
            }
        }

        private void Click_実行(object sender, EventArgs e)
        {
            ベクトル格納();
            表面角度計算();
        }

        private void Click_color(object sender, EventArgs e)
        {
            pictureBoxIpl1.ImageIpl = 表面ベクトル分布;
            表示中 = pictureBoxIpl1.ImageIpl;
        }

        private void Click_gray(object sender, EventArgs e)
        {
            pictureBoxIpl1.ImageIpl = 表面ベクトル分布_gray;
            表示中 = pictureBoxIpl1.ImageIpl;
        }

        private void Click_B(object sender, EventArgs e)
        {
            pictureBoxIpl1.ImageIpl = 表面ベクトル分布_x;
            表示中 = pictureBoxIpl1.ImageIpl;
        }

        private void Click_G(object sender, EventArgs e)
        {
            pictureBoxIpl1.ImageIpl = 表面ベクトル分布_y;
            表示中 = pictureBoxIpl1.ImageIpl;
        }

        private void Click_R(object sender, EventArgs e)
        {
            pictureBoxIpl1.ImageIpl = 表面ベクトル分布_z;
            表示中 = pictureBoxIpl1.ImageIpl;
        }
    }
}
