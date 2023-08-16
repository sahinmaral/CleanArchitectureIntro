using System.Reflection;

namespace CleanArchitectureIntro.Presentation
{
    public static class AssemblyReference
    {
        public static readonly Assembly Assembly = typeof(Assembly).Assembly;
    }
}
