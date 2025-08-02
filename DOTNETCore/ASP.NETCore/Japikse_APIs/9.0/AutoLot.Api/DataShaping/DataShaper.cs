// Copyright Information
// ==================================
// AutoLot9 - AutoLot.Api - DataShaper.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/07/13
// ==================================

namespace AutoLot.Api.DataShaping;

public class DataShaper<T> : IDataShaper<T>
{
    private readonly List<PropertyInfo> _properties;
    private readonly PropertyInfo[] _complexProperties;

    public DataShaper()
    {
        _properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance).ToList();
        _complexProperties = _properties.Where(p => p.PropertyType.IsClass && p.PropertyType != typeof(string))
            .ToArray();
    }

    public IEnumerable<ShapedEntity> ShapeData(IEnumerable<T> entities, string fieldsString) =>
        entities.Select(e => ShapeData(e, fieldsString));

    internal PropertyInfo FindProperty(List<PropertyInfo> properties, string fieldName) =>
        properties.FirstOrDefault(p => p.Name.Equals(fieldName.Trim(), StringComparison.OrdinalIgnoreCase));

    internal void SetValue<TI>(TI entity, ExpandoObject shapedObject, PropertyInfo prop)
    {
        ((IDictionary<string, object>)shapedObject).Add(prop.Name, prop.GetValue(entity));
    }

    public void UpdateData(T entity, Dictionary<string, string> values)
    {
        //This only works with strings
        foreach (var entry in values)
        {
            var property = FindProperty(_properties, entry.Key);
            if (property != null)
            {
                property.SetValue(entity, entry.Value);
                continue;
            }

            foreach (var complexProperty in _complexProperties)
            {
                var innerProperties = complexProperty.PropertyType
                    .GetProperties(BindingFlags.Public | BindingFlags.Instance).ToList();
                var innerProperty = FindProperty(innerProperties, entry.Key);
                if (innerProperty != null)
                {
                    var innerValue = complexProperty.GetValue(entity);
                    if (innerValue == null)
                    {
                        innerValue = Activator.CreateInstance(complexProperty.PropertyType);
                        complexProperty.SetValue(entity, innerValue);
                    }

                    innerProperty.SetValue(innerValue, entry.Value);
                    continue;
                }
            }
        }
    }

    public ShapedEntity ShapeData(T entity, string fieldsString)
    {
        var shapedObject = new ExpandoObject();
        var idProp = FindProperty(_properties, nameof(BaseEntity.Id));
        var entityId = (int?)idProp!.GetValue(entity) ?? 0;

        if (string.IsNullOrWhiteSpace(fieldsString))
        {
            foreach (var prop in _properties.Where(x => !x.Name.Equals(idProp!.Name)))
            {
                if (prop.PropertyType.IsClass && prop.PropertyType != typeof(string))
                {
                    var innerProperties = prop.PropertyType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                        .ToList();
                    var innerValue = prop.GetValue(entity);
                    foreach (var innerProp in innerProperties)
                    {
                        SetValue(innerValue, shapedObject, innerProp);
                    }

                    continue;
                }

                SetValue(entity, shapedObject, prop);
            }
        }
        else
        {
            var fields = fieldsString.Split(',', StringSplitOptions.RemoveEmptyEntries);
            foreach (var field in fields)
            {
                var prop = FindProperty(_properties, field.Trim());
                if (prop != null)
                {
                    SetValue(entity, shapedObject, prop);
                }

                foreach (var complexProp in _complexProperties)
                {
                    var innerProperties = complexProp.PropertyType
                        .GetProperties(BindingFlags.Public | BindingFlags.Instance).ToList();
                    var innerProp = FindProperty(innerProperties, field.Trim());
                    if (innerProp == null)
                    {
                        continue;
                    }

                    var innerValue = complexProp.GetValue(entity);
                    SetValue(innerValue, shapedObject, innerProp);
                }
            }
        }

        return new ShapedEntity { Entity = shapedObject, Id = entityId };
    }
}