using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmaceutical_MES
{
    interface ISideBar
    {
        void hideSubMenu();
        void showSubMenu(Panel subMenu);

    }
}
