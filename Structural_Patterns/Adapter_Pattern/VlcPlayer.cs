using Adapter_Pattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adapter_Pattern
{
    public class VlcPlayer : IAdvancedMediaPlayer
    {
        public void playMp4(string fileName)
        {
            Console.WriteLine("Playing vlc file. Name: " + fileName);
        }

        public void playVlc(string fileName)
        {
            // 什么都不做
        }
    }
}
