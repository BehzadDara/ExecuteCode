using System.Dynamic;
using Z.Expressions;

#region sum

// Parameter: Anonymous Type
object result = Eval.Execute("X + Y", new { X = 1, Y = 2 });
Console.WriteLine($"sum result using Anonymous Type is {result}");

// Parameter: Argument Position
result = Eval.Execute("{0} + {1}", 1, 2);

Console.WriteLine($"sum result using Argument Position is {result}");
// Parameter: Class Member
dynamic expandoObject = new ExpandoObject();
expandoObject.X = 1;
expandoObject.Y = 2;
result = Eval.Execute("X + Y", expandoObject);
Console.WriteLine($"sum result using Class Member is {result}");

// Parameter: Dictionary Key
var values = new Dictionary<string, object>() { { "X", 1 }, { "Y", 2 } };
result = Eval.Execute("X + Y", values);
Console.WriteLine($"sum result using Dictionary Key is {result}");

#endregion

#region function

var simpleFunction = "int Simple() { return 1; }";
var simpleFunctionResult = Eval.Execute(simpleFunction);
Console.WriteLine($"multiply function result is {simpleFunctionResult}");

var multiplyFunction = "int Multiply(int x, int y) { return x * y; }";
dynamic multiplyFunctionInput = new ExpandoObject();
multiplyFunctionInput.x = 3;
multiplyFunctionInput.y = 5;
var multiplyFunctionResult = Eval.Execute(multiplyFunction, multiplyFunctionInput);
Console.WriteLine($"multiply function result is {multiplyFunctionResult}");

#endregion