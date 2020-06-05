using System;
using System.IO;
using System.Text;
using static BulkEmail.CSV.CSVReaderWriter;

namespace BulkEmail.CSV
{

    public class CSVOpenAndCloseFiles
    {
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


    }
}
