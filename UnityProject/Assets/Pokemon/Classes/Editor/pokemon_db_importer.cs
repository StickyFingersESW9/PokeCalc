using UnityEngine;
using System.Collections;
using System.IO;
using UnityEditor;
using System.Xml.Serialization;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

public class pokemon_db_importer : AssetPostprocessor
{
    private static readonly string filePath = "Assets/Terasurware/ExcelData/pokemon_db.xls";
    private static readonly string[] sheetNames = { "pokemon_db", };
    
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
                    var data = (Entity_pokemon_db)AssetDatabase.LoadAssetAtPath(exportPath, typeof(Entity_pokemon_db));
                    if (data == null)
                    {
                        data = ScriptableObject.CreateInstance<Entity_pokemon_db>();
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
                        
                        var p = new Entity_pokemon_db.Param();
			
					cell = row.GetCell(0); p.PrimaryID = (int)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(1); p.PokemonID = (int)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(2); p.FromID = (int)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(3); p.MegaID = (int)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(4); p.Name = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(5); p.HP = (int)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(6); p.A = (int)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(7); p.B = (int)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(8); p.C = (int)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(9); p.D = (int)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(10); p.S = (int)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(11); p.Type1 = (int)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(12); p.Type2 = (int)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(13); p.Height = (float)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(14); p.Weight = (float)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(15); p.Ability1 = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(16); p.Ability2 = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(17); p.Hidden_ability = (cell == null ? "" : cell.StringCellValue);

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
