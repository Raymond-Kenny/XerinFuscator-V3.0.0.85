using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using XVM.Core.Services;

namespace XF
{
	internal class c2f
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class Ioo
		{
			public static readonly Ioo AoZ;

			public static Func<char, string> moT;

			static Ioo()
			{
				AoZ = new Ioo();
			}

			internal string uol(char char_0)
			{
				return $"{Convert.ToInt32(char_0):X2}";
			}
		}

		private ModuleDef G2z;

		private readonly Dictionary<string, string> nK4 = new Dictionary<string, string>();

		private static RandomGenerator RKe;

		public c2f(ModuleDef moduleDef_0 = null)
		{
			G2z = moduleDef_0;
			nK4 = new Dictionary<string, string>();
			RKe = new RandomGenerator(32);
		}

		public string i2i(string string_0)
		{
			if (!nK4.TryGetValue(string_0, out var value))
			{
				return nK4[string_0] = G2J();
			}
			return value;
		}

		private string G2J()
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < 4; i++)
			{
				char value = Convert.ToChar(Convert.ToInt32(Math.Floor(32m + (decimal)RKe.method_1(122) - 32m)));
				stringBuilder.Append(value);
			}
			return string.Join(string.Empty, (from char_0 in stringBuilder.ToString()
				select $"{Convert.ToInt32(char_0):X2}").ToArray());
		}

		public void d28()
		{
			foreach (TypeDef type in G2z.GetTypes())
			{
				if (!(type.Name == TNd.Q29))
				{
					if (type.FullName == "System.Runtime.ExceptionServices.HandleProcessCorruptedStateExceptionsAttribute" || type.FullName == "System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute")
					{
						continue;
					}
					type.Namespace = string.Empty;
					type.Name = i2i(type.Name);
					foreach (GenericParam genericParameter in type.GenericParameters)
					{
						genericParameter.Name = i2i(genericParameter.Name);
					}
					bool flag = type.BaseType != null && (type.BaseType.FullName == "System.Delegate" || type.BaseType.FullName == "System.MulticastDelegate");
					foreach (MethodDef method in type.Methods)
					{
						if (method.HasBody)
						{
							foreach (Instruction instruction in method.Body.Instructions)
							{
								if (!(instruction.Operand is MemberRef memberRef))
								{
									continue;
								}
								TypeDef typeDef = memberRef.DeclaringType.ResolveTypeDef();
								if (memberRef.IsMethodRef && typeDef != null)
								{
									MethodDef methodDef = typeDef.ResolveMethod(memberRef);
									if (methodDef != null && methodDef.IsRuntimeSpecialName)
									{
										typeDef = null;
									}
								}
								if (typeDef != null && typeDef.Module == G2z)
								{
									memberRef.Name = i2i(memberRef.Name);
								}
							}
						}
						foreach (Parameter parameter in method.Parameters)
						{
							parameter.Name = i2i(parameter.Name);
						}
						if (!(method.IsRuntimeSpecialName || flag))
						{
							method.Name = i2i(method.Name);
						}
					}
					for (int i = 0; i < type.Fields.Count; i++)
					{
						FieldDef fieldDef = type.Fields[i];
						if (!fieldDef.IsLiteral)
						{
							if (!fieldDef.IsRuntimeSpecialName)
							{
								fieldDef.Name = i2i(fieldDef.Name);
							}
						}
						else
						{
							type.Fields.RemoveAt(i--);
						}
					}
					type.Properties.Clear();
					type.Events.Clear();
					continue;
				}
				type.Namespace = string.Empty;
				type.Name = i2i(type.Name);
				TNd.Q29 = type.Name;
				foreach (MethodDef method2 in type.Methods)
				{
					if (method2.Name == TNd.Y2G)
					{
						method2.Name = i2i(method2.Name);
						TNd.Y2G = method2.Name;
					}
					else if (!(method2.Name == TNd.Y2G))
					{
						if (!(method2.Name == TNd.O2q))
						{
							if (!(method2.Name == TNd.a2M))
							{
								if (method2.Name == TNd.T2A)
								{
									method2.Name = i2i(method2.Name);
									TNd.T2A = method2.Name;
								}
							}
							else
							{
								method2.Name = i2i(method2.Name);
								TNd.a2M = method2.Name;
							}
						}
						else
						{
							method2.Name = i2i(method2.Name);
							TNd.O2q = method2.Name;
						}
					}
					else
					{
						method2.Name = i2i(method2.Name);
						TNd.Y2G = method2.Name;
					}
					foreach (Parameter parameter2 in method2.Parameters)
					{
						parameter2.Name = i2i(parameter2.Name);
					}
				}
				foreach (FieldDef field in type.Fields)
				{
					string text = field.Name;
					string text2 = text;
					switch (PLe.OLu(text2))
					{
					case 715663743u:
						if (text2 == "IntKey20")
						{
							field.Name = i2i(field.Name);
							XjJ.BO0[field.Name] = 20;
						}
						break;
					case 585266689u:
						if (text2 == "LdstrKey19")
						{
							field.Name = i2i(field.Name);
							XjJ.yOE[field.Name] = Convert.ToString(19);
						}
						break;
					case 568489070u:
						if (text2 == "LdstrKey18")
						{
							field.Name = i2i(field.Name);
							XjJ.yOE[field.Name] = Convert.ToString(18);
						}
						break;
					case 518156213u:
						if (text2 == "LdstrKey15")
						{
							field.Name = i2i(field.Name);
							XjJ.yOE[field.Name] = Convert.ToString(15);
						}
						break;
					case 501378594u:
						if (text2 == "LdstrKey14")
						{
							field.Name = i2i(field.Name);
							XjJ.yOE[field.Name] = Convert.ToString(14);
						}
						break;
					case 484600975u:
						if (text2 == "LdstrKey17")
						{
							field.Name = i2i(field.Name);
							XjJ.yOE[field.Name] = Convert.ToString(17);
						}
						break;
					case 467823356u:
						if (text2 == "LdstrKey16")
						{
							field.Name = i2i(field.Name);
							XjJ.yOE[field.Name] = Convert.ToString(16);
						}
						break;
					case 451045737u:
						if (text2 == "LdstrKey11")
						{
							field.Name = i2i(field.Name);
							XjJ.yOE[field.Name] = Convert.ToString(11);
						}
						break;
					case 434268118u:
						if (text2 == "LdstrKey10")
						{
							field.Name = i2i(field.Name);
							XjJ.yOE[field.Name] = Convert.ToString(10);
						}
						break;
					case 423290183u:
						if (text2 == "IntKey8")
						{
							field.Name = i2i(field.Name);
							XjJ.BO0[field.Name] = 8;
						}
						break;
					case 870339117u:
						if (text2 == "LdstrKey20")
						{
							field.Name = i2i(field.Name);
							XjJ.yOE[field.Name] = Convert.ToString(20);
						}
						break;
					case 857671090u:
						if (text2 == "ULongKey3")
						{
							field.Name = i2i(field.Name);
							XjJ.vOW[field.Name] = 3;
						}
						break;
					case 840893471u:
						if (text2 == "ULongKey0")
						{
							field.Name = i2i(field.Name);
							XjJ.vOW[field.Name] = 0;
						}
						break;
					case 975114423u:
						if (text2 == "ULongKey8")
						{
							field.Name = i2i(field.Name);
							XjJ.vOW[field.Name] = 8;
						}
						break;
					case 958336804u:
						if (text2 == "ULongKey9")
						{
							field.Name = i2i(field.Name);
							XjJ.vOW[field.Name] = 9;
						}
						break;
					case 874448709u:
						if (text2 == "ULongKey2")
						{
							field.Name = i2i(field.Name);
							XjJ.vOW[field.Name] = 2;
						}
						break;
					case 773782995u:
						if (text2 == "ULongKey4")
						{
							field.Name = i2i(field.Name);
							XjJ.vOW[field.Name] = 4;
						}
						break;
					case 757005376u:
						if (text2 == "ULongKey5")
						{
							field.Name = i2i(field.Name);
							XjJ.vOW[field.Name] = 5;
						}
						break;
					case 824115852u:
						if (text2 == "ULongKey1")
						{
							field.Name = i2i(field.Name);
							XjJ.vOW[field.Name] = 1;
						}
						break;
					case 807338233u:
						if (text2 == "ULongKey6")
						{
							field.Name = i2i(field.Name);
							XjJ.vOW[field.Name] = 6;
						}
						break;
					case 790560614u:
						if (text2 == "ULongKey7")
						{
							field.Name = i2i(field.Name);
							XjJ.vOW[field.Name] = 7;
						}
						break;
					case 417490499u:
						if (text2 == "LdstrKey13")
						{
							field.Name = i2i(field.Name);
							XjJ.yOE[field.Name] = Convert.ToString(13);
						}
						break;
					case 406512564u:
						if (text2 == "IntKey9")
						{
							field.Name = i2i(field.Name);
							XjJ.BO0[field.Name] = 9;
						}
						break;
					case 400712880u:
						if (text2 == "LdstrKey12")
						{
							field.Name = i2i(field.Name);
							XjJ.yOE[field.Name] = Convert.ToString(12);
						}
						break;
					case 322624469u:
						if (text2 == "IntKey2")
						{
							field.Name = i2i(field.Name);
							XjJ.BO0[field.Name] = 2;
						}
						break;
					case 315708077u:
						if (text2 == "ULongKey13")
						{
							field.Name = i2i(field.Name);
							XjJ.vOW[field.Name] = 13;
						}
						break;
					case 305846850u:
						if (text2 == "IntKey3")
						{
							field.Name = i2i(field.Name);
							XjJ.BO0[field.Name] = 3;
						}
						break;
					case 298930458u:
						if (text2 == "ULongKey12")
						{
							field.Name = i2i(field.Name);
							XjJ.vOW[field.Name] = 12;
						}
						break;
					case 289069231u:
						if (text2 == "IntKey0")
						{
							field.Name = i2i(field.Name);
							XjJ.BO0[field.Name] = 0;
						}
						break;
					case 282152839u:
						if (text2 == "ULongKey11")
						{
							field.Name = i2i(field.Name);
							XjJ.vOW[field.Name] = 11;
						}
						break;
					case 272291612u:
						if (text2 == "IntKey1")
						{
							field.Name = i2i(field.Name);
							XjJ.BO0[field.Name] = 1;
						}
						break;
					case 265375220u:
						if (text2 == "ULongKey10")
						{
							field.Name = i2i(field.Name);
							XjJ.vOW[field.Name] = 10;
						}
						break;
					case 231819982u:
						if (text2 == "ULongKey16")
						{
							field.Name = i2i(field.Name);
							XjJ.vOW[field.Name] = 16;
						}
						break;
					case 221958755u:
						if (text2 == "IntKey4")
						{
							field.Name = i2i(field.Name);
							XjJ.BO0[field.Name] = 4;
						}
						break;
					case 255513993u:
						if (text2 == "IntKey6")
						{
							field.Name = i2i(field.Name);
							XjJ.BO0[field.Name] = 6;
						}
						break;
					case 248597601u:
						if (text2 == "ULongKey17")
						{
							field.Name = i2i(field.Name);
							XjJ.vOW[field.Name] = 17;
						}
						break;
					case 238736374u:
						if (text2 == "IntKey7")
						{
							field.Name = i2i(field.Name);
							XjJ.BO0[field.Name] = 7;
						}
						break;
					case 147931887u:
						if (text2 == "ULongKey19")
						{
							field.Name = i2i(field.Name);
							XjJ.vOW[field.Name] = 19;
						}
						break;
					case 131154268u:
						if (text2 == "ULongKey18")
						{
							field.Name = i2i(field.Name);
							XjJ.vOW[field.Name] = 18;
						}
						break;
					case 215042363u:
						if (text2 == "ULongKey15")
						{
							field.Name = i2i(field.Name);
							XjJ.vOW[field.Name] = 15;
						}
						break;
					case 205181136u:
						if (text2 == "IntKey5")
						{
							field.Name = i2i(field.Name);
							XjJ.BO0[field.Name] = 5;
						}
						break;
					case 198264744u:
						if (text2 == "ULongKey14")
						{
							field.Name = i2i(field.Name);
							XjJ.vOW[field.Name] = 14;
						}
						break;
					case 1594994371u:
						if (text2 == "LdstrKey6")
						{
							field.Name = i2i(field.Name);
							XjJ.yOE[field.Name] = Convert.ToString(6);
						}
						break;
					case 1578216752u:
						if (text2 == "LdstrKey7")
						{
							field.Name = i2i(field.Name);
							XjJ.yOE[field.Name] = Convert.ToString(7);
						}
						break;
					case 1628549609u:
						if (text2 == "LdstrKey4")
						{
							field.Name = i2i(field.Name);
							XjJ.yOE[field.Name] = Convert.ToString(4);
						}
						break;
					case 1621490480u:
						if (text2 == "LongKey11")
						{
							field.Name = i2i(field.Name);
							XjJ.HOw[field.Name] = 11;
						}
						break;
					case 1611771990u:
						if (text2 == "LdstrKey5")
						{
							field.Name = i2i(field.Name);
							XjJ.yOE[field.Name] = Convert.ToString(5);
						}
						break;
					case 1645327228u:
						if (text2 == "LdstrKey3")
						{
							field.Name = i2i(field.Name);
							XjJ.yOE[field.Name] = Convert.ToString(3);
						}
						break;
					case 1638268099u:
						if (text2 == "LongKey10")
						{
							field.Name = i2i(field.Name);
							XjJ.HOw[field.Name] = 10;
						}
						break;
					case 1671823337u:
						if (text2 == "LongKey12")
						{
							field.Name = i2i(field.Name);
							XjJ.HOw[field.Name] = 12;
						}
						break;
					case 1662104847u:
						if (text2 == "LdstrKey2")
						{
							field.Name = i2i(field.Name);
							XjJ.yOE[field.Name] = Convert.ToString(2);
						}
						break;
					case 1655045718u:
						if (text2 == "LongKey13")
						{
							field.Name = i2i(field.Name);
							XjJ.HOw[field.Name] = 13;
						}
						break;
					case 1688600956u:
						if (text2 == "LongKey15")
						{
							field.Name = i2i(field.Name);
							XjJ.HOw[field.Name] = 15;
						}
						break;
					case 1678882466u:
						if (text2 == "LdstrKey1")
						{
							field.Name = i2i(field.Name);
							XjJ.yOE[field.Name] = Convert.ToString(1);
						}
						break;
					case 1722156194u:
						if (text2 == "LongKey17")
						{
							field.Name = i2i(field.Name);
							XjJ.HOw[field.Name] = 17;
						}
						break;
					case 1705378575u:
						if (text2 == "LongKey14")
						{
							field.Name = i2i(field.Name);
							XjJ.HOw[field.Name] = 14;
						}
						break;
					case 1695660085u:
						if (text2 == "LdstrKey0")
						{
							field.Name = i2i(field.Name);
							XjJ.yOE[field.Name] = Convert.ToString(0);
						}
						break;
					case 2178465071u:
						if (text2 == "ULongKey20")
						{
							field.Name = i2i(field.Name);
							XjJ.vOW[field.Name] = 20;
						}
						break;
					case 1829881037u:
						if (text2 == "LdstrKey8")
						{
							field.Name = i2i(field.Name);
							XjJ.yOE[field.Name] = Convert.ToString(8);
						}
						break;
					case 1813103418u:
						if (text2 == "LdstrKey9")
						{
							field.Name = i2i(field.Name);
							XjJ.yOE[field.Name] = Convert.ToString(9);
						}
						break;
					case 1772489051u:
						if (text2 == "LongKey18")
						{
							field.Name = i2i(field.Name);
							XjJ.HOw[field.Name] = 18;
						}
						break;
					case 1755711432u:
						if (text2 == "LongKey19")
						{
							field.Name = i2i(field.Name);
							XjJ.HOw[field.Name] = 19;
						}
						break;
					case 1738933813u:
						if (text2 == "LongKey16")
						{
							field.Name = i2i(field.Name);
							XjJ.HOw[field.Name] = 16;
						}
						break;
					case 2490878345u:
						if (text2 == "LongKey9")
						{
							field.Name = i2i(field.Name);
							XjJ.HOw[field.Name] = 9;
						}
						break;
					case 2474100726u:
						if (text2 == "LongKey8")
						{
							field.Name = i2i(field.Name);
							XjJ.HOw[field.Name] = 8;
						}
						break;
					case 2608321678u:
						if (text2 == "LongKey0")
						{
							field.Name = i2i(field.Name);
							XjJ.HOw[field.Name] = 0;
						}
						break;
					case 2591544059u:
						if (text2 == "LongKey3")
						{
							field.Name = i2i(field.Name);
							XjJ.HOw[field.Name] = 3;
						}
						break;
					case 2574766440u:
						if (text2 == "LongKey2")
						{
							field.Name = i2i(field.Name);
							XjJ.HOw[field.Name] = 2;
						}
						break;
					case 2641876916u:
						if (text2 == "LongKey6")
						{
							field.Name = i2i(field.Name);
							XjJ.HOw[field.Name] = 6;
						}
						break;
					case 2625099297u:
						if (text2 == "LongKey1")
						{
							field.Name = i2i(field.Name);
							XjJ.HOw[field.Name] = 1;
						}
						break;
					case 2692209773u:
						if (text2 == "LongKey5")
						{
							field.Name = i2i(field.Name);
							XjJ.HOw[field.Name] = 5;
						}
						break;
					case 2675432154u:
						if (text2 == "LongKey4")
						{
							field.Name = i2i(field.Name);
							XjJ.HOw[field.Name] = 4;
						}
						break;
					case 2658654535u:
						if (text2 == "LongKey7")
						{
							field.Name = i2i(field.Name);
							XjJ.HOw[field.Name] = 7;
						}
						break;
					case 3063985950u:
						if (text2 == "IntKey16")
						{
							field.Name = i2i(field.Name);
							XjJ.BO0[field.Name] = 16;
						}
						break;
					case 3047208331u:
						if (text2 == "IntKey15")
						{
							field.Name = i2i(field.Name);
							XjJ.BO0[field.Name] = 15;
						}
						break;
					case 3030430712u:
						if (text2 == "IntKey14")
						{
							field.Name = i2i(field.Name);
							XjJ.BO0[field.Name] = 14;
						}
						break;
					case 2980097855u:
						if (text2 == "IntKey19")
						{
							field.Name = i2i(field.Name);
							XjJ.BO0[field.Name] = 19;
						}
						break;
					case 2963320236u:
						if (text2 == "IntKey18")
						{
							field.Name = i2i(field.Name);
							XjJ.BO0[field.Name] = 18;
						}
						break;
					case 3114318807u:
						if (text2 == "IntKey11")
						{
							field.Name = i2i(field.Name);
							XjJ.BO0[field.Name] = 11;
						}
						break;
					case 3097541188u:
						if (text2 == "IntKey10")
						{
							field.Name = i2i(field.Name);
							XjJ.BO0[field.Name] = 10;
						}
						break;
					case 3080763569u:
						if (text2 == "IntKey17")
						{
							field.Name = i2i(field.Name);
							XjJ.BO0[field.Name] = 17;
						}
						break;
					case 4020145544u:
						if (text2 == "LongKey20")
						{
							field.Name = i2i(field.Name);
							XjJ.HOw[field.Name] = 20;
						}
						break;
					case 3147874045u:
						if (text2 == "IntKey13")
						{
							field.Name = i2i(field.Name);
							XjJ.BO0[field.Name] = 13;
						}
						break;
					case 3131096426u:
						if (text2 == "IntKey12")
						{
							field.Name = i2i(field.Name);
							XjJ.BO0[field.Name] = 12;
						}
						break;
					}
				}
			}
		}

		static c2f()
		{
			RKe = new RandomGenerator(32);
		}
	}
}
