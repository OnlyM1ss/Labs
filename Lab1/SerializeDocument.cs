using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Lab1
{
    class SerializeDocument
    {
        //id < 255
        private byte Id;
        private byte[] Name;
        private byte[] DataBegin;
        private byte[] DataEnd;
        private byte[] Discribe;


        public byte getId()
        {
            return Id;
        }
        public byte[] getName()
        {
            return Name;
        }
        public byte[] getDataBegin()
        {
            return DataBegin;
        }
        public byte[] getDataEnd()
        {
            return DataEnd;
        }
        public byte[] getDiscribe()
        {
            return Discribe;
        }
        
        public void setId(byte id)
        {
            Id = id;
        }
        public void setName(byte[] name)
        {
            Name = name;
        }
        public void setDataBegin(byte[] dataBegin)
        {
            DataBegin = dataBegin;
        }
        public void setDataEnd(byte[] dataEnd)
        {
            DataEnd = dataEnd;
        }
        public void setDiscribe(byte[] discribe)
        {
            Discribe = discribe;
        }
        public SerializeDocument(Document document)
        {
            Id = (byte)document.getId();
            Name = Encoding.Default.GetBytes(document.getName());
            DataBegin = Encoding.Default.GetBytes(document.getbeginTime().ToString());
            DataEnd = Encoding.Default.GetBytes(document.getEndTime().ToString());
            Discribe = Encoding.Default.GetBytes(document.getdiscribe());
        }
    }
}
