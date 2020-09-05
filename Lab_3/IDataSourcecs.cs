using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_3
{
    interface IDataSource
    {
        Document Save(Administative document);
        Document Save(Legal document);
        Document Get(int id, bool isLegal);
        bool Delete(int id, bool isLegal);
        List<Document> GetLegals();
        List<Administative> GetAdministatives();
    }
}
