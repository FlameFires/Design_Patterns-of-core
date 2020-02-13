using Adapter_Pattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adapter_Pattern
{
    public class AudioPlayer : IMediaPlayer
    {
        MediaAdapter mediaAdapter;
        public void play(string audioType, string fileName)
        {
            //播放 mp3 音乐文件的内置支持
            if (audioType.Equals("mp3", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Playing mp3 file. Name: " + fileName);
            }
            //mediaAdapter 提供了播放其他文件格式的支持
            else if (audioType.Equals("vlc", StringComparison.OrdinalIgnoreCase)
               || audioType.Equals("mp4", StringComparison.OrdinalIgnoreCase))
            {
                mediaAdapter = new MediaAdapter(audioType);
                mediaAdapter.play(audioType, fileName);
            }
            else
            {
                Console.WriteLine("Invalid media. " +
                   audioType + " format not supported");
            }
        }
    }
}
