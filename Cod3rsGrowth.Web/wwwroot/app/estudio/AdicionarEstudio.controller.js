sap.ui.define([
    "../BaseController",
    "sap/ui/core/library",
    "sap/m/Dialog",
    "sap/m/Button",
    "sap/m/library",
    "sap/m/Text",
    "../servico/validacao"
], (BaseController, coreLibrary, Dialog, Button, mobileLibrary, Text, validacao) => {
    "use strict";

    const idInputEstudio = "idInputEstudio";
    const idCheckBoxEstaAberto = "idCheckBoxEstaAberto";
    const nenhum = "None"
    var estudio = {};

    return BaseController.extend("ui5.cod3rsgrowth.app.estudio.AdicionarEstudio", {
        validacao: validacao,

        onInit: function () {
            const rotaTelaDeAdicionarEstudio = "appAdicionarEstudio"
            this.getRouter().getRoute(rotaTelaDeAdicionarEstudio).attachMatched(this._limparNomeECheckBoxEstudio, this);
        },

        _limparNomeECheckBoxEstudio: function () {
            this.getView().byId(idInputEstudio).setValueState(nenhum);
            this.getView().byId(idInputEstudio).setValue("");

            this.getView().byId(idCheckBoxEstaAberto).setSelected(false);
        },

        aoClicarSalvarEstudio: function () {
            estudio.nome = this.getView().byId(idInputEstudio).getValue();
            
            estudio.estaAberto = this.getView().byId(idCheckBoxEstaAberto).getSelected();

            this.validacao.aoValidarEntrada(estudio.nome, this.getView());

            let urlEstudio = '/api/EstudioMusical';
            this.requisicaoPost(urlEstudio, estudio);
        },

        aoClicarCancelarEstudio: function () {
            if (!this.aMensagemDeCancelarEstudio) {
                this.aMensagemDeCancelarEstudio = new Dialog({
                    type: mobileLibrary.DialogType.Message,
                    title: "Aviso",
                    state: coreLibrary.ValueState.Warning,
                    content: new Text({ text: "Tem certeza que deseja cancelar a adição de um novo estúdio?" }),
                    beginButton: new Button({
                        type: mobileLibrary.ButtonType.Emphasized,
                        text: "Sim",
                        press: function () {
                            this.aMensagemDeCancelarEstudio.close();
                            this.getRouter().navTo("appEstudio", {}, true);
                        }.bind(this)
                    }),
                    endButton: new Button({
                        text: "Não",
                        press: function () {
                            this.aMensagemDeCancelarEstudio.close();
                        }.bind(this)
                    })
                });
            }
            this.aMensagemDeCancelarEstudio.open();
        }
    });
});