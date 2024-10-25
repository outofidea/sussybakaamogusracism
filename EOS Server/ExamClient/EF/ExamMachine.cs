using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.ServiceProcess;

namespace EF
{
	// Token: 0x02000009 RID: 9
	public class ExamMachine
	{
		// Token: 0x06000034 RID: 52 RVA: 0x000028F4 File Offset: 0x000018F4
		public static bool Assert()
		{
			string text = ExamMachine.ExecuteCommandAsAdmin("systeminfo | find \"System\"");
			return text.ToString().ToUpper().Contains("VIRTUAL") || text.ToString().ToUpper().Contains("VMWARE");
		}

		// Token: 0x06000035 RID: 53 RVA: 0x0000294C File Offset: 0x0000194C
		public static bool Assert(out string name, out string debug)
		{
			IVirtualEnvironment[] source = new IVirtualEnvironment[]
			{
				new VmWarePlayer(),
				new HyperVMachine(),
				new QEmuMachine(),
				new VirtualBoxMachine()
			};
			ComputerSystem _computer = ExamMachine.Create<ComputerSystem>("Win32_ComputerSystem");
			BIOS _bios = ExamMachine.Create<BIOS>("Win32_BIOS");
			MotherboardDevice arg = ExamMachine.Create<MotherboardDevice>("Win32_MotherboardDevice");
			IEnumerable<PnPEntity> _devices = ExamMachine.CreateList<PnPEntity>("Win32_PnPEntity");
			IEnumerable<DiskDrive> _disks = ExamMachine.CreateList<DiskDrive>("Win32_DiskDrive");
			IEnumerable<WindowsService> _services = ExamMachine.GetWindowsServices();
			debug = "\r\n";
			debug += "MOTHERBOARD INFO\r\n";
			debug += "================\r\n";
			debug = debug + arg + "\r\n";
			debug += "\r\n";
			debug += "BIOS INFO\r\n";
			debug += "=========\r\n";
			debug = debug + _bios + "\r\n";
			debug += "\r\n";
			debug += "COMPUTER INFO\r\n";
			debug += "=============\r\n";
			debug = debug + _computer + "\r\n";
			debug += "\r\n";
			debug += "DEVICES INFO\r\n";
			debug += "============\r\n";
			foreach (PnPEntity arg2 in _devices)
			{
				debug = debug + arg2 + "\r\n";
			}
			debug += "\r\n";
			debug += "HARD DRIVES INFO\r\n";
			debug += "================\r\n";
			foreach (DiskDrive arg3 in _disks)
			{
				debug = debug + arg3 + "\r\n";
			}
			debug += "\r\n";
			debug += "WINDOWS SERVICES\r\n";
			debug += "================\r\n";
			foreach (WindowsService arg4 in _services)
			{
				debug = debug + arg4 + "\r\n";
			}
			debug += "\r\n";
			string[] processes = (from p in Process.GetProcesses()
			select p.ProcessName.ToLower() into p
			orderby p
			select p).ToArray<string>();
			IVirtualEnvironment virtualEnvironment = source.FirstOrDefault((IVirtualEnvironment c) => c.Assert(_computer, _bios, _disks, _devices, processes, _services));
			bool flag = virtualEnvironment != null;
			name = (flag ? virtualEnvironment.Name : null);
			return flag;
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00002C8C File Offset: 0x00001C8C
		private static IEnumerable<WindowsService> GetWindowsServices()
		{
			return (from s in ServiceController.GetServices()
			select new WindowsService(s) into s
			orderby s.Name
			select s).ToArray<WindowsService>();
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00002CF0 File Offset: 0x00001CF0
		private static T Create<T>(string key)
		{
			ManagementClass managementClass = new ManagementClass(key);
			using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = managementClass.GetInstances().GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					ManagementBaseObject managementBaseObject = enumerator.Current;
					return (T)((object)Activator.CreateInstance(typeof(T), new object[]
					{
						managementBaseObject
					}));
				}
			}
			return default(T);
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00002D70 File Offset: 0x00001D70
		private static List<T> CreateList<T>(string key)
		{
			ManagementClass managementClass = new ManagementClass(key);
			List<T> list = new List<T>();
			foreach (ManagementBaseObject managementBaseObject in managementClass.GetInstances())
			{
				list.Add((T)((object)Activator.CreateInstance(typeof(T), new object[]
				{
					managementBaseObject
				})));
			}
			return list;
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00002DF4 File Offset: 0x00001DF4
		private static string ExecuteCommandAsAdmin(string command)
		{
			string arguments = "/c " + command;
			ProcessStartInfo processStartInfo = new ProcessStartInfo("cmd", arguments);
			processStartInfo.RedirectStandardOutput = true;
			processStartInfo.UseShellExecute = false;
			processStartInfo.CreateNoWindow = true;
			Process process = new Process();
			process.StartInfo = processStartInfo;
			process.Start();
			string result = process.StandardOutput.ReadToEnd();
			process.Close();
			return result;
		}
	}
}
