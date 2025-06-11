using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace XCore.XVM.Helper
{
	public class MethodTreeLoader
	{
		public enum NodeType
		{
			Namespace,
			Type,
			Method,
			ModuleRoot
		}

		public class NodeInfo
		{
			[CompilerGenerated]
			private NodeType JJ6;

			[CompilerGenerated]
			private MethodDef UJ0;

			[CompilerGenerated]
			private ModuleDefMD MJR;

			public NodeType Type
			{
				[CompilerGenerated]
				get
				{
					return JJ6;
				}
				[CompilerGenerated]
				set
				{
					JJ6 = value;
				}
			}

			public MethodDef Method
			{
				[CompilerGenerated]
				get
				{
					return UJ0;
				}
				[CompilerGenerated]
				set
				{
					UJ0 = value;
				}
			}

			public ModuleDefMD Module
			{
				[CompilerGenerated]
				get
				{
					return MJR;
				}
				[CompilerGenerated]
				set
				{
					MJR = value;
				}
			}
		}

		public static class Colors
		{
			public static readonly Color PublicMethod;

			public static readonly Color PrivateMethod;

			public static readonly Color Constructor;

			public static readonly Color PrivateConstructor;

			public static readonly Color SelectedMethod;

			public static readonly Color StaticConstructor;

			public static readonly Color RedMethod;

			public static readonly Color UnsafeMethod;

			public static readonly Color ModuleNode;

			static Colors()
			{
				PublicMethod = Color.FromArgb(16744448);
				PrivateMethod = Color.FromArgb(13395456);
				Constructor = Color.FromArgb(5163440);
				PrivateConstructor = Color.FromArgb(4567708);
				SelectedMethod = Color.FromArgb(41, 230, 124);
				StaticConstructor = Color.Cyan;
				RedMethod = Color.Tomato;
				UnsafeMethod = Color.DarkRed;
				ModuleNode = Color.White;
			}
		}

		[Serializable]
		[CompilerGenerated]
		private sealed class VJo
		{
			public static readonly VJo kJ1;

			public static Func<TypeDef, UTF8String> IJv;

			public static Func<Instruction, bool> mJx;

			static VJo()
			{
				kJ1 = new VJo();
			}

			internal UTF8String YJD(TypeDef typeDef_0)
			{
				return typeDef_0.Namespace;
			}

			internal bool cJd(Instruction instruction_0)
			{
				return instruction_0.OpCode == OpCodes.Or || instruction_0.OpCode == OpCodes.And;
			}
		}

		[CompilerGenerated]
		private sealed class qJj
		{
			public OpCode[] FJ4;

			internal bool dJK(Instruction instruction_0)
			{
				return FJ4.Contains(instruction_0.OpCode);
			}
		}

		private readonly TreeView yUK;

		private bool QU4 = false;

		[CompilerGenerated]
		private static bool xUn;

		[CompilerGenerated]
		private static bool pUh;

		[CompilerGenerated]
		private static bool DUr;

		[CompilerGenerated]
		private static bool sUc;

		public static bool IsVirt
		{
			[CompilerGenerated]
			get
			{
				return xUn;
			}
			[CompilerGenerated]
			set
			{
				xUn = value;
			}
		}

		public bool All
		{
			get
			{
				return QU4;
			}
			set
			{
				QU4 = value;
				zUR();
			}
		}

		public static bool ExcludeConstructors
		{
			[CompilerGenerated]
			get
			{
				return pUh;
			}
			[CompilerGenerated]
			set
			{
				pUh = value;
			}
		}

		public static bool ExcludeRedMethods
		{
			[CompilerGenerated]
			get
			{
				return DUr;
			}
			[CompilerGenerated]
			set
			{
				DUr = value;
			}
		}

		public static bool ExcludeUnsafeMethods
		{
			[CompilerGenerated]
			get
			{
				return sUc;
			}
			[CompilerGenerated]
			set
			{
				sUc = value;
			}
		}

		public MethodTreeLoader(TreeView treeView_0)
		{
			yUK = treeView_0;
		}

		public void LoadModule(ModuleDefMD moduleDefMD_0, string string_0 = null)
		{
			string text = string_0 ?? ((string)moduleDefMD_0.Name);
			yUK.BeginUpdate();
			TreeNode treeNode = new TreeNode(text)
			{
				Tag = new NodeInfo
				{
					Type = NodeType.ModuleRoot,
					Module = moduleDefMD_0
				},
				ForeColor = Colors.ModuleNode,
				ImageKey = "module",
				SelectedImageKey = "module"
			};
			IEnumerable<IGrouping<UTF8String, TypeDef>> enumerable = from typeDef_0 in moduleDefMD_0.GetTypes()
				where !SU1(typeDef_0)
				group typeDef_0 by typeDef_0.Namespace;
			foreach (IGrouping<UTF8String, TypeDef> item in enumerable)
			{
				TreeNode treeNode2 = KUe(item.Key);
				pUJ(treeNode2, item, moduleDefMD_0);
				if (treeNode2.Nodes.Count > 0)
				{
					treeNode.Nodes.Add(treeNode2);
				}
			}
			if (treeNode.Nodes.Count > 0)
			{
				yUK.Nodes.Add(treeNode);
			}
			yUK.EndUpdate();
			yUK.Sort();
		}

		public void RefreshTreeView()
		{
			yUK.BeginUpdate();
			TreeNode selectedNode = yUK.SelectedNode;
			yUK.SelectedNode = null;
			yUK.SelectedNode = selectedNode;
			yUK.EndUpdate();
		}

		public List<MethodDef> GetSelectedMethods()
		{
			List<MethodDef> list = new List<MethodDef>();
			foreach (TreeNode node in yUK.Nodes)
			{
				zUd(node, list);
			}
			return list;
		}

		public Dictionary<ModuleDefMD, List<MethodDef>> GetSelectedMethodsByModule()
		{
			Dictionary<ModuleDefMD, List<MethodDef>> dictionary = new Dictionary<ModuleDefMD, List<MethodDef>>();
			foreach (TreeNode node in yUK.Nodes)
			{
				NodeInfo nodeInfo = node.Tag as NodeInfo;
				if (nodeInfo != null && nodeInfo.Type == NodeType.ModuleRoot)
				{
					List<MethodDef> list = new List<MethodDef>();
					zUd(node, list);
					if (list.Count > 0)
					{
						dictionary[nodeInfo.Module] = list;
					}
				}
			}
			return dictionary;
		}

		public List<uint> GetSelectedMethodTokens()
		{
			List<uint> list = new List<uint>();
			foreach (TreeNode node in yUK.Nodes)
			{
				bU0(node, list);
			}
			return list;
		}

		public Dictionary<ModuleDefMD, List<uint>> GetSelectedMethodTokensByModule()
		{
			Dictionary<ModuleDefMD, List<uint>> dictionary = new Dictionary<ModuleDefMD, List<uint>>();
			foreach (TreeNode node in yUK.Nodes)
			{
				NodeInfo nodeInfo = node.Tag as NodeInfo;
				if (nodeInfo != null && nodeInfo.Type == NodeType.ModuleRoot)
				{
					List<uint> list = new List<uint>();
					bU0(node, list);
					if (list.Count > 0)
					{
						dictionary[nodeInfo.Module] = list;
					}
				}
			}
			return dictionary;
		}

		public static List<MethodDef> ResolveMethodsFromTokens(ModuleDefMD moduleDefMD_0, List<uint> list_0)
		{
			List<MethodDef> list = new List<MethodDef>();
			foreach (uint item in list_0)
			{
				MethodDef methodDef = moduleDefMD_0.ResolveToken(item) as MethodDef;
				if (methodDef != null)
				{
					list.Add(methodDef);
				}
			}
			return list;
		}

		private TreeNode KUe(string string_0)
		{
			return new TreeNode(string_0)
			{
				Tag = new NodeInfo
				{
					Type = NodeType.Namespace
				},
				ImageKey = "namespace",
				SelectedImageKey = "namespace"
			};
		}

		private void pUJ(TreeNode treeNode_0, IEnumerable<TypeDef> ienumerable_0, ModuleDefMD moduleDefMD_0)
		{
			foreach (TypeDef item in ienumerable_0)
			{
				TreeNode treeNode = aUt(item);
				iU7(treeNode, item.Methods, moduleDefMD_0);
				if (treeNode.Nodes.Count > 0)
				{
					treeNode_0.Nodes.Add(treeNode);
				}
			}
		}

		private TreeNode aUt(TypeDef typeDef_0)
		{
			UTF8String uTF8String = ((!typeDef_0.Name.Contains("`")) ? typeDef_0.Name.Replace("`", string.Empty) : typeDef_0.Name.Substring(0, typeDef_0.Name.IndexOf('`')));
			return new TreeNode(uTF8String)
			{
				Tag = new NodeInfo
				{
					Type = NodeType.Type
				},
				ImageKey = "class",
				SelectedImageKey = "class"
			};
		}

		private void iU7(TreeNode treeNode_0, IEnumerable<MethodDef> ienumerable_0, ModuleDefMD moduleDefMD_0)
		{
			foreach (MethodDef item in ienumerable_0.Where(nUv))
			{
				treeNode_0.Nodes.Add(XU6(item, moduleDefMD_0));
			}
		}

		private TreeNode XU6(MethodDef methodDef_0, ModuleDefMD moduleDefMD_0)
		{
			TreeNode treeNode = new TreeNode($"{methodDef_0.Name}  (0x{methodDef_0.MDToken:X4})")
			{
				Tag = new NodeInfo
				{
					Type = NodeType.Method,
					Method = methodDef_0,
					Module = moduleDefMD_0
				},
				ForeColor = GetMethodColor(methodDef_0),
				Checked = (All && jUD(methodDef_0))
			};
			treeNode.ImageKey = (methodDef_0.IsConstructor ? "constructor" : "method");
			treeNode.SelectedImageKey = treeNode.ImageKey;
			return treeNode;
		}

		private void bU0(TreeNode treeNode_0, List<uint> list_0)
		{
			foreach (TreeNode node in treeNode_0.Nodes)
			{
				NodeInfo nodeInfo = node.Tag as NodeInfo;
				if (nodeInfo != null && nodeInfo.Type == NodeType.Method && node.Checked)
				{
					list_0.Add(nodeInfo.Method.MDToken.Raw);
				}
				bU0(node, list_0);
			}
		}

		public static void UpdateChildNodes(TreeNode treeNode_0, bool bool_0)
		{
			foreach (TreeNode node in treeNode_0.Nodes)
			{
				NodeInfo nodeInfo = node.Tag as NodeInfo;
				if (nodeInfo != null)
				{
					if (nodeInfo.Type == NodeType.Method)
					{
						bool flag = (node.Checked = bool_0 && (!ExcludeConstructors || !nodeInfo.Method.IsConstructor) && (!ExcludeRedMethods || !IsRedMethod(nodeInfo.Method)) && (!ExcludeUnsafeMethods || !IsUnsafeMethod(nodeInfo.Method)));
						node.ForeColor = (flag ? Colors.SelectedMethod : GetMethodColor(nodeInfo.Method));
						node.ImageIndex = (node.Checked ? 1 : 0);
						node.SelectedImageIndex = node.ImageIndex;
					}
					else
					{
						node.Checked = bool_0;
						UpdateChildNodes(node, bool_0);
					}
				}
			}
		}

		private void zUR()
		{
			yUK.BeginUpdate();
			foreach (TreeNode node in yUK.Nodes)
			{
				node.Checked = QU4;
				FUo(node);
			}
			yUK.EndUpdate();
		}

		private void FUo(TreeNode treeNode_0)
		{
			foreach (TreeNode node in treeNode_0.Nodes)
			{
				NodeInfo nodeInfo = node.Tag as NodeInfo;
				if (nodeInfo != null)
				{
					if (nodeInfo.Type != NodeType.Method)
					{
						node.Checked = QU4;
						FUo(node);
					}
					else
					{
						bool flag = (node.Checked = QU4 && jUD(nodeInfo.Method));
						node.ForeColor = (flag ? Colors.SelectedMethod : GetMethodColor(nodeInfo.Method));
					}
				}
			}
		}

		private bool jUD(MethodDef methodDef_0)
		{
			return !methodDef_0.IsStaticConstructor && (!ExcludeConstructors || !methodDef_0.IsConstructor) && (!ExcludeRedMethods || !IsRedMethod(methodDef_0)) && (!ExcludeUnsafeMethods || !IsUnsafeMethod(methodDef_0));
		}

		private void zUd(TreeNode treeNode_0, List<MethodDef> list_0)
		{
			foreach (TreeNode node in treeNode_0.Nodes)
			{
				NodeInfo nodeInfo = node.Tag as NodeInfo;
				if (nodeInfo != null && nodeInfo.Type == NodeType.Method && node.Checked)
				{
					list_0.Add(nodeInfo.Method);
				}
				zUd(node, list_0);
			}
		}

		public static Color GetMethodColor(MethodDef methodDef_0)
		{
			if (!methodDef_0.IsStaticConstructor)
			{
				if (!IsUnsafeMethod(methodDef_0))
				{
					if (!IsRedMethod(methodDef_0))
					{
						return methodDef_0.IsConstructor ? (methodDef_0.IsPrivate ? Colors.PrivateConstructor : Colors.Constructor) : ((!methodDef_0.IsPublic) ? Colors.PrivateMethod : Colors.PublicMethod);
					}
					return Colors.RedMethod;
				}
				return Colors.UnsafeMethod;
			}
			return Colors.StaticConstructor;
		}

		private bool SU1(TypeDef typeDef_0)
		{
			return string.IsNullOrEmpty(typeDef_0.Namespace) || typeDef_0.Name.Contains("ImplementationDetails>") || typeDef_0.Name.StartsWith("<");
		}

		private bool nUv(MethodDef methodDef_0)
		{
			return !methodDef_0.IsStaticConstructor && DUx(methodDef_0);
		}

		private bool DUx(MethodDef methodDef_0)
		{
			if (!methodDef_0.HasBody)
			{
				return false;
			}
			if (!methodDef_0.Body.HasInstructions)
			{
				return false;
			}
			if (methodDef_0.HasGenericParameters)
			{
				return false;
			}
			if (!methodDef_0.IsPinvokeImpl)
			{
				if (methodDef_0.IsUnmanagedExport)
				{
					return false;
				}
				return true;
			}
			return false;
		}

		public static bool IsRedMethod(MethodDef methodDef_0)
		{
			if (methodDef_0.Body.Instructions.Any((Instruction instruction_0) => instruction_0.OpCode == OpCodes.Or || instruction_0.OpCode == OpCodes.And))
			{
				return true;
			}
			return false;
		}

		public static bool IsUnsafeMethod(MethodDef methodDef_0)
		{
			OpCode[] FJ4 = new OpCode[3]
			{
				OpCodes.Ldind_I1,
				OpCodes.Stind_I1,
				OpCodes.Conv_I
			};
			if (!methodDef_0.Body.Instructions.Any((Instruction instruction_0) => FJ4.Contains(instruction_0.OpCode)))
			{
				return false;
			}
			return true;
		}

		static MethodTreeLoader()
		{
			pUh = false;
			DUr = true;
			sUc = true;
		}

		[CompilerGenerated]
		private bool RUj(TypeDef typeDef_0)
		{
			return !SU1(typeDef_0);
		}
	}
}
