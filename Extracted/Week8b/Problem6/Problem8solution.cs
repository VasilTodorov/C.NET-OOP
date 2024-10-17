using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem8  // Problem 8 solution
{
    public interface IUndoable { void Undo(); }
    public class TextBox : IUndoable
    {
        void IUndoable.Undo() => Undo(); // Calls method below
        protected virtual void Undo() => Console.WriteLine($"{(GetType())}.Undo");
    }
    public class RichTextBox : TextBox
    {
        protected override void Undo() => Console.WriteLine($"{(GetType())}.Undo");
    }
    public class MultilineRichTextBox : RichTextBox
    {
        protected override void Undo() => Console.WriteLine($"{(GetType())}.Undo");
        public void PolyTest()
        {
            TextBox r = new RichTextBox();
            ((IUndoable)r).Undo();
            var b = new TextBox();
            //b.IUndoable.Undo();
            IUndoable rtb = new RichTextBox();//Problem8.RichTextBox.Undo
            rtb.Undo();//calls protected overriden method insted of reimplaimantation
            IUndoable tb = this;//Problem8.MultilineRichTextBox.Undo
            tb.Undo();             
        }
        static void Main(string[] args)
        {
            MultilineRichTextBox mtb = new MultilineRichTextBox();
            mtb.PolyTest();

        }
    }
}
     
