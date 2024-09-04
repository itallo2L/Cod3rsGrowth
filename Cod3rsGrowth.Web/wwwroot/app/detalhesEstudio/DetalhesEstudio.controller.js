sap.ui.define([
  "../BaseController",
  "ui5/cod3rsgrowth/model/formatter",
  "sap/m/MessageBox"
], (BaseController, formatter, MessageBox) => {
  "use strict";

  var estudioId;
  const existe = true;

  return BaseController.extend("ui5.cod3rsgrowth.app.detalhesEstudio.DetalhesEstudio", {
    formatter: formatter,

    onInit: function () {
      const rotaTelaDeDetalhesEstudio = "appDetalhesEstudio";
      this.getRouter().getRoute(rotaTelaDeDetalhesEstudio).attachMatched(this._obterDetalhes, this);
    },

    _obterDetalhes: function (evento, deletar) {
      estudioId = evento.getParameters().arguments.estudioId;
      const urlObterPorId = `/api/EstudioMusical/${estudioId}`;
      const view = this.getView();
      const detalhesEstudio = "detalhesEstudio";
      this.requisicaoGet(urlObterPorId, view, detalhesEstudio);
    },

    aoClicarEmEditar: function () {
      this.getRouter().navTo("appAdicionarEstudio", { estudioId: estudioId });
    },

    aoClicarEmDeletar: function () {
      let mensagemDeAviso
      MessageBox.warning(mensagemDeAviso, {
        styleClass: sResponsivePaddingClasses,
        dependentOn: this.getView(),
        actions: [MessageBox.Action.OK, MessageBox.Action.CANCEL],
        onClose: (sAction) => {
           if(sAction == MessageBox.Action.OK){
              let url = `/api/Empresa/${idEmpresa}`;
              this.deletarEmpresa(url, nomeDaEmpresa);
           }
        }
     })

      this._obterDetalhes(evento, );
    }
  });
});