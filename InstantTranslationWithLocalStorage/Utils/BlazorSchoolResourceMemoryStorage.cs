namespace InstantTranslationWithLocalStorage.Utils;

public class BlazorSchoolResourceMemoryStorage
{
    public Dictionary<KeyValuePair<string, string>, string> JsonComponentResources { get; set; } = new();
}
