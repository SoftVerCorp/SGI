using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace SGI.Helpers
{
    public static class ExportToExcel
    {
        public static void ExportDocument(System.Data.DataTable dt, string title, string path)
        {
            //Microsoft.Office.Interop.Excel.Application excel;
            // Microsoft.Office.Interop.Excel.Workbook worKbooK;
            Microsoft.Office.Interop.Excel.Worksheet worKsheeT;
            Microsoft.Office.Interop.Excel.Range celLrangE;

            Excel.Application excel;
            Excel.Workbook worKbooK;
            Excel.Worksheet xlWorkSheet;

            try
            {
                excel = new Excel.Application();
                worKbooK = excel.Workbooks.Add(Missing.Value);
                xlWorkSheet = (Excel.Worksheet)worKbooK.Worksheets.get_Item(1);


                worKsheeT = (Microsoft.Office.Interop.Excel.Worksheet)worKbooK.ActiveSheet;
                worKsheeT.Name = "Reporte";

                worKsheeT.Range[worKsheeT.Cells[1, 1], worKsheeT.Cells[1, 8]].Merge();
                worKsheeT.Cells[1, 1] = title;
                worKsheeT.Cells.Font.Size = 15;


                int rowcount = 2;

                foreach (DataRow datarow in dt.Rows)
                {
                    rowcount += 1;
                    for (int i = 1; i <= dt.Columns.Count; i++)
                    {

                        if (rowcount == 3)
                        {
                            worKsheeT.Cells[2, i] = dt.Columns[i - 1].ColumnName;
                            worKsheeT.Cells.Font.Color = System.Drawing.Color.Black;

                        }

                        worKsheeT.Cells[rowcount, i] = datarow[i - 1].ToString();

                        if (rowcount > 3)
                        {
                            if (i == dt.Columns.Count)
                            {
                                if (rowcount % 2 == 0)
                                {
                                    celLrangE = worKsheeT.Range[worKsheeT.Cells[rowcount, 1], worKsheeT.Cells[rowcount, dt.Columns.Count]];
                                }

                            }
                        }

                    }

                }

                celLrangE = worKsheeT.Range[worKsheeT.Cells[1, 1], worKsheeT.Cells[rowcount, dt.Columns.Count]];
                celLrangE.EntireColumn.AutoFit();
                Microsoft.Office.Interop.Excel.Borders border = celLrangE.Borders;
                border.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                border.Weight = 2d;

                celLrangE = worKsheeT.Range[worKsheeT.Cells[1, 1], worKsheeT.Cells[2, dt.Columns.Count]];


                worKbooK.SaveAs(path);
                //excel.Visible = true;
              
                worKbooK.Close();
                excel.Quit();
                Process.Start(path);

            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);

            }
            finally
            {
                worKsheeT = null;
                celLrangE = null;
                worKbooK = null;
            }
        }

        public static void ExportDocument2(System.Data.DataTable dt)
        {

            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            string data = string.Empty;

            Excel.Application oXL = null;
            Excel._Workbook oWB = null;
            Excel._Worksheet oSheet = null;

            try
            {
                var x = dt.Columns.Count;

                //xlApp = new Excel.Application();
                //xlWorkBook = xlApp.Workbooks.Add(Missing.Value);
                //xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);


                oXL = new Excel.Application();
                // oXL.Visible = true;

                oWB = (Excel._Workbook)(oXL.Workbooks.Add(Missing.Value));
                oSheet = (Excel._Worksheet)oWB.ActiveSheet;


                DataSet ds = new DataSet();
                ds.Tables.Add(dt);

                //string[] colNames = new string[dt.Columns.Count];

                System.Data.DataTable dtCategories = dt.DefaultView.ToTable(true, "Id");

                foreach (DataRow category in dtCategories.Rows)
                {
                    oSheet = (Excel._Worksheet)oXL.Worksheets.Add();
                    oSheet.Name = category[0].ToString().Replace(" ", "").Replace("  ", "").Replace("/", "").Replace("\\", "").Replace("*", "");

                    string[] colNames = new string[dt.Columns.Count];

                    int col = 0;

                    foreach (DataColumn dc in dt.Columns)
                        colNames[col++] = dc.ColumnName;

                    char lastColumn = (char)(65 + dt.Columns.Count - 1);

                    oSheet.get_Range("A1", lastColumn + "1").Value2 = colNames;
                    oSheet.get_Range("A1", lastColumn + "1").Font.Bold = true;
                    oSheet.get_Range("A1", lastColumn + "1").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;

                    DataRow[] dr = dt.Select(string.Format("Id='{0}'", category[0].ToString()));

                    string[,] rowData = new string[dr.Count<DataRow>(), dt.Columns.Count];

                    int rowCnt = 0;
                    int redRows = 2;
                    foreach (DataRow row in dr)
                    {
                        for (col = 0; col < dt.Columns.Count; col++)
                        {
                            rowData[rowCnt, col] = row[col].ToString();
                        }

                        //if (int.Parse(row["ReorderLevel"].ToString()) < int.Parse(row["UnitsOnOrder"].ToString()))
                        //{
                        //    Range range = oSheet.get_Range("A" + redRows.ToString(), "J" + redRows.ToString());
                        //    range.Cells.Interior.Color = System.Drawing.Color.Red;
                        //}
                        //redRows++;
                        rowCnt++;
                    }
                    oSheet.get_Range("A2", lastColumn + rowCnt.ToString()).Value2 = rowData;
                }

                oXL.Visible = true;
                oXL.UserControl = true;

                oWB.SaveAs(@"c:\Products.xlsx",
                    AccessMode: Excel.XlSaveAsAccessMode.xlExclusive);

                //for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                //{
                //    for (int j = 0; j <= ds.Tables[0].Columns.Count - 1; j++)
                //    {
                //        data = ds.Tables[0].Rows[i].ItemArray[j].ToString();
                //        xlWorkSheet.Cells[i + 1, j + 1] = data;
                //    }
                //}

                //xlWorkBook.SaveAs(@"c:\csharp.net-informations.xls", Excel.XlFileFormat.xlWorkbookNormal, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Excel.XlSaveAsAccessMode.xlExclusive, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                //xlWorkBook.Close(true, Missing.Value, Missing.Value);
                //xlApp.Quit();

                //releaseObject(xlWorkSheet);
                //releaseObject(xlWorkBook);
                //releaseObject(xlApp);

            }
            catch (Exception ex)
            {

            }
            finally
            {
                Marshal.ReleaseComObject(oWB);
            }
        }

        private static void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        }

        public static System.Data.DataTable ListToDataTable<T>(List<T> list)
        {
            System.Data.DataTable dt = new System.Data.DataTable();

            foreach (PropertyInfo info in typeof(T).GetProperties())
            {
                dt.Columns.Add(new DataColumn(info.Name, GetNullableType(info.PropertyType)));
            }
            foreach (T t in list)
            {
                DataRow row = dt.NewRow();
                foreach (PropertyInfo info in typeof(T).GetProperties())
                {
                    if (!IsNullableType(info.PropertyType))
                        row[info.Name] = info.GetValue(t, null);
                    else
                        row[info.Name] = (info.GetValue(t, null) ?? DBNull.Value);
                }
                dt.Rows.Add(row);
            }
            return dt;
        }

        private static Type GetNullableType(Type t)
        {
            Type returnType = t;
            if (t.IsGenericType && t.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                returnType = Nullable.GetUnderlyingType(t);
            }
            return returnType;
        }
        private static bool IsNullableType(Type type)
        {
            return (type == typeof(string) ||
                    type.IsArray ||
                    (type.IsGenericType &&
                     type.GetGenericTypeDefinition().Equals(typeof(Nullable<>))));
        }
    }
}
