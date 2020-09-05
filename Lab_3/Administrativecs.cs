using System;

namespace Lab_3
{
    [Serializable]
    class Administative : Document
    {
        protected override string type { get; set; }
        protected override int id { get; set; }
        protected override DateTime beginTime { get; set; }
        protected override DateTime endTime { get; set; }
        protected override string discribe { get; set; }
        protected override string name { get; set; }

        public bool rulesRoot;
        public override string getType()
        {
            return "Административный";
        }
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
            if (endTime >= beginTime) this.endTime = endTime;
            else
            {
                Console.WriteLine("Дата окончания не может быть меньше даты начала");
            }
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