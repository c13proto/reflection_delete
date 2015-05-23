using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCvSharp;

namespace 鏡面反射光除去処理
{
    class manualCV
    {

        public void Median(IplImage[] images,ref IplImage DST)
        {
            int width = images[0].Width;
            int height = images[0].Height;

            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                {//medianX,Y SG完成
                    double[] vals = { 0, 0, 0, 0 };

                    for (int num = 0; num < 4; num++) vals[num]= Cv.Get2D(images[num], y, x).Val0;
                    Array.Sort(vals);//並び替えを行う．min=vals[0]

                    CvScalar cs=Cv.Get2D(DST,y,x);
                    cs.Val0 = (vals[0] + vals[1] + vals[2]) / 3;
                    Cv.Set2D(DST, y, x, cs);
                }
            //for (int num = 0; num < 4; num++)images[num].Dispose();元のものに影響するっぽい

        }
        public void brightness(ref IplImage img,double 目標)
        {//中心近くの9ピクセルから輝度調整

            int width = img.Width;
            int height = img.Height;
            int center_x = width / 2;
            int center_y = height / 2;

            double[] vals= new double[9];
            double average=0;
            double diff = 0;

            vals[0] = Cv.Get2D(img, center_y - 10, 310); vals[3] = Cv.Get2D(img, center_y - 10, center_x); vals[6] = Cv.Get2D(img, center_y-10, 330);
            vals[1] = Cv.Get2D(img, center_y, 310);      vals[4] = Cv.Get2D(img, center_y, center_x);      vals[7] = Cv.Get2D(img, center_y, 330);
            vals[2] = Cv.Get2D(img, center_y + 10, 310); vals[5] = Cv.Get2D(img, center_y + 10, center_x); vals[8] = Cv.Get2D(img, center_y+10, 330);

            for (int num = 0; num < 9; num++) average += vals[num];
            average = average / 9.0;
            diff = 目標 - average;

            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                {
                    CvScalar cs = Cv.Get2D(img, y, x);
                    double val= cs.Val0 + diff;
                    if (val > 255) cs.Val0 = 255;
                    else cs.Val0 = val;
                    Cv.Set2D(img, y, x, cs);
                }
        }
        public void infilterX(ref IplImage DST,IplImage SRC)
        {
            int width = SRC.Width;
            int height = SRC.Height;
            for (int x = 0; x < width - 1; x++)
                for (int y = 0; y < height; y++)
                {
                    CvScalar cs;
                    cs = Cv.Get2D(SRC, y, x + 1) - Cv.Get2D(SRC, y, x);
                    Cv.Set2D(DST, y, x, cs);
                }
            //SRC.Dispose();
        }
        public void infilterY(ref IplImage DST,IplImage SRC)
        {
            int width = SRC.Width;
            int height = SRC.Height;
            for (int x = 0; x < width; x++)
                for (int y = 0; y < height - 1; y++)
                {
                    CvScalar cs;
                    cs = Cv.Get2D(SRC, y + 1, x) - Cv.Get2D(SRC, y, x);
                    Cv.Set2D(DST, y, x, cs);
                }
            //SRC.Dispose();
        }
        public void CvDct(ref IplImage DST, ref IplImage SRC, int N)
        {
            IplImage dct, idct;
            IplImage dct2, dct3;
            int width = 640;//N;
            int height = 480;//N;
            

            //DCT,IDCT用の行列作成(double)
            dct = Cv.CreateImage(new CvSize(width, height), BitDepth.F64, 1);
            idct = Cv.CreateImage(new CvSize(width, height), BitDepth.F64, 1);

            dct2 = Cv.CreateImage(new CvSize(width, height), BitDepth.F64, 1);
            dct3 = Cv.CreateImage(new CvSize(width, height), BitDepth.F64, 1);

            //行列dctに画像データをコピー
            //double fcos;
            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                {
                    CvScalar cs = Cv.Get2D(SRC, y, x) / 256.0;
                    Cv.Set2D(dct, y, x, cs);
                }

            //DCT…dctをコサイン変換してdct2を作成します
            Cv.DCT(dct, dct2, DCTFlag.Forward);

            //dct2をDenomで割りdct3を作成します
            PerformDenom(dct3, dct2, width, height);

            //IDCT…dct3を逆コサイン変換します
            Cv.DCT(dct3, idct, DCTFlag.Inverse);

            //逆変換用画像にデータをコピー
            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                {
                    CvScalar cs = Cv.Get2D(idct, y, x) * 256.0;
                    Cv.Set2D(DST, y, x, cs);
                }

            //正規化
            double min, max;
            min = 4000000000000;
            max = -4000000000000;
            double offset = 0.0;

            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                {
                    CvScalar cs = Cv.Get2D(DST, y, x);
                    double data = cs.Val0;
                    if (data < min) min = data;
                    if (data > max) max = data;
                }

            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                {
                    CvScalar cs = Cv.Get2D(DST, y, x);
                    double data = cs.Val0;

                    if (data < min + offset) data = min + offset;
                    cs.Val0 = (((data / (max - min + offset))) * 255.0) - (((min + offset) / (max - min + offset)) * 255.0);
                    Cv.Set2D(DST, y, x, cs);
                }
            //DST = idct.Clone();

            //行列メモリを開放します
            dct.Dispose();
            dct2.Dispose();
            dct3.Dispose();
            idct.Dispose();
        }

        private void PerformDenom(IplImage DST, IplImage SRC, int width, int height)
        {
            double PI = 3.1416;
            //XとYを準備
            double[,] meshX = new double[width, height];
            double[,] meshY = new double[width, height];
            double[,] denom = new double[width, height];

            //メッシュグリッドの作成
            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                {
                    meshX[x,y] = x;
                    meshY[x,y] = y;
                }

            //固有値計算
            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                    denom[x, y] = (2.0 * Math.Cos(PI * (double)x / ((double)width)) - 2.0) + (2.0 * Math.Cos(PI * (double)y / ((double)height)) - 2.0);
            //計算
            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                {
                    //data_d[j][i] = data_s[j][i] / denom[j][i];
                    CvScalar cs = Cv.Get2D(SRC, y, x);
                    //ゼロ割防止
                    if (!(x == 0 && y == 0)) cs= cs/denom[x, y];

                    Cv.Set2D(DST, y, x, cs);
                }
        }
    }
}
