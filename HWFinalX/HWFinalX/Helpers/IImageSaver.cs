using System;
using System.Collections.Generic;
using System.Text;

namespace HWFinalX.Helpers
{
    public interface IImageSaver
    {
        void Save(string url, string filename);
    }
}
