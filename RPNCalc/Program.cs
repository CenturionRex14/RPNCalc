
using RPNCalcLib;
/**
using System.Diagnostics.Metrics;
using System;

Supported operations:
+-Adds X and Y
- - Subtracts X from Y
/ - Divides Y by X
* - Multiplies Y by X
% - Gives remainder of Y / X
D - Drops X
S - Swaps X and Y
<Enter> - View current registers if no proceeding char
R - Prints registers
C - Clears registers
P - Push registers up

Stretch Goals:
M - Saves X into memory
V - Prints value in memory
E - Erases memory (set to 0)
L - takes place of memory in operation, e.g.:
> 5M(stores 5 into memory)
> 6 < enter >
> L *
30
>
*/
var calc = new RPNCalc();
Dictionary<char, Action> operators = new();
operators.Add('+', () =>
{
    calc.Add();
});
operators.Add('-', () =>
{
    calc.Subtract();
});
operators.Add('/', () =>
{
    calc.Divide();
});
operators.Add('*', () =>
{
    calc.Multiply();
});
operators.Add('%', () =>
{
    calc.Modulo();
});
operators.Add('D', () =>
{
    calc.Drop();
});
operators.Add('S', () =>
{
    calc.Swap();
});
operators.Add('R', () =>
{
    double x = calc.X;
    double y = calc.Y;
    throw new NotImplementedException();
});
operators.Add('C', () =>
{
    calc.Clear();
});
operators.Add('P', () =>
{
    calc.Push(0);
});
operators.Add('M', () =>
{
    calc.SaveMem();
});
operators.Add('V', () =>
{
    double m = calc.Mem();
    throw new NotImplementedException();
});
operators.Add('E', () =>
{
    throw new NotImplementedException();
});
operators.Add('L', () =>
{
    throw new NotImplementedException();
});