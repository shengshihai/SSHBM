using System.Web;
using System.Web.Optimization;

namespace ShengUI
{
    public class BundleConfig
    {
        // 有关 Bundling 的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
            //            "~/Scripts/jquery-ui-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.unobtrusive*",
            //            "~/Scripts/jquery.validate*"));

            //// 使用 Modernizr 的开发版本进行开发和了解信息。然后，当你做好
            //// 生产准备时，请使用 http://modernizr.com 上的生成工具来仅选择所需的测试。
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));
            bundles.Add(new ScriptBundle("~/validate").Include(
                "~/Scripts/jquery-1.7.1.min.js",
                "~/Scripts/jquery.unobtrusive-ajax.js",
                 //<!-- / validate -->
                 "~/Scripts/Back/plugins/validate/jquery.validate.min.js",
                     "~/Scripts/jquery.validate.unobtrusive.js"
            
                ));

            bundles.Add(new StyleBundle("~/Content/Back/base/css").Include(
                          "~/Content/Back/css/bootstrap/bootstrap.css",
                          "~/Content/Back/css/bootstrap/bootstrap-responsive.css",
                          "~/Content/Back/css/jquery_ui/jquery-ui-1.10.0.custom.css",
                          "~/Content/Back/css/jquery_ui/jquery.ui.1.10.0.ie.css",
                            // <!-- / switch buttons -->
                          "~/Content/Back/css/plugins/bootstrap_switch/bootstrap-switch.css",
                            //  <!-- / xeditable -->
                          "~/Content/Back/css/plugins/xeditable/bootstrap-editable.css",
                          "~/Content/Back/css/plugins/common/bootstrap-wysihtml5.css",
                            //  <!-- / wysihtml5 (wysywig) -->
                          "~/Content/Back/css/plugins/common/bootstrap-wysihtml5.css",
                            //   <!-- / jquery file upload -->
                          "~/Content/Back/css/plugins/jquery_fileupload/jquery.fileupload-ui.css",
                            //  <!-- / full calendar -->
                          "~/Content/Back/css/plugins/fullcalendar/fullcalendar.css",
                            //<!-- / select2 -->
                          "~/Content/Back/css/plugins/select2/select2.css",
                            //<!-- / mention -->
                          "~/Content/Back/css/plugins/mention/mention.css",
                           //<!-- / tabdrop (responsive tabs) -->
                          "~/Content/Back/css/plugins/tabdrop/tabdrop.css",
                          // <!-- / jgrowl notifications -->
                          "~/Content/Back/css/plugins/jgrowl/jquery.jgrowl.css",
                          //<!-- / datatables -->
                          "~/Content/Back/css/plugins/datatables/bootstrap-datatable.css",
                          // <!-- / dynatrees (file trees) -->
                          "~/Content/Back/css/plugins/dynatree/ui.dynatree.css",
                          // <!-- / color picker -->
                          "~/Content/Back/css/plugins/bootstrap_colorpicker/bootstrap-colorpicker.css",
                          // <!-- / datetime picker -->
                          "~/Content/Back/css/plugins/bootstrap_datetimepicker/bootstrap-datetimepicker.min.css",
                          // <!-- / daterange picker) -->
                          "~/Content/Back/css/plugins/bootstrap_daterangepicker/bootstrap-daterangepicker.css",
                          //  <!-- / flags (country flags) -->
                          "~/Content/Back/css/plugins/flags/flags.css",
                          //<!-- / slider nav (address book) -->
                          "~/Content/Back/css/plugins/slider_nav/slidernav.css",
                          // <!-- / fuelux (wizard) -->
                          "~/Content/Back/css/plugins/fuelux/wizard.css",
                           // <!-- / flatty theme -->
                          "~/Content/Back/css/light-theme.css",
                          //  <!-- / demo -->
                           "~/Content/Back/css/demo.css"
                        ));

            bundles.Add(new ScriptBundle("~/mvcAjax").Include(
                "~/Scripts/jquery-1.7.1.min.js", 
                "~/Scripts/jquery.unobtrusive-ajax.js", 
               // "~/Scripts/jquery.validate.js", 
                "~/Scripts/Back/Common/common.js",
                "~/Scripts/Back/Common/LG.js",
            
                //<!-- / jquery mobile events (for touch and slide) -->
                "~/Scripts/Back/plugins/mobile_events/jquery.mobile-events.min.js",
                 //<!-- / jquery migrate (for compatibility with new jquery) -->
                "~/Scripts/Back/jquery/jquery-migrate.min.js",
                 //<!-- / jquery ui -->
                 "~/Scripts/Back/jquery_ui/jquery-ui.min.js",
                 //<!-- / bootstrap -->
                 "~/Scripts/Back/bootstrap/bootstrap.min.js",
                 "~/Scripts/Back/plugins/flot/excanvas.js",
                 //<!-- / sparklines -->
                 "~/Scripts/Back/plugins/sparklines/jquery.sparkline.min.js",
                 //<!-- / flot charts -->
                 "~/Scripts/Back/plugins/flot/flot.min.js",
                 "~/Scripts/Back/plugins/flot/flot.resize.js",
                 "~/Scripts/Back/plugins/flot/flot.pie.js",
                 //<!-- / bootstrap switch -->
                 "~/Scripts/Back/plugins/bootstrap_switch/bootstrapSwitch.min.js",
                 //<!-- / fullcalendar -->
                 "~/Scripts/Back/plugins/fullcalendar/fullcalendar.min.js",
                 //<!-- / datatables -->
              //   "~/Scripts/Back/plugins/datatables/jquery.dataTables.js",
                 //"~/Scripts/Back/plugins/datatables/jquery.dataTables.columnFilter.js",
                 //<!-- / wysihtml5 -->
                 "~/Scripts/Back/plugins/common/wysihtml5.min.js",
                 "~/Scripts/Back/plugins/common/bootstrap-wysihtml5.js",
                 //<!-- / select2 -->
                 "~/Scripts/Back/plugins/select2/select2.js",
                 //<!-- / color picker -->
                 "~/Scripts/Back/plugins/bootstrap_colorpicker/bootstrap-colorpicker.min.js",
                 //<!-- / mention -->
                 "~/Scripts/Back/plugins/mention/mention.min.js",
                 //<!-- / input mask -->
                 "~/Scripts/Back/plugins/input_mask/bootstrap-inputmask.min.js",
                 //<!-- / fileinput -->
                 "~/Scripts/Back/plugins/fileinput/bootstrap-fileinput.js",
                 //<!-- / modernizr -->
                 "~/Scripts/Back/plugins/modernizr/modernizr.min.js",
                 //<!-- / retina -->
                 "~/Scripts/Back/plugins/retina/retina.js",
                 //<!-- / fileupload -->
                 "~/Scripts/Back/plugins/fileupload/tmpl.min.js",
                 "~/Scripts/Back/plugins/fileupload/load-image.min.js",
                 "~/Scripts/Back/plugins/fileupload/canvas-to-blob.min.js",
                 "~/Scripts/Back/plugins/fileupload/jquery.iframe-transport.min.js",
                 "~/Scripts/Back/plugins/fileupload/jquery.fileupload.min.js",
                 "~/Scripts/Back/plugins/fileupload/jquery.fileupload-fp.min.js",
                 "~/Scripts/Back/plugins/fileupload/jquery.fileupload-ui.min.js",
                 "~/Scripts/Back/plugins/fileupload/jquery.fileupload-init.js",
                 //<!-- / timeago -->
                 "~/Scripts/Back/plugins/timeago/jquery.timeago.js",
                 //<!-- / slimscroll -->
                 "~/Scripts/Back/plugins/slimscroll/jquery.slimscroll.min.js",
                 //<!-- / autosize (for textareas) -->
                 "~/Scripts/Back/plugins/autosize/jquery.autosize-min.js",
                 //<!-- / charCount -->
                 "~/Scripts/Back/plugins/charCount/charCount.js",
                 //<!-- / validate -->
                 "~/Scripts/Back/plugins/validate/jquery.validate.min.js",
   "~/Scripts/jquery.validate.unobtrusive.js",
                 "~/Scripts/Back/plugins/validate/additional-methods.js",
                 //<!-- / naked password -->
                 "~/Scripts/Back/plugins/naked_password/naked_password-0.2.4.min.js",
                 //<!-- / nestable -->
                 "~/Scripts/Back/plugins/nestable/jquery.nestable.js",
                 //<!-- / tabdrop -->
                 "~/Scripts/Back/plugins/tabdrop/bootstrap-tabdrop.js",
                 //<!-- / jgrowl -->
                 "~/Scripts/Back/plugins/jgrowl/jquery.jgrowl.min.js",
                 //<!-- / bootbox -->
                 "~/Scripts/Back/plugins/bootbox/bootbox.min.js",
                 //<!-- / inplace editing -->
                 "~/Scripts/Back/plugins/xeditable/bootstrap-editable.min.js",


                 "~/Scripts/Back/plugins/xeditable/wysihtml5.js",
                 //<!-- / ckeditor -->
                 "~/Scripts/Back/plugins/ckeditor/ckeditor.js",
                 //<!-- / filetrees -->
                 "~/Scripts/Back/plugins/dynatree/jquery.dynatree.min.js",
                 //<!-- / datetime picker -->
                 "~/Scripts/Back/plugins/bootstrap_datetimepicker/bootstrap-datetimepicker.js",
                 //<!-- / daterange picker -->
                 "~/Scripts/Back/plugins/bootstrap_daterangepicker/moment.min.js",
                 "~/Scripts/Back/plugins/bootstrap_daterangepicker/bootstrap-daterangepicker.js",
                 //<!-- / max length -->
                 "~/Scripts/Back/plugins/bootstrap_maxlength/bootstrap-maxlength.min.js",
                 //<!-- / dropdown hover -->
                 "~/Scripts/Back/plugins/bootstrap_hover_dropdown/twitter-bootstrap-hover-dropdown.min.js",
                 //<!-- / slider nav (address book) -->
                 "~/Scripts/Back/plugins/slider_nav/slidernav-min.js",
                 //<!-- / fuelux -->
                 "~/Scripts/Back/plugins/fuelux/wizard.js",
                 //<!-- / flatty theme -->
                 "~/Scripts/Back/nav.js",
                  //  "~/Scripts/Back/table.js",
                 "~/Scripts/Back/theme.js",
                 //<!-- / demo -->
                 "~/Scripts/Back/demo/jquery.mockjax.js",
                 "~/Scripts/Back/demo/inplace_editing.js",
                 "~/Scripts/Back/demo/charts.js",
                 "~/Scripts/Back/demo/demo.js"
                ));
            bundles.Add(new ScriptBundle("~/datatables").Include(
               "~/Scripts/Back/plugins/datatables/jquery.dataTables.js",
               "~/Scripts/Back/plugins/datatables/jquery.dataTables.columnFilter.js",
              "~/Scripts/Back/tables.js"
               ));


            BundleTable.EnableOptimizations = true;
        }
    }
}