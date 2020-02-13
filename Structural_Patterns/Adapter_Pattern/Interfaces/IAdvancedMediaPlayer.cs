using System;
using System.Collections.Generic;
using System.Text;

namespace Adapter_Pattern.Interfaces
{
    public interface IAdvancedMediaPlayer
    {
        public void playVlc(String fileName);
        public void playMp4(String fileName);
    }
}
