using System;

namespace Lab_3
{
    [Serializable]
    public class Document

    {
        protected virtual string type { get; set; }
        protected virtual int id { get; set; }
        protected virtual DateTime beginTime { get; set; }
        protected virtual DateTime endTime { get; set; }
        protected virtual string discribe { get; set; }
        protected virtual string name { get; set; }

        public virtual string getType()
        {
            return null;
        }
        virtual public int getId()
        {
            return id;
        }
        virtual public DateTime getbeginTime()
        {
            return beginTime;
        }
        virtual public DateTime getEndTime()
        {
            return endTime;
        }
        virtual public string getdiscribe()
        {
            return discribe;
        }
        virtual public string getName()
        {
            return name;
        }
        virtual public void setID(int id)
        {
            this.id = id;
        }
        virtual public void setBeginTime(DateTime beginTime)
        {
            this.beginTime = beginTime;
        }
        virtual public void setEndTime(DateTime endTime)
        {
            this.endTime = endTime;
        }
        virtual public void setDiscribe(string discribe)
        {
            this.discribe = discribe;
        }
        virtual public void setName(string name)
        {
            this.name = name;
        }
    }
}
