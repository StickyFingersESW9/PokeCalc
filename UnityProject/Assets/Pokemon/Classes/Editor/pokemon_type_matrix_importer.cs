using UnityEngine;
using System.Collections;
using System.IO;
using UnityEditor;
using System.Xml.Serialization;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

public class pokemon_type_matrix_importer : AssetPostprocessor
{
    private static readonly string filePath = "Assets/Terasurware/ExcelData/pokemon_type_matrix.xls";
    private static readonly string[] sheetNames = { "pokemon_type_matrix", };
    
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
                    var data = (Entity_pokemon_type_matrix)AssetDatabase.LoadAssetAtPath(exportPath, typeof(Entity_pokemon_type_matrix));
                    if (data == null)
                    {
                        data = ScriptableObject.CreateInstance<Entity_pokemon_type_matrix>();
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
                        
                        var p = new Entity_pokemon_type_matrix.Param();
			
					cell = row.GetCell(0); p.TypeMatrixID = (int)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(1); p.Name = (cell == null ? "" : cell.StringCellValue);
					cell = row.GetCell(2); p.Normal = (float)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(3); p.Fire = (float)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(4); p.Water = (float)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(5); p.Electric = (float)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(6); p.Grass = (float)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(7); p.Psychic = (float)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(8); p.Fighting = (float)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(9); p.Poison = (float)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(10); p.Ground = (float)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(11); p.Flying = (float)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(12); p.Dragon = (float)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(13); p.Bug = (float)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(14); p.Rock = (float)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(15); p.Ghost = (float)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(16); p.Ice = (float)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(17); p.Steel = (float)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(18); p.Dark = (float)(cell == null ? 0 : cell.NumericCellValue);
					cell = row.GetCell(19); p.Fairy = (float)(cell == null ? 0 : cell.NumericCellValue);

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
