using System.Collections.Generic;
using HueShape.Data;

namespace HueShape.Logic
{
    public interface IDocumentLogic
    {
        void SaveFile(string fileName, IList<Shape> shapes);
        IList<Shape> OpenFile(string fileName);
    }
}