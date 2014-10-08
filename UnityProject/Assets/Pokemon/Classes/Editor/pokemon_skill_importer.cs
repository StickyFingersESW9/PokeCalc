using UnityEngine;
using System.Collections;
using System.IO;
using UnityEditor;
using System.Xml.Serialization;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

public class pokemon_skill_importer : AssetPostprocessor
{
    private static readonly string filePath = "Assets/Terasurware/ExcelData/pokemon_skill.xls";
    private static readonly string[] sheetNames = { "pokemon_skill", };
    
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
                    var data = (Entity_pokemon_skill)AssetDatabase.LoadAssetAtPath(exportPath, typeof(Entity_pokemon_skill));
                    if (data == null)
                    {
                        data = ScriptableObject.CreateInstance<Entity_pokemon_skill>();
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
                        
                        var p = new Entity_pokemon_skill.Param();
			
					cell = row.GetCell(0); p.SkillID = (int)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(1); p.Name = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(2); p.type = (int)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(3); p.category = (int)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(4); p.power = (int)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(5); p.accuracy = (int)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(6); p.pp = (int)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(7); p.attack_range = (int)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(8); p.direct_flg = (int)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(9); p.description = (cell == null ? "" : cell.StringCellValue);

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
