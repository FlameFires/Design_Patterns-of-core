using Adapter_Pattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adapter_Pattern
{
    public class Mp4Player : IAdvancedMediaPlayer
    {
        public void playMp4(string fileName)
        {
            // not to do
        }

        public void playVlc(string fileName)
        {
            Console.WriteLine("Playing mp4 file. Name: " + fileName);
        }
    }
}
