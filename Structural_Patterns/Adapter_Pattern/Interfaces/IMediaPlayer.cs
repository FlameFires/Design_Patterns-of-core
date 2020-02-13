using System;
using System.Collections.Generic;
using System.Text;

namespace Adapter_Pattern.Interfaces
{
    public interface IMediaPlayer
    {
        public void play(String audioType, String fileName);
    }
}
