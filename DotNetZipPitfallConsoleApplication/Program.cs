using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetZipPitfallConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ZipFile zip = ZipFile.Read("catalog.zip"))
            {
                foreach (ZipEntry entry in zip.Entries)
                {
                    using (var ms = new MemoryStream())
                    {
                        entry.Extract(ms);

                        ms.Position = 0;

                        using (BinaryReader reader = new BinaryReader(ms))
                        {
                            File.WriteAllBytes(Path.Combine(@"G:\Temp", entry.FileName), reader.ReadBytes((int)ms.Length));
                        }
                    }
                }
            }
        }
    }
}
