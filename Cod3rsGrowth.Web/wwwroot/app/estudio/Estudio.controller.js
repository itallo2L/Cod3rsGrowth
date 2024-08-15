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
         this._obterTodos(urlEstudio, statusOk);
      },

      _obterTodos: function (url) {
         fetch(url).then(resposta => {
            return resposta.ok
               ? resposta.json()
               : resposta.json()
                  .then(resposta => { this._mensagemDeErroExtensaoDeProblema(resposta) })
         })
            .then(resposta => {
               const dataModel = new JSONModel();
               dataModel.setData(resposta);

               this.getView().setModel(dataModel, "listaEstudio");
            })
      },

      filtroBarraDePesquisa: function (oEvent) {
         filtroNome = oEvent.getSource().getValue();

         this._filtrosEstudioMusical();
      },

      filtroSelecaoEstaAberto: function (oEvent) {
         let chave = oEvent.getSource().getSelectedKey();
         if (chave === "aberto") {
            filtroEstaAberto = "true";
            filtroEstaFechado = "false";
         } else if (chave === "fechado") {
            filtroEstaFechado = "true";
            filtroEstaAberto = "false";
         } else if (chave === "todos") {
            this._limparFiltros();
         }

         this._filtrosEstudioMusical();
      },

      _filtrosEstudioMusical: function () {
         let url = `/api/EstudioMusical?Nome=${filtroNome}&EstaAberto=${filtroEstaAberto}&EstaFechado=${filtroEstaFechado}`;

         fetch(url).then(resposta => resposta.json()).then(resposta => {
            const dataModel = new JSONModel();
            dataModel.setData(resposta);

            this.getView().setModel(dataModel, "listaEstudio");
         });
      },

      _limparFiltros: function () {
         let vazio = "";
         filtroEstaAberto = vazio;
         filtroEstaFechado = vazio;
      },

      _mensagemDeErroExtensaoDeProblema: function (erro) {
         const tituloMensagem = "Erro";
         const detalhesMensagem = "Detalhes:";
         const statusMensagem = "Status:"

         MessageBox.error(`${erro.Title}`, {
            title: tituloMensagem,
            id: "messageBoxErro",
            details:
               `<p><strong>${statusMensagem} ${erro.Status}</strong></p>` +
               `<p><strong> ${detalhesMensagem} </strong></p>` +
               "<ul>" +
               `<li>${erro.Detail}</li>` +
               "</ul>",
            styleClass: "sResponsivePaddingClasses",
            dependentOn: this.getView()
         });
      }
   });
});