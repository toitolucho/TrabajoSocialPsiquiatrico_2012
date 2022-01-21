using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SISTEMA_SEGUIMIENTO_SOCIAL.Utilidades.Componentes
{
    class DataGridViewSort : DataGrid
    {
        //sort a column by its index

        public void SortColumn(int columnIndex)
        {
            if (this.DataSource != null &&
              ((System.Collections.IList)this.DataSource).Count > 0)
            {
                //discover the TYPE of underlying objects

                Type sourceType = ((System.Collections.IList)this.DataSource)[0].GetType();

                //get the PropertyDescriptor for a sorted column

                //assume TableStyles[0] is used for our datagrid... (change it if necessary)

                System.ComponentModel.PropertyDescriptor pd =
                 this.TableStyles[0].GridColumnStyles[columnIndex].PropertyDescriptor;

                //if the above line of code didn't work try to get a propertydescriptor

                // via MappingName

                if (pd == null)
                {
                    System.ComponentModel.PropertyDescriptorCollection pdc =
                     System.ComponentModel.TypeDescriptor.GetProperties(sourceType);
                    pd =
                     pdc.Find(this.TableStyles[0].GridColumnStyles[columnIndex].MappingName,
                                                                                      false);
                }

                //now invoke ColumnHeaderClicked method using system.reflection tools

                System.Reflection.MethodInfo mi =
                 typeof(System.Windows.Forms.DataGrid).GetMethod("ColumnHeaderClicked",
                  System.Reflection.BindingFlags.Instance |
                  System.Reflection.BindingFlags.NonPublic);
                mi.Invoke(this, new object[] { pd });
            }
        }
    }
}
