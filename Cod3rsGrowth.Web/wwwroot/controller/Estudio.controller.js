sap.ui.define([
   "./BaseController",
   "sap/ui/model/resource/ResourceModel"
], (BaseController, ResourceModel) => {
   "use strict";

   return BaseController.extend("ui5.cod3rsgrowth.controller.EstudioController", {
      onInit: function () {
         const i18nModel = new ResourceModel({
            bundleName: "ui5.cod3rsgrowth.i18n.i18n"
         });
         this.getView().setModel(i18nModel, "i18n");
         const oBundle = this.getView().getModel("i18n").getResourceBundle();
         const sTitulo = oBundle.getText("tituloEstudio");
         document.title = sTitulo;
      },
   });
});