// Copyright Information
// ==================================
// AutoLot70 - AutoLot.Dal - ICarRepo.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/08/20
// ==================================

namespace AutoLot.Dal.Repos.Interfaces;

public interface ICarRepo : ITemporalTableBaseRepo<Car>
{
    IEnumerable<Car> GetAllBy(int makeId);
    string GetPetName(int id);
    int SetAllDrivableCarsColorAndMakeId(string color, int makeId);
    int DeleteNonDrivableCars();
}
