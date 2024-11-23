using Polenter.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowMover
{
    public partial class Form1 : Form
    {
        [DllImport("kernel32.dll")]
        static extern int GetProcessId(IntPtr handle);
        public delegate bool EnumChildCallback(IntPtr hwnd, ref IntPtr lParam);

        [DllImport("User32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool EnumChildWindows(IntPtr hWndParent, EnumChildCallback lpEnumFunc, ref IntPtr lParam);


        [DllImport("User32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("User32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);


        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowRect(HandleRef hWnd, out RECT lpRect);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;        // x position of upper-left corner
            public int Top;         // y position of upper-left corner
            public int Right;       // x position of lower-right corner
            public int Bottom;      // y position of lower-right corner
        }

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int width, int height, int wFlags);

        [DllImport("user32.dll")]
        private static extern int ShowWindow(IntPtr hWnd, uint Msg);

        private const uint SW_RESTORE = 0x09;
        private const uint SW_MINIMIZE = 0x06;
        private const uint SW_NORMAL = 0x01;
        const short SWP_NOMOVE = 0X2;
        const short SWP_NOSIZE = 1;
        const short SWP_NOZORDER = 0X4;
        const int SWP_SHOWWINDOW = 0x0040;
        public Form1()
        {
            InitializeComponent();
            GetAllWindows();
        }

        public void MoveSpecificWindow(IntPtr handle, int X, int Y, int width, int height)
        {
            ShowWindow(handle, SW_RESTORE);
            SetWindowPos(handle, 0, X, Y, width, height, SWP_NOZORDER | SWP_SHOWWINDOW);

        }

        public void GetAllWindows()
        {
            dataGridViewWindows.Rows.Clear();
            Process[] processlist = Process.GetProcesses();

            foreach (Process process in processlist)
            {
                AllTheOtherStuff atos = new AllTheOtherStuff();
                IDictionary<IntPtr, string> windows = atos.GetOpenWindowsFromPID(process.Id);
                foreach (KeyValuePair<IntPtr, string> kvp in windows)
                {
                    RECT windowRectangle;
                    new HandleRef();
                    GetWindowRect(new HandleRef(process, process.MainWindowHandle), out windowRectangle);
                    dataGridViewWindows.Rows.Add(kvp.Value, kvp.Key.ToInt32(), "Reset", windowRectangle.Left, windowRectangle.Top, windowRectangle.Right, windowRectangle.Bottom);
                }

                /*
                if (!String.IsNullOrEmpty(process.MainWindowTitle))
                {




                    RECT windowRectangle;
                    new HandleRef();
                    GetWindowRect(new HandleRef(process, process.MainWindowHandle), out windowRectangle);
                    dataGridViewWindows.Rows.Add(process.MainWindowTitle, process.MainWindowHandle.ToInt32(), "Reset", windowRectangle.Left, windowRectangle.Top, windowRectangle.Right, windowRectangle.Bottom);



                    //Console.WriteLine("Process: {0} ID: {1} Window title: {2}", process.ProcessName, process.Id, process.MainWindowTitle);
                }*/
            }
        }

        public void ResetWindows()
        {
            for (int i = 0; i < dataGridViewWindows.Rows.Count; i++)
            {

                try
                {
                    if (dataGridViewWindows.Rows[i]?.Cells[1]?.Value != null)
                    {

                        var handle = new IntPtr((int)dataGridViewWindows.Rows[i]?.Cells[1]?.Value);
                        RECT windowRectangle = new RECT();
                        windowRectangle.Left = (int)dataGridViewWindows.Rows[i].Cells["Left"]?.Value;
                        windowRectangle.Top = (int)dataGridViewWindows.Rows[i].Cells["Top"]?.Value;
                        windowRectangle.Right = (int)dataGridViewWindows.Rows[i].Cells["Right"]?.Value;
                        windowRectangle.Bottom = (int)dataGridViewWindows.Rows[i].Cells["Bottom"]?.Value;
                        if (handle != IntPtr.Zero)
                        {
                            MoveSpecificWindow(handle, windowRectangle.Left, windowRectangle.Top, Math.Abs(windowRectangle.Right-windowRectangle.Left),Math.Abs( windowRectangle.Bottom-windowRectangle.Top));
                        }
                    }
                }
                catch { }
            }

        }


        private void dataGridViewWindows_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewWindows.Columns["Button"]?.Index)
            {
                var handle = new IntPtr((int)dataGridViewWindows.Rows[e.RowIndex].Cells[1].Value);

                RECT windowRectangle = new RECT();
                windowRectangle.Left = (int)dataGridViewWindows.Rows[e.RowIndex].Cells["Left"]?.Value;
                windowRectangle.Top = (int)dataGridViewWindows.Rows[e.RowIndex].Cells["Top"]?.Value;
                windowRectangle.Right = (int)dataGridViewWindows.Rows[e.RowIndex].Cells["Right"]?.Value;
                windowRectangle.Bottom = (int)dataGridViewWindows.Rows[e.RowIndex].Cells["Bottom"]?.Value;
                if (handle != IntPtr.Zero)
                {
                    MoveSpecificWindow(handle, 0, 0, Math.Abs (windowRectangle.Right - windowRectangle.Left), Math.Abs (windowRectangle.Bottom - windowRectangle.Top));
                }
            }

        }

        private void saveCurrentLayout_Click(object sender, EventArgs e)
        {
            GetAllWindows();
        }



        private void saveLayoutAsFile()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                object[,] dataGridViewObjectsArray = new object[dataGridViewWindows.Rows.Count, dataGridViewWindows.Columns.Count];
                for (int x = 0; x < dataGridViewWindows.Rows.Count; x++)
                    for (int y = 0; y < dataGridViewWindows.Columns.Count; y++)
                        dataGridViewObjectsArray[x, y] = dataGridViewWindows.Rows[x].Cells[y].Value;


                var serializer = new SharpSerializer();
                serializer.Serialize(dataGridViewObjectsArray, saveFileDialog.FileName);
            }
        }

        private void loadLayoutFromFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {


                var serializer = new SharpSerializer();
                object[,] dataGridViewObjectsArray = (object[,])serializer.Deserialize(openFileDialog.FileName);
                dataGridViewWindows.Rows.Clear();
                for (int x = 0; x < dataGridViewObjectsArray.GetLength(0); x++)
                {
                    dataGridViewWindows.Rows.Add();
                    for (int y = 0; y < dataGridViewObjectsArray.GetLength(1); y++)
                        dataGridViewWindows.Rows[x].Cells[y].Value = dataGridViewObjectsArray[x, y];
                }
            }
            ResetWindows();
        }

        private void splitSidewaysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int count = dataGridViewWindows.SelectedRows.Count;
            Rectangle rect = Screen.FromHandle(this.Handle).Bounds;
            int windowWidth = rect.Width / count;
            for (int i = 0; i < dataGridViewWindows.SelectedRows.Count; i++)
            {
                var handle = new IntPtr((int)dataGridViewWindows.SelectedRows[i].Cells[1].Value);
                //RECT windowRectangle = (RECT)dataGridViewWindows.SelectedRows[i].Cells[3].Value;
                if (handle != IntPtr.Zero)
                {
                    MoveSpecificWindow(handle, i * windowWidth+rect.Left, rect.Top, windowWidth, rect.Bottom);
                }
            }
        }

        private void splitHorizontallyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int count = dataGridViewWindows.SelectedRows.Count;
            Rectangle rect = Screen.FromHandle(this.Handle).Bounds;
            int windowHeight = rect.Height / count;
            for (int i = 0; i < dataGridViewWindows.SelectedRows.Count; i++)
            {
                var handle = new IntPtr((int)dataGridViewWindows.SelectedRows[i].Cells[1].Value);
                //RECT windowRectangle = (RECT)dataGridViewWindows.SelectedRows[i].Cells[3].Value;
                if (handle != IntPtr.Zero)
                {
                    MoveSpecificWindow(handle, rect.Left,i * windowHeight+rect.Top, rect.Right, windowHeight);
                }
            }
        }

        private void dataGridViewWindows_Click(object sender, EventArgs e)
        {
            if (e.GetType() == typeof(DataGridViewCellEventArgs))
            {
                dataGridViewWindows_CellContentClick(sender, (DataGridViewCellEventArgs)e);
            }
            else if (e.GetType() == typeof(MouseEventArgs))
            {
                if (((MouseEventArgs)e).Button == MouseButtons.Right)
                {
                    contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
                }


            }
        }

        private void loadLayoutFromFileButton_Click(object sender, EventArgs e)
        {
            loadLayoutFromFile();
        }

        private void saveLayoutAsFileButton_Click(object sender, EventArgs e)
        {
            saveLayoutAsFile();
        }

        private void loadLastLayout_Click(object sender, EventArgs e)
        {
            ResetWindows();
        }

        private void minimizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int count = dataGridViewWindows.SelectedRows.Count;
            for (int i = 0; i < dataGridViewWindows.SelectedRows.Count; i++)
            {
                var handle = new IntPtr((int)dataGridViewWindows.SelectedRows[i].Cells[1].Value);
                if (handle != IntPtr.Zero)
                {
                    ShowWindow(handle, SW_MINIMIZE);

                }
            }
        }

        private void restoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int count = dataGridViewWindows.SelectedRows.Count;
            for (int i = 0; i < dataGridViewWindows.SelectedRows.Count; i++)
            {
                var handle = new IntPtr((int)dataGridViewWindows.SelectedRows[i].Cells[1].Value);
                if (handle != IntPtr.Zero)
                {
                    BringtoFront(handle);

                }
            }
        }

        private void BringtoFront(IntPtr handle)
        {
            ShowWindow(handle, SW_RESTORE);
        }
    }
}
