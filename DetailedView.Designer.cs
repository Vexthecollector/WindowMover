namespace WindowMover
{
    partial class DetailedView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.loadLastLayout = new System.Windows.Forms.Button();
            this.saveCurrentLayout = new System.Windows.Forms.Button();
            this.dataGridViewWindows = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Button = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Left = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Top = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Right = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bottom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.splitSidewaysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitHorizontallyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minimizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.applyCurrentSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spreadAcrossAllScreensToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWindows)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // loadLastLayout
            // 
            this.loadLastLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.loadLastLayout.Location = new System.Drawing.Point(12, 372);
            this.loadLastLayout.Name = "loadLastLayout";
            this.loadLastLayout.Size = new System.Drawing.Size(173, 23);
            this.loadLastLayout.TabIndex = 11;
            this.loadLastLayout.Text = "Restore Layout from Current List";
            this.loadLastLayout.UseVisualStyleBackColor = true;
            this.loadLastLayout.Click += new System.EventHandler(this.loadLastLayout_Click);
            // 
            // saveCurrentLayout
            // 
            this.saveCurrentLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveCurrentLayout.Location = new System.Drawing.Point(12, 343);
            this.saveCurrentLayout.Name = "saveCurrentLayout";
            this.saveCurrentLayout.Size = new System.Drawing.Size(173, 23);
            this.saveCurrentLayout.TabIndex = 10;
            this.saveCurrentLayout.Text = "Update List";
            this.saveCurrentLayout.UseVisualStyleBackColor = true;
            this.saveCurrentLayout.Click += new System.EventHandler(this.saveCurrentLayout_Click);
            // 
            // dataGridViewWindows
            // 
            this.dataGridViewWindows.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewWindows.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWindows.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Button,
            this.Left,
            this.Top,
            this.Right,
            this.Bottom});
            this.dataGridViewWindows.Location = new System.Drawing.Point(12, 32);
            this.dataGridViewWindows.Name = "dataGridViewWindows";
            this.dataGridViewWindows.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewWindows.Size = new System.Drawing.Size(849, 305);
            this.dataGridViewWindows.TabIndex = 9;
            this.dataGridViewWindows.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewWindows_CellContentClick);
            this.dataGridViewWindows.Click += new System.EventHandler(this.dataGridViewWindows_Click);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "Window Name";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Handle";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Button
            // 
            this.Button.HeaderText = "Button";
            this.Button.Name = "Button";
            this.Button.ReadOnly = true;
            this.Button.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Left
            // 
            this.Left.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Left.HeaderText = "Left";
            this.Left.Name = "Left";
            this.Left.Width = 50;
            // 
            // Top
            // 
            this.Top.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Top.HeaderText = "Top";
            this.Top.Name = "Top";
            this.Top.Width = 51;
            // 
            // Right
            // 
            this.Right.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Right.HeaderText = "Right";
            this.Right.Name = "Right";
            this.Right.Width = 57;
            // 
            // Bottom
            // 
            this.Bottom.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Bottom.HeaderText = "Bottom";
            this.Bottom.Name = "Bottom";
            this.Bottom.Width = 65;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.splitSidewaysToolStripMenuItem,
            this.splitHorizontallyToolStripMenuItem,
            this.minimizeToolStripMenuItem,
            this.restoreToolStripMenuItem,
            this.applyCurrentSettingsToolStripMenuItem,
            this.spreadAcrossAllScreensToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(209, 136);
            // 
            // splitSidewaysToolStripMenuItem
            // 
            this.splitSidewaysToolStripMenuItem.Name = "splitSidewaysToolStripMenuItem";
            this.splitSidewaysToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.splitSidewaysToolStripMenuItem.Text = "Split Sideways";
            this.splitSidewaysToolStripMenuItem.Click += new System.EventHandler(this.splitSidewaysToolStripMenuItem_Click);
            // 
            // splitHorizontallyToolStripMenuItem
            // 
            this.splitHorizontallyToolStripMenuItem.Name = "splitHorizontallyToolStripMenuItem";
            this.splitHorizontallyToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.splitHorizontallyToolStripMenuItem.Text = "Split Horizontally";
            this.splitHorizontallyToolStripMenuItem.Click += new System.EventHandler(this.splitHorizontallyToolStripMenuItem_Click);
            // 
            // minimizeToolStripMenuItem
            // 
            this.minimizeToolStripMenuItem.Name = "minimizeToolStripMenuItem";
            this.minimizeToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.minimizeToolStripMenuItem.Text = "Minimize";
            this.minimizeToolStripMenuItem.Click += new System.EventHandler(this.minimizeToolStripMenuItem_Click);
            // 
            // restoreToolStripMenuItem
            // 
            this.restoreToolStripMenuItem.Name = "restoreToolStripMenuItem";
            this.restoreToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.restoreToolStripMenuItem.Text = "Restore";
            // 
            // applyCurrentSettingsToolStripMenuItem
            // 
            this.applyCurrentSettingsToolStripMenuItem.Name = "applyCurrentSettingsToolStripMenuItem";
            this.applyCurrentSettingsToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.applyCurrentSettingsToolStripMenuItem.Text = "Apply Current Settings";
            this.applyCurrentSettingsToolStripMenuItem.Click += new System.EventHandler(this.applyCurrentSettingsToolStripMenuItem_Click);
            // 
            // spreadAcrossAllScreensToolStripMenuItem
            // 
            this.spreadAcrossAllScreensToolStripMenuItem.Name = "spreadAcrossAllScreensToolStripMenuItem";
            this.spreadAcrossAllScreensToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.spreadAcrossAllScreensToolStripMenuItem.Text = "Spread Across All Screens";
            this.spreadAcrossAllScreensToolStripMenuItem.Click += new System.EventHandler(this.spreadAcrossAllScreensToolStripMenuItem_Click);
            // 
            // DetailedView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 426);
            this.Controls.Add(this.loadLastLayout);
            this.Controls.Add(this.saveCurrentLayout);
            this.Controls.Add(this.dataGridViewWindows);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DetailedView";
            this.Text = "DetailedView";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWindows)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button loadLastLayout;
        private System.Windows.Forms.Button saveCurrentLayout;
        private System.Windows.Forms.DataGridView dataGridViewWindows;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewButtonColumn Button;
        private System.Windows.Forms.DataGridViewTextBoxColumn Left;
        private System.Windows.Forms.DataGridViewTextBoxColumn Top;
        private System.Windows.Forms.DataGridViewTextBoxColumn Right;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bottom;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem splitSidewaysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem splitHorizontallyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minimizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem applyCurrentSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spreadAcrossAllScreensToolStripMenuItem;
    }
}