sap.ui.define([
  "../BaseController",
  "ui5/cod3rsgrowth/model/formatter",
  "sap/m/MessageBox",
  "sap/m/library",
], (BaseController, formatter, MessageBox, library) => {
  "use strict";

  var estudioId;
  var urlObterPorId;
  const detalhesEstudio = "detalhesEstudio";

  return BaseController.extend("ui5.cod3rsgrowth.app.detalhesEstudio.DetalhesEstudio", {
    formatter: formatter,

    onInit: function () {
      const rotaTelaDeDetalhesEstudio = "appDetalhesEstudio";
      this.getRouter().getRoute(rotaTelaDeDetalhesEstudio).attachMatched(this._obterDetalhes, this);
    },

    _obterDetalhes: function (evento) {
      estudioId = evento.getParameters().arguments.estudioId;
      urlObterPorId = `/api/EstudioMusical/${estudioId}`;
      const view = this.getView();
      this.requisicaoGet(urlObterPorId, view, detalhesEstudio);
    },
    
    aoClicarEmEditar: function () {
      this.getRouter().navTo("appAdicionarEstudio", { estudioId: estudioId }, true);
    },
    
    aoClicarEmDeletar: function () {
      let nomeEstudio = this.getView().byId("idNomeEstudio").getText();
      let mensagemDeletar = "deletado";
      debugger
      const view = this.getView();
      let mensagemDeAviso = `Tem ceteza de que deseja deletar o estúdio "${nomeEstudio}"?`
      var sResponsivePaddingClasses = "sapUiResponsivePadding--header sapUiResponsivePadding--content sapUiResponsivePadding--footer";
      MessageBox.warning(mensagemDeAviso, {
        styleClass: sResponsivePaddingClasses,
        dependentOn: this.getView(),
        actions: [MessageBox.Action.YES, MessageBox.Action.CANCEL],
        onClose: (sAction) => {
           if(sAction == MessageBox.Action.YES){
              this.requisicaoDelete(urlObterPorId, nomeEstudio, mensagemDeletar, view, detalhesEstudio);
           }
        }
     })
    }
  });
});