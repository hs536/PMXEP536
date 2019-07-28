using System;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace PMXEP536
{
    public partial class Form_ConsoleLog
    {
        private RichTextBox _textbox;
        private ComboBox _filter;

        //---CONSTRUCTOR---//
        public Form_ConsoleLog(RichTextBox textbox, ComboBox filter)
        {
            _textbox = textbox;
            _filter = filter;
            _filter.SelectedIndex = 0;//default log level
        }

        //---PUBLIC API----//
        public void debug(string message)
        {
            if (_filter.SelectedIndex <= 0)
            {
                log("[DEBUG]", message, Color.Gray);
            }
        }

        public void info(string message)
        {
            if (_filter.SelectedIndex <= 1)
            {
                log("[INFO ]", message, Color.Black);
            }
        }

        public void warning(string message)
        {
            if (_filter.SelectedIndex <= 2)
            {
                log("[WARN ]", message, Color.DarkOrange);
            }
        }

        public void error(string message)
        {
            if (_filter.SelectedIndex <= 3)
            {
                log("[ERROR]", message, Color.Red);
            }
        }

        public void clear()
        {
            _textbox.Clear();
        }

        //---INTERNAL API---//
        private void log(string key, string message, Color color)
        {
            string time = DateTime.Now.ToString("[HH:mm:ss.fff]");
            _textbox.Focus();
            _textbox.SelectionLength = 0;
            _textbox.SelectionColor = color;
            StringBuilder sb = new StringBuilder()
                .Append(time).Append(key).Append(" ").Append(message)
                .Append(Environment.NewLine);
            _textbox.AppendText(sb.ToString());
        }
    }
}
