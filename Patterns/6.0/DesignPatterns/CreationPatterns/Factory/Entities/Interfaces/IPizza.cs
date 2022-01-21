// Copyright Information
// =============================
// CreationalPatterns - IPizza.cs
// All samples copyright Philip Japikse 
// http://www.skimedic.com 20/06/2017
// See License.txt for more information
// =============================

namespace CreationPatterns.Factory.Entities.Interfaces;

public interface IPizza
{
    IList<string> Toppings { get; init; }
    DoughTypeEnum Dough { get; init; }
    public void Prepare();
    public void Bake();
    public void Cut();
    public void Box();
}