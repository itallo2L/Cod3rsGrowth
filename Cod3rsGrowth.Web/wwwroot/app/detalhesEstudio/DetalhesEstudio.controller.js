sap.ui.define([
  "../BaseController",
  "ui5/cod3rsgrowth/model/formatter"
], (BaseController, formatter) => {
  "use strict";

  let estudioId;

  return BaseController.extend("ui5.cod3rsgrowth.app.detalhesEstudio.DetalhesEstudio", {
    formatter: formatter,

    onInit: function () {
      const rotaTelaDeDetalhesEstudio = "appDetalhesEstudio";
      this.getRouter().getRoute(rotaTelaDeDetalhesEstudio).attachMatched(this._obterDetalhes, this);
    },

    _obterDetalhes: function (evento) {
      estudioId = evento.getParameters().arguments.estudioId;
      const urlObterTodos = `/api/EstudioMusical/${estudioId}`;
      const view = this.getView();
      const detalhesEstudio = "detalhesEstudio";
      this.requisicaoGet(urlObterTodos, view, detalhesEstudio);
    },

    aoClicarEmEditar: function () {
      this.getRouter().navTo("appAdicionarEstudio", { estudioId: estudioId }, true);
    }
  });
});