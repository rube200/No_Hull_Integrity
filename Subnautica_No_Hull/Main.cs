using Ryder;
using System;
using System.Reflection;

namespace Subnautica_No_Hull
{
    public class Main
    {
        public static MethodRedirection RedirectAwake { get; private set; } = null;
        public static MethodRedirection RedirectStart { get; private set; } = null;


        public static void Initialize()
        {
            var MethodAwake = typeof(BaseHullStrength).GetMethod("Awake", BindingFlags.Instance | BindingFlags.NonPublic);
            var MethodStart = typeof(BaseHullStrength).GetMethod("Start", BindingFlags.Instance | BindingFlags.NonPublic);
            var MethodRedirect = typeof(Main).GetMethod("Redirect", BindingFlags.Instance | BindingFlags.NonPublic);


            if (RedirectAwake != null)
                RedirectAwake.Dispose();
            RedirectAwake = Redirection.Redirect(MethodAwake, MethodRedirect);


            if (RedirectStart != null)
                RedirectStart.Dispose();
            RedirectStart = Redirection.Redirect(MethodStart, MethodRedirect);


            Console.WriteLine("[No Hull] Loaded");
        }

#pragma warning disable IDE0051
        private void Redirect() { }
#pragma warning restore IDE0051
    }
}