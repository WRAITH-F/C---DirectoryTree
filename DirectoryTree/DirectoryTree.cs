using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DirectoryTree.Properties;

namespace DirectoryTree
{
    public partial class DirectoryTree : Form
    {
        String path = Application.StartupPath + "\\TestDir";
        public DirectoryTree()
        {
            InitializeComponent();

            this.treeView.HideSelection = false;
            //自已绘制  
            this.treeView.DrawMode = TreeViewDrawMode.OwnerDrawText;
            this.treeView.DrawNode += new DrawTreeNodeEventHandler(treeView_DrawNode);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景. 
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
        }

        private void DirectoryTree_Load(object sender, EventArgs e)
        {
            TreeNode rootNode = new TreeNode();     //实例化一个根节点
            rootNode.Text = "我的小说";         //节点的名称
            rootNode.ForeColor = Color.DarkRed;     //节点字体颜色
            rootNode.ImageIndex = 0;    //imagelist中的图片索引
            rootNode.SelectedImageIndex = 1;    //选中时imagelist中的图片索引
            treeView.Nodes.Add(rootNode); //添加根目录

           //调用该方法实现将指定路径下的子文件与子目录按照层次结构加载到TreeView
            LoadFilesAndDirectoriesToTree(path, rootNode.Nodes);
        }
        //将目录与文件加载到TreeView上
        private void LoadFilesAndDirectoriesToTree(string path, TreeNodeCollection treeNodeCollection)
        {
            //1.先根据路径获取所有的子文件和子文件夹
            string[] files = Directory.GetFiles(path);
            string[] dirs = Directory.GetDirectories(path);
            //2.把所有的子文件与子目录加到TreeView上。
            foreach (string item in files)
            {
               if(Path.GetExtension(item) == ".txt"){   //只读取文件夹下的txt文件
                   //实例化TreeNode类 TreeNode(string text,int imageIndex,int selectImageIndex)
                   //把每一个子文件加到TreeView上
                   treeNodeCollection.Add(Path.GetFileName(item), Path.GetFileName(item), 4, 4);
               }; 
            }
            //文件夹
            foreach (string item in dirs)
            {
                TreeNode node = treeNodeCollection.Add(Path.GetFileName(item), Path.GetFileName(item),2,3);
                //由于目录，可能下面还存在子目录，所以这时要对每个目录再次进行获取子目录与子文件的操作
                //这里进行了递归
                LoadFilesAndDirectoriesToTree(item, node.Nodes);
            }
        }

        /// <summary>
        /// 绘制颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            //or  自定义颜色  
            if ((e.State & TreeNodeStates.Selected) != 0)
            {
                ///刷新背景色防止字体图标重绘叠加
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(227, 251, 244)), e.Node.Bounds);
                //重绘字体
                Font nodeFont = e.Node.NodeFont;
                if (nodeFont == null) nodeFont = ((TreeView)sender).Font;
                e.Graphics.DrawString(e.Node.Text, nodeFont,new SolidBrush(Color.FromArgb(0, 0, 0)), Rectangle.Inflate(e.Bounds, 0, -7));
            }
            else
            {
                ///刷新背景色防止字体图标重绘叠加
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(0, Color.Gray)), e.Node.Bounds);
                //重绘字体
                Font nodeFont = e.Node.NodeFont;
                if (nodeFont == null) nodeFont = ((TreeView)sender).Font;
                e.Graphics.DrawString(e.Node.Text, nodeFont, new SolidBrush(Color.FromArgb(0, 0, 0)), Rectangle.Inflate(e.Bounds, 0, -7));
            }
            //节点头图标绘制
            if (e.Node.IsExpanded)
            {
                e.Graphics.DrawImage(Resources.open, e.Node.Bounds.X - 46, e.Node.Bounds.Y + 7);
            }
            else if (e.Node.IsExpanded == false && e.Node.Nodes.Count > 0)
            {
                e.Graphics.DrawImage(Resources.close, e.Node.Bounds.X-46, e.Node.Bounds.Y + 7);
            }
            //失焦之后选中状态不消失
            if ((e.State & TreeNodeStates.Focused) != 0)
            {
                using (Pen focusPen = new Pen(Color.Black))
                {
                    focusPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                    Rectangle focusBounds = e.Node.Bounds;
                    focusBounds.Size = new Size(focusBounds.Width - 1,
                    focusBounds.Height - 1);
                    e.Graphics.DrawRectangle(focusPen, focusBounds);
                }
            }
        }
        /// <summary>
        /// 鼠标按下时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)//判断你点的是不是右键
            {
                Point ClickPoint = new Point(e.X, e.Y);
                TreeNode CurrentNode = treeView.GetNodeAt(ClickPoint);
                if (CurrentNode != null)//判断你点的是不是一个节点
                {
                    CurrentNode.ContextMenuStrip = TreeMenuStrip;
                    //name = treeView.SelectedNode.Text.ToString();//存储节点的文本
                    treeView.SelectedNode = CurrentNode;//选中这个节点
                }
            }
        }
        /// <summary>
        /// 右键菜单打开时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            if (this.treeView.SelectedNode == null)
            {
                this.treeView.SelectedNode = treeView.SelectedNode;
            }
            // 如果依然没有将操作的结点（就是 DocTree.SelectedNode 也为 null) 则返回。
            if (this.treeView.SelectedNode == null) return;
        }
        /// <summary>
        /// 目录树右键新建文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IMenuNew_Click(object sender, EventArgs e)
        {
            if (this.treeView.SelectedNode == null)
                return;
            
        }
    }
}
