using System.Collections.Generic;
using InnotTech.VideoApplication2021.Core.Models;

namespace InnotTech.VideoApplication2021.Core.IServices
{
    public interface IVideoService
    {
        Video Create(Video video);

        List<Video> ReadAll();
    }
}