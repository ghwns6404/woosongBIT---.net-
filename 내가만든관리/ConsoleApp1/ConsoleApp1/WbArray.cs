using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace ConsoleApp1
{
    class WbArray
    {
        private List<Animal> animals = new List<Animal>();  

        public int Max { get; set; }
        public int Size { get {  return animals.Count; } }
        public Animal this[int index]
        {
            get
            {
                if (index < 0 || index >= Size)
                    throw new IndexOutOfRangeException("인덱스 범위 초과");
                return animals[index];
            }
            set
            {
                if (index < 0 || index >= Size)
                    throw new IndexOutOfRangeException("인덱스 범위 초과");
                animals[index] = value;
            }
        }

        public void Add(Animal value)
        {
            if (value != null)
                animals.Add(value);
        }
        public void RemoveIdx(int idx)
        {
            if (idx < 0 || idx >= Size)
                throw new Exception("잘못된 인덱스 입니다.");
            animals.RemoveAt(idx); // 인덱스로 삭제
        }
        public List<Animal> get_Books()
        {
            return animals;
        }
    }
}
