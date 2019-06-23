namespace DirectoryTree
{
    partial class DirectoryTree
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DirectoryTree));
            this.treeView = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.TreeMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.IMenuNew = new System.Windows.Forms.ToolStripMenuItem();
            this.TreeMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView
            // 
            this.treeView.AllowDrop = true;
            this.treeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll;
            this.treeView.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeView.ForeColor = System.Drawing.Color.Yellow;
            this.treeView.HideSelection = false;
            this.treeView.HotTracking = true;
            this.treeView.ImageKey = "bookList Rx.png";
            this.treeView.ImageList = this.imageList;
            this.treeView.ItemHeight = 28;
            this.treeView.LabelEdit = true;
            this.treeView.LineColor = System.Drawing.Color.White;
            this.treeView.Location = new System.Drawing.Point(0, 0);
            this.treeView.Name = "treeView";
            this.treeView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.treeView.Scrollable = false;
            this.treeView.SelectedImageIndex = 0;
            this.treeView.ShowLines = false;
            this.treeView.ShowPlusMinus = false;
            this.treeView.ShowRootLines = false;
            this.treeView.Size = new System.Drawing.Size(402, 500);
            this.treeView.TabIndex = 0;
            this.treeView.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.treeView_DrawNode);
            this.treeView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeView_MouseDown);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "bookList Rx.png");
            this.imageList.Images.SetKeyName(1, "bookList.png");
            this.imageList.Images.SetKeyName(2, "ibook.png");
            this.imageList.Images.SetKeyName(3, "ibookeasy.png");
            this.imageList.Images.SetKeyName(4, "TXT.png");
            this.imageList.Images.SetKeyName(5, "open.png");
            this.imageList.Images.SetKeyName(6, "close.png");
            // 
            // TreeMenuStrip
            // 
            this.TreeMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.IMenuNew});
            this.TreeMenuStrip.Name = "TreeMenuStrip";
            this.TreeMenuStrip.Size = new System.Drawing.Size(153, 48);
            this.TreeMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.TreeMenuStrip_Opening);
            // 
            // IMenuNew
            // 
            this.IMenuNew.Name = "IMenuNew";
            this.IMenuNew.Size = new System.Drawing.Size(152, 22);
            this.IMenuNew.Text = "新建";
            this.IMenuNew.Click += new System.EventHandler(this.IMenuNew_Click);
            // 
            // DirectoryTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 500);
            this.Controls.Add(this.treeView);
            this.Name = "DirectoryTree";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DirectoryTree";
            this.Load += new System.EventHandler(this.DirectoryTree_Load);
            this.TreeMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList;
        public System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.ContextMenuStrip TreeMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem IMenuNew;
    }
}

