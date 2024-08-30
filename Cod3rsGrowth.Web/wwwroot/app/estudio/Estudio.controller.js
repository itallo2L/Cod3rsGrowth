sap.ui.define([
   "../BaseController",
   "sap/ui/model/resource/ResourceModel",
   "sap/ui/model/json/JSONModel",
   "ui5/cod3rsgrowth/model/formatter",

], (BaseController, ResourceModel, JSONModel, formatter) => {
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

         const rotaTelaDeListagemEstudio = "appEstudio";
         this.getRouter().getRoute(rotaTelaDeListagemEstudio).attachMatched(this._atualizarListaDeEstudios, this);
      },

      _atualizarListaDeEstudios: function () {
         const urlObterTodos = "/api/EstudioMusical";
         const view = this.getView();
         const listaEstudio = "listaEstudio";
         this.requisicaoGet(urlObterTodos, view, listaEstudio);
      },

      _navegarParaDetalhes: function (id) {
         const rotaDetalhes = 'appDetalhesEstudio';
         this._navegarPara(rotaDetalhes, id);
      },

      _obterEstudioPorId: function (evento) {
         const contexto = 'listaEstudio';
         const propriedadeId = "id";
         let idEstudio = evento.getSource().getBindingContext(contexto).getProperty(propriedadeId);
         return idEstudio;
      },

      _navegarPara: function (nomeRota, id) {
         this.getRouter().navTo(nomeRota, { estudioId: id }, true);
      },

      _filtrosEstudioMusical: function () {
         let query = {};

         if (filtroNome)
            query.nome = filtroNome;

         if (filtroEstaAberto)
            query.estaAberto = filtroEstaAberto;

         if (filtroEstaFechado)
            query.estaFechado = filtroEstaFechado;

         let url = `/api/EstudioMusical?${new URLSearchParams(query)}`;

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

      aoClicarAdicionarEstudioTelaListagem: function () {
         this.getRouter().navTo("appAdicionarEstudio", {}, true);
      },

      aoClicarEmDetalhes: function (oEvent) {
         const id = this._obterEstudioPorId(oEvent);
         this._navegarParaDetalhes(id);
      }
   });
});