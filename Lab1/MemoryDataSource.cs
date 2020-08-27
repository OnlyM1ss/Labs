using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;

namespace Lab1
{
    class MemoryDataSource : IDataSource
    {
        static int IndexAdministrative = 0;
        static int IndexLegal = 0;
        private List<Legal> LegalDocuments = new List<Legal>();
        private List<Administative> AdministrativeDocuments = new List<Administative>();

        //solid mistake
        public Document Save(Administative document)
        {
            ++IndexAdministrative;
            document.setID(IndexAdministrative);
            AdministrativeDocuments.Add(document);
            return document;
        }
        public Document Save(Legal document)
        {
            ++IndexLegal;
            document.setID(IndexLegal);
            LegalDocuments.Add(document);
            return document;
        }

        public Document Get(int id, bool isLegal)
        {
            return isLegal == true ? (Document)LegalDocuments.Where(d => d.getId() == id) : (Document)AdministrativeDocuments.Where(d => d.getId() == id);
        }
        public bool Delete(int id, bool isLegal)
        {
            try
            {
                if (isLegal) LegalDocuments.Remove(LegalDocuments[id]);
                else AdministrativeDocuments.Remove(AdministrativeDocuments[id]);
                return true;
            }
            catch
            {
                throw new Exception("Не удалось добавить запись");
            }
        }
        public List<Legal> GetLegals()
        {
            return LegalDocuments;
        }
        public List<Administative> GetAdministatives()
        {

            return AdministrativeDocuments;
        }
    }
}