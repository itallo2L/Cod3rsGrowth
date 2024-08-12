sap.ui.define([
   "../BaseController",
   "sap/ui/model/resource/ResourceModel",
   "sap/ui/model/json/JSONModel",
	"../../model/formatter",
   "sap/m/MessageBox"
], (BaseController, ResourceModel, JSONModel, formatter, MessageBox) => {
   "use strict";

   let filtroNome = "";
   let filtroEstaAberto = "";
   let filtroEstaFechado = "";

   return BaseController.extend("ui5.cod3rsgrowth.app.estudio.EstudioController", {
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
         const statusOk = 200;
         this.buscarApi(urlEstudio, statusOk);
      },
      buscarApi: function (url, statusOk){
         fetch(url).then(resposta => resposta.json()).then(resposta => {
            if (resposta.Status && resposta.Status !== statusOk) {
               this.mensagemDeErroExtensaoDeProblema(resposta);
            } 
            else {
            const dataModel = new JSONModel();
            dataModel.setData(resposta);

            this.getView().setModel(dataModel, "listaEstudio");
            }
         });
        },
        filtroBarraDePesquisa : function (oEvent){
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
               this.limparFiltros();
           }
         
         this.filtrosEstudioMusical();
        },
         filtrosEstudioMusical : function (){
            let url = `/api/EstudioMusical?Nome=${filtroNome}&EstaAberto=${filtroEstaAberto}&EstaFechado=${filtroEstaFechado}`;

            fetch(url).then(resposta => resposta.json()).then(resposta => {
               const dataModel = new JSONModel();
               dataModel.setData(resposta);

               this.getView().setModel(dataModel, "listaEstudio");
        });
        },
         limparFiltros : function () {
            let vazio = "";
            filtroEstaAberto = vazio;
            filtroEstaFechado = vazio;
         },
         mensagemDeErroExtensaoDeProblema: function (erro) {
            const tituloMensagem = "Erro";
            const detalhesMensagem = "Detalhes:";
            const statusMensagem = "Status:"
   
            MessageBox.error(`${erro.Title}`, {
               title: tituloMensagem,
               id: "messageBoxErro",
               details: 
               `<p><strong>${statusMensagem} ${erro.Status}</strong></p>` +
               `<p><strong> ${detalhesMensagem} </strong></p>`+
               "<ul>" +
               `<li>${erro.Detail}</li>` +
               "</ul>",
               styleClass: "sResponsivePaddingClasses",
               dependentOn: this.getView()
            });
      }
   });
});