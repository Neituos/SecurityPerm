using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace SecurityPerm
{
    class Program
    {
        //Exemples

        //L'exemple suivant requiert que le principal actif soit un administrateur. 
        //Le nameparamètre est null, qui permet à tout utilisateur administrateur de transmettre la demande.

       // le contrôle de compte d'utilisateur (UAC) détermine les privilèges d'un utilisateur.
       // Si vous êtes membre du groupe Administrateurs intégrés, deux jetons d'accès au moment de l'exécution vous sont 
       // attribués: un jeton d'accès utilisateur standard et un jeton d'accès administrateur.
       // Par défaut, vous êtes dans le rôle d'utilisateur standard. Pour exécuter le code nécessitant que vous soyez administrateur, 
       // vous devez d'abord élever vos privilèges d'utilisateur standard à administrateur.
       // Vous pouvez le faire lorsque vous démarrez une application en cliquant avec le bouton droit de la souris sur l'icône de l'application 
       // et en indiquant que vous souhaitez exécuter l'exécution en tant qu'administrateur.


        static void Main(string[] args)
        {
            //Avant de demander l'autorisation principale, il est nécessaire de définir la stratégie principale du domaine d'application
            //actuel sur la valeur d'énumération WindowsPrincipal .
            AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
            //Initialise une nouvelle instance de la classe PrincipalPermission pour les objets spécifiés nameet role.
            PrincipalPermission principalPerm = new PrincipalPermission(null, "Administrators");
            //Détermine au moment de l'exécution si le principal actuel correspond au principal spécifié par l'autorisation actuelle.
            principalPerm.Demand();
            //je fais hibou coucou
            Console.WriteLine("Demand succeeded.");
        }

        //Remarques
        //    En transmettant des informations d'identité (nom d'utilisateur et rôle) au constructeur,
        //    PrincipalPermission peut être utilisé pour demander que l'identité du principal actif corresponde à cette information.

        //    Pour correspondre à l' identité IIrentale IPrincipal et associée active , 
        //    l'identité et le rôle spécifiés doivent correspondre.Si nullune chaîne d'identité est utilisée, 
        //    elle est interprétée comme une demande de correspondance avec toute identité. 
        //    L'utilisation de la nullchaîne de rôle correspond à n'importe quel rôle. Par implication,
        //    passer un nullparamètre pour nameou roleà PrincipalPermission correspond à l'identité et aux rôles de tout IPrincipal.
        //    Il est également possible de construire une PrincipalPermission qui détermine uniquement si l' entité IIdentity représente 
        //    une entité authentifiée ou non authentifiée. Dans ce cas, nameet rolesont ignorés.

        //    Contrairement à la plupart des autres autorisations, PrincipalPermission n’étend pas CodeAccessPermission.
        //    Cependant, il implémente l' interface IPermission . En effet, PrincipalPermission n'est pas une permission d'accès au code.
        //    c'est-à-dire qu'il n'est pas accordé en fonction de l'identité de l'assembly d'exécution. Au lieu de cela, 
        //    il permet au code d'effectuer des actions(demande , union , intersection , etc.) sur l'identité de l'utilisateur actuel, 
        //    de manière cohérente avec la façon dont ces actions sont effectuées pour l'accès au code et les autorisations d'identité de code.
    }
}
