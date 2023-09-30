/**
 * Two Register RPN calculator

Supported operations:
+ - Adds X and Y
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
    >5M (stores 5 into memory)
    >6<enter>
    >L*
    30
    >

Interface:
Show a `>` symbol to indicate prompt
print the answer directly
Enter any digit to push onto the stack
Enter a operator symbol/letter to perform operation
If it is a two register operation and Y is empty, show error
Entering a operation immediately ends input, e.g. to get 30:
    >5<Enter>
    y = 0
    x = 5
    >6*
    y = 0
    x = 30
    ><Enter>
    y = 30
    x = 30
 */
double x = 0;
double y = 0;
const double z = 0; //Always zero with two register version
double m = 0;
string temp = "";
bool hasDecimal = false;

//Create a dictionary with allowed operators
Dictionary<char, Action> operators = new();
operators.Add('+', () =>
{
    x += y;
    y = z;
});
operators.Add('-', () =>
{
    x = y - x;
    y = z;
});
operators.Add('/', () =>
{
    x = y / x;
    y = z;
});
operators.Add('*', () =>
{
    x *= y;
    y = z;
});
operators.Add('%', () =>
{
    x = y % x;
    y = z;
});
operators.Add('D', () =>
{
    x = y;
    y = z;
});

void get()
{
    char c = (char)Console.Read();
    /*
     * Check if input is:
     * - number
     * - period
     * - operator
     * - <Enter>
     * - invlaid
     */
    if (char.IsNumber(c))
    {
        temp += c;
    }
    else if (c == '.')
    {
        if (hasDecimal)
        {
            throw new Exception("Invalid number.");
        }
        hasDecimal = true;
        temp += c;
    }
    else if (operators.ContainsKey(c))
    {
        push();
        operators[c]();
    }
    else if (c == '\n')
    {
        push();
        put();
    }
    else if (c != '\r')
    {
        throw new Exception("oopsie invalid operator teehee");
    }
}
void push()
{
    if (!string.IsNullOrEmpty(temp))
    {
        y = x;
        x = double.Parse(temp);
        temp = "";
    }
}

void put()
{
    Console.Write($"y = {y}\n");
    Console.Write($"x = {x}\n");
}

Console.WriteLine("Hello, World!");
while (true)
{
    get();
}
