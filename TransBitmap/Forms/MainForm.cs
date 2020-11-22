using Microsoft.VisualBasic;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;
using TransBitmap.Models;
using TransBitmap.Services;

namespace TransBitmap.Forms
{
    public partial class MainForm : Form
    {
        private static readonly HttpClient _httpClient = new();
        private BitmapConverterSetting _setting = new();
        private ConvertColor _convertColor = (red, green, blue) => (red, green, blue);

        public MainForm()
        {
            InitializeComponent();
        }

        private void OpenFileEvent(object sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog
            {
                Filter = GetImageFilterString(false)
            };

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    originalPicture.Image = Image.FromFile(dialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SaveFileEvent(object sender, EventArgs e)
        {
            using var dialog = new SaveFileDialog
            {
                Filter = GetImageFilterString(true)
            };

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    var info = GetImageEncoder(dialog.FileName);

                    if (info == null)
                    {
                        transformPicture.Image.Save(dialog.FileName);
                    }
                    else
                    {
                        transformPicture.Image.Save(dialog.FileName, info, null);
                    }
                }
                catch (Exception ex)
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
        private static string GetImageFilterString(bool isEncode)
        {
            // 使用可能なエンコード情報を取得する
            ImageCodecInfo[] encoders = isEncode switch
            {
                true => ImageCodecInfo.GetImageEncoders(),
                false => ImageCodecInfo.GetImageDecoders()
            };

            // フィルタ文字列を編集する
            var sb = new StringBuilder();

            // すべてのイメージファイルに対応したフィルタ行を追加する
            sb.AppendFormat("すべてのイメージファイル ({0})|{0}",
                            string.Join(';', encoders.Select(info => info.FilenameExtension)));

            // 各々のイメージファイルに対応したフィルタ列を追加する
            foreach (ImageCodecInfo info in encoders)
            {
                sb.AppendFormat("|{0} ファイル ({1})|{1}", info.FormatDescription, info.FilenameExtension);
            }

            // すべてのファイルに対応したフィルタ列を追加する
            sb.AppendFormat("|すべてのファイル (*.*)|*.*");

            // 生成したフィルタ文字列を返す
            return sb.ToString();
        }

        /// <summary>
        /// ファイル名の拡張子からエンコードコーデックの情報を取得する。
        /// </summary>
        /// <param name="fileName">保存するファイル名</param>
        /// <returns>エンコードコーデックの情報を示す ImageCodecInfo オブジェクト</returns>
        private static ImageCodecInfo? GetImageEncoder(string fileName)
        {
            string extension = Path.GetExtension(fileName);

            if (string.IsNullOrEmpty(extension))
            {
                return null;
            }

            extension = "*" + extension;
            return ImageCodecInfo.GetImageEncoders()
                                 .Where(info => info.FilenameExtension?.Contains(extension) ?? false)
                                 .FirstOrDefault();
        }

        private async void OpenUrlEvent(object sender, EventArgs e)
        {
            try
            {
                string url = Interaction.InputBox("URLを指定してください。", "URLから画像を開く");

                if (!string.IsNullOrEmpty(url))
                {
                    var responseMessage = await _httpClient.GetAsync(url);
                    var stream = await responseMessage.Content.ReadAsStreamAsync();
                    originalPicture.Image = Image.FromStream(stream);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormCloseEvent(object sender, EventArgs e)
        {
            Close();
        }

        private void ConvertBitmapWithPixelEvent(object sender, EventArgs e)
        {
            ConvertBitmap(new BitmapPixelConverter());
        }

        private void ConvertBitmapWithLockBitsEvent(object sender, EventArgs e)
        {
            ConvertBitmap(new BitmapLockBitsConverter());
        }

        private void ConvertBitmapWithUnsafeEvent(object sender, EventArgs e)
        {
            ConvertBitmap(new BitmapUnsafeConverter());
        }

        private void ConvertBitmap(IBitmapConverter converter)
        {
            if (originalPicture.Image is not Bitmap org)
            {
                MessageBox.Show(this, "画像が読み込まれていません。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                Bitmap trans = converter.ConvertBitmapColor(org, _convertColor);
                stopwatch.Stop();

                toolStripStatusLabel1.Text = $"画像を変換しました。(処理時間: {stopwatch.Elapsed})";
                transformPicture.Image = trans;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MoveImageEvent(object sender, EventArgs e)
        {
            originalPicture.Image = transformPicture.Image;
        }

        private void SettingConverterEvent(object sender, EventArgs e)
        {
            using var dialog = new ConvertSettingDialog()
            {
                BitmapConverterSetting = _setting
            };

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                _setting = dialog.BitmapConverterSetting;
                _convertColor = _setting.ConvertStrategy;
            }
        }
    }
}
