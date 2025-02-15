﻿using ProcessManager.Profiling.Models.Process;
using System.Runtime.InteropServices;

namespace ProcessManager.Profiling
{
    internal static class Profiler 
    {
        //
        // ---------------------------------- CONSTANTS ----------------------------------
        //

        public const string DllPath = "C:\\Users\\wixxx\\source\\repos\\ProcessManager\\x64\\Debug\\ProcessManagerLib.dll";

        //
        // ---------------------------------- VOID ----------------------------------
        //

        [DllImport(DllPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern void EnableDebugPrivilages();

        //
        // ---------------------------------- METHODS ----------------------------------
        //

        /// <summary>
        /// Converts pointer to UTF-8 encoded string.
        /// </summary>
        /// <param name="ptr">Pointer to the int.</param>
        /// <returns>If conversion was successfull returns the string; else returns "N/A".</returns>
        public static string ToString(IntPtr ptr)
        {
            try
            {
                return Marshal.PtrToStringUTF8(ptr) ?? "N/A"; 
            }
            catch { return "N/A"; }
        }

        /// <summary>
        /// Converts pointer to Int32.
        /// </summary>
        /// <param name="ptr">Pointer to the char array.</param>
        /// <returns>If conversion was successfull returns the Int32; else returns null.</returns>
        public static Int32? ToInt32(IntPtr ptr)
        {
            try
            {
                return Marshal.PtrToStructure<Int32>(ptr);
            }
            catch { return null; }
        }

        /// <summary>
        /// Converts pointer to Int64.
        /// </summary>
        /// <param name="ptr">Pointer to the char array.</param>
        /// <returns>If conversion was successfull returns the Int64; else returns null.</returns>
        public static Int64? ToInt64(IntPtr ptr)
        {
            try
            {
                return Marshal.PtrToStructure<Int64>(ptr);
            }
            catch { return null; }
        }

        /// <summary>
        /// Converts pointer to UInt32.
        /// </summary>
        /// <param name="ptr">Pointer to the char array.</param>
        /// <returns>If conversion was successfull returns the Int32; else returns null.</returns>
        public static UInt32? ToUInt32(IntPtr ptr)
        {
            try
            {
                return Marshal.PtrToStructure<UInt32>(ptr);
            }
            catch { return null; }
        }

        /// <summary>
        /// Converts pointer to UInt64.
        /// </summary>
        /// <param name="ptr">Pointer to the int.</param>
        /// <returns>If conversion was successfull returns the Int64; else returns null.</returns>
        public static UInt64? ToUInt64(IntPtr ptr)
        {
            try
            {
                return Marshal.PtrToStructure<UInt64>(ptr);
            }
            catch { return null; }
        }

        /// <summary>
        /// Converts pointer to Double.
        /// </summary>
        /// <param name="ptr">Pointer to the int.</param>
        /// <returns>If conversion was successfull returns the Double; else returns null.</returns>
        public static Double? ToDouble(IntPtr ptr)
        {
            try
            {
                return Marshal.PtrToStructure<Double>(ptr);
            }
            catch { return null; }
        }

        /// <summary>
        /// Converts <see cref="FILETIME"/> structure to DateTime.
        /// </summary>
        /// <param name="time"><see cref="FILETIME"/> structure.</param>
        /// <param name="utc">UTC conversion.</param>
        /// <returns>If conversion was successfull returns the DateTime; else returns null.</returns>
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

        /// <summary>
        /// Converts pointer to <typeparamref name="TStruct"/>.
        /// </summary>
        /// <param name="ptr">Pointer to the structure.</param>
        /// <returns>If conversion was successfull returns the <typeparamref name="TStruct"/>; else returns null.</returns>
        public static TStruct? ToStruct<TStruct>(IntPtr ptr)
        {
            try
            {
                return Marshal.PtrToStructure<TStruct>(ptr);
            }
            catch { return default; }
        }

        /// <summary>
        /// Converts pointer to value array.
        /// </summary>
        /// <param name="ptr">Pointer to the <typeparamref name="TValue"/> array.</param>
        /// <param name="size">Size of the array.</param>
        /// <returns>If conversion was successfull returns the <typeparamref name="TValue[]"/>; else returns empty array.</returns>
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
