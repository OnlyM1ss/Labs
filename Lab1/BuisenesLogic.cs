using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    class BuisenesLogic
    {
        FileDataSource dataSource = new FileDataSource(@"C:\Users\Murdergorn\source\repos\Labs-Lab1\AdminSource", @"C:\Users\Murdergorn\source\repos\Labs-Lab1\LegalSource");
        public string addRecord(Legal document)
        {
            try
            {
                dataSource.Save(document);
                return "Запись " + document.getName() + "Добавлена";
            }
            catch
            {
                throw new Exception("Запись не добавлена");
            }
        }
        public string addRecord(Administative document)
        {
            try
            {
                dataSource.Save(document);
                return "Запись " + document.getName() + "Добавлена";
            }
            catch
            {
                throw new Exception("Запись не добавлена");
            }
        }
        public void changeRecord(int id, bool isLegal,string name,DateTime beginTime,DateTime endTime,String discribe)
        {
            try
            {
                if(isLegal)
                {
                    Legal record = new Legal();
                    dataSource.Delete(id, true);
                    record.setID(id);
                    record.setName(name);
                    record.setBeginTime(beginTime);
                    record.setEndTime(endTime);
                    record.setDiscribe(discribe);
                    dataSource.Save(record);

                }
                if(!isLegal)
                {
                    Administative record = new Administative();
                    dataSource.Delete(id, false);
                    record.setID(id);
                    record.setName(name);
                    record.setBeginTime(beginTime);
                    record.setEndTime(endTime);
                    record.setDiscribe(discribe);
                    dataSource.Save(record);
                }
            }
            catch
            {
                throw new Exception("Запись не изменена");
            }
        }
        public void deleteDocument(int id,bool isLegal)
        {
            try
            {
                if(isLegal)
                {
                List<Document> documents = new List<Document>();
                    documents = GetLegals();
                    dataSource.Delete(id, true);
                }
                else
                {
                    List<Document> documents = new List<Document>(dataSource.GetAdministatives());
                    documents.Remove(documents[id]);
                    dataSource.Delete(id, false);
                }
            }
            catch
            {
                throw new Exception("Не удалось удалить");
            }
        }
        public List<Document> GetLegals()
        {
            return dataSource.GetLegals();
        }
        public List<Document> GetAdministatives()
        {
            return dataSource.GetAdministatives();
        }
        
    }
}
