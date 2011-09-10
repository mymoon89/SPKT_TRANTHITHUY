using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PaintCSharp2010.GraphicsObject;

namespace PaintCSharp2010.Commands
{
    /// <summary>
    /// Định nghĩa lớp cơ sở Command để dùng cho hàm Undo và Redo
    /// </summary>
    public abstract class Command
    {
        // Xây dựng hàm public abstract void Undo(GraphicsList list)
        // Hàm này dùng cho việc thực hiện thao tác Undo.
        public abstract void Undo(LayersList list);
        // Xây dựng hàm public abstract void Redo(GraphicsList list)
        // Hàm này dùng cho việc thực hiện thao tác Redo.
        public abstract void Redo(LayersList list);
        //Trong các lớp kế thừa sẽ có các thành phần chứa thông tin đầy đủ
        //để thực hiện Undo và Redo cho từng lớp cụ thể

    }
}
