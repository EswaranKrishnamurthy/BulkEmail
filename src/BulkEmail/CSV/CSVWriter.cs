using System;
using System.IO;
using System.Text;

namespace BulkEmail.CSV
{

    public class CSVWriter
    {
        public void Write(StreamWriter _writerStream, params string[] columns)
        {
            StringBuilder outPut = new StringBuilder();

            for (int i = 0; i < columns.Length; i++)
            {
                outPut.Append(columns[i]);
                if ((columns.Length - 1) != i)
                {
                    outPut.Append("\t");
                }
            }
            _writerStream.WriteLine(outPut.ToString());
        }

      
    }
}
