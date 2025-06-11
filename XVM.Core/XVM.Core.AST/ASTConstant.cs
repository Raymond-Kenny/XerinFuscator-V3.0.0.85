using System.Runtime.CompilerServices;
using System.Text;

namespace XVM.Core.AST
{
	public class ASTConstant : ASTExpression
	{
		[CompilerGenerated]
		private object itF;

		public object Value
		{
			[CompilerGenerated]
			get
			{
				return itF;
			}
			[CompilerGenerated]
			set
			{
				itF = value;
			}
		}

		public static void EscapeString(StringBuilder stringBuilder_0, string string_0, bool bool_0)
		{
			if (string_0 != null)
			{
				if (bool_0)
				{
					stringBuilder_0.Append('"');
				}
				foreach (char c in string_0)
				{
					if (c >= ' ')
					{
						if (c == '\\' || c == '"')
						{
							stringBuilder_0.Append('\\');
							stringBuilder_0.Append(c);
						}
						else
						{
							stringBuilder_0.Append(c);
						}
						continue;
					}
					switch (c)
					{
					default:
						stringBuilder_0.Append($"\\u{(int)c:X4}");
						break;
					case '\a':
						stringBuilder_0.Append("\\a");
						break;
					case '\b':
						stringBuilder_0.Append("\\b");
						break;
					case '\t':
						stringBuilder_0.Append("\\t");
						break;
					case '\n':
						stringBuilder_0.Append("\\n");
						break;
					case '\v':
						stringBuilder_0.Append("\\v");
						break;
					case '\f':
						stringBuilder_0.Append("\\f");
						break;
					case '\r':
						stringBuilder_0.Append("\\r");
						break;
					}
				}
				if (bool_0)
				{
					stringBuilder_0.Append('"');
				}
			}
			else
			{
				stringBuilder_0.Append("null");
			}
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (Value == null)
			{
				stringBuilder.Append("<<<NULL>>>");
			}
			else if (Value is string)
			{
				EscapeString(stringBuilder, (string)Value, bool_0: true);
			}
			else
			{
				stringBuilder.Append(Value);
			}
			return stringBuilder.ToString();
		}
	}
}
