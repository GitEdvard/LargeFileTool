using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace Molmed.LargeFileTool.Data
{
    public class ConfigurationManager
    {
        private const String MyConfigurationFileName = "LFTConfig.xml";
        //private static StringDictionary MyItems;

        public static void SaveCopyPasteColumnSetting(string name, string columnDelimiterSourceFile,
            string columnDelimiterDestinationFile, string columnOrderString)
        {
            StringDictionary items = new StringDictionary();
            DataSet dSet;
            DataRow dataRow;
            string configFilePath;
            dSet = CreateSerializeDataSet();
            configFilePath = System.Windows.Forms.Application.StartupPath + "\\" + MyConfigurationFileName;
            if (File.Exists(configFilePath))
            {
                dSet.ReadXml(configFilePath, XmlReadMode.IgnoreSchema);
            }
            dataRow = dSet.Tables[CopyPasteColumnSettingData.TABLE].NewRow();

            dataRow[CopyPasteColumnSettingData.NAME] = name;
            dataRow[CopyPasteColumnSettingData.COLUMN_DELIMITER_SOURCE_FILE] = columnDelimiterSourceFile;
            dataRow[CopyPasteColumnSettingData.COLUMN_DELIMITER_DESTINATION_FILE] = columnDelimiterDestinationFile;
            dataRow[CopyPasteColumnSettingData.COLUMN_ORDER_STRING] = columnOrderString;

            dSet.Tables[CopyPasteColumnSettingData.TABLE].Rows.Add(dataRow);
            dSet.WriteXml(configFilePath, XmlWriteMode.IgnoreSchema);
        }

        private static DataSet CreateSerializeDataSet()
        {
            DataSet dSet;
            DataTable table;

            table = new DataTable(CopyPasteColumnSettingData.TABLE);
            table.Columns.Add(CopyPasteColumnSettingData.NAME, typeof(System.String));
            table.Columns.Add(CopyPasteColumnSettingData.COLUMN_DELIMITER_SOURCE_FILE, typeof(System.String));
            table.Columns.Add(CopyPasteColumnSettingData.COLUMN_DELIMITER_DESTINATION_FILE, typeof(System.String));
            table.Columns.Add(CopyPasteColumnSettingData.COLUMN_ORDER_STRING, typeof(System.String));

            dSet = new DataSet("Configuration");
            dSet.Tables.Add(table);

            return dSet;
        }

    }
}
