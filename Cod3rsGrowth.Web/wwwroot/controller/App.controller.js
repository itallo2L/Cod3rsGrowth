sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "sap/ui/model/resource/ResourceModel"
 ], (Controller, ResourceModel) => {
    "use strict";
    return Controller.extend("ui5.cod3rsgrowth.controller.App", {
      onInit: function () {
         const i18nModel = new ResourceModel({
            bundleName: "ui5.cod3rsgrowth.i18n.i18n"
         });
         this.getView().setModel(i18nModel, "i18n");
         const oBundle = this.getView().getModel("i18n").getResourceBundle();
         const sTitulo = oBundle.getText("tituloDaPagina");
         document.title = sTitulo;
      }
   });
 });