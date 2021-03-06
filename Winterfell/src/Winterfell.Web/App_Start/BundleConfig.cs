﻿using System.Web.Optimization;

namespace Winterfell.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
          
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                 "~/Scripts/jquery/jquery-{version}.js",
                "~/Scripts/jquery/spin.js",
                "~/Scripts/jquery/ladda.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery/jquery.validate*",
                "~/Scripts/jquery.mask.js",
                "~/Scripts/app/infra/jquery.config.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                 "~/Scripts/bootstrap/bootstrap.js",
                 "~/Scripts/bootstrap/respond.js"
                 //"~/Content/bootstrap-grid.css",
                 //"~/Content/bootstrap-grid.min.css"


                 ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Scripts/plugins/angular-toastr/angular-toastr.css",
                "~/Content/ladda-themeless.min.css",
                "~/Content/bootstrap.css",
                "~/Content/bootstrap.min.css",              
                "~/Content/site.css",
                "~/Content/shop-homepage.css"
                ));

            bundles.Add(new StyleBundle("~/Content/AdminCss").Include(
                 "~/Content/Admin/bootstrap/css/bootstrap.min.css",
                "~/Content/Admin/font-awesome/css/font-awesome.min.css",
                 "~/Content/Admin/css/local.css"
                //"~/Content/Admin/font-awesome/css/font-awesome.css",            
                //"~/Content/Admin/bootstrap/css/bootstrap.css"
                ));

           


            CustomBundles(bundles);

            RegisterApp(bundles);

            BundleTable.EnableOptimizations = true;
        }

        private static void CustomBundles(BundleCollection bundles)
        {
            #region AngularJS

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
               "~/Scripts/angular/angular.min.js",
               "~/Scripts/plugins/datetime.js",
               "~/Scripts/plugins/bootbox.min.js",
               "~/Scripts/plugins/angular-validate.min.js",
               "~/Scripts/plugins/angular-ladda.min.js",
               "~/Scripts/plugins/angular-animate.min.js",
               "~/Scripts/plugins/angular-toastr/angular-toastr.min.js",
               "~/Scripts/plugins/angular-toastr/angular-toastr.tpls.min.js",
               "~/Scripts/app/app.js",                
               "~/Scripts/app/filters.js"

               ));

            #endregion

            #region DataTable

            // dataTables 
            bundles.Add(new ScriptBundle("~/plugins/dataTables").Include(
                "~/Scripts/plugins/dataTables/datatables.min.js",
                "~/Scripts/plugins/dataTables/angular-datatables.min.js",
                "~/Scripts/plugins/dataTables/buttons/angular-datatables.buttons.min.js",
                "~/Scripts/plugins/dataTables/angular-datatables.bootstrap.min.js",
                "~/Scripts/plugins/summernote/summernote.min.js"
                ));

            // dataTables css styles
            bundles.Add(new StyleBundle("~/Content/plugins/dataTables/dataTablesStyles").Include(
                "~/Scripts/plugins/dataTables/datatables.min.css",
                "~/Scripts/plugins/dataTables/angular-datatables.min.css",
                "~/Scripts/plugins/dataTables/datatables.bootstrap.min.css"));

            #endregion
        }

        private static void RegisterApp(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/crudController").Include(
                "~/Scripts/app/crud/crudController.js"));

            #region Modulo Cliente

            bundles.Add(new ScriptBundle("~/bundles/cliente").Include(
                "~/Scripts/app/cliente/clienteController.js"));

            #endregion

            #region Modulo Usuario
            bundles.Add(new ScriptBundle("~/bundles/usuarioAngular").Include(
                "~/Scripts/app/usuario/usuarioCtrl.js"
                ));

            #endregion
            #region Modulo Categoria
            bundles.Add(new ScriptBundle("~/bundles/categoriaAngular").Include(
                "~/Scripts/app/categoria/categoriaCtrl.js"
                ));

            #endregion

            //#region Modulo Administrativo
            //bundles.Add(new ScriptBundle("~/bundles/administrativo").Include(               
            //    "~/Scripts/app/administrativo/administrativoController.js"
            //    ));


            //#endregion
        }
    }
}
