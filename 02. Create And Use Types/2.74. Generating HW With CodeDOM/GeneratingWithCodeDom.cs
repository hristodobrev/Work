﻿using Microsoft.CSharp;
using System;
using System.IO;
using System.CodeDom;
using System.CodeDom.Compiler;

class GeneratingWithCodeDom
{
    static void Main()
    {
        CodeCompileUnit compileUnit = new CodeCompileUnit();
        CodeNamespace myNamespace = new CodeNamespace("MyNamespace");
        myNamespace.Imports.Add(new CodeNamespaceImport("System"));
        CodeTypeDeclaration myClass = new CodeTypeDeclaration("MyClass");
        CodeEntryPointMethod start = new CodeEntryPointMethod();
        CodeMethodInvokeExpression cs1 = new CodeMethodInvokeExpression(
            new CodeTypeReferenceExpression("Console"),
            "WriteLine", new CodePrimitiveExpression("Hello World!"));

        compileUnit.Namespaces.Add(myNamespace);
        myNamespace.Types.Add(myClass);
        myClass.Members.Add(start);
        start.Statements.Add(cs1);

        CSharpCodeProvider provider = new CSharpCodeProvider();
        using (StreamWriter sw = new StreamWriter("HelloWorld.cs", false))
        {
            IndentedTextWriter tw = new IndentedTextWriter(sw, "    ");
            provider.GenerateCodeFromCompileUnit(compileUnit, tw,
                new CodeGeneratorOptions());
            tw.Close();
        }
    }
}