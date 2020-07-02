using System;
using System.Collections.Generic;
using System.Text;

namespace RentNScoot
{
    public interface IDialog
    {
        void Show();
        void Hide();
        void Dispose();
    }
}
