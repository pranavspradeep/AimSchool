using System;
using System.Configuration;
using System.Runtime.InteropServices;
using System.Data;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Reflection;

namespace ExcelFormatter
{
	/// <summary>
	/// Summary description for IExcelFormatter.
	/// </summary>
	public interface IExcelFormatter
	{	
		string ErrorMessage{get;set;}
  		bool AssignCellValue(int row, int col, string val);
		bool AssignRowValue(int row, int col, object[] val);
		bool SetRowFont(int row, int numCols, string fontType, int fontSize, bool isBold);
		bool SetRowFont(int row, int numCols, string fontType, int fontSize, bool isBold, bool isUnderlined);
		bool SetHeaderCell(int col, string headerName, decimal colWidth);
		bool SetHeaderCell(int row, int col, string headerName, decimal colWidth);
		bool SetColumnIntegerFormat(int col, string formatString);
		bool SetColumnAlignment(int col, string align);
		bool SaveExcel(string path);
		bool CloseExcel();
		bool SetColumnShrinkToFit(int col);
		bool SetColumnAutofit(int col);
		bool CloseCurrentWorkbook();
		bool AddNewWorkBook();
		bool AddWorkSheet(string sheetName);

	}
}
