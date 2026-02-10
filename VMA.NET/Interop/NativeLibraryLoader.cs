using System.Reflection;
using System.Runtime.InteropServices;

namespace VMA.NET.Interop;

internal static class NativeLibraryLoader
{
    internal static void Register()
    {
        NativeLibrary.SetDllImportResolver(typeof(NativeLibraryLoader).Assembly, ResolveLibrary);
    }

    private static nint ResolveLibrary(string libraryName, Assembly assembly, DllImportSearchPath? searchPath)
    {
        if (libraryName != "vma")
            return 0;

        string[] candidates;
        if (OperatingSystem.IsWindows())
            candidates = ["vma.dll", "libvma.dll"];
        else if (OperatingSystem.IsMacOS())
            candidates = ["libvma.dylib", "vma.dylib"];
        else
            candidates = ["libvma.so", "vma.so"];

        foreach (var candidate in candidates)
        {
            if (NativeLibrary.TryLoad(candidate, assembly, searchPath, out var handle))
                return handle;
        }

        return 0;
    }
}
