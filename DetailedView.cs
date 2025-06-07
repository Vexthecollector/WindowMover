using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowMover
{
    public partial class DetailedView : Form
    {
        public DetailedView()
        {
            InitializeComponent();
            GetAllWindows();
        }

        private void loadLastLayout_Click(object sender, EventArgs e)
        {
            ResetWindows();
        }
        private void saveCurrentLayout_Click(object sender, EventArgs e)
        {
            GetAllWindows();
        }

        public void GetAllWindows()
        {
            WindowHandler.Instance.GetAllWindows();

            dataGridViewWindows.Rows.Clear();
            Process[] processlist = Process.GetProcesses();


            foreach (WindowHandler.WindowData data in WindowHandler.Instance.windows)
            {


                WindowHandler.RECT windowRectangle = WindowHandler.Instance.GetWindowRectangle(data.HandleRef);
                dataGridViewWindows.Rows.Add(data.Name, data.Handle.ToInt32(), "Reset", windowRectangle.Left, windowRectangle.Top, windowRectangle.Right, windowRectangle.Bottom);
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
                        WindowHandler.RECT windowRectangle = new WindowHandler.RECT();
                        windowRectangle.Left = int.Parse(dataGridViewWindows.SelectedRows[i].Cells["Left"]?.Value.ToString());
                        windowRectangle.Top = int.Parse(dataGridViewWindows.SelectedRows[i].Cells["Top"]?.Value.ToString());
                        windowRectangle.Right = int.Parse(dataGridViewWindows.SelectedRows[i].Cells["Right"]?.Value.ToString());
                        windowRectangle.Bottom = int.Parse(dataGridViewWindows.SelectedRows[i].Cells["Bottom"]?.Value.ToString());
                        if (handle != IntPtr.Zero)
                        {
                            WindowHandler.Instance.MoveSpecificWindow(handle, windowRectangle.Left, windowRectangle.Top, Math.Abs(windowRectangle.Right - windowRectangle.Left), Math.Abs(windowRectangle.Bottom - windowRectangle.Top));
                        }
                    }
                }
                catch { }
            }
        }

        private void minimizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int count = dataGridViewWindows.SelectedRows.Count;
            for (int i = 0; i < dataGridViewWindows.SelectedRows.Count; i++)
            {
                var handle = new IntPtr((int)dataGridViewWindows.SelectedRows[i].Cells[1].Value);
                if (handle != IntPtr.Zero)
                {
                    WindowHandler.Instance.MinimizeWindow(handle);
                    //ShowWindow(handle, SW_MINIMIZE);

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
                    WindowHandler.Instance.RestoreWindow(handle);
                    //BringtoFront(handle);

                }
            }
        }

        private void applyCurrentSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int count = dataGridViewWindows.SelectedRows.Count;
            for (int i = 0; i < dataGridViewWindows.SelectedRows.Count; i++)
            {
                var handle = new IntPtr((int)dataGridViewWindows.SelectedRows[i].Cells[1].Value);
                if (handle != IntPtr.Zero)
                {

                    WindowHandler.RECT windowRectangle = new WindowHandler.RECT();
                    windowRectangle.Left = int.Parse(dataGridViewWindows.SelectedRows[i].Cells["Left"]?.Value.ToString());
                    windowRectangle.Top = int.Parse(dataGridViewWindows.SelectedRows[i].Cells["Top"]?.Value.ToString());
                    windowRectangle.Right = int.Parse(dataGridViewWindows.SelectedRows[i].Cells["Right"]?.Value.ToString());
                    windowRectangle.Bottom = int.Parse(dataGridViewWindows.SelectedRows[i].Cells["Bottom"]?.Value.ToString());
                    WindowHandler.Instance.MoveSpecificWindow(handle, windowRectangle.Left, windowRectangle.Top, windowRectangle.Right, windowRectangle.Bottom);

                }
            }
        }

        private void spreadAcrossAllScreensToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int count = dataGridViewWindows.SelectedRows.Count;
            for (int i = 0; i < dataGridViewWindows.SelectedRows.Count; i++)
            {
                var handle = new IntPtr((int)dataGridViewWindows.SelectedRows[i].Cells[1].Value);
                if (handle != IntPtr.Zero)
                {

                    WindowHandler.RECT windowRectangle = new WindowHandler.RECT();
                    windowRectangle.Left = Screen.AllScreens.Min(selector => selector.Bounds.Left);
                    windowRectangle.Top = 0;
                    windowRectangle.Right = Screen.AllScreens.Sum(selector => selector.Bounds.Width);
                    windowRectangle.Bottom = Screen.FromHandle(this.Handle).WorkingArea.Height;
                    WindowHandler.Instance.MoveSpecificWindow(handle, windowRectangle.Left, windowRectangle.Top, windowRectangle.Right, windowRectangle.Bottom);

                }
            }
        }
        private void splitSidewaysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int count = dataGridViewWindows.SelectedRows.Count;
            Rectangle rect = Screen.FromHandle(this.Handle).WorkingArea;
            int windowWidth = rect.Width / count;
            for (int i = 0; i < dataGridViewWindows.SelectedRows.Count; i++)
            {
                var handle = new IntPtr((int)dataGridViewWindows.SelectedRows[i].Cells[1].Value);
                //RECT windowRectangle = (RECT)dataGridViewWindows.SelectedRows[i].Cells[3].Value;
                if (handle != IntPtr.Zero)
                {
                    WindowHandler.Instance.MoveSpecificWindow(handle, i * windowWidth + rect.Left, rect.Top, windowWidth, rect.Bottom);
                }
            }
        }

        private void splitHorizontallyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int count = dataGridViewWindows.SelectedRows.Count;
            Rectangle rect = Screen.FromHandle(this.Handle).WorkingArea;
            int windowHeight = rect.Height / count;
            for (int i = 0; i < dataGridViewWindows.SelectedRows.Count; i++)
            {
                var handle = new IntPtr((int)dataGridViewWindows.SelectedRows[i].Cells[1].Value);
                //RECT windowRectangle = (RECT)dataGridViewWindows.SelectedRows[i].Cells[3].Value;
                if (handle != IntPtr.Zero)
                {
                    WindowHandler.Instance.MoveSpecificWindow(handle, rect.Left, i * windowHeight + rect.Top, rect.Right, windowHeight);
                }
            }
        }

        private void dataGridViewWindows_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewWindows.Columns["Button"]?.Index)
            {
                var handle = new IntPtr((int)dataGridViewWindows.Rows[e.RowIndex].Cells[1].Value);

                WindowHandler.RECT windowRectangle = new WindowHandler.RECT();
                windowRectangle.Left = int.Parse(dataGridViewWindows.Rows[e.RowIndex].Cells["Left"]?.Value.ToString());
                windowRectangle.Top = int.Parse(dataGridViewWindows.Rows[e.RowIndex].Cells["Top"]?.Value.ToString());
                windowRectangle.Right = int.Parse(dataGridViewWindows.Rows[e.RowIndex].Cells["Right"]?.Value.ToString());
                windowRectangle.Bottom = int.Parse(dataGridViewWindows.Rows[e.RowIndex].Cells["Bottom"]?.Value.ToString());
                if (handle != IntPtr.Zero)
                {
                    WindowHandler.Instance.MoveSpecificWindow(handle, 0, 0, Math.Abs(windowRectangle.Right - windowRectangle.Left), Math.Abs(windowRectangle.Bottom - windowRectangle.Top));
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
    }
}
