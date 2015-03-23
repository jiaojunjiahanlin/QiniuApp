using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Qiniu.Conf;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
         
        public Form1()
        {
            InitializeComponent();
        }

        

        private void 复制单个文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckOneInfo cof = new CheckOneInfo();

            cof.ShowDialog();

        }

        private void 复制单个文件ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CopyOneFile cof = new CopyOneFile();

            cof.ShowDialog();

        }

        private void 移动单个文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Moveone cof = new Moveone();
            cof.ShowDialog();

        }

        private void 删除单个文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Deletone cof = new Deletone();
            cof.ShowDialog();
        }

        private void 查看批量文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 复制批量文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 移动批量文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 删除批量文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 查看图片属性ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 查看图片EXIFToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 生成图片预览ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 图片高级处理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pfop1 cof = new Pfop1();
            cof.ShowDialog();
        }

        private void 图像水印借口ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Qiniu.Conf.Config.ACCESS_KEY = textBox1.Text.ToString().Trim();
            Qiniu.Conf.Config.SECRET_KEY = textBox2.Text.ToString().Trim();
        }

        private void 私有资源下载ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            download dn = new download();
            dn.ShowDialog();
        }

        private void 单个文件上传ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UP dn = new UP();
            dn.ShowDialog();
        }
        
    }
}
