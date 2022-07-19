using System.Runtime.InteropServices;

public static class DllHelper
{
    [DllImport("GameAssembly.dll", EntryPoint = "il2cpp_gc_get_used_size")]
    public static extern long il2cpp_gc_get_used_size();
    
    [DllImport("GameAssembly.dll", EntryPoint = "il2cpp_gc_get_heap_size")]
    public static extern long il2cpp_gc_get_heap_size();
}
