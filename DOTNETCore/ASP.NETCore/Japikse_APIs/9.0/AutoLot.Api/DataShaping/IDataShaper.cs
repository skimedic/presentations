// Copyright Information
// ==================================
// AutoLot9 - AutoLot.Api - IDataShaper.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2025/07/13
// ==================================

namespace AutoLot.Api.DataShaping;

public interface IDataShaper<T>
{
    IEnumerable<ShapedEntity> ShapeData(IEnumerable<T> entities, string fieldsString);
    ShapedEntity ShapeData(T entity, string fieldsString);
    void UpdateData(T entity, Dictionary<string, string> values);
}