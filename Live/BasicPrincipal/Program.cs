using System.Security.Claims;
using System.Security.Principal;

namespace BasicPrincipal;

class Program
{
    static void Main(string[] args)
    {
        AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);

        IIdentity identity;
        IPrincipal principal;

        ClaimsPrincipal claim;
        GenericIdentity iden = new GenericIdentity("Peter Pan");
        GenericPrincipal gen = new GenericPrincipal(iden, ["Admin"]);
        //WindowsPrincipal prin = Thread.CurrentPrincipal as WindowsPrincipal;
        Thread.CurrentPrincipal =gen;
        System.Console.WriteLine(Thread.CurrentPrincipal.Identity.Name);

        System.Console.WriteLine(Thread.CurrentPrincipal.IsInRole("Admin"));
    }
}
