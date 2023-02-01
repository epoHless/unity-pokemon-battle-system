using CsvHelper.Configuration.Attributes;

[System.Serializable]
public class PokedexEntry
{
    [Name("No")]
    public int No { get; set; }
    
    [Name("Original_Name")]
    public string Original_Name { get; set; }
    
    [Name("Name")]
    public string Name { get; set; }
    
    [Name("Generation")]
    public int Generation { get; set; }
    
    [Name("Height")]
    public string Height { get; set; }
    [Name("Weight")]
    public string Weight { get; set; }
    
    [Name("Type1")]
    public string Type1 { get; set; }
    [Name("Type2")]
    public string Type2 { get; set; }
    
    [Name("Ability1")]
    public string Ability1 { get; set; }
    [Name("Ability2")]
    public string Ability2 { get; set; }
    [Name("Ability_Hidden")]
    public string Ability_Hidden { get; set; }
    
    [Name("Color")]
    public string Color { get; set; }
    
    [Name("Gender_Male")]
    public float Gender_Male { get; set; }
    [Name("Gender_Female")]
    public float Gender_Female { get; set; }
    [Name("Gender_Unknown")]
    public int Gender_Unknown { get; set; }
    
    [Name("Egg_Steps")]
    public int Egg_Steps { get; set; }
    [Name("Egg_Group1")]
    public string Egg_Group1 { get; set; }
    [Name("Egg_Group2")]
    public string Egg_Group2 { get; set; }
    
    [Name("Get_Rate")]
    public int Get_Rate { get; set; }
    
    [Name("Base_Experience")]
    public int Base_Experience { get; set; }
    [Name("Experience_Type")]
    public int Experience_Type { get; set; }
    
    [Name("Category")]
    public string Category { get; set; }
    
    [Name("Mega_Evolution_Flag")]
    public string Mega_Evolution_Flag { get; set; }
    
    [Name("Region_Form")]
    public string Region_Form { get; set; }
    
    [Name("HP")]
    public int HP { get; set; }
    [Name("Attack")]
    public int Attack { get; set; }
    [Name("Defense")]
    public int Defense { get; set; }
    [Name("SP_Attack")]
    public int SP_Attack { get; set; }
    [Name("SP_Defense")]
    public int SP_Defense { get; set; }
    [Name("Speed")]
    public int Speed { get; set; }
    [Name("Total")]
    public int Total { get; set; }
    
    [Name("E_HP")]
    public int E_HP { get; set; }
    [Name("E_Attack")]
    public int E_Attack { get; set; }
    [Name("E_Defense")]
    public int E_Defense { get; set; }
    [Name("E_SP_Attack")]
    public int E_SP_Attack { get; set; }
    [Name("E_SP_Defense")]
    public int E_SP_Defense { get; set; }
    [Name("E_Speed")]
    public int E_Speed { get; set; }
}