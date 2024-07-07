/*
 * Copyright (c) 2022 Winsider Seminars & Solutions, Inc.  All rights reserved.
 *
 * This file is part of System Informer.
 *
 * Authors:
 *
 *     jxy-s
 *
 */

namespace CustomBuildTool
{
    public static class DynData
    {
        private const string FileHeader =
@"/*
 * Copyright (c) 2022 Winsider Seminars & Solutions, Inc.  All rights reserved.
 *
 * This file is part of System Informer.
 *
 * THIS IS AN AUTOGENERATED FILE, DO NOT MODIFY
 *
 */";

        private const string Includes =
@"#include <kphlibbase.h>";

        private const UInt32 Version = 13;

        private static readonly byte[] SessionTokenPublicKey = new byte[]
        {
            0x45, 0x43, 0x53, 0x31, 0x20, 0x00, 0x00, 0x00,
            0x04, 0x4d, 0x12, 0x40, 0x1c, 0xa4, 0x1b, 0xfd,
            0x71, 0xbd, 0x0b, 0x4a, 0x6b, 0x4d, 0xe3, 0xc9,
            0xac, 0xde, 0x26, 0x73, 0x84, 0xe7, 0xb9, 0xf8,
            0x19, 0xd5, 0xd9, 0xb8, 0x7d, 0x7b, 0x7d, 0x0e,
            0x24, 0x4d, 0x69, 0xc6, 0x89, 0xf4, 0x64, 0x4c,
            0xa2, 0x9d, 0x29, 0xb3, 0x5c, 0x9b, 0x4e, 0xf5,
            0x35, 0xaa, 0x87, 0xd3, 0xf1, 0xbb, 0x0a, 0xcd,
            0x0c, 0x6c, 0x55, 0x56, 0x71, 0x8f, 0x79, 0x27,
        };

