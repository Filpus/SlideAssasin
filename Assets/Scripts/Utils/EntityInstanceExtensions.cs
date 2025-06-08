using LDtkUnity;

public static class EntityInstanceExtensions
{
    public static int GetInt(this EntityInstance entity, string fieldName)
    {
        foreach (var field in entity.FieldInstances)
        {
            if (field.Identifier == fieldName)
            {
                switch (field.Value)
                {
                    case long longValue:
                        return (int)longValue;
                    case int intValue:
                        return intValue;
                    case double doubleValue:
                        return (int)doubleValue;
                    case float floatValue:
                        return (int)floatValue;
                    case string stringValue when int.TryParse(stringValue, out int parsed):
                        return parsed;
                    default:
                        UnityEngine.Debug.LogWarning($"Field '{fieldName}' found but cannot convert to int. Type: {field.Value?.GetType()}, Value: {field.Value}");
                        break;
                }
            }
        }

        UnityEngine.Debug.LogWarning($"Field '{fieldName}' not found or not an integer.");
        return 0;
    }



    public static string GetString(this EntityInstance entity, string fieldName)
    {
        foreach (var field in entity.FieldInstances)
        {
            if (field.Identifier == fieldName && field.Value is string value)
            {
                return value;
            }
        }

        UnityEngine.Debug.LogWarning($"Field '{fieldName}' not found or not a string.");
        return string.Empty;
    }

    public static bool GetBool(this EntityInstance entity, string fieldName)
    {
        foreach (var field in entity.FieldInstances)
        {
            if (field.Identifier == fieldName && field.Value is bool value)
            {
                return value;
            }
        }

        UnityEngine.Debug.LogWarning($"Field '{fieldName}' not found or not a boolean.");
        return true;
    }

}
