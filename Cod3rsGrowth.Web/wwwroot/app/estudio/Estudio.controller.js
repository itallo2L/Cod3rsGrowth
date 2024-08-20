sap.ui.define([
   "../BaseController",
   "sap/ui/model/resource/ResourceModel",
   "sap/ui/model/json/JSONModel",
   "../../model/formatter",
   "sap/m/MessageBox"
], (BaseController, ResourceModel, JSONModel, formatter, MessageBox) => {
   "use strict";

   const filtroVazio = "";
   var filtroNome;
   var filtroEstaAberto;
   var filtroEstaFechado;

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
         this._obterTodos(urlEstudio);
      },

      aoClicarAdicionarEstudioTelaListagem: function () {
         this.getRouter().navTo("appAdicionarEstudio", {}, true);
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

         switch (chave) {
            case 'aberto':
               this._alterarValoresFiltroSelecao(true, false);
               break;
            case 'fechado':
               this._alterarValoresFiltroSelecao(false, true);
               break;
            case 'todos':
               this._alterarValoresFiltroSelecao(filtroVazio, filtroVazio);
               break;
         }

         this._filtrosEstudioMusical();
      },

      _filtrosEstudioMusical: function () {
         let query = {};

         if (filtroNome)
            query.nome = filtroNome;

         if (filtroEstaAberto)
            query.estaAberto = filtroEstaAberto;

         if (filtroEstaFechado)
            query.estaFechado = filtroEstaFechado;

         let url = `/api/EstudioMusical?` + new URLSearchParams(query);

         fetch(url).then(resposta => resposta.json()).then(resposta => {
            const dataModel = new JSONModel();
            dataModel.setData(resposta);

            this.getView().setModel(dataModel, "listaEstudio");
         });
      },

      _alterarValoresFiltroSelecao: function (estaAberto, estaFechado) {
         filtroEstaAberto = estaAberto;
         filtroEstaFechado = estaFechado;
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