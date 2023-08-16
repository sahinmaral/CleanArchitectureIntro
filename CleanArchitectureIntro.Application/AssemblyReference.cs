using System.Reflection;

namespace CleanArchitectureIntro.Application;

public static class AssemblyReference
{
    public static Assembly Assembly = typeof(AssemblyReference).Assembly;
}
