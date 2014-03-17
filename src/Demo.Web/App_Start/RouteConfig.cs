﻿using System.Web.Mvc;
using System.Web.Routing;

namespace Demo.Web.App_Start {

    public class RouteConfig {

        private static void ErrorRegisterRoutes(RouteCollection routes) {
            routes.MapRoute(
                "Error",
                "erro",
                new { controller = "ErrorBase", action = "InternalServerError" },
                new { httpMethod = new HttpMethodConstraint("Get") },
                new[] { "Library.Net.Mvc.Controllers" }
            );

            routes.MapRoute(
                "NotFound",
                "pagina-nao-encontrada",
                new { controller = "ErrorBase", action = "NotFound" },
                new { httpMethod = new HttpMethodConstraint("Get") },
                new[] { "Library.Net.Mvc.Controllers" }
            );

            routes.MapRoute(
                "InternalServerError",
                "erro-interno",
                new { controller = "ErrorBase", action = "InternalServerError" },
                new { httpMethod = new HttpMethodConstraint("Get") },
                new[] { "Library.Net.Mvc.Controllers" }
            );

            routes.MapRoute(
                "Unauthorized",
                "nao-autorizado",
                new { controller = "ErrorBase", action = "Unauthorized" },
                new { httpMethod = new HttpMethodConstraint("Get") },
                new[] { "Library.Net.Mvc.Controllers" }
            );
        }

        private static void LoginRegisterRoutes(RouteCollection routes) {
            routes.MapRoute(
                "LogOn",
                "entrar",
                new { controller = "Login", action = "LogOn" },
                new { httpMethod = new HttpMethodConstraint("Get", "Post") }
            );

            routes.MapRoute(
                "LoOff",
                "sair",
                new { controller = "Login", action = "LogOff" },
                new { httpMethod = new HttpMethodConstraint("Get") }
            );
        }

        private static void AccountRegisterRoutes(RouteCollection routes) {
            routes.MapRoute(
                "ForgotPasswordAccount",
                "conta/esqueci-minha-senha",
                new { controller = "Account", action = "ForgotPassword" },
                new { httpMethod = new HttpMethodConstraint("Get", "Post") }
            );

            routes.MapRoute(
                "ChangePasswordAccount",
                "conta/alterar-senha",
                new { controller = "Account", action = "ChangePassword" },
                new { httpMethod = new HttpMethodConstraint("Get", "Post") }
            );

            routes.MapRoute(
                "CreateAccount",
                "conta/criar",
                new { controller = "Account", action = "Create" },
                new { httpMethod = new HttpMethodConstraint("Get", "Post") }
            );

            routes.MapRoute(
                "EditAccount",
                "conta/editar",
                new { controller = "Account", action = "Edit" },
                new { httpMethod = new HttpMethodConstraint("Get", "Post") }
            );

            routes.MapRoute(
                "CheckUserEmailNonexistenceAccount",
                "conta/verificar-email-inexistente",
                new { controller = "Account", action = "CheckUserEmailNonexistence" },
                new { httpMethod = new HttpMethodConstraint("Get") }
            );

            routes.MapRoute(
                "CheckUserEmailExistenceAccount",
                "conta/verificar-email-existente",
                new { controller = "Account", action = "CheckUserEmailExistence" },
                new { httpMethod = new HttpMethodConstraint("Get") }
            );
        }

        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("elmah.axd");
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            LoginRegisterRoutes(routes);
            AccountRegisterRoutes(routes);
            ErrorRegisterRoutes(routes);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}