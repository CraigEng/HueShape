using System;
using System.Collections.Generic;
using System.IO;
using System.Security;
using System.Xml.Serialization;
using HueShape.Data;

namespace HueShape.Logic.Implementation
{
    public class DocumentLogic : IDocumentLogic
    {
        private readonly ILogger _logger;

        public DocumentLogic(ILogger logger)
        {
            _logger = logger;
        }

        public void SaveFile(string fileName, IList<Shape> shapes)
        {
            var fileInfo = new FileInfo(fileName);
            try
            {
                if (fileInfo.Exists)
                {
                    using (var fileStream = fileInfo.Open(FileMode.Truncate, FileAccess.ReadWrite))
                    {
                        SerializeAndSave(shapes, fileStream);
                    }
                }
                else
                {
                    using (var fileStream = fileInfo.Open(FileMode.CreateNew, FileAccess.ReadWrite))
                    {
                        SerializeAndSave(shapes, fileStream);
                    }
                }
            }
            catch (Exception exception)
            {
               ThrowMeaningfulException(exception, fileName);
            }
        }

        public IList<Shape> OpenFile(string fileName)
        {
            var fileInfo = new FileInfo(fileName);
            IList<Shape> shapes = null;

            try
            {
                using (var fileStream = fileInfo.Open(FileMode.Open, FileAccess.Read))
                {
                    var serializer = new XmlSerializer(typeof (List<Shape>));
                    shapes = (IList<Shape>) serializer.Deserialize(fileStream);
                    fileStream.Close();
                }
            }
            catch (Exception exception)
            {
                ThrowMeaningfulException(exception, fileName);
            }
            return shapes;
        }

        private void ThrowMeaningfulException(Exception exception, string fileName)
        {
            _logger.LogException(exception);

            if (exception is SecurityException)
            {
                throw new Exception("You does not have the required permission. ");
            }
            if (exception is FileNotFoundException)
            {
                throw new Exception("The file is not found.");
            }
            if (exception is UnauthorizedAccessException)
            {
                throw new Exception(string.Format("Path '{0}' is read-only or is a directory.", fileName));
            }
            if (exception is DirectoryNotFoundException)
            {
                throw new Exception("The specified path is invalid, such as being on an unmapped drive.");
            }
            if (exception is IOException)
            {
                throw new Exception("The file is already open.");
            }

            throw new Exception("Unexpected error occurred.");
        }

        private static void SerializeAndSave(IList<Shape> shapes, FileStream fileStream)
        {
            var serializer = new XmlSerializer(typeof (List<Shape>));
            serializer.Serialize(fileStream, shapes);
            fileStream.Close();
        }
    }
}