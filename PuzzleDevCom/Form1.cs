using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
        public class Cell
        {
            public PictureBox Face;
            public int AmountOfRotations;
        }
        public static Image IMG_FROM_LINK;
        public static List<int> randomList = new List<int>();
        public static Random RANDOM = new Random();
        public static int VerticalAmount = 2;
        public static int GorizontalAmount = 2;

        public static List<Cell> Puzzles = new List<Cell>();
        public static List<PictureBox> NewBoxList = new List<PictureBox>();
        public static Point MouseUpLocation;
        public static Point TravellerLocation;

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
            PuzzleBuilderAndRefact();
            Bitmap originalImage = new Bitmap(IMG_FROM_LINK);
            Rectangle rect;
            Bitmap PartOfOriginal = originalImage;
            int counter = 0;
            for (int i = 0; i < VerticalAmount; ++i)
                for (int j = 0; j < GorizontalAmount; ++j)
                {
                    rect = new Rectangle(j * originalImage.Width / GorizontalAmount, i * originalImage.Height / VerticalAmount, originalImage.Width / GorizontalAmount, originalImage.Height / VerticalAmount);
                    PartOfOriginal = originalImage.Clone(rect, originalImage.PixelFormat);
                    Puzzles[counter++].Face.Image = PartOfOriginal;
                }
        }
        private void PuzzleBuilderAndRefact()
        {
            PictureBox tmp;
            int counter = 0;
            for (int i = 0; i < VerticalAmount; ++i)
            {
                for (int j = 0; j < GorizontalAmount; ++j)
                {
                    {
                        tmp = new PictureBox();
                        tmp.Name = $"picturebox{counter++}";
                        tmp.SizeMode = PictureBoxSizeMode.StretchImage;
                        tmp.Location = new Point(500 + j * (LinkPictureBox.Width / GorizontalAmount + 3),12 + i * (LinkPictureBox.Height / VerticalAmount + 3));
                        tmp.Parent = this;
                        //tmp.MouseDown += new MouseEventHandler(this.Mouse_Down);
                        tmp.MouseMove += new MouseEventHandler(this.Mouse_Move);
                        tmp.MouseUp += new MouseEventHandler(this.Mouse_Up);
                        tmp.MouseDown += new MouseEventHandler(this.Mouse_Down);

                        Puzzles.Add(new Cell { Face = tmp, AmountOfRotations = 0 });
                    }
                }

                foreach (var item in Puzzles)
                {
                    item.Face.Width = LinkPictureBox.Width / GorizontalAmount;
                    item.Face.Height = LinkPictureBox.Height / VerticalAmount;
                }
            }
        }
        private void NewPictureBoxGeneration()
        {
            PictureBox newone;
            int counter = 0;
            for(int i = 0; i < GorizontalAmount; ++i)
            {
                for(int j = 0; j < VerticalAmount; ++j)
                {
                    newone = new PictureBox();
                    newone.Size = Puzzles[0].Face.Size;
                    newone.SizeMode = PictureBoxSizeMode.StretchImage;
                    newone.Location = new Point(500 + j * (Puzzles[0].Face.Width + 3 ), 12 + i * (Puzzles[0].Face.Height + 3));
                    newone.BackColor = Color.White;
                    newone.Name = $"picturebox{counter++}";
                    newone.Parent = this;
                    NewBoxList.Add(newone);
                }
            }
        }
        private void NecessaryBoxFinder( PictureBox Traveller)
        {
            bool Finder = false;
            Point tmp;
            foreach ( var item in NewBoxList)
            {
                if ( (item.Location.X < MouseUpLocation.X && (item.Location.X + item.Width)>MouseUpLocation.X)   && (item.Location.Y < MouseUpLocation.Y && (item.Location.Y + item.Height) > MouseUpLocation.Y)) {
                    tmp = item.Location;
                    item.Location = TravellerLocation;
                    Traveller.Location = tmp;
                    Finder = !Finder;
                    break;
                }
            }
            if (!Finder) 
                Traveller.Location = new Point(TravellerLocation.X , TravellerLocation.Y);
        }


        private void Mouse_Up(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                MouseUpLocation = new Point(e.X + (sender as PictureBox).Left, e.Y + (sender as PictureBox).Top);
            NecessaryBoxFinder((sender as PictureBox));
        }
        private void Mouse_Down(object sender, MouseEventArgs e)
        {
            TravellerLocation = new Point((sender as PictureBox).Left, (sender as PictureBox).Top);
            if(e.Button == MouseButtons.Right)
            {
                (sender as PictureBox).Image = RotateImage((sender as PictureBox).Image);
                foreach( var item in Puzzles)
                {
                    if (item.Face == (sender as PictureBox))
                    {
                        item.AmountOfRotations++;
                        break;
                    }
                }
            }
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
            this.Size = new Size(860, 260);
            label1.Visible = false;
            LinkBox.Visible = false;
            OK.Visible = false;
            LinkPictureBox.Visible = true;
            unsort.Visible = true;
            using (WebClient webClient = new WebClient())
            {
            //string str = (ok == true) ? "+" : "-";
            //https://images.wallpaperscraft.ru/image/fon_yarkiy_svet_oskolki_85568_1280x720.jpg
                string str = LinkBox.Text.Trim()=="" ? "https://images.wallpaperscraft.ru/image/most_solnce_luchi_svet_utro_reka_park_skazka_48376_1280x720.jpg" : LinkBox.Text;
                byte[] data = webClient.DownloadData(str);

                using (MemoryStream mem = new MemoryStream(data))
                    IMG_FROM_LINK = Image.FromStream(mem);
                LinkPictureBox.Image = IMG_FROM_LINK;
            }

            //pictureBoxes.AddRange(new List<PictureBox> { pictureBox1, pictureBox2, pictureBox3, pictureBox4 });
            Split();
        }
        private void unsort_Click(object sender, EventArgs e)
        {
            this.Size = new Size(860, 400);
            foreach (var item in Puzzles)
            {
                item.Face.Location = new Point(70 + generator() * (Puzzles[0].Face.Width + 10), 250);
                item.AmountOfRotations = RANDOM.Next(0, 4);
                for (int i = 0; i < item.AmountOfRotations ; ++i)
                    item.Face.Image = RotateImage(item.Face.Image);

            }
            unsort.Visible = false;
            check.Visible = true;
            auto.Visible = true;
            tips.Visible = true;
            NewPictureBoxGeneration();

        }

        private static int CompareBoxesByLocation(Cell a, Cell b)
        {
            if (a.Face.Location.Y == b.Face.Location.Y)
                return a.Face.Location.X.CompareTo(b.Face.Location.X);
            return a.Face.Location.Y.CompareTo(b.Face.Location.Y); ;
        }
        private void check_Click(object sender, EventArgs e)
        {
            bool ableToCheck = true;
            foreach ( var item in Puzzles) {
                if (item.Face.Location.Y + item.Face.Height > LinkPictureBox.Location.Y + LinkPictureBox.Height + 10)
                {
                    ableToCheck = false;
                    break;
                }
            }
            if (ableToCheck)
            {
                Puzzles.Sort(CompareBoxesByLocation);
                for (int i = 0; i < Puzzles.Count; ++i)
                {
                    if (Puzzles[i].Face.Name != $"picturebox{i}" || (Puzzles[i].AmountOfRotations % 4 != 0))
                    {
                        ableToCheck = false;
                        break;
                    }
                }
            }
            string str = (ableToCheck == true) ? "+" : "-";
            MessageBox.Show(str);
        }
        private void auto_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Puzzles.Count; ++i)
            {
                Point tmp = NewBoxList[i].Location;
                NewBoxList[i].Location = Puzzles[i].Face.Location;
                Puzzles[i].Face.Location = tmp;
                //MessageBox.Show(Puzzles[i].AmountOfRotations.ToString());
                int RA = 4 - Puzzles[i].AmountOfRotations;
                //MessageBox.Show(RA.ToString());
                for (int j = 0; j < RA; ++j)
                    Puzzles[i].Face.Image = RotateImage(Puzzles[i].Face.Image);
                Puzzles[i].AmountOfRotations += RA;
            }
        }
        public Image RotateImage(Image img)
        {
            var bmp = new Bitmap(img);

            using (Graphics gfx = Graphics.FromImage(bmp))
            {
                gfx.Clear(Color.White);
                gfx.DrawImage(img, 0, 0, img.Width, img.Height);
            }

            bmp.RotateFlip(RotateFlipType.Rotate270FlipNone);
            return bmp;
        }


        private void tips_Click(object sender, EventArgs e)
        {
            tip1.Visible = !tip1.Visible;
            tip2.Visible = !tip2.Visible;
        }
    }
}
