using System;
using System.IO;
using System.Text;

namespace BulkEmail.CSV
{

    public class CSVReader
    {
        const int FIRST_COLUMN = 0;
        const int SECOND_COLUMN = 1;
        public bool Read(out string column1, out string column2, StreamReader _readerStream)
        {         
            string line;
            string[] columns;

            line = _readerStream.ReadLine();

            if (string.IsNullOrWhiteSpace(line))
            {
                column1 = null;
                column2 = null;
                return false;
            }

            columns = line.Split('\t');

            if (columns.Length == 0)
            {
                column1 = null;
                column2 = null;

                return false;
            } 
            else
            {
                column1 = columns[FIRST_COLUMN];
                column2 = columns[SECOND_COLUMN];

                return true;
            }
        }


    }
}
