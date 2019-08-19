using System;
using Android.Graphics;
using Android.OS;
using Android.Widget;
using Java.Net;

namespace MobileApp
{
    public class DownloadImageTask : AsyncTask<string, object, Bitmap>
    {
        private ImageView bmImage;

        public DownloadImageTask(ImageView bmImage)
        {
            this.bmImage = bmImage;
        }

        protected override Bitmap RunInBackground(params string[] urls)
        {
            string urldisplay = urls[0];
            Bitmap bitmap = null;
            try
            {
                bitmap = BitmapFactory.DecodeStream(new URL(urldisplay).OpenStream());
            }
            catch (Exception) { }
            
            return bitmap;
        }

        protected override void OnPostExecute(Bitmap result)
        {
            bmImage.SetImageBitmap(result);
        }
    }
}