using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzleDevCom
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static Image IMG_FROM_LINK;
        public static List<int> randomList = new List<int>();
        public static Random RANDOM = new Random();
        public static int VerticalAmount = 2;
        public static int GorizontalAmount = 2;
        public static List<PictureBox> Puzzles = new List<PictureBox>();
        public static List<PictureBox> NewBoxList = new List<PictureBox>();
        public static Point MouseUpLocation;

        public static int generator()
        {
            int aa = RANDOM.Next(0, VerticalAmount*GorizontalAmount);
            while (randomList.Contains(aa) && randomList.Count < VerticalAmount * GorizontalAmount)
            {
                aa = RANDOM.Next(0, VerticalAmount*GorizontalAmount);
            }
            randomList.Add(aa);
            return aa;
        }
        private void Split()
        {
            BoxBuilderAndRefact();
            Bitmap originalImage = new Bitmap(IMG_FROM_LINK);
            Rectangle rect;
            Bitmap PartOfOriginal = originalImage;
            int counter = 0;
            for (int i = 0; i < VerticalAmount; ++i)
                for (int j = 0; j < GorizontalAmount; ++j)
                {
                    rect = new Rectangle(j * originalImage.Width / GorizontalAmount, i * originalImage.Height / VerticalAmount, originalImage.Width / GorizontalAmount, originalImage.Height / VerticalAmount);
                    PartOfOriginal = originalImage.Clone(rect, originalImage.PixelFormat);
                    Puzzles[counter++].Image = PartOfOriginal;
                }
        }
        private void BoxBuilderAndRefact()
        {
            PictureBox tmp;
            for (int i = 0; i < VerticalAmount; ++i)
            {
                for (int j = 0; j < GorizontalAmount; ++j)
                {
                    {
                        tmp = new PictureBox();
                        tmp.Name = $"picturebox{i}";
                        tmp.SizeMode = PictureBoxSizeMode.StretchImage;
                        tmp.Location = new Point(500 + j * (LinkPictureBox.Width / GorizontalAmount + 3), i * (LinkPictureBox.Height / VerticalAmount + 3));
                        tmp.Parent = this;
                        //tmp.MouseDown += new MouseEventHandler(this.Mouse_Down);
                        tmp.MouseMove += new MouseEventHandler(this.Mouse_Move);
                        tmp.MouseUp += new MouseEventHandler(this.Mouse_Up);
                        Puzzles.Add(tmp);
                    }
                }

                foreach (var item in Puzzles)
                {
                    item.Width = LinkPictureBox.Width / GorizontalAmount;
                    item.Height = LinkPictureBox.Height / VerticalAmount;
                }
            }
        }
        private void NewPictureBoxGeneration()
        {
            PictureBox newone;
            for(int i = 0; i < GorizontalAmount; ++i)
            {
                for(int j = 0; j < VerticalAmount; ++j)
                {
                    newone = new PictureBox();
                    newone.Size = Puzzles[0].Size;
                    newone.SizeMode = PictureBoxSizeMode.StretchImage;
                    newone.Location = new Point(500 + j * (Puzzles[0].Width + 3 ), i * (Puzzles[0].Height + 3));
                    newone.BackColor = Color.White;
                    newone.Parent = this;
                    NewBoxList.Add(newone);
                }
            }
        }
        private void NecessaryBoxFinder( PictureBox Traveller)
        {
            foreach ( var item in NewBoxList)
            {
                if ( (item.Location.X < MouseUpLocation.X && (item.Location.X + item.Width)>MouseUpLocation.X)   && (item.Location.Y < MouseUpLocation.Y && (item.Location.Y + item.Height) > MouseUpLocation.Y)) {
                    item.Name = Traveller.Name;
                    item.BackColor = Color.Red;
                    Traveller.Parent = this;
                    item.Image = Traveller.Image;
                    MessageBox.Show(item.Name);
                    Traveller.Image = null;
                }
            }
        }


        private void Mouse_Up(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                MouseUpLocation = new Point(e.X + (sender as PictureBox).Left, e.Y + (sender as PictureBox).Top);
            NecessaryBoxFinder((sender as PictureBox));
        }
        private void Mouse_Move(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                (sender as PictureBox).Left = e.X + (sender as PictureBox).Left - 50;
                (sender as PictureBox).Top = e.Y + (sender as PictureBox).Top - 50;
            }
        }
        private void OK_Click(object sender, EventArgs e)
        {
            this.Size = new Size(1000, 500);
            label1.Visible = false;
            LinkBox.Visible = false;
            OK.Visible = false;
            LinkPictureBox.Visible = true;
            using (WebClient webClient = new WebClient())
            {
                byte[] data = webClient.DownloadData("https://images.wallpaperscraft.ru/image/fon_yarkiy_svet_oskolki_85568_1280x720.jpg");

                using (MemoryStream mem = new MemoryStream(data))
                    IMG_FROM_LINK = Image.FromStream(mem);
                LinkPictureBox.Image = IMG_FROM_LINK;
            }
           
            //pictureBoxes.AddRange(new List<PictureBox> { pictureBox1, pictureBox2, pictureBox3, pictureBox4 });
            Split();
        }
        private void unsort_Click(object sender, EventArgs e)
        {
            foreach (PictureBox item in Puzzles)
                item.Location = new Point(40 + generator() * (Puzzles[0].Width + 10), 250);
            unsort.Visible = false;
            NewPictureBoxGeneration();
        }
    }
}
