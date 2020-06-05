using System;
using System.IO;
using System.Text;

namespace BulkEmail.CSV
{
    /*
     2) Refactor the CSVReaderWriter implementation into clean, elegant, well performing 
        and maintainable code, as you see fit.
        You should not update the BulkEmailProcessor as part of this task.
        Backwards compatibility of the CSVReaderWriter must be maintained, so that the 
        existing BulkEmailProcessor is not broken.
        Other that that, you can make any change you see fit, even to the code structure.
    */

    public class CSVReaderWriter
    {
        private StreamReader _readerStream = null;
        private StreamWriter _writerStream = null;
        CSVReader reader;
        CSVWriter writer;

        public CSVReaderWriter()
        {
            this.reader = new CSVReader();
            this.writer = new CSVWriter();
        }

        public enum Mode { Read = 1, Write = 2 };

        public void Open(string fileName, Mode mode)
        {
            if (mode == Mode.Read)
            {
                try
                {
                    _readerStream = File.OpenText(fileName);
                }
                catch (Exception e)
                {
                    throw e;
                }
               
            }
            else if (mode == Mode.Write)
            {
                try
                {
                    FileInfo fileInfo = new FileInfo(fileName);
                    _writerStream = fileInfo.CreateText();
                }
                catch (Exception e)
                {
                    throw e;
                }
              
            }
            else
            {
                throw new Exception("Unknown file mode for " + fileName);
            }
        }

        public bool Read(out string column1, out string column2)
        {           
            return reader.Read(out column1,out column2, _readerStream);
        }

        public void Write(params string[] columns) {
             writer.Write(_writerStream, columns);
        }

        public void Close()
        {
            if (_writerStream != null)
            {
                _writerStream.Close();
            }

            if (_readerStream != null)
            {
                _readerStream.Close();
            }

        }
    }
}
