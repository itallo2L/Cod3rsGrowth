sap.ui.define([
   "./BaseController",
   "sap/ui/model/resource/ResourceModel",
   "sap/ui/model/json/JSONModel",
	"../model/formatter"
], (BaseController, ResourceModel, JSONModel, formatter) => {
   "use strict";

   let filtroNome = "";
   let filtroEstaAberto = "";
   let filtroEstaFechado = "";

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
         fetch(url).then(resposta => resposta.json()).then(resposta => {
            const dataModel = new JSONModel();
            dataModel.setData(resposta);

            this.getView().setModel(dataModel, "listaEstudio");
        });
        },
        filtroBarraDePesquisa: function (oEvent){
         filtroNome = oEvent.getSource().getValue();

         this.filtrosEstudioMusical();
        },
        filtroSelectEstaAberto: function (oEvent){
           let chave = oEvent.getSource().getSelectedKey();
           if(chave === "Aberto"){
             filtroEstaAberto = "true";
             filtroEstaFechado = "false";
           } else if (chave === "Fechado"){
              filtroEstaFechado = "true";
              filtroEstaAberto = "false";
           } else {
               filtroEstaAberto = "";
               filtroEstaFechado = "";
           }
         
         this.filtrosEstudioMusical();
        },
         filtrosEstudioMusical: function (){
            let url = `/api/EstudioMusical?Nome=${filtroNome}&EstaAberto=${filtroEstaAberto}&EstaFechado=${filtroEstaFechado}`;

            fetch(url).then(resposta => resposta.json()).then(resposta => {
               const dataModel = new JSONModel();
               dataModel.setData(resposta);

               this.getView().setModel(dataModel, "listaEstudio");
        });
        }
    });
});