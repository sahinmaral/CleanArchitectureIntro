using System.Reflection;

namespace CleanArchitectureIntro.Persistance;

public static class AssemblyReference
{
    public static Assembly Assembly = typeof(AssemblyReference).Assembly;
}
