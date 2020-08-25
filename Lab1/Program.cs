using System;
using System.Collections.Generic;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            ViewInterfaceLogic viewInterface = new ViewInterfaceLogic();
            BuisenesLogic buisenesLogic = new BuisenesLogic();
            while(true)
            {
                viewInterface.showMenu();
                int vote = int.Parse(Console.ReadLine());
                switch(vote)
                {
                    case 1:
                        Console.WriteLine("Выберите тип документа \n1) Административный\n2)Легальный");
                        int type = int.Parse(Console.ReadLine());
                        if(type == 1)
                        {
                            Administative administative = new Administative();
                            Console.WriteLine("Введите название документа");
                            administative.setName(Console.ReadLine());
                            Console.WriteLine("Введите дату начала");
                            administative.setBeginTime(DateTime.Parse(Console.ReadLine()));
                            Console.WriteLine("Введите дату окончания");
                            administative.setEndTime(DateTime.Parse(Console.ReadLine()));
                            Console.WriteLine("Есть ли привелегии?: \n1)Да\n 2)Нет");
                            int root = int.Parse(Console.ReadLine());
                            if (root == 1) administative.rulesRoot = true;
                            if (root == 2) administative.rulesRoot = false;
                            Console.WriteLine("Введите описание");
                            administative.setDiscribe(Console.ReadLine());
                            Console.WriteLine("Добавлено: " + buisenesLogic.addRecord(administative));
                        }
                        if(type == 2)
                        {
                            Legal legal = new Legal();
                            Console.WriteLine("Введите название документа");
                            legal.setName(Console.ReadLine());
                            Console.WriteLine("Введите дату начала");
                            legal.setBeginTime(DateTime.Parse(Console.ReadLine()));
                            Console.WriteLine("Введите дату окончания");
                            legal.setEndTime(DateTime.Parse(Console.ReadLine()));
                            Console.WriteLine("Это законно?: \n1)Да\n 2)Нет");
                            int isLegal = int.Parse(Console.ReadLine());
                            if (isLegal == 1) legal.isLegal = true;
                            if (isLegal == 2) legal.isLegal = false;
                            Console.WriteLine("Введите описание");
                            legal.setDiscribe(Console.ReadLine());
                            Console.WriteLine("Добавлено: " + buisenesLogic.addRecord(legal));
                        }
                        
                        break;
                    case 2:
                        
                        List<Administative> administatives = new List<Administative>();
                        administatives = buisenesLogic.GetAdministatives();
                        Console.Clear();
                        Console.WriteLine("Распорядительные: ");
                        Console.WriteLine(administatives.Count);
                        Console.WriteLine("+-------------------------------------------+");
                        Console.WriteLine("|id|name|beginData|endData|discribe");
                        foreach (var administative in administatives)
                        {
                            Console.WriteLine(administative.getId() + "|" + administative.getName() + "|" + administative.getbeginTime() + "|" + administative.getEndTime() + "|" + administative.getdiscribe());
                        }
                        Console.WriteLine("Легальные: ");
                        List<Legal> legals = new List<Legal>();
                        legals = buisenesLogic.GetLegals();
                        Console.WriteLine(legals.Count);
                        Console.WriteLine("+-------------------------------------------+");
                        Console.WriteLine("|id|name|beginData|endData|discribe");
                        foreach (var legal in legals)
                        {
                            Console.WriteLine(legal.getId() + "|"  + legal.getName() + "|" + legal.getbeginTime() + "|" + legal.getEndTime() + "|" + legal.getdiscribe());
                        }
                        Console.WriteLine("Нажмите любую кнопку для продолжения");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3:
                        Console.WriteLine("В каком документе вы хотите изменить запись?: \n1) Административный\n2)Легальный");
                        int voteForChange = int.Parse(Console.ReadLine());
                        if(voteForChange == 1)
                        {
                            Console.WriteLine("Какой элемент вы хотите изменить?: ");
                            int ind = int.Parse(Console.ReadLine());
                            Console.WriteLine("Введите название документа");
                            string name = Console.ReadLine();
                            Console.WriteLine("Введите дату начала");
                            DateTime beginTime = DateTime.Parse(Console.ReadLine());
                            Console.WriteLine("Введите дату окончания");
                            DateTime endTime = DateTime.Parse(Console.ReadLine());
                            Console.WriteLine("Введите описание");
                            string discribe = Console.ReadLine();
                            buisenesLogic.changeRecord(ind,false,name,beginTime,endTime,discribe); 
                        }
                        if(voteForChange == 2)
                        {
                            Console.WriteLine("Какой элемент вы хотите изменить?: ");
                            int ind = int.Parse(Console.ReadLine());
                            Console.WriteLine("Введите название документа");
                            string name = Console.ReadLine();
                            Console.WriteLine("Введите дату начала");
                            DateTime beginTime = DateTime.Parse(Console.ReadLine());
                            Console.WriteLine("Введите дату окончания");
                            DateTime endTime = DateTime.Parse(Console.ReadLine());
                            Console.WriteLine("Введите описание");
                            string discribe = Console.ReadLine();
                            buisenesLogic.changeRecord(ind, false, name, beginTime, endTime, discribe);
                        }
                        break;
                    case 4:
                        Console.WriteLine("В каком документе вы хотите изменить удалить?: \n1) Административный\n2)Легальный");
                        int deletevote = int.Parse(Console.ReadLine());
                        if(deletevote == 1)
                        {
                            int id = int.Parse(Console.ReadLine());
                            buisenesLogic.deleteDocument(id, false);
                        }
                        if(deletevote == 2)
                        {
                            int id = int.Parse(Console.ReadLine());
                            buisenesLogic.deleteDocument(id, true);
                        }
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
