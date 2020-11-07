using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace TransBitmap
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = GetImageFilterString(false);
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    using (Image org = Image.FromFile(dialog.FileName))
                    {
                        originalPicture.Image = (Image)org.Clone();
                    }
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(this, ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// 読み込み可能な画像ファイルのフィルタ文字列を取得する。
        /// </summary>
        /// <param name="isEncode">保存に使用可能なファイルのフィルタ文字列取得時は true、読み込み可能なファイルのフィルタ文字列取得時は false。</param>
        /// <returns>読み込み可能な画像ファイルのフィルタ文字列</returns>
        private string GetImageFilterString(bool isEncode)
        {
            ImageCodecInfo[] encoders;
            StringBuilder sb = new StringBuilder();
            string ext;

            // 使用可能なエンコード情報を取得する
            if (isEncode)
            {
                encoders = ImageCodecInfo.GetImageEncoders();
            }
            else
            {
                encoders = ImageCodecInfo.GetImageDecoders();
            }

            // すべてのイメージファイルの拡張子を連結した文字列を生成する
            sb.Length = 0;
            foreach (ImageCodecInfo info in encoders)
            {
                sb.AppendFormat("{0};", info.FilenameExtension);
            }
            sb.Length -= 1;
            ext = sb.ToString();

            // すべてのイメージファイルに対応したフィルタ行を追加する
            sb.Length = 0;
            sb.AppendFormat("すべてのイメージファイル ({0})|{1}", ext, ext);

            // 各々のイメージファイルに対応したフィルタ列を追加する
            foreach (ImageCodecInfo info in encoders)
            {
                ext = info.FilenameExtension;
                sb.AppendFormat("|{0} ファイル ({1})|{2}", info.FormatDescription, ext, ext);
            }

            // すべてのファイルに対応したフィルタ列を追加する
            sb.AppendFormat("|すべてのファイル (*.*)|*.*");

            // 生成したフィルタ文字列を返す
            return sb.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap org = originalPicture.Image as Bitmap;

            if (org == null)
            {
                MessageBox.Show(this, "画像が読み込まれていません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Cursor.Current = Cursors.WaitCursor;

                Bitmap trans = new Bitmap(org.Width, org.Height, org.PixelFormat);

                for (int x = 0; x < org.Width; x++)
                {
                    for (int y = 0; y < org.Height; y++)
                    {
                        Color src = org.GetPixel(x, y);
                        trans.SetPixel(x, y, Color.FromArgb(src.B, src.R, src.G));
                    }
                }

                transformPicture.Image = trans;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap org = originalPicture.Image as Bitmap;

            if (org == null)
            {
                MessageBox.Show(this, "画像が読み込まれていません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Cursor.Current = Cursors.WaitCursor;

                try
                {
                    Bitmap trans = (Bitmap)org.Clone();

                    BitmapData bmpData = trans.LockBits(new Rectangle(0, 0, trans.Width, trans.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

                    try
                    {
                        IntPtr ptr = bmpData.Scan0;
                        int bytes = bmpData.Height * bmpData.Stride;
                        byte[] rgbValues = new byte[bytes];

                        Marshal.Copy(ptr, rgbValues, 0, bytes);

                        for (int y = 0, index0 = 0; y < bmpData.Height; y++, index0 += bmpData.Stride)
                        {
                            for (int x = 0; x < bmpData.Width; x++)
                            {
                                int index = index0 + x * 3;

                                byte b = rgbValues[index];
                                byte g = rgbValues[index + 1];
                                byte r = rgbValues[index + 2];

                                rgbValues[index] = g;
                                rgbValues[index + 1] = r;
                                rgbValues[index + 2] = b;
                            }
                        }

                        Marshal.Copy(rgbValues, 0, ptr, bytes);
                    }
                    finally
                    {
                        trans.UnlockBits(bmpData);
                    }

                    transformPicture.Image = trans;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bitmap org = originalPicture.Image as Bitmap;

            if (org == null)
            {
                MessageBox.Show(this, "画像が読み込まれていません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Cursor.Current = Cursors.WaitCursor;

                try
                {
                    Bitmap trans = (Bitmap)org.Clone();

                    BitmapData bmpData = trans.LockBits(new Rectangle(0, 0, trans.Width, trans.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

                    try
                    {
                        unsafe
                        {
                            byte* ptr = (byte*)bmpData.Scan0;

                            for (int y = 0, index0 = 0; y < bmpData.Height; y++, index0 += bmpData.Stride)
                            {
                                for (int x = 0; x < bmpData.Width; x++)
                                {
                                    int index = index0 + x * 3;

                                    byte b = ptr[index];
                                    byte g = ptr[index + 1];
                                    byte r = ptr[index + 2];

                                    ptr[index] = (byte)~b;
                                    ptr[index + 1] = (byte)~g;
                                    ptr[index + 2] = (byte)~r;
                                }
                            }
                        }
                    }
                    finally
                    {
                        trans.UnlockBits(bmpData);
                    }

                    transformPicture.Image = trans;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();

            dialog.Filter = GetImageFilterString(true);
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    transformPicture.Image.Save(dialog.FileName, GetImageEncoders(dialog.FileName), null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// ファイル名の拡張子からエンコードコーデックの情報を取得する。
        /// </summary>
        /// <param name="fileName">保存するファイル名</param>
        /// <returns>エンコードコーデックの情報を示す ImageCodecInfo オブジェクト</returns>
        private ImageCodecInfo GetImageEncoders(string fileName)
        {
            string extension = Path.GetExtension(fileName);

            if (string.IsNullOrEmpty(extension))
            {
                return null;
            }
            else
            {
                extension = "*" + extension;
            }

            foreach (ImageCodecInfo info in ImageCodecInfo.GetImageEncoders())
            {
                if (info.FilenameExtension.Contains(extension))
                {
                    return info;
                }
            }

            return null;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            originalPicture.Image = transformPicture.Image;
        }
    }
}