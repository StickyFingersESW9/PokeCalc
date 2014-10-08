using UnityEngine;
using System.Collections;
using System.IO;
using UnityEditor;
using System.Xml.Serialization;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

public class pokemon_personality_importer : AssetPostprocessor
{
    private static readonly string filePath = "Assets/Terasurware/ExcelData/pokemon_personality.xls";
    private static readonly string[] sheetNames = { "pokemon_personality", };
    
    static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
    {
        foreach (string asset in importedAssets)
        {
            if (!filePath.Equals(asset))
                continue;

            using (FileStream stream = File.Open (filePath, FileMode.Open, FileAccess.Read))
            {
                var book = new HSSFWorkbook(stream);

                foreach (string sheetName in sheetNames)
                {
                    var exportPath = "Assets/Terasurware/ExcelData/" + sheetName + ".asset";
                    
                    // check scriptable object
                    var data = (Entity_pokemon_personality)AssetDatabase.LoadAssetAtPath(exportPath, typeof(Entity_pokemon_personality));
                    if (data == null)
                    {
                        data = ScriptableObject.CreateInstance<Entity_pokemon_personality>();
                        AssetDatabase.CreateAsset((ScriptableObject)data, exportPath);
                        data.hideFlags = HideFlags.NotEditable;
                    }
                    data.param.Clear();

					// check sheet
                    var sheet = book.GetSheet(sheetName);
                    if (sheet == null)
                    {
                        Debug.LogError("[QuestData] sheet not found:" + sheetName);
                        continue;
                    }

                	// add infomation
                    for (int i=1; i<= sheet.LastRowNum; i++)
                    {
                        IRow row = sheet.GetRow(i);
                        ICell cell = null;
                        
                        var p = new Entity_pokemon_personality.Param();
			
					cell = row.GetCell(0); p.PersonalityID = (int)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(1); p.Name = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(2); p.A = (float)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(3); p.B = (float)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(4); p.C = (float)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(5); p.D = (float)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(6); p.S = (float)(cell == null ? 0 : cell.NumericCellValue);

                        data.param.Add(p);
                    }
                    
                    // save scriptable object
                    ScriptableObject obj = AssetDatabase.LoadAssetAtPath(exportPath, typeof(ScriptableObject)) as ScriptableObject;
                    EditorUtility.SetDirty(obj);
                }
            }

        }
    }
}
