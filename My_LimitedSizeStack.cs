 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApplication
{ /*стек ограниченного размера. Этот стек работает как обычный стек, 
    однако при превышении максимального размера удаляет самый глубокий
    элемент в стеке. Таким образом в стеке всегда будет
    ограниченное число элементов.*/
    public class LimitedSizeStack<T>
    {
        LinkedList<T> list = new LinkedList<T>();
        private int limit;
        public int Count { get; private set; }
        public LimitedSizeStack(int limit)
        {
            this.limit = limit;
            Count = 0;
        }

        public void Push(T item)
        {
            if (list.Count==limit)
            { list.RemoveFirst();
                Count--;
            }
            list.AddLast(item);
            Count++;
        }

        public T Pop()
        {
           if(list.Count==0) throw new NotImplementedException();
            T result = list.Last.Value;
            list.RemoveLast();
            Count--;
            return result;
        }
        
    }
}
