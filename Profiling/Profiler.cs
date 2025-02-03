using ProcessManager.Profiling.Models.Process;
using System.Runtime.InteropServices;

namespace ProcessManager.Profiling
{
    internal static class Profiler 
    {
        public const string DllPath = "C:\\Users\\wixxx\\source\\repos\\ProcessManager\\x64\\Debug\\ProcessManagerLib.dll";

        //
        // ---------------------------------- VOID ----------------------------------
        //

        [DllImport(DllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern void EnableDebugPrivilages();

        public static string ToString(IntPtr ptr)
        {
            try
            {
                return Marshal.PtrToStringUTF8(ptr) ?? "N/A";
            }
            catch { return "N/A"; }
        }
        public static Int32? ToInt32(IntPtr ptr)
        {
            try
            {
                return Marshal.ReadInt32(ptr);
            }
            catch { return null; }
        }
        public static Int64? ToInt64(IntPtr ptr)
        {
            try
            {
                return Marshal.ReadInt64(ptr);
            }
            catch { return null; }
        }
        public static DateTime? ToDateTime(FILETIME time, bool utc = false)
        {
            try
            {
                long fileTimeValue = (long)((ulong)time.dwHighDateTime << 32 | time.dwLowDateTime);

                if (utc)
                    return DateTime.FromFileTimeUtc(fileTimeValue);
                else
                    return DateTime.FromFileTime(fileTimeValue);
            }
            catch { return null; }
        }
        public static TStruct? ToStruct<TStruct>(IntPtr ptr)
        {
            try
            {
                return Marshal.PtrToStructure<TStruct>(ptr);
            }
            catch { return default; }
        }
        public static TValue?[] ToArray<TValue>(IntPtr ptr, uint size)
        {
            try
            {
                TValue?[] values = new TValue[size];

                for (int i = 0; i < values.Length; i++)
                {
                    IntPtr arrPtr = ptr + (i * Marshal.SizeOf<TValue>());
                    values[i] = Marshal.PtrToStructure<TValue>(arrPtr);
                }

                return values;
            }
            catch { return []; }
        }
    }
}
