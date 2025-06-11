using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using Confuser.Protections.ReferenceProxy;
using XCore.Context;
using XCore.Embed;
using XCore.Protections;
using XF;
using XProtections;
using XProtections.AntiCrack.Globals;
using XProtections.ControlFlow;

public class ControlProj
{
	[Serializable]
	[CompilerGenerated]
	private sealed class xe9
	{
		public static readonly xe9 Hef;

		public static Func<XElement, string> heT;

		static xe9()
		{
			Hef = new xe9();
		}

		internal string QeP(XElement xelement_0)
		{
			return xelement_0.Value;
		}
	}

	public static string path;

	public static string projLocation;

	public static string modLocation;

	public static bool optimizeAsm;

	public static List<Protection> addedProt;

	public static List<string> dlls;

	public static List<string> dlls2;

	public static List<bool> rChecked;

	public static bool sameloc;

	public static bool antiskip;

	public static bool dynamicctor;

	public static bool delegatesref;

	public static bool antiemulate;

	public static bool renamer;

	public static bool cfexrenamer;

	public static bool antiCrack;

	public static bool antiDebug;

	public static bool antiDecombiler;

	public static bool antiDump;

	public static bool antiVM;

	public static bool stringsEncoder;

	public static bool intencoding;

	public static bool antitamper;

	public static bool aggressivecodemutation2;

	public static bool aggressivecodemutation;

	public static bool balancedcodemutation;

	public static bool cflowStrong;

	public static bool cflowPerformance;

	public static bool cflowUltraPerformance;

	public static bool resourcesEncoder;

	public static bool refProxy;

	public static bool controlFlow;

	public static bool codeEncryption;

	public static bool codeVirt;

	public static bool localtofield;

	public static bool integrityCheck;

	[CompilerGenerated]
	private static string ty;

	[CompilerGenerated]
	private static bool lb;

	public static bool RenameEvents;

	public static bool RenameFields;

	public static bool RenameMethods;

	public static bool RenameParameters;

	public static bool RenameProperties;

	public static bool RenameTypes;

	public static bool embeder;

	public static string webhook;

	public static string api;

	public static string exclude;

	public static string customMsg;

	public static bool normal;

	public static bool excludep;

	public static bool silentMsg;

	public static bool bsod;

	public static int R;

	public static int G;

	public static int B;

	public static string Custom
	{
		[CompilerGenerated]
		get
		{
			return ty;
		}
		[CompilerGenerated]
		set
		{
			ty = value;
		}
	}

	public static bool CustomRN
	{
		[CompilerGenerated]
		get
		{
			return lb;
		}
		[CompilerGenerated]
		set
		{
			lb = value;
		}
	}

	public void Save(MemoryStream memoryStream_0)
	{
		SaveFileDialog saveFileDialog = new SaveFileDialog
		{
			FileName = "Saved Project.xml",
			Title = "Save Xerin's Project",
			Filter = "Project File(*.xml)|*.xml"
		};
		if (saveFileDialog.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(saveFileDialog.FileName))
		{
			WriteProject(memoryStream_0);
			File.WriteAllBytes(Path.GetFullPath(saveFileDialog.FileName), memoryStream_0.ToArray());
			memoryStream_0.Flush();
		}
	}

