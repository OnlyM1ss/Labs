using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.IO;
using System.Text;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lab_3
{
    class FileDataSource : IDataSource
    {
        private static int IndexAdministrative = 0;
        private static int IndexLegal = 0;
        private static string FilePathForAdmin = "";
        private static string FilePathForLegal = "";
        private static string Sighnature = "";

        //solid mistake
        public Document Save(Administative document)
        {
            ++IndexAdministrative;
            document.setID(IndexAdministrative);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (FileStream sw = new FileStream(FilePathForAdmin, FileMode.OpenOrCreate))
            {
                binaryFormatter.Serialize(sw, document);
            }
            return document;
        }

        internal Document Save(Document document)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (FileStream sw = new FileStream(FilePathForAdmin, FileMode.OpenOrCreate))
            {
                binaryFormatter.Serialize(sw, document);
            }
            return document;
        }

        public Document Save(Legal document)
        {
            ++IndexLegal;
            document.setID(IndexLegal);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (FileStream sw = new FileStream(FilePathForLegal, FileMode.OpenOrCreate))
            {
                binaryFormatter.Serialize(sw, document);
            }
            return document;
        }

        public Document Get(int id, bool isLegal)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            if (isLegal)
            {
                List<Document> documents = new List<Document>();
                using (FileStream fileStream = new FileStream(FilePathForLegal, FileMode.OpenOrCreate))
                {
                    for (int i = 0; i < IndexLegal; i++)
                    {
                        documents.Add((Document)binaryFormatter.Deserialize(fileStream));
                    }
                }
                return (Document)documents.Where(d => d.getId() == id);
            }
            if (!isLegal)
            {
                List<Document> documents = new List<Document>();
                using (FileStream fileStream = new FileStream(FilePathForAdmin, FileMode.OpenOrCreate))
                {
                    for (int i = 0; i < IndexLegal; i++)
                    {
                        documents.Add((Document)binaryFormatter.Deserialize(fileStream));
                    }
                }
                return (Document)documents.Where(d => d.getId() == id);
            }
            return null;
            //return isLegal == true ? (Document)LegalDocuments.Where(d => d.getId() == id) : (Document)AdministrativeDocuments.Where(d => d.getId() == id);
        }
        public bool Delete(int id, bool isLegal)
        {
            try
            {
                if (isLegal)
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    List<Document> documents = new List<Document>();
                    using (FileStream fileStream = new FileStream(FilePathForAdmin, FileMode.OpenOrCreate))
                    {
                        for (int i = 0; i < IndexLegal; i++)
                        {
                            documents.Add((Document)binaryFormatter.Deserialize(fileStream));
                        }
                        documents.Remove((Document)documents.Where(d => d.getId() == id));
                    }
                    using (StreamWriter sw = new StreamWriter(FilePathForLegal, false))
                    {
                        sw.Write("");
                    }
                    using (FileStream fs = new FileStream(FilePathForLegal, FileMode.OpenOrCreate))
                    {
                        foreach (Document document in documents)
                        {
                            binaryFormatter.Serialize(fs, document);
                        }
                    }
                }
                //else AdministrativeDocuments.Remove(AdministrativeDocuments[id]);
                return true;
            }
            catch
            {
                throw new Exception("Не удалось добавить запись");
            }
        }
        public List<Document> GetLegals()
        {
            List<Document> documents = new List<Document>();
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            if (FilePathForLegal != null)
            {
                using (FileStream fs = new FileStream(FilePathForLegal, FileMode.OpenOrCreate))
                {

                    for (int i = 0; i < IndexAdministrative; i++)
                    {
                        documents.Add((Legal)binaryFormatter.Deserialize(fs));
                    }
                }
                return documents;
            }
            return null;
        }
        public List<Administative> GetAdministatives()
        {
            List<Administative> documents = new List<Administative>();
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(FilePathForAdmin, FileMode.OpenOrCreate))
            {

                for (int i = 0; i < IndexAdministrative; i++)
                {
                    documents.Add((Administative)binaryFormatter.Deserialize(fs));
                }
            }
            return documents;
        }
        public FileDataSource(string filepathforadmin, string filepathforlegal)
        {
            FilePathForAdmin = filepathforadmin;
            FilePathForLegal = filepathforlegal;
        }
    }
}