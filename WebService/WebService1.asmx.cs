using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.IO;
using System.IO.Compression;

namespace WebService
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]        
        public byte[] ZipThat(string FileName, byte[] TxtData)
        {
            using (MemoryStream mst = new MemoryStream())
            {
                using (ZipArchive arc = new ZipArchive(mst, ZipArchiveMode.Create))
                {
                    var zipEntry = arc.CreateEntry(FileName);

                    using (Stream st = zipEntry.Open())
                    {
                        st.Write(TxtData, 0, TxtData.Length);
                    }
                }

                return mst.ToArray();
            }
        }

        [WebMethod]
        public byte[] ZipMulti(string FileName1, string FileName2, byte[] TxtData1,byte[] TxtData2)
        {
            try
            {
                using (MemoryStream mst = new MemoryStream())
                {
                    using (ZipArchive arc = new ZipArchive(mst, ZipArchiveMode.Create))
                    {
                        // var zipEntry1 = arc.CreateEntry(FileName1);
                        // var zipEntry2 = arc.CreateEntry(FileName2);

                        ZipArchiveEntry zipFileEntry1 = arc.CreateEntry(FileName1);

                        using (Stream st = zipFileEntry1.Open())
                        {
                            st.Write(TxtData1, 0, TxtData1.Length);

                        }

                        ZipArchiveEntry zipFileEntry2 = arc.CreateEntry(FileName2);
                        using (Stream st = zipFileEntry2.Open())
                        {
                            st.Write(TxtData2, 0, TxtData2.Length);

                        }
                    }

                    return mst.ToArray();
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Hata: " + ex);
                 
            }


            return TxtData1;
        }




    }
}
