using System;
using System.Windows.Forms;
using TransBitmap.Models;

namespace TransBitmap.Forms
{
    public partial class ConvertSettingDialog : Form
    {
        private BitmapConverterSetting _bitmapConverterSetting;

        public BitmapConverterSetting BitmapConverterSetting
        {
            get => _bitmapConverterSetting;
            set
            {
                _bitmapConverterSetting = value;
                comboFromRed.Text = value.FromRed.ToString();
                checkReverseRed.Checked = value.ReverseRed;
                comboFromGreen.Text = value.FromGreen.ToString();
                checkReverseGreen.Checked = value.ReverseGreen;
                comboFromBlue.Text = value.FromBlue.ToString();
                checkReverseBlue.Checked = value.ReverseBlue;
            }
        }

        public ConvertSettingDialog()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboFromRed.Text) || string.IsNullOrEmpty(comboFromGreen.Text)
                || string.IsNullOrEmpty(comboFromBlue.Text))
            {
                MessageBox.Show(this, "変換色が選択されていません。", "エラー",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.BitmapConverterSetting = new(
                ToColorSpace(comboFromRed.Text),
                checkReverseRed.Checked,
                ToColorSpace(comboFromGreen.Text),
                checkReverseGreen.Checked,
                ToColorSpace(comboFromBlue.Text),
                checkReverseBlue.Checked);
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private static ColorSpace ToColorSpace(string s) => s switch
        {
            "Red" => ColorSpace.Red,
            "Green" => ColorSpace.Green,
            "Blue" => ColorSpace.Blue,
            _ => throw new ArgumentException("Invalid enum value: " + s, nameof(s))
        };
    }
}
