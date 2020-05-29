 using System;
using System.Collections.Generic;

namespace TodoApplication
{   

    public class ListModel<TItem>
    {
        public List<TItem> Items { get; }
        public int Limit;
        LimitedSizeStack<(string motion,TItem item,int index) > commandsHistory;
        


        public ListModel(int limit)
        {
            Items = new List<TItem>();
            Limit = limit;
            commandsHistory = new LimitedSizeStack<(string motion, TItem item, int index)>(limit);
           

        }

        public void AddItem(TItem item)
        {

            Items.Add(item);
            commandsHistory.Push(("add",item,(Items.Count-1)));
        }

        public void RemoveItem(int index)
        {
            commandsHistory.Push(("remove", Items[index], index));
            Items.RemoveAt(index);
            

        }

        public bool CanUndo()
        {
            if (commandsHistory.Count > 0)
                return true;
            else
                return false; 
        }

        public void Undo()
        { if (CanUndo())
            {
              var undoCommand = commandsHistory.Pop();
                if (undoCommand.motion == "remove") Items.Insert(undoCommand.index, undoCommand.item);
                else Items.RemoveAt(undoCommand.index);
            }
            else      throw new NotImplementedException();

            
        }

       
    }
}
