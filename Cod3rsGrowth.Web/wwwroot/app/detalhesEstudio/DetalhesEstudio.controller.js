sap.ui.define([
    "../BaseController",
   "ui5/cod3rsgrowth/model/formatter"
], (BaseController, formatter) => {
    "use strict";

    return BaseController.extend("ui5.cod3rsgrowth.app.detalhesEstudio.DetalhesEstudio", {
      formatter: formatter,

        onInit: function () {
            const rotaTelaDeDetalhesEstudio = "appDetalhesEstudio";
            this.getRouter().getRoute(rotaTelaDeDetalhesEstudio).attachMatched(this._obterDetalhes, this);
         },
   
         _obterDetalhes: function () {
            let posicaoId = 1;
            let estudioId = this.getOwnerComponent().getRouter().getHashChanger().getHash().split("/")[posicaoId]; 
            const urlObterTodos = `/api/EstudioMusical/${estudioId}`;
            const view = this.getView();
            const detalhesEstudio = "detalhesEstudio";
            this.requisicaoGet(urlObterTodos, view, detalhesEstudio);
         },
    });
});