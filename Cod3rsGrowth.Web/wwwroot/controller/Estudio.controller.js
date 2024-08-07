sap.ui.define([
   "./BaseController",
   "sap/ui/model/resource/ResourceModel",
   "sap/ui/model/json/JSONModel",
	"../model/formatter"
], (BaseController, ResourceModel, JSONModel, formatter) => {
   "use strict";

   return BaseController.extend("ui5.cod3rsgrowth.controller.EstudioController", {
      formatter: formatter,
      onInit: function () {
         const i18nModel = new ResourceModel({
            bundleName: "ui5.cod3rsgrowth.i18n.i18n"
         });
         this.getView().setModel(i18nModel, "i18n");
         const oBundle = this.getView().getModel("i18n").getResourceBundle();
         const sTitulo = oBundle.getText("tituloEstudio");
         document.title = sTitulo;

         const urlEstudio = '/api/EstudioMusical';
         this.buscarApi(urlEstudio);
      },
      buscarApi: function (url){
         fetch(url).then(res => res.json()).then(res => {
            const dataModel = new JSONModel();
            dataModel.setData(res);
            this.getView().setModel(dataModel, "listaEstudio")
        });
        }
    });
});