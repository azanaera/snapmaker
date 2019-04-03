using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.IO;

namespace Snapshot_Maker
{
    public partial class SnapshotForm : Form
    {
        // The original image.
        private Bitmap OriginalImage = null;

        // The currently cropped image.
        private Bitmap CroppedImage;

        // The cropped image with the selection rectangle.
        private Bitmap DisplayImage;
        private Graphics DisplayGraphics;

        public SnapshotForm( )
        {
            InitializeComponent( );
        }

        public void SetImage( Bitmap bitmap )
        {
                timeBox.Text = DateTime.Now.ToLongTimeString( );

            //Bitmap old = (Bitmap)pictureBox.Image;
            //pictureBox.Image = bitmap;


            //picCropped.Image = bitmap;

            //OriginalImage = bitmap;
            //CroppedImage = (Bitmap)bitmap.Clone();
            //DisplayImage = (Bitmap)CroppedImage.Clone();
            //DisplayGraphics = Graphics.FromImage(DisplayImage);

            //picCropped.Image = DisplayImage;
            //picCropped.Visible = true;




            Bitmap nb = new Bitmap(512, 512);
            Graphics g = Graphics.FromImage(nb);
            g.DrawImage(bitmap, -398, -108);
            picCropped.Image = nb;
            //if ( old != null )
            //{
            //    old.Dispose( );
            //}
        }
        

        private void saveButton_Click( object sender, EventArgs e )
        {
            if ( saveFileDialog.ShowDialog( ) == DialogResult.OK )
            {
                string ext = Path.GetExtension( saveFileDialog.FileName ).ToLower( );
                ImageFormat format = ImageFormat.Jpeg;

                if ( ext == ".bmp" )
                {
                    format = ImageFormat.Bmp;
                }
                else if ( ext == ".png" )
                {
                    format = ImageFormat.Png;
                }

                try
                {
                    lock ( this )
                    {
                        Bitmap image = (Bitmap) picCropped.Image;
                        image.Save(saveFileDialog.FileName, format);
                    }
                }
                catch ( Exception ex )
                {
                    MessageBox.Show( "Failed saving the snapshot.\n" + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
                }
            }
        }










        // Open a file.
        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            if (ofdPicture.ShowDialog() == DialogResult.OK)
            {
                OriginalImage = LoadBitmapUnlocked(ofdPicture.FileName);
                CroppedImage = OriginalImage.Clone() as Bitmap;
                DisplayImage = CroppedImage.Clone() as Bitmap;
                DisplayGraphics = Graphics.FromImage(DisplayImage);

                picCropped.Image = DisplayImage;
                picCropped.Visible = true;
            }
        }

        // Let the user select an area.
        private bool Drawing = false;
        private Point StartPoint, EndPoint;
        private void picCropped_MouseDown(object sender, MouseEventArgs e)
        {
            Drawing = true;
            StartPoint = e.Location;

            // Draw the area selected.
            DrawSelectionBox(e.Location);
        }

        private void picCropped_MouseMove(object sender, MouseEventArgs e)
        {
            if (!Drawing) return;

            // Draw the area selected.
            DrawSelectionBox(e.Location);
        }

        private void picCropped_MouseUp(object sender, MouseEventArgs e)
        {
            if (!Drawing) return;
            Drawing = false;

            // Crop.
            // Get the selected area's dimensions.
            int x = Math.Min(StartPoint.X, EndPoint.X);
            int y = Math.Min(StartPoint.Y, EndPoint.Y);
            int width = Math.Abs(StartPoint.X - EndPoint.X);
            int height = Math.Abs(StartPoint.Y - EndPoint.Y);
            Rectangle source_rect = new Rectangle(x, y, width, height);
            Rectangle dest_rect = new Rectangle(0, 0, width, height);

            // Copy that part of the image to a new bitmap.
            DisplayImage = new Bitmap(width, height);
            DisplayGraphics = Graphics.FromImage(DisplayImage);
            DisplayGraphics.DrawImage(CroppedImage, dest_rect, source_rect, GraphicsUnit.Pixel);

            // Display the new bitmap.
            CroppedImage = DisplayImage;
            DisplayImage = CroppedImage.Clone() as Bitmap;
            DisplayGraphics = Graphics.FromImage(DisplayImage);
            picCropped.Image = DisplayImage;
            picCropped.Refresh();
        }

        // Draw the area selected.
        private void DrawSelectionBox(Point end_point)
        {
            // Save the end point.
            EndPoint = end_point;
            if (EndPoint.X < 0) EndPoint.X = 0;
            if (EndPoint.X >= CroppedImage.Width) EndPoint.X = CroppedImage.Width - 1;
            if (EndPoint.Y < 0) EndPoint.Y = 0;
            if (EndPoint.Y >= CroppedImage.Height) EndPoint.Y = CroppedImage.Height - 1;

            // Reset the image.
            DisplayGraphics.DrawImageUnscaled(CroppedImage, 0, 0);

            // Draw the selection area.
            int x = Math.Min(StartPoint.X, EndPoint.X);
            int y = Math.Min(StartPoint.Y, EndPoint.Y);
            Console.WriteLine(" x,y : {0} {1}", x, y);
            int width = Math.Abs(StartPoint.X - EndPoint.X);
            int height = Math.Abs(StartPoint.Y - EndPoint.Y);
            Console.WriteLine(" w,h : {0} {1}", width,height);
            DisplayGraphics.DrawRectangle(Pens.Red, x, y, width, height);
            picCropped.Refresh();
        }

        // Display the original image.
        private void mnuPictureReset_Click(object sender, EventArgs e)
        {
            CroppedImage = OriginalImage.Clone() as Bitmap;
            DisplayImage = OriginalImage.Clone() as Bitmap;
            DisplayGraphics = Graphics.FromImage(DisplayImage);
            picCropped.Image = DisplayImage;
        }

        // Save the current file.
        private void mnuFileSave_Click(object sender, EventArgs e)
        {
            if (sfdPicture.ShowDialog() == DialogResult.OK)
            {
                SaveBitmapUsingExtension(CroppedImage, sfdPicture.FileName);
            }
        }

        // Save the file with the appropriate format.
        // Throw a NotSupportedException if the file
        // has an unknown extension.
        public void SaveBitmapUsingExtension(Bitmap bm, string filename)
        {
            string extension = Path.GetExtension(filename);
            switch (extension.ToLower())
            {
                case ".bmp":
                    bm.Save(filename, ImageFormat.Bmp);
                    break;
                case ".exif":
                    bm.Save(filename, ImageFormat.Exif);
                    break;
                case ".gif":
                    bm.Save(filename, ImageFormat.Gif);
                    break;
                case ".jpg":
                case ".jpeg":
                    bm.Save(filename, ImageFormat.Jpeg);
                    break;
                case ".png":
                    bm.Save(filename, ImageFormat.Png);
                    break;
                case ".tif":
                case ".tiff":
                    bm.Save(filename, ImageFormat.Tiff);
                    break;
                default:
                    throw new NotSupportedException(
                        "Unknown file extension " + extension);
            }
        }

        private void SnapshotForm_SizeChanged(object sender, EventArgs e)
        {
            Console.WriteLine(this.Size);
        }

        // Load the image into a Bitmap, clone it, and
        // set the PictureBox's Image property to the Bitmap.
        private Bitmap LoadBitmapUnlocked(string file_name)
        {
            using (Bitmap bm = new Bitmap(file_name))
            {
                Bitmap new_bitmap = new Bitmap(bm.Width, bm.Height);
                using (Graphics gr = Graphics.FromImage(new_bitmap))
                {
                    gr.DrawImage(bm, 0, 0);
                }
                return new_bitmap;
            }
        }
    }
}