        private static string DynConfigC =
$@"#define KPH_DYN_CONFIGURATION_VERSION { Version }

#define KPH_DYN_SESSION_TOKEN_PUBLIC_KEY_LENGTH { SessionTokenPublicKey.Length }

#include <pshpack1.h>

typedef struct _KPH_DYN_CONFIGURATION_ARCH
{{
    USHORT EgeGuid;                      // dt nt!_ETW_GUID_ENTRY Guid
    USHORT EpObjectTable;                // dt nt!_EPROCESS ObjectTable
    USHORT EreGuidEntry;                 // dt nt!_ETW_REG_ENTRY GuidEntry
    USHORT HtHandleContentionEvent;      // dt nt!_HANDLE_TABLE HandleContentionEvent
    USHORT OtName;                       // dt nt!_OBJECT_TYPE Name
    USHORT OtIndex;                      // dt nt!_OBJECT_TYPE Index
    USHORT ObDecodeShift;                // dt nt!_HANDLE_TABLE_ENTRY ObjectPointerBits
    USHORT ObAttributesShift;            // dt nt!_HANDLE_TABLE_ENTRY Attributes
    USHORT AlpcCommunicationInfo;        // dt nt!_ALPC_PORT CommunicationInfo
    USHORT AlpcOwnerProcess;             // dt nt!_ALPC_PORT OwnerProcess
    USHORT AlpcConnectionPort;           // dt nt!_ALPC_COMMUNICATION_INFO ConnectionPort
    USHORT AlpcServerCommunicationPort;  // dt nt!_ALPC_COMMUNICATION_INFO ServerCommunicationPort
    USHORT AlpcClientCommunicationPort;  // dt nt!_ALPC_COMMUNICATION_INFO ClientCommunicationPort
    USHORT AlpcHandleTable;              // dt nt!_ALPC_COMMUNICATION_INFO HandleTable
    USHORT AlpcHandleTableLock;          // dt nt!_ALPC_HANDLE_TABLE Lock
    USHORT AlpcAttributes;               // dt nt!_ALPC_PORT PortAttributes
    USHORT AlpcAttributesFlags;          // dt nt!_ALPC_PORT_ATTRIBUTES Flags
    USHORT AlpcPortContext;              // dt nt!_ALPC_PORT PortContext
    USHORT AlpcPortObjectLock;           // dt nt!_ALPC_PORT PortObjectLock
    USHORT AlpcSequenceNo;               // dt nt!_ALPC_PORT SequenceNo
    USHORT AlpcState;                    // dt nt!_ALPC_PORT u1.State
    USHORT KtReadOperationCount;         // dt nt!_KTHREAD ReadOperationCount
    USHORT KtWriteOperationCount;        // dt nt!_KTHREAD WriteOperationCount
    USHORT KtOtherOperationCount;        // dt nt!_KTHREAD OtherOperationCount
    USHORT KtReadTransferCount;          // dt nt!_KTHREAD ReadTransferCount
    USHORT KtWriteTransferCount;         // dt nt!_KTHREAD WriteTransferCount
    USHORT KtOtherTransferCount;         // dt nt!_KTHREAD OtherTransferCount
    USHORT LxPicoProc;                   // uf lxcore!LxpSyscall_GETPID
    USHORT LxPicoProcInfo;               // uf lxcore!LxpSyscall_GETPID
    USHORT LxPicoProcInfoPID;            // uf lxcore!LxpSyscall_GETPID
    USHORT LxPicoThrdInfo;               // uf lxcore!LxpSyscall_GETTID
    USHORT LxPicoThrdInfoTID;            // uf lxcore!LxpSyscall_GETTID
    USHORT MmSectionControlArea;         // dt nt!_SECTION u1.ControlArea
    USHORT MmControlAreaListHead;        // dt nt!_CONTROL_AREA ListHead
    USHORT MmControlAreaLock;            // dt nt!_CONTROL_AREA ControlAreaLock
    USHORT EpSectionObject;              // dt nt!_EPROCESS SectionObject
}} KPH_DYN_CONFIGURATION_ARCH, *PKPH_DYN_CONFIGURATION_ARCH;

typedef struct _KPH_DYN_CONFIGURATION
{{
    USHORT MajorVersion;
    USHORT MinorVersion;
    USHORT BuildNumberMin;
    USHORT RevisionMin;
    USHORT BuildNumberMax;
    USHORT RevisionMax;
    KPH_DYN_CONFIGURATION_ARCH ArchAMD64;
    KPH_DYN_CONFIGURATION_ARCH ArchARM64;
}} KPH_DYN_CONFIGURATION, *PKPH_DYN_CONFIGURATION;

typedef struct _KPH_DYNDATA
{{
    ULONG Version;
    BYTE SessionTokenPublicKey[KPH_DYN_SESSION_TOKEN_PUBLIC_KEY_LENGTH];
    ULONG Count;
    KPH_DYN_CONFIGURATION Configs[ANYSIZE_ARRAY];
}} KPH_DYNDATA, *PKPH_DYNDATA;

#include <poppack.h>";

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct DynConfigArch
        {
            public UInt16 EgeGuid;
            public UInt16 EpObjectTable;
            public UInt16 EreGuidEntry;
            public UInt16 HtHandleContentionEvent;
            public UInt16 OtName;
            public UInt16 OtIndex;
            public UInt16 ObDecodeShift;
            public UInt16 ObAttributesShift;
            public UInt16 AlpcCommunicationInfo;
            public UInt16 AlpcOwnerProcess;
            public UInt16 AlpcConnectionPort;
            public UInt16 AlpcServerCommunicationPort;
            public UInt16 AlpcClientCommunicationPort;
            public UInt16 AlpcHandleTable;
            public UInt16 AlpcHandleTableLock;
            public UInt16 AlpcAttributes;
            public UInt16 AlpcAttributesFlags;
            public UInt16 AlpcPortContext;
            public UInt16 AlpcPortObjectLock;
            public UInt16 AlpcSequenceNo;
            public UInt16 AlpcState;
            public UInt16 KtReadOperationCount;
            public UInt16 KtWriteOperationCount;
            public UInt16 KtOtherOperationCount;
            public UInt16 KtReadTransferCount;
            public UInt16 KtWriteTransferCount;
            public UInt16 KtOtherTransferCount;
            public UInt16 LxPicoProc;
            public UInt16 LxPicoProcInfo;
            public UInt16 LxPicoProcInfoPID;
            public UInt16 LxPicoThrdInfo;
            public UInt16 LxPicoThrdInfoTID;
            public UInt16 MmSectionControlArea;
            public UInt16 MmControlAreaListHead;
            public UInt16 MmControlAreaLock;
            public UInt16 EpSectionObject;

            public DynConfigArch()
            {
                EgeGuid = UInt16.MaxValue;
                EpObjectTable = UInt16.MaxValue;
                EreGuidEntry = UInt16.MaxValue;
                HtHandleContentionEvent = UInt16.MaxValue;
                OtName = UInt16.MaxValue;
                OtIndex = UInt16.MaxValue;
                ObDecodeShift = UInt16.MaxValue;
                ObAttributesShift = UInt16.MaxValue;
                AlpcCommunicationInfo = UInt16.MaxValue;
                AlpcOwnerProcess = UInt16.MaxValue;
                AlpcConnectionPort = UInt16.MaxValue;
                AlpcServerCommunicationPort = UInt16.MaxValue;
                AlpcClientCommunicationPort = UInt16.MaxValue;
                AlpcHandleTable = UInt16.MaxValue;
                AlpcHandleTableLock = UInt16.MaxValue;
                AlpcAttributes = UInt16.MaxValue;
                AlpcAttributesFlags = UInt16.MaxValue;
                AlpcPortContext = UInt16.MaxValue;
                AlpcPortObjectLock = UInt16.MaxValue;
                AlpcSequenceNo = UInt16.MaxValue;
                AlpcState = UInt16.MaxValue;
                KtReadOperationCount = UInt16.MaxValue;
                KtWriteOperationCount = UInt16.MaxValue;
                KtOtherOperationCount = UInt16.MaxValue;
                KtReadTransferCount = UInt16.MaxValue;
                KtWriteTransferCount = UInt16.MaxValue;
                KtOtherTransferCount = UInt16.MaxValue;
                LxPicoProc = UInt16.MaxValue;
                LxPicoProcInfo = UInt16.MaxValue;
                LxPicoProcInfoPID = UInt16.MaxValue;
                LxPicoThrdInfo = UInt16.MaxValue;
                LxPicoThrdInfoTID = UInt16.MaxValue;
                MmSectionControlArea = UInt16.MaxValue;
                MmControlAreaListHead = UInt16.MaxValue;
                MmControlAreaLock = UInt16.MaxValue;
                EpSectionObject = UInt16.MaxValue;
            }
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct DynConfig
        {
            public UInt16 MajorVersion;
            public UInt16 MinorVersion;
            public UInt16 BuildNumberMin;
            public UInt16 RevisionMin;
            public UInt16 BuildNumberMax;
            public UInt16 RevisionMax;

            public DynConfigArch ArchAMD64;
            public DynConfigArch ArchARM64;

            public DynConfig()
            {
                MajorVersion = UInt16.MaxValue;
                MinorVersion = UInt16.MaxValue;
                BuildNumberMin = UInt16.MaxValue;
                RevisionMin = UInt16.MaxValue;
                BuildNumberMax = UInt16.MaxValue;
                RevisionMax = UInt16.MaxValue;
                ArchAMD64 = new DynConfigArch();
                ArchARM64 = new DynConfigArch();
            }
        }

        public static bool Execute(string OutDir, bool StrictChecks)
        {
            string manifestFile = $"{Build.BuildWorkingFolder}\\kphlib\\kphdyn.xml";
            string headerFile = $"{Build.BuildWorkingFolder}\\kphlib\\include\\kphdyn.h";
            string sourceFile = $"{Build.BuildWorkingFolder}\\kphlib\\kphdyn.c";

            GenerateConfig(manifestFile, out byte[] config);

            Utils.WriteAllText(headerFile, GenerateHeader());
            Program.PrintColorMessage($"Dynamic header -> {headerFile}", ConsoleColor.Cyan);
            Utils.WriteAllText(sourceFile, GenerateSource(BytesToString(config)));
            Program.PrintColorMessage($"Dynamic source -> {sourceFile}", ConsoleColor.Cyan);

            if (string.IsNullOrWhiteSpace(OutDir))
                return true;

            string configFile = $"{OutDir}\\ksidyn.bin";

            if (File.Exists(configFile))
                File.Delete(configFile);
            Directory.CreateDirectory(OutDir);
            Utils.WriteAllBytes(configFile, config);
            Program.PrintColorMessage($"Dynamic config -> {configFile}", ConsoleColor.Cyan);
            return Verify.CreateSigFile("kph", configFile, StrictChecks);
        }

        private static string GenerateHeader()
        {
            StringBuilder sb = new StringBuilder(8192);

            sb.AppendLine(FileHeader);
            sb.AppendLine();
            sb.AppendLine("#pragma once");
            sb.AppendLine();
            sb.AppendLine(Includes);
            sb.AppendLine();
            sb.AppendLine(DynConfigC);
            sb.AppendLine();
            sb.AppendLine("#ifdef _WIN64");
            sb.AppendLine("extern CONST BYTE KphDynData[];");
            sb.AppendLine("extern CONST ULONG KphDynDataLength;");
            sb.AppendLine("#endif");

            return sb.ToString();
        }

        private static string GenerateSource(
            string Config
            )
        {
            StringBuilder sb = new StringBuilder(16348);

            sb.AppendLine(FileHeader);
            sb.AppendLine();
            sb.AppendLine(Includes);
            sb.AppendLine();
            sb.AppendLine("#ifdef _WIN64");
            sb.AppendLine("CONST BYTE KphDynData[] =");
            sb.AppendLine("{");
            sb.Append(Config);
            sb.AppendLine("};");
            sb.AppendLine();
            sb.AppendLine("CONST ULONG KphDynDataLength = ARRAYSIZE(KphDynData);");
            sb.AppendLine("#endif");

            return sb.ToString();
        }

        private static void GenerateConfig(
            string ManifestFile,
            out byte[] ConfigBytes
            )
        {
            var xml = new XmlDocument();
            var configs = new List<DynConfig>(10);
            var configNames = new List<string>(10);

            xml.Load(ManifestFile);

            var dyn = xml.SelectSingleNode("/dyn");
            var dataNodes = dyn?.SelectNodes("data");

            foreach (XmlNode data in dataNodes)
            {
                var config = new DynConfig();
                var fieldNodes = data.SelectNodes("field");
                var min = data.Attributes?.GetNamedItem("min")?.Value;
                var max = data.Attributes?.GetNamedItem("max")?.Value;
                string configName = $"{min} - {max}";

                Program.PrintColorMessage(configName, ConsoleColor.Cyan);

                string[] minParts = min.Split('.');
                string[] maxParts = max.Split('.');

                if (minParts.Length != 4 || maxParts.Length != 4)
                {
                    throw new Exception("Invalid version format!");
                }

                config.MajorVersion = UInt16.Parse(minParts[0]);
                config.MinorVersion = UInt16.Parse(minParts[1]);

                if (config.MajorVersion != UInt16.Parse(maxParts[0]))
                {
                    throw new Exception("Major version mismatch!");
                }

                if (config.MinorVersion != UInt16.Parse(maxParts[1]))
                {
                    throw new Exception("Minor version mismatch!");
                }

                config.BuildNumberMin = UInt16.Parse(minParts[2]);
                config.RevisionMin = UInt16.Parse(minParts[3]);
                config.BuildNumberMax = UInt16.Parse(maxParts[2]);
                config.RevisionMax = UInt16.Parse(maxParts[3]);

                foreach (XmlNode field in fieldNodes)
                {
                    var attributes = field.Attributes;
                    var value = attributes?.GetNamedItem("value")?.Value;
                    var name = attributes?.GetNamedItem("name")?.Value;
                    var arch = attributes?.GetNamedItem("arch")?.Value;

                    if (value.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
                    {
                        var hex = value.AsSpan(2, value.Length - 2); // Remove "0x" prefix
                        value = ulong.Parse(hex, NumberStyles.HexNumber, CultureInfo.InvariantCulture).ToString(); // Convert.ToUInt64(value, 16);
                    }
                    else if (value.Equals("-1", StringComparison.OrdinalIgnoreCase))
                    {
                        value = UInt32.MaxValue.ToString();
                    }

                    var member = typeof(DynConfigArch).GetField(name);

                    if (arch == null)
                    {
                        member.SetValueDirect(__makeref(config.ArchAMD64), Convert.ChangeType(value, member.FieldType));
                        member.SetValueDirect(__makeref(config.ArchARM64), Convert.ChangeType(value, member.FieldType));
                    }
                    else if (arch == "amd64")
                    {
                        member.SetValueDirect(__makeref(config.ArchAMD64), Convert.ChangeType(value, member.FieldType));
                    }
                    else if (arch == "arm64")
                    {
                        member.SetValueDirect(__makeref(config.ArchARM64), Convert.ChangeType(value, member.FieldType));
                    }
                    else
                    {
                        throw new Exception($"Invalid architecture ({arch}) specified!");
                    }
                }

                configs.Add(config);
                configNames.Add(configName);
            }

            if (!Validate(configs, configNames))
            {
                throw new Exception("Dynamic configuration is invalid!");
            }

            using (var stream = new MemoryStream())
            using (var writer = new BinaryWriter(stream))
            {
                //
                // Write the version, session token public key, and count first,
                // then the blocks. This conforms with KPH_DYNDATA defined above.
                //
                writer.Write(Version);
                writer.Write(SessionTokenPublicKey);
                writer.Write((uint)configs.Count);
                writer.Write(MemoryMarshal.AsBytes(CollectionsMarshal.AsSpan(configs)));

                ConfigBytes = stream.ToArray();
            }
        }

        private static bool Validate(List<DynConfig> Configs, List<string> ConfigNames)
        {
            bool valid = true;

            for (int i = 0; i < Configs.Count; i++)
            {
                var config = Configs[i];
                var configName = ConfigNames[i];

                if (config.MajorVersion == UInt16.MaxValue)
                {
                    Program.PrintColorMessage($"{configName} - MajorVersion required", ConsoleColor.Red);
                    valid = false;
                }

                if (config.MinorVersion == UInt16.MaxValue)
                {
                    Program.PrintColorMessage($"{configName} - MinorVersion required", ConsoleColor.Red);
                    valid = false;
                }

                if (config.BuildNumberMax < config.BuildNumberMin)
                {
                    Program.PrintColorMessage($"{configName} - BuildNumber range is invalid", ConsoleColor.Red);
                    valid = false;
                }

                if (config.BuildNumberMax == config.BuildNumberMin &&
                    config.RevisionMax < config.RevisionMin)
                {
                    Program.PrintColorMessage($"{configName} - Revision range is invalid", ConsoleColor.Red);
                    valid = false;
                }
            }

            return valid;
        }

        private static string BytesToString(byte[] Buffer)
        {
            using (MemoryStream stream = new MemoryStream(Buffer, false))
            {
                StringBuilder hex = new StringBuilder(64);
                StringBuilder sb = new StringBuilder(8192);
                Span<byte> bytes = stackalloc byte[8];

                while (true)
                {
                    var len = stream.Read(bytes);

                    if (len == 0)
                    {
                        break;
                    }

                    for (int i = 0; i < len; i++)
                    {
                        hex.AppendFormat("0x{0:x2}, ", bytes[i]);
                    }
                    hex.Remove(hex.Length - 1, 1);

                    sb.Append("    ");
                    sb.AppendLine(hex.ToString());
                    hex.Clear();

                    if (len < bytes.Length)
                    {
                        break;
                    }
                }

                return sb.ToString();
            }
        }
    }
}
