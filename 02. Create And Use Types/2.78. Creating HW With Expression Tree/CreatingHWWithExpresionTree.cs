using System;
using System.Linq.Expressions;

class CreatingHWWithExpresionTree
{
    static void Main()
    {
        BlockExpression blockExpr = Expression.Block(
        Expression.Call(
        null,
        typeof(Console).GetMethod("Write", new Type[] { typeof(String) }),
        Expression.Constant("Hello ")
            ),
        Expression.Call(
        null,
        typeof(Console).GetMethod("WriteLine", new Type[] { typeof(String) }),
        Expression.Constant("World!")
            )
        );

        Expression.Lambda<Action>(blockExpr).Compile()();
    }
}