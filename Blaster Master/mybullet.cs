using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace BlasterMaster
{
    class mybullet : clsPlayerBullet
    {
        int n=2;
        int v = 1;
        // Obj refs and instances
        private System.Drawing.Bitmap bullet;
        private ImageAttributes ImagingAtt = new ImageAttributes();
        
        public mybullet(int x, int y): base(x, y)
        {
            //------------------------------------------------------------------------------------------------------------------
            // Purpose: Class constructor  
            //------------------------------------------------------------------------------------------------------------------

            // Load resource image(s) & remove background and thu a sprite is born 
            bullet = BlasterMaster.Properties.Resources.mBullets;
           bullet.MakeTransparent(Color.White);
        }

        public override void moveBullets(Graphics Destination)
        {
            //------------------------------------------------------------------------------------------------------------------
            // Purpose: Method to move the player's bullets by 16 pixels every frame  
            //------------------------------------------------------------------------------------------------------------------

            // Scroll bullets
            base.setY(base.getY() - (n* v));
            base.setX(base.getX() );
            v += 1;

            // Sync collision rect
            base.setRectX(base.getX() + 2);
            base.setRectY(base.getY());
            base.setRectW(base.getW() - 5);
            base.setRectH(base.getH());

            // call to render
            this.Draw(Destination);
        }

        private void Draw(Graphics Destination)
        {
            //------------------------------------------------------------------------------------------------------------------
            // Purpose: Method to render the player's sprite  
            //------------------------------------------------------------------------------------------------------------------

            // Draw sprite
            Destination.DrawImage(bullet, new Rectangle(base.getX(), base.getY(), base.getW(), base.getH()), 0, 0, base.getW(), base.getH(), GraphicsUnit.Pixel, ImagingAtt);
        }
    }
}

