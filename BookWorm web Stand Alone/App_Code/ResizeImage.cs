using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

/// <summary>
/// Filename: ResizeImage.cs
/// Author:  Craig Turner
/// Created: 2015-10-22
/// Operating System: Windows
/// Version: 8.1 x64
/// Description: This class resizes and image to the best quality possible.
/// </summary>
public class ResizeImage
{
	public ResizeImage()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public  Bitmap Resize(Image image, int width, int height)
    {
        //Set the values for the new image changes
        var destRect = new Rectangle(0, 0, width, height);
        var destImage = new Bitmap(width, height);

        //maintains DPI regardless of physically size
        destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

        using (var graphics = Graphics.FromImage(destImage))
        {
            graphics.CompositingMode = CompositingMode.SourceCopy;
            //Set the quality of the image
            graphics.CompositingQuality = CompositingQuality.HighQuality;
            //determines how intermediate values between two endpoints are calculated
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            //specifies whether lines, curves, and the edges of filled areas use smoothing (also called antialiasing)
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            //affects rendering quality when drawing the new image
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            using (var wrapMode = new ImageAttributes())
            {
                //prevents ghosting around the image borders
                wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                //Draw the image
                graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
            }
        }

        return destImage;
    }
}