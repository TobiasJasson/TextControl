using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.LocalWidget
{
       public static class Navigator
       {
           public static MainScreen GetMain(Control control)
           {
               if (control == null) return null;

               if (control is MainScreen ms)
                   return ms;

               Control current = control;
               while (current != null)
               {
                   if (current is MainScreen ms2)
                       return ms2;

                   current = current.Parent;
               }

               Form form = control.FindForm();
               if (form != null)
               {
                   if (form is MainScreen ms3)
                       return ms3;

                   if (form.Owner is MainScreen ms4)
                       return ms4;

                   if (form.MdiParent is MainScreen ms5)
                       return ms5;
               }

               return null;
           }
       }
    }
