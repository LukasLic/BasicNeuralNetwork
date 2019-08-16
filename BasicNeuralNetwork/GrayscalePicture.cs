using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;

namespace Pictures
{
    class GrayscalePicture
    {
        public int size;
        public float[] values;
        private int iterator;

        public GrayscalePicture(string filepath)
        {
            ResetIterator();

            Bitmap bitmap = new Bitmap(filepath);

            int width = bitmap.Width;
            int height = bitmap.Height;
            size = bitmap.Width;

            values = new float[width * height];

            for (int h = 0; h < height; h++)
            {
                for (int w = 0; w < width; w++)
                {
                    Color pixel = bitmap.GetPixel(w, h);
                    // Calculating intesity
                    float intensity = 0.299f * pixel.R + 0.587f * pixel.G + 0.114f * pixel.B;
                    // Reversing B/W value
                    intensity = 1 - intensity;
                    // Cropping between <0f, 1f>
                    intensity = (intensity < 0f) ? 0f : (intensity > 1f) ? 1f : intensity;
                    // Saving to field
                    values[h * height + w] = intensity;
                }
            }
        }

        public void ResetIterator()
        {
            iterator = 0;
        }
        public float NextValue()
        {
            if(iterator>= values.Length)
            {
                iterator = 0;
            }
            return values[iterator++];
        }
    }
}
