using System;

namespace Lab1
{
    class Legal : Document
    {
        protected override int id { get; set; }
        protected override DateTime beginTime { get; set; }
        protected override DateTime endTime { get; set; }
        protected override string discribe { get; set; }
        protected override string name { get; set; }

        public bool isLegal;
        public override int getId()
        {
            return id;
        }
        public override DateTime getbeginTime()
        {
            return beginTime;
        }
        public override DateTime getEndTime()
        {
            return endTime;
        }
        public override string getdiscribe()
        {
            return discribe;
        }
        public override string getName()
        {
            return name;
        }
        public override void setID(int id)
        {
            this.id = id;
        }
        public override void setBeginTime(DateTime beginTime)
        {
            this.beginTime = beginTime;
        }
        public override void setEndTime(DateTime endTime)
        {
            this.endTime = endTime;
        }
        public override void setDiscribe(string discribe)
        {
            this.discribe = discribe;
        }
        public override void setName(string name)
        {
            this.name = name;
        }
    }
}

