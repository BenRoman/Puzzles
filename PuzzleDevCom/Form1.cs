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
        #region fields
        public static Image IMG_FROM_LINK;
        public static List<int> randomList = new List<int>();
        public static Random RANDOM = new Random();
        public static int VerticalAmount;
        public static int GorizontalAmount;
        public static int UpperBound;
        public static List<Cell> Puzzles = new List<Cell>();
        public static List<PictureBox> NewBoxList = new List<PictureBox>();
        public static Point MouseUpLocation;
        public static Point TravellerLocation;
        public Rectangle rect;
        #endregion
        public static int generator()
        {
            int aa = RANDOM.Next(0, UpperBound);
            while (randomList.Contains(aa) && randomList.Count < UpperBound)
                aa = RANDOM.Next(0, UpperBound);
            randomList.Add(aa);
            return aa;
        }
        private void Split()
        {
            PuzzleBuilderAndRefact();
            Bitmap originalImage = new Bitmap(IMG_FROM_LINK);
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
                    tmp = new PictureBox();
                    tmp.Name = $"picturebox{counter++}";
                    tmp.SizeMode = PictureBoxSizeMode.StretchImage;
                    tmp.Location = new Point(500 + j * (LinkPictureBox.Width / GorizontalAmount + 3), 12 + i * (LinkPictureBox.Height / VerticalAmount + 3));
                    tmp.Parent = this;
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

            this.Size = new Size(520 + GorizontalAmount * (Puzzles[0].Face.Width + 3), 12 + (VerticalAmount + 1) * (Puzzles[0].Face.Height + 4));
        }
        private void NewPictureBoxGeneration()
        {
            PictureBox newone;
            int counter = 0;
            for (int i = 0; i < GorizontalAmount; ++i)
                for (int j = 0; j < VerticalAmount; ++j)
                {
                    newone = new PictureBox();
                    newone.Size = Puzzles[0].Face.Size;
                    newone.SizeMode = PictureBoxSizeMode.StretchImage;
                    newone.Location = new Point(500 + j * (Puzzles[0].Face.Width + 3), 12 + i * (Puzzles[0].Face.Height + 3));
                    newone.BackColor = Color.White;
                    newone.Name = $"picturebox{counter++}";
                    newone.Parent = this;
                    NewBoxList.Add(newone);
                }
        }
        private void NecessaryBoxFinder(PictureBox Traveller)
        {
            bool Finder = false;
            Point tmp;
            foreach (var item in NewBoxList)
                if ((item.Location.X < MouseUpLocation.X && (item.Location.X + item.Width) > MouseUpLocation.X) && (item.Location.Y < MouseUpLocation.Y && (item.Location.Y + item.Height) > MouseUpLocation.Y))
                {
                    tmp = item.Location;
                    item.Location = TravellerLocation;
                    Traveller.Location = tmp;
                    Finder = !Finder;
                    break;
                }
            if (!Finder)
                Traveller.Location = new Point(TravellerLocation.X, TravellerLocation.Y);
        }
        private static int CompareBoxesByLocation(Cell a, Cell b)
        {
            if (a.Face.Location.Y == b.Face.Location.Y)
                return a.Face.Location.X.CompareTo(b.Face.Location.X);
            return a.Face.Location.Y.CompareTo(b.Face.Location.Y); ;
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
        #region events
        private void Mouse_Up(object sender, MouseEventArgs e)
        {
            foreach (var item in Puzzles)
                if (item.Face.Location.Y + item.Face.Height < tip2.Location.Y)
                    auto.Visible = false;
            if (e.Button == MouseButtons.Left)
                MouseUpLocation = new Point(e.X + (sender as PictureBox).Left, e.Y + (sender as PictureBox).Top);
            NecessaryBoxFinder((sender as PictureBox));
        }
        private void Mouse_Down(object sender, MouseEventArgs e)
        {
            TravellerLocation = new Point((sender as PictureBox).Left, (sender as PictureBox).Top);
            if (e.Button == MouseButtons.Right)
            {
                (sender as PictureBox).Image = RotateImage((sender as PictureBox).Image);
                foreach (var item in Puzzles)
                    if (item.Face == (sender as PictureBox))
                    {
                        item.AmountOfRotations++;
                        break;
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
            try
            {
                VerticalAmount = Convert.ToInt32(SizeBox.Text);
                GorizontalAmount = Convert.ToInt32(SizeBox.Text);
                if (VerticalAmount == 1)
                {
                    VerticalAmount++;
                    GorizontalAmount++;
                }
            }
            catch (Exception ex)
            {
                VerticalAmount = 6;
                GorizontalAmount = 6;
                MessageBox.Show(ex.Message);
            }

            SizeBox.Visible = false;
            label1.Visible = false;
            LinkBox.Visible = false;
            OK.Visible = false;
            LinkPictureBox.Visible = true;
            unsort.Visible = true;
            using (WebClient webClient = new WebClient())
            {
                string str = LinkBox.Text.Trim() == "" ? "https://images.wallpaperscraft.ru/image/most_solnce_luchi_svet_utro_reka_park_skazka_48376_1280x720.jpg" : LinkBox.Text;
                byte[] data = webClient.DownloadData(str);
                using (MemoryStream mem = new MemoryStream(data))
                    IMG_FROM_LINK = Image.FromStream(mem);
                LinkPictureBox.Image = IMG_FROM_LINK;
            }
            Split();
        }
        private void unsort_Click(object sender, EventArgs e)
        {
            this.Size = new Size(520 + GorizontalAmount * (Puzzles[0].Face.Width + 3), 300 + Puzzles.Count / VerticalAmount * (Puzzles[0].Face.Height + 3));
            UpperBound = (this.Size.Width - 130) / (Puzzles[0].Face.Width + 10);
            for (int item = 0; item < Puzzles.Count; ++item)
            {
                if (item % UpperBound == 0)
                    randomList = new List<int>();
                Puzzles[item].Face.Location = new Point(70 + generator() * (Puzzles[0].Face.Width + 10), 250 + (item / UpperBound + 1) * (Puzzles[0].Face.Height + 3));
                int RA = RANDOM.Next(0, 4);
                Puzzles[item].AmountOfRotations += RA;
                for (int i = 0; i < RA; ++i)
                    Puzzles[item].Face.Image = RotateImage(Puzzles[item].Face.Image);
                Puzzles[item].Face.Image.Save($@"..\Bitmaps\{item}.png");

            }
            unsort.Visible = false;
            check.Visible = true;
            auto.Visible = true;
            second_auto.Visible = true;
            tips.Visible = true;
            NewPictureBoxGeneration();
        }
        private void check_Click(object sender, EventArgs e)
        {
            bool ableToCheck = true;
            foreach (var item in Puzzles)
            {
                if (item.Face.Location.Y + item.Face.Height > LinkPictureBox.Location.Y + LinkPictureBox.Height + VerticalAmount * 3)
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
            string str = (ableToCheck == true) ? "Congratulations !!" : "Keep trying ..";
            MessageBox.Show(str);
        }
        private void auto_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Puzzles.Count; ++i)
            {
                Point tmp = NewBoxList[i].Location;
                NewBoxList[i].Location = Puzzles[i].Face.Location;
                Puzzles[i].Face.Location = tmp;
                int RA = 4 - Puzzles[i].AmountOfRotations % 4;
                for (int j = 0; j < RA; ++j)
                    Puzzles[i].Face.Image = RotateImage(Puzzles[i].Face.Image);
                Puzzles[i].AmountOfRotations += RA;
            }
        }
        private void tips_Click(object sender, EventArgs e)
        {
            tip1.Visible = !tip1.Visible;
            tip2.Location = new Point(550, 20 + VerticalAmount * (Puzzles[0].Face.Height + 3));
            tip2.Visible = !tip2.Visible;
        }
        #endregion
        private bool Compare(Bitmap bmp1, Bitmap bmp2)
        {
            bool equals = true;
            bool flag = true;  //Inner loop isn't broken

            //Test to see if we have the same size of image
            if (bmp1.Size == bmp2.Size)
            {
                for (int x = 0; x < bmp1.Width; ++x)
                {
                    for (int y = 0; y < bmp1.Height; ++y)
                    {
                        if (bmp1.GetPixel(x, y) != bmp2.GetPixel(x, y))
                        {
                            equals = false;
                            flag = false;
                            break;
                        }
                    }
                    if (!flag)
                    {
                        break;
                    }
                }
            }
            else
            {
                equals = false;
            }
            return equals;
        }

        private void second_auto_Click(object sender, EventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            Bitmap originalImage = new Bitmap(IMG_FROM_LINK);
            Bitmap PartOfOriginal;

            List<Bitmap> arrOfpuzzles = new List<Bitmap>();
            for (int i = 0; i < VerticalAmount * GorizontalAmount; ++i)
                arrOfpuzzles.Add(new Bitmap(Image.FromFile($@"..\Bitmaps\{i}.png")));

            //int counter = 0;
            string text = "";
            bool found;
            List<Bitmap> ListOfSortedAndRotatedPuzzles = new List<Bitmap>();
            for (int i = 0; i < VerticalAmount; ++i)
            {
                for (int j = 0; j < GorizontalAmount; ++j)
                {
                    rect = new Rectangle(j * originalImage.Width / GorizontalAmount, i * originalImage.Height / VerticalAmount, originalImage.Width / GorizontalAmount, originalImage.Height / VerticalAmount);
                    PartOfOriginal = originalImage.Clone(rect, originalImage.PixelFormat);
                    found = false;
                    for (int k = 0; k < arrOfpuzzles.Count; ++k)
                    {
                        for (int q = 0; q < 4; ++q)
                        {
                            if (Compare(arrOfpuzzles[k], PartOfOriginal))
                            {
                                ListOfSortedAndRotatedPuzzles.Add(PartOfOriginal);
                                arrOfpuzzles.Remove(arrOfpuzzles[k]);
                                found = true;
                                break;
                            }
                            else
                                arrOfpuzzles[k] = new Bitmap(RotateImage(arrOfpuzzles[k]));
                        }
                        if (found)
                            break;
                    }
                }
            }
            PictureBox tmp;
            int counter = 0;
            for (int i = 0; i < VerticalAmount; ++i)
            {
                for (int j = 0; j < GorizontalAmount; ++j)
                {
                    tmp = new PictureBox();
                    tmp.SizeMode = PictureBoxSizeMode.StretchImage;
                    tmp.Location = new Point(900 + j * (LinkPictureBox.Width / GorizontalAmount + 3), 12 + i * (LinkPictureBox.Height / VerticalAmount + 3));
                    tmp.Parent = this;
                    tmp.Image = ListOfSortedAndRotatedPuzzles[counter++];
                    tmp.Width = LinkPictureBox.Width / GorizontalAmount;
                    tmp.Height = LinkPictureBox.Height / VerticalAmount;
                }
            }
            this.Size = new Size(520 + GorizontalAmount * (Puzzles[0].Face.Width + 3), 12 + (VerticalAmount + 1) * (Puzzles[0].Face.Height + 4));

            //counter = 0;
            //for (int i = 0; i < VerticalAmount; ++i)
            //{
            //    for (int j = 0; j < GorizontalAmount; ++j)
            //    {
            //        rect = new Rectangle(j * originalImage.Width / GorizontalAmount, i * originalImage.Height / VerticalAmount, originalImage.Width / GorizontalAmount, originalImage.Height / VerticalAmount);
            //        PartOfOriginal = originalImage.Clone(rect, originalImage.PixelFormat);
            //        text += Compare(ListOfSortedAndRotatedPuzzles[counter++], PartOfOriginal) + " ";
            //    }
            //    text += "\n";
            //}
            //watch.Stop();
            //var elapsedMs = watch.ElapsedMilliseconds;
            //text += elapsedMs;
            //MessageBox.Show(text.ToString());
            this.Width += 500;
        }
    }
}