	public bool WriteProject(MemoryStream memoryStream_0)
	{
		try
		{
			using (XmlWriter xmlWriter = XmlWriter.Create(memoryStream_0, new XmlWriterSettings
			{
				Indent = true,
				IndentChars = "\t",
				CloseOutput = true,
				OmitXmlDeclaration = true
			}))
			{
				xmlWriter.WriteStartElement("XerinFuscator");
				xmlWriter.WriteElementString("R", Convert.ToString(R));
				xmlWriter.WriteElementString("G", Convert.ToString(G));
				xmlWriter.WriteElementString("B", Convert.ToString(B));
				if (XContext.sameLocation)
				{
					xmlWriter.WriteElementString("Inside", "True");
				}
				if (optimizeAsm)
				{
					xmlWriter.WriteElementString("Optimize", "True");
				}
				xmlWriter.WriteElementString("File", path);
				xmlWriter.WriteElementString("Webhook", Global.webhookLink);
				xmlWriter.WriteElementString("Exclude", Global.excludeString);
				xmlWriter.WriteElementString("Message", Global.customMessage);
				xmlWriter.WriteElementString("Normal", Global.Normal.ToString());
				xmlWriter.WriteElementString("Silent", Global.Silent.ToString());
				xmlWriter.WriteElementString("Bsod", Global.Bsod.ToString());
				if (ReferenceProxyPhase.isDelegate)
				{
					xmlWriter.WriteElementString("Delegates", "True");
				}
				if (cctorHider.isDynamc)
				{
					xmlWriter.WriteElementString("Dynamic", "True");
				}
				if (ControlFlow.ultraPerformance)
				{
					xmlWriter.WriteElementString("ControlFlow", "Ultra");
				}
				if (ControlFlow.isPerformance)
				{
					xmlWriter.WriteElementString("ControlFlow", "Performance");
				}
				if (ControlFlow.isStrong)
				{
					xmlWriter.WriteElementString("ControlFlow", "Strong");
				}
				if (Embeder.isEmbed)
				{
					xmlWriter.WriteElementString("Embed", "True");
				}
				if (dlls.Count > 0)
				{
					xmlWriter.WriteStartElement("Dlls");
					foreach (string dll in dlls)
					{
						xmlWriter.WriteElementString("Path", dll);
					}
					xmlWriter.WriteEndElement();
				}
				if (addedProt.Count > 0)
				{
					xmlWriter.WriteStartElement("Protections");
					foreach (Protection item in addedProt)
					{
						xmlWriter.WriteElementString("Protection", item.name.Replace(" ", ""));
					}
					xmlWriter.WriteEndElement();
				}
				if (CustomRN)
				{
					xmlWriter.WriteElementString("Custom", "True");
					xmlWriter.WriteElementString("Signature", Custom);
				}
				xmlWriter.WriteStartElement("ROptions");
				if (rChecked[0])
				{
					xmlWriter.WriteElementString("Flag", "Events");
				}
				if (rChecked[1])
				{
					xmlWriter.WriteElementString("Flag", "Fields");
				}
				if (rChecked[2])
				{
					xmlWriter.WriteElementString("Flag", "Methods");
				}
				if (rChecked[3])
				{
					xmlWriter.WriteElementString("Flag", "Parameters");
				}
				if (rChecked[4])
				{
					xmlWriter.WriteElementString("Flag", "Properties");
				}
				if (rChecked[5])
				{
					xmlWriter.WriteElementString("Flag", "Types");
				}
				xmlWriter.WriteEndElement();
				xmlWriter.Flush();
				xmlWriter.Close();
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
		return true;
	}

	public void Load(MemoryStream memoryStream_0)
	{
		try
		{
			memoryStream_0.Position = 0L;
			XElement xElement = XDocument.Load(new StreamReader(memoryStream_0)).Element("XerinFuscator");
			if (xElement == null)
			{
				return;
			}
			R = ((int?)xElement.Element("R")).GetValueOrDefault();
			G = ((int?)xElement.Element("G")).GetValueOrDefault();
			B = ((int?)xElement.Element("B")).GetValueOrDefault();
			sameloc = xElement.Element("Inside")?.Value == "True";
			optimizeAsm = xElement.Element("Optimize")?.Value == "True";
			XElement xElement2 = xElement.Element("File");
			object obj;
			if (xElement2 != null)
			{
				obj = xElement2.Value;
				if (obj != null)
				{
					goto IL_0120;
				}
			}
			else
			{
				obj = null;
			}
			obj = string.Empty;
			goto IL_0120;
			IL_0120:
			path = (string)obj;
			XElement xElement3 = xElement.Element("Webhook");
			object obj2;
			if (xElement3 != null)
			{
				obj2 = xElement3.Value;
				if (obj2 != null)
				{
					goto IL_014b;
				}
			}
			else
			{
				obj2 = null;
			}
			obj2 = string.Empty;
			goto IL_014b;
			IL_07af:
			XElement xElement4 = xElement.Element("ROptions");
			if (xElement4 == null)
			{
				return;
			}
			foreach (XElement item in xElement4.Elements("Flag"))
			{
				switch (item.Value)
				{
				case "Parameters":
					RenameParameters = true;
					break;
				case "Types":
					RenameTypes = true;
					break;
				case "Properties":
					RenameProperties = true;
					break;
				case "Methods":
					RenameMethods = true;
					break;
				case "Fields":
					RenameFields = true;
					break;
				case "Events":
					RenameEvents = true;
					break;
				}
			}
			return;
			IL_014b:
			webhook = (string)obj2;
			XElement xElement5 = xElement.Element("Exclude");
			object obj3;
			if (xElement5 == null)
			{
				obj3 = null;
			}
			else
			{
				obj3 = xElement5.Value;
				if (obj3 != null)
				{
					goto IL_0176;
				}
			}
			obj3 = string.Empty;
			goto IL_0176;
			IL_01a1:
			object obj4;
			customMsg = (string)obj4;
			normal = xElement.Element("Normal")?.Value == "True";
			silentMsg = xElement.Element("Silent")?.Value == "True";
			bsod = xElement.Element("Bsod")?.Value == "True";
			embeder = xElement.Element("Embed")?.Value == "True";
			delegatesref = xElement.Element("Delegates")?.Value == "True";
			dynamicctor = xElement.Element("Dynamic")?.Value == "True";
			cflowUltraPerformance = xElement.Element("ControlFlow")?.Value == "Ultra";
			cflowPerformance = xElement.Element("ControlFlow")?.Value == "Performance";
			cflowStrong = xElement.Element("ControlFlow")?.Value == "Strong";
			XElement xElement6 = xElement.Element("Dlls");
			if (xElement6 != null)
			{
				dlls2.AddRange(from xelement_0 in xElement6.Elements("Path")
					select xelement_0.Value);
			}
			XElement xElement7 = xElement.Element("Protections");
			if (xElement7 != null)
			{
				foreach (XElement item2 in xElement7.Elements("Protection"))
				{
					string value = item2.Value;
					string text = value;
					switch (reW.xeG(text))
					{
					case 1523711135u:
						if (text == "AntiDump")
						{
							antiDump = true;
						}
						break;
					case 1267398499u:
						if (text == "AntiDecompiler")
						{
							antiDecombiler = true;
						}
						break;
					case 937540564u:
						if (text == "IntegrityCheck")
						{
							integrityCheck = true;
						}
						break;
					case 935487561u:
						if (text == "AntiCrack")
						{
							antiCrack = true;
						}
						break;
					case 744098732u:
						if (text == "StringsEncoding")
						{
							stringsEncoder = true;
						}
						break;
					case 653919652u:
						if (text == "AntiVM")
						{
							antiVM = true;
						}
						break;
					case 536015391u:
						if (text == "cfexRenamer")
						{
							cfexrenamer = true;
						}
						break;
					case 525375048u:
						if (text == "AntiTamper")
						{
							antitamper = true;
						}
						break;
					case 166479488u:
						if (text == "Aggressivemutationstage")
						{
							aggressivecodemutation2 = true;
						}
						break;
					case 141419467u:
						if (text == "Localtofield")
						{
							localtofield = true;
						}
						break;
					case 4294718961u:
						if (text == "Strongmutationstage")
						{
							aggressivecodemutation = true;
						}
						break;
					case 4100154100u:
						if (text == "AntiFormSkip")
						{
							antiskip = true;
						}
						break;
					case 3923233766u:
						if (text == "Intsencoding")
						{
							intencoding = true;
						}
						break;
					case 3811496112u:
						if (text == "AntiDebug")
						{
							antiDebug = true;
						}
						break;
					case 3752908018u:
						if (text == "AntiEmulate")
						{
							antiemulate = true;
						}
						break;
					case 3000675781u:
						if (text == "CodeEncryption")
						{
							codeEncryption = true;
						}
						break;
					case 1962877098u:
						if (text == "ControlFlow")
						{
							controlFlow = true;
						}
						break;
					case 1656745491u:
						if (text == "Renamer")
						{
							renamer = true;
						}
						break;
					case 2912229100u:
						if (text == "Performancemutationstage")
						{
							balancedcodemutation = true;
						}
						break;
					case 2417006160u:
						if (text == "MildReferenceProxy")
						{
							refProxy = true;
						}
						break;
					case 2112848739u:
						if (text == "ResourcesEncoding")
						{
							resourcesEncoder = true;
						}
						break;
					}
				}
			}
			object obj5;
			if (xElement.Element("Custom")?.Value == "True")
			{
				CustomRN = true;
				XElement xElement8 = xElement.Element("Signature");
				if (xElement8 == null)
				{
					obj5 = null;
				}
				else
				{
					obj5 = xElement8.Value;
					if (obj5 != null)
					{
						goto IL_07aa;
					}
				}
				obj5 = string.Empty;
				goto IL_07aa;
			}
			goto IL_07af;
			IL_07aa:
			Custom = (string)obj5;
			goto IL_07af;
			IL_0176:
			exclude = (string)obj3;
			XElement xElement9 = xElement.Element("Message");
			if (xElement9 != null)
			{
				obj4 = xElement9.Value;
				if (obj4 != null)
				{
					goto IL_01a1;
				}
			}
			else
			{
				obj4 = null;
			}
			obj4 = string.Empty;
			goto IL_01a1;
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	static ControlProj()
	{
		path = "Empty";
		projLocation = string.Empty;
		modLocation = string.Empty;
		optimizeAsm = false;
		addedProt = ProtectionManager.Protections;
		dlls = Embeder.dlls;
		dlls2 = new List<string>();
		rChecked = new List<bool> { false, false, false, false, false, false };
		sameloc = false;
		antiskip = false;
		dynamicctor = false;
		delegatesref = false;
		antiemulate = false;
		renamer = false;
		cfexrenamer = false;
		antiCrack = false;
		antiDebug = false;
		antiDecombiler = false;
		antiDump = false;
		antiVM = false;
		stringsEncoder = false;
		intencoding = false;
		antitamper = false;
		aggressivecodemutation2 = false;
		aggressivecodemutation = false;
		balancedcodemutation = false;
		cflowStrong = false;
		cflowPerformance = false;
		cflowUltraPerformance = false;
		resourcesEncoder = false;
		refProxy = false;
		controlFlow = false;
		codeEncryption = false;
		codeVirt = false;
		localtofield = false;
		integrityCheck = false;
		RenameEvents = false;
		RenameFields = false;
		RenameMethods = false;
		RenameParameters = false;
		RenameProperties = false;
		RenameTypes = false;
		embeder = false;
		webhook = string.Empty;
		api = string.Empty;
		exclude = string.Empty;
		customMsg = string.Empty;
		normal = false;
		excludep = false;
		silentMsg = false;
		bsod = false;
		R = 41;
		G = 230;
		B = 124;
	}
}
