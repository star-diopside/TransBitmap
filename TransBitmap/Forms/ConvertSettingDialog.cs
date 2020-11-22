using System;
using System.Windows.Forms;
using TransBitmap.Models;

namespace TransBitmap.Forms
{
    public partial class ConvertSettingDialog : Form
    {
        private BitmapConverterSetting _bitmapConverterSetting = new();

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

            this.BitmapConverterSetting = new()
            {
                FromRed = Enum.Parse<ColorSpace>(comboFromRed.Text),
                ReverseRed = checkReverseRed.Checked,
                FromGreen = Enum.Parse<ColorSpace>(comboFromGreen.Text),
                ReverseGreen = checkReverseGreen.Checked,
                FromBlue = Enum.Parse<ColorSpace>(comboFromBlue.Text),
                ReverseBlue = checkReverseBlue.Checked
            };
            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}
