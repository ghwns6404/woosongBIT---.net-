using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal static class WbFile
    {
        private const string ANIMALS_FILENAME = "animals.txt";
        
        //text모드(데이터 기반)
        public static void Write_Animals(List<Animal> animals)
        {
            StreamWriter writer = new StreamWriter(ANIMALS_FILENAME);
            writer.WriteLine(animals.Count);
            for (int i = 0; i < animals.Count; i++)
            {
                Animal animal = (Animal)animals[i];
                string temp = string.Empty;
                temp += animal.Name + "@";
                temp += animal.Age + "@";
                temp += animal.Kind;
               
                writer.WriteLine(temp);
            }
            writer.Dispose();
        }
       
        public static void Read_Animals(List<Animal> animals)
        {
            StreamReader reader = new StreamReader(ANIMALS_FILENAME);
            int size = int.Parse(reader.ReadLine());
            for (int i = 0; i < size; i++)
            {
                string temp = reader.ReadLine();  //번호@이름@잔액@날짜
                string[] sp = temp.Split('@');
                string name = sp[0];
                int age = int.Parse(sp[1]);
                string kind = sp[2];
                animals.Add(new Animal(name, age, kind));
            }
            reader.Dispose();
        }  
    }
}
