using System;

namespace EF
{
	// Token: 0x02000005 RID: 5
	internal enum BiosCharacteristics : ushort
	{
		// Token: 0x0400000E RID: 14
		Reserved0,
		// Token: 0x0400000F RID: 15
		Reserved1,
		// Token: 0x04000010 RID: 16
		Unknown,
		// Token: 0x04000011 RID: 17
		BIOS_Characteristics_Not_Supported,
		// Token: 0x04000012 RID: 18
		ISA_is_supported,
		// Token: 0x04000013 RID: 19
		MCA_is_supported,
		// Token: 0x04000014 RID: 20
		EISA_is_supported,
		// Token: 0x04000015 RID: 21
		PCI_is_supported,
		// Token: 0x04000016 RID: 22
		PC_Card_PCMCIA_is_supported,
		// Token: 0x04000017 RID: 23
		Plug_and_Play_is_supported,
		// Token: 0x04000018 RID: 24
		APM_is_supported,
		// Token: 0x04000019 RID: 25
		BIOS_is_Upgradeable_Flash,
		// Token: 0x0400001A RID: 26
		BIOS_shadowing_is_allowed,
		// Token: 0x0400001B RID: 27
		VL_VESA_is_supported,
		// Token: 0x0400001C RID: 28
		ESCD_support_is_available,
		// Token: 0x0400001D RID: 29
		Boot_from_CD_is_supported,
		// Token: 0x0400001E RID: 30
		Selectable_Boot_is_supported,
		// Token: 0x0400001F RID: 31
		BIOS_ROM_is_socketed,
		// Token: 0x04000020 RID: 32
		Boot_From_PC_Card_PCMCIA_is_supported,
		// Token: 0x04000021 RID: 33
		EDD_Enhanced_Disk_Drive_Specification_is_supported,
		// Token: 0x04000022 RID: 34
		Int_13h_Japanese_Floppy_for_NEC_9800_is_supported,
		// Token: 0x04000023 RID: 35
		Int_13h_Japanese_Floppy_for_Toshiba_is_supported,
		// Token: 0x04000024 RID: 36
		Int_13h_5_25_360_KB_Floppy_Services_are_supported,
		// Token: 0x04000025 RID: 37
		Int_13h_5_25_1_2MB_Floppy_Services_are_supported,
		// Token: 0x04000026 RID: 38
		Int_13h_3_5_720_KB_Floppy_Services_are_supported,
		// Token: 0x04000027 RID: 39
		Int_13h_3_5_2_88_MB_Floppy_Services_are_supported,
		// Token: 0x04000028 RID: 40
		Int_5h_Print_Screen_Service_is_supported,
		// Token: 0x04000029 RID: 41
		Int_9h_8042_Keyboard_services_are_supported,
		// Token: 0x0400002A RID: 42
		Int_14h_Serial_Services_are_supported,
		// Token: 0x0400002B RID: 43
		Int_17h_printer_services_are_supported,
		// Token: 0x0400002C RID: 44
		Int_10h_CGA_Mono_Video_Services_are_supported,
		// Token: 0x0400002D RID: 45
		NEC_PC_98,
		// Token: 0x0400002E RID: 46
		ACPI_supported,
		// Token: 0x0400002F RID: 47
		USB_Legacy_is_supported,
		// Token: 0x04000030 RID: 48
		AGP_is_supported,
		// Token: 0x04000031 RID: 49
		I2O_boot_is_supported,
		// Token: 0x04000032 RID: 50
		LS120_boot_is_supported,
		// Token: 0x04000033 RID: 51
		ATAPI_ZIP_Drive_boot_is_supported,
		// Token: 0x04000034 RID: 52
		Firewire_1394_boot_is_supported,
		// Token: 0x04000035 RID: 53
		Smart_Battery_supported,
		// Token: 0x04000036 RID: 54
		Reserved_Bios_Vendor_1,
		// Token: 0x04000037 RID: 55
		Reserved_Bios_Vendor_2,
		// Token: 0x04000038 RID: 56
		Reserved_Bios_Vendor_3,
		// Token: 0x04000039 RID: 57
		Reserved_Bios_Vendor_4,
		// Token: 0x0400003A RID: 58
		Reserved_Bios_Vendor_5,
		// Token: 0x0400003B RID: 59
		Reserved_Bios_Vendor_6,
		// Token: 0x0400003C RID: 60
		Reserved_Bios_Vendor_7,
		// Token: 0x0400003D RID: 61
		Reserved_System_Vendor_1 = 48,
		// Token: 0x0400003E RID: 62
		Reserved_System_Vendor_2,
		// Token: 0x0400003F RID: 63
		Reserved_System_Vendor_3,
		// Token: 0x04000040 RID: 64
		Reserved_System_Vendor_4,
		// Token: 0x04000041 RID: 65
		Reserved_System_Vendor_5,
		// Token: 0x04000042 RID: 66
		Reserved_System_Vendor_6,
		// Token: 0x04000043 RID: 67
		Reserved_System_Vendor_7,
		// Token: 0x04000044 RID: 68
		Reserved_System_Vendor_8,
		// Token: 0x04000045 RID: 69
		Reserved_System_Vendor_9,
		// Token: 0x04000046 RID: 70
		Reserved_System_Vendor_10,
		// Token: 0x04000047 RID: 71
		Reserved_System_Vendor_11,
		// Token: 0x04000048 RID: 72
		Reserved_System_Vendor_12,
		// Token: 0x04000049 RID: 73
		Reserved_System_Vendor_13,
		// Token: 0x0400004A RID: 74
		Reserved_System_Vendor_14,
		// Token: 0x0400004B RID: 75
		Reserved_System_Vendor_15,
		// Token: 0x0400004C RID: 76
		Reserved_System_Vendor_16
	}
}
