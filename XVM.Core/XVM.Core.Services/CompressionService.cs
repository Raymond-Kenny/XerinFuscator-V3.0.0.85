using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using XF;

namespace XVM.Core.Services
{
	public class CompressionService
	{
		private class x5M : DRH
		{
			private readonly Action<double> r5A;

			private readonly int L5R;

			public x5M(Action<double> action_0, int int_0)
			{
				r5A = action_0;
				L5R = int_0;
			}

			public void dUS(long long_0, long long_1)
			{
				double obj = (double)long_0 / (double)L5R;
				r5A(obj);
			}
		}

		public byte[] LZMA_Compress(byte[] byte_0, Action<double> action_0 = null)
		{
			XuQ[] xuQ_ = new XuQ[8]
			{
				(XuQ)1,
				(XuQ)5,
				(XuQ)6,
				(XuQ)7,
				(XuQ)12,
				(XuQ)8,
				(XuQ)9,
				(XuQ)14
			};
			object[] object_ = new object[8] { 8388608, 2, 3, 0, 2, 128, "bt4", false };
			MemoryStream memoryStream = new MemoryStream();
			twQ twQ = new twQ();
			twQ.HUU(xuQ_, object_);
			twQ.aUh(memoryStream);
			byte[] bytes = BitConverter.GetBytes(byte_0.Length);
			if (!BitConverter.IsLittleEndian)
			{
				int num = bytes.GetLowerBound(0);
				int num2 = bytes.GetLowerBound(0) + 4 - 1;
                object[] array = bytes.Cast<object>().ToArray();
				if (array != null)
                {
                    while (num < num2)
                    {
                        object obj = array[num];
                        array[num] = array[num2];
                        array[num2] = obj;
                        num++;
                        num2--;
                    }
                }
                else
				{
					while (num < num2)
					{
						object value = bytes.GetValue(num);
						bytes.SetValue(bytes.GetValue(num2), num);
						bytes.SetValue(value, num2);
						num++;
						num2--;
					}
				}
			}
			memoryStream.Write(bytes, 0, 4);
			DRH drh_ = null;
			if (action_0 != null)
			{
				drh_ = new x5M(action_0, byte_0.Length);
			}
			twQ.VUa(new MemoryStream(byte_0), memoryStream, -1L, -1L, drh_);
			return memoryStream.ToArray();
		}

		public byte[] GZIP_Compress(byte[] byte_0)
		{
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (GZipStream gZipStream = new GZipStream(memoryStream, CompressionMode.Compress))
				{
					gZipStream.Write(byte_0, 0, byte_0.Length);
				}
				return memoryStream.ToArray();
			}
		}
	}
}
