using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Automation;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            Process[] processes = Process.GetProcessesByName("chrome");
            foreach (Process process in processes)
            {
                if (process.MainWindowHandle == IntPtr.Zero) continue;
                AutomationElement element = AutomationElement.FromHandle(process.MainWindowHandle);
                AutomationElement urlBar = element.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit));
                if (urlBar != null)
                {

                    AutomationPattern[] patterns = urlBar.GetSupportedPatterns();
                    if (patterns.Length > 0)
                    {
                        ValuePattern value = (ValuePattern)urlBar.GetCurrentPattern(patterns[0]);
                        listBox1.Items.Add("Chrome URL : " + value.Current.Value);
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process[] processes = Process.GetProcessesByName("msedge");
            foreach (Process process in processes)
            {
                if (process.MainWindowHandle == IntPtr.Zero) continue;
                AutomationElement element = AutomationElement.FromHandle(process.MainWindowHandle);
                AutomationElement urlBar = element.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit));
                if (urlBar != null)
                {

                    AutomationPattern[] patterns = urlBar.GetSupportedPatterns();
                    if (patterns.Length > 0)
                      {
                         ValuePattern value = (ValuePattern)urlBar.GetCurrentPattern(patterns[0]);
                        listBox1.Items.Add("Edge URL : " + value.Current.Value);
                      }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process[] processes = Process.GetProcessesByName("opera");
            foreach (Process process in processes)
            {
                if (process.MainWindowHandle == IntPtr.Zero) continue;
                AutomationElement element = AutomationElement.FromHandle(process.MainWindowHandle);
                AutomationElement urlBar = element.FindFirst(TreeScope.Descendants,
                  new PropertyCondition(AutomationElement.NameProperty, "Address field"));
                if (urlBar != null)
                {

                    AutomationPattern pattern = urlBar.GetSupportedPatterns().FirstOrDefault(wr => wr.ProgrammaticName == "ValuePatternIdentifiers.Pattern");
                    if (pattern == null) continue;
                    ValuePattern value = (ValuePattern)urlBar.GetCurrentPattern(pattern);
                    listBox1.Items.Add("Opera : " + value.Current.Value);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Process[] processes = Process.GetProcessesByName("firefox");
            foreach (Process process in processes)
            {
                if (process.MainWindowHandle == IntPtr.Zero) continue;
                AutomationElement element = AutomationElement.FromHandle(process.MainWindowHandle);
                AutomationElement urlBar = element.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit));
                if (urlBar != null)
                {
                    AutomationPattern pattern = urlBar.GetSupportedPatterns().FirstOrDefault(wr => wr.ProgrammaticName == "ValuePatternIdentifiers.Pattern");
                    if (pattern == null) continue;
                    ValuePattern value = (ValuePattern)urlBar.GetCurrentPattern(pattern);
                    listBox1.Items.Add("Firefox URL : " + value.Current.Value);
                }
            }
        }
    }
}
