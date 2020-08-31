using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    class DesirilizeDocument : Document
    {
        protected override int id { get => base.id; set => base.id = value; }
        protected override DateTime beginTime { get => base.beginTime; set => base.beginTime = value; }
        protected override DateTime endTime { get => base.endTime; set => base.endTime = value; }
        protected override string discribe { get => base.discribe; set => base.discribe = value; }
        protected override string name { get => base.name; set => base.name = value; }

        public override DateTime getbeginTime()
        {
            return base.getbeginTime();
        }

        public override string getdiscribe()
        {
            return base.getdiscribe();
        }

        public override DateTime getEndTime()
        {
            return base.getEndTime();
        }

        public override int getId()
        {
            return base.getId();
        }

        public override string getName()
        {
            return base.getName();
        }

        public override void setBeginTime(DateTime beginTime)
        {
            base.setBeginTime(beginTime);
        }

        public override void setDiscribe(string discribe)
        {
            setDiscribe(discribe);
        }

        public override void setEndTime(DateTime endTime)
        {
            base.setEndTime(endTime);
        }

        public override void setID(int id)
        {
            base.setID(id);
        }

        public override void setName(string name)
        {
            base.setName(name);
        }
        public DesirilizeDocument(Document document)
        {
            setID(document.getId());
            setName(document.getName());
            setBeginTime(document.getbeginTime());
            setEndTime(document.getEndTime());
            setDiscribe(document.getdiscribe());
        }
    }
}
