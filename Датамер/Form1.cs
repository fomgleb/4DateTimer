using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Датамер
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadEnterDate();
        }

        public void SetNow()
        {
            TextBoxNowDay.Text = AddZero(DateTime.Now.Day);
            TextBoxNowMonth.Text = AddZero(DateTime.Now.Month);
            TextBoxNowYear.Text = AddZero(DateTime.Now.Year);

            TextBoxNowHour.Text = AddZero(DateTime.Now.Hour);
            TextBoxNowMinute.Text = AddZero(DateTime.Now.Minute);
            TextBoxNowSecond.Text = AddZero(DateTime.Now.Second);
        }

        public void SetLastDate()
        {
            try
            {
                DateTime startDate = new DateTime(Convert.ToInt32(TextBoxEnterYear.Text), Convert.ToInt32(TextBoxEnterMonth.Text),
                                                  Convert.ToInt32(TextBoxEnterDay.Text), Convert.ToInt32(TextBoxEnterHour.Text),
                                                  Convert.ToInt32(TextBoxEnterMinute.Text), Convert.ToInt32(TextBoxEnterSecond.Text));

                TimeSpan differenseDate = DateTime.Now - startDate;

                DateTime rel = new DateTime(differenseDate.Ticks);

                int Year = rel.Year;
                int Month = rel.Month;
                int Day = rel.Day;
                int Hour = rel.Hour;
                int Minute = rel.Minute;
                int Second = rel.Second;

                LabelLast.Text = "";
                if (--Year != 0)
                    LabelLast.Text += $"{Year} г.";
                if (--Month != 0)
                    LabelLast.Text += $" {Month} мес.";
                if (--Day != 0)
                    LabelLast.Text += $" {Day} дн.";
                if (Hour != 0)
                    LabelLast.Text += $" {Hour} ч.";
                if (Minute != 0)
                    LabelLast.Text += $" {Minute} мин.";
                if (Second != 0)
                    LabelLast.Text += $" {Second} сек.";
            }
            catch(Exception)
            {
            }
        }

        public void LoadEnterDate()
        {
            TextBoxEnterDay.Text = AddZero(Properties.Settings.Default.EnterDay);
            TextBoxEnterMonth.Text = AddZero(Properties.Settings.Default.EnterMonth);
            TextBoxEnterYear.Text = AddZero(Properties.Settings.Default.EnterYear);

            TextBoxEnterHour.Text = AddZero(Properties.Settings.Default.EnterHour);
            TextBoxEnterMinute.Text = AddZero(Properties.Settings.Default.EnterMinute);
            TextBoxEnterSecond.Text = AddZero(Properties.Settings.Default.EnterSecond);
        }

        public void SaveEnterDate()
        {
            Properties.Settings.Default.EnterDay = Convert.ToInt32(TextBoxEnterDay.Text);
            Properties.Settings.Default.EnterMonth = Convert.ToInt32(TextBoxEnterMonth.Text);
            Properties.Settings.Default.EnterYear = Convert.ToInt32(TextBoxEnterYear.Text);

            Properties.Settings.Default.EnterHour = Convert.ToInt32(TextBoxEnterHour.Text);
            Properties.Settings.Default.EnterMinute = Convert.ToInt32(TextBoxEnterMinute.Text);
            Properties.Settings.Default.EnterSecond = Convert.ToInt32(TextBoxEnterSecond.Text);

            Properties.Settings.Default.Save();
        }

        public string AddZero(Int32 dateTime)
        {
            string result = Convert.ToString(dateTime);
            if (dateTime < 10)
            {
                result = "0" + Convert.ToString(dateTime);
            }
            return result;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            SetNow();
            SetLastDate();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveEnterDate();
        }

        private void RefreshEnterYear_Click(object sender, EventArgs e)
        {
            TextBoxEnterDay.Text = AddZero(DateTime.Now.Day);
            TextBoxEnterMonth.Text = AddZero(DateTime.Now.Month);
            TextBoxEnterYear.Text = AddZero(DateTime.Now.Year);

            TextBoxEnterHour.Text = AddZero(DateTime.Now.Hour);
            TextBoxEnterMinute.Text = AddZero(DateTime.Now.Minute);
            TextBoxEnterSecond.Text = AddZero(DateTime.Now.Second);
        }
    }
}
