using System;
using System.Diagnostics;
using System.IO;
using System.ServiceProcess;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Win32;

// Token: 0x02000002 RID: 2
internal class WindowsService
{
	// Token: 0x17000001 RID: 1
	// (get) Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00001050
	// (set) Token: 0x06000002 RID: 2 RVA: 0x00002058 File Offset: 0x00001058
	public string DisplayName { get; private set; }

	// Token: 0x17000002 RID: 2
	// (get) Token: 0x06000003 RID: 3 RVA: 0x00002061 File Offset: 0x00001061
	// (set) Token: 0x06000004 RID: 4 RVA: 0x00002069 File Offset: 0x00001069
	public string Name { get; private set; }

	// Token: 0x17000003 RID: 3
	// (get) Token: 0x06000005 RID: 5 RVA: 0x00002072 File Offset: 0x00001072
	// (set) Token: 0x06000006 RID: 6 RVA: 0x0000207A File Offset: 0x0000107A
	public string CommandLine { get; private set; }

	// Token: 0x17000004 RID: 4
	// (get) Token: 0x06000007 RID: 7 RVA: 0x00002083 File Offset: 0x00001083
	// (set) Token: 0x06000008 RID: 8 RVA: 0x0000208B File Offset: 0x0000108B
	public FileInfo Executable { get; private set; }

	// Token: 0x17000005 RID: 5
	// (get) Token: 0x06000009 RID: 9 RVA: 0x00002094 File Offset: 0x00001094
	// (set) Token: 0x0600000A RID: 10 RVA: 0x0000209C File Offset: 0x0000109C
	public FileVersionInfo Version { get; private set; }

	// Token: 0x0600000B RID: 11 RVA: 0x000020A8 File Offset: 0x000010A8
	public WindowsService(ServiceController service)
	{
		this.Name = service.ServiceName.ToLower();
		this.DisplayName = service.DisplayName.ToLower();
		try
		{
			string name = "SYSTEM\\CurrentControlSet\\Services\\" + service.ServiceName;
			RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(name);
			string name2 = registryKey.GetValue("ImagePath").ToString();
			registryKey.Close();
			this.CommandLine = Environment.ExpandEnvironmentVariables(name2).ToLower();
			Match match = WindowsService._fileNameRegex.Match(this.CommandLine);
			bool success = match.Success;
			if (success)
			{
				string text = match.Groups["name"].Value;
				bool flag = !File.Exists(text);
				if (flag)
				{
					text += ".exe";
				}
				bool flag2 = File.Exists(text);
				if (flag2)
				{
					this.Executable = new FileInfo(text);
					bool flag3 = this.Executable != null && this.Executable.Exists;
					if (flag3)
					{
						this.Version = FileVersionInfo.GetVersionInfo(text);
					}
				}
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x0600000C RID: 12 RVA: 0x000021E0 File Offset: 0x000011E0
	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat("{0} ({1})", this.DisplayName, this.Name);
		bool flag = this.Executable == null;
		if (flag)
		{
			stringBuilder.AppendFormat(" - {0}", this.CommandLine);
		}
		else
		{
			bool flag2 = this.Executable != null;
			if (flag2)
			{
				stringBuilder.AppendFormat(" - {0}", this.Executable.ToString());
			}
			bool flag3 = this.Version != null;
			if (flag3)
			{
				stringBuilder.AppendFormat(" (v{0})", this.Version.ProductVersion);
			}
		}
		return stringBuilder.ToString();
	}

	// Token: 0x04000001 RID: 1
	private static Regex _fileNameRegex = new Regex("((?<name>[A-Z]:.+?(\\.exe|\\Z))|(?:\"(?<name>.+?)\"))", RegexOptions.IgnoreCase);
}
