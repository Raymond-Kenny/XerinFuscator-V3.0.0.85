using dnlib.DotNet;
using XCore.Context;
using XCore.Injection;
using XRuntime;

public class SelfString
{
    private static newInjector mUV;

    public static MethodDef XorCipher;

    public void injectXorCipher(XContext xcontext_0)
    {
        mUV = new newInjector(xcontext_0.Module, typeof(SelfString));
        XorCipher = mUV.FindMember("XorCipher") as MethodDef;
        mUV.Rename();
    }
}
