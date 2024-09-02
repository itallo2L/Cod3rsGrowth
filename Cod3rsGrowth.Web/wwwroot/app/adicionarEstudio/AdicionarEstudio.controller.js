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
    const nenhum = "None";
    var idEditarEstudio;
    var estudio = {};

    return BaseController.extend("ui5.cod3rsgrowth.app.adicionarEstudio.AdicionarEstudio", {
        validacao: validacao,

        onInit: function () {
            const rotaTelaDeAdicionarEstudio = "appAdicionarEstudio";

            this.getRouter().getRoute(rotaTelaDeAdicionarEstudio).attachMatched(this._aoCoicidirRota, this);
        },

        _aoCoicidirRota: function (oEvent) {
            this.getView().byId(idInputEstudio).setValueState(nenhum);
            this.getView().byId(idInputEstudio).setValue("");

            this.getView().byId(idCheckBoxEstaAberto).setSelected(false);
            idEditarEstudio = this._obterIdEstudio(oEvent);
            this._verificarSeContemId();
        },

        _verificarSeContemId: function () {
            if (!idEditarEstudio)
                return;
            const view = this.getView();
            const url = `/api/EstudioMusical/${idEditarEstudio}`;
            this._obterEstudioEditar(url, view);
        },

        _obterEstudioEditar: function (url, view) {
            fetch(url).then(resposta => {
                return resposta.ok
                    ? resposta.json()
                        .then(resposta => { this._colocarValoresNosCampos(resposta) })
                    : resposta.json()
                        .then(resposta => { this.validacao.mostrarErroDeValidacao(resposta, view) })
            });
        },

        _colocarValoresNosCampos: function (estudioQueSeraAtualizado) {
            this.getView().byId(idInputEstudio).setValue(estudioQueSeraAtualizado.nome);
            this.getView().byId(idCheckBoxEstaAberto).setSelected(estudioQueSeraAtualizado.estaAberto);
        },

        _obterIdEstudio: function (oEvent) {
            let estudioId = oEvent.getParameters().arguments.estudioId;
            return estudioId;
        },

        aoClicarSalvarEstudio: function () {
            estudio.nome = this.getView().byId(idInputEstudio).getValue();

            estudio.estaAberto = this.getView().byId(idCheckBoxEstaAberto).getSelected();

            this.validacao.aoValidarEntrada(estudio.nome, this.getView());

            let urlEstudio = '/api/EstudioMusical';

            let tipoDaRequisicao;

            if (!idEditarEstudio)
                tipoDaRequisicao = 'Post';
            else {
                tipoDaRequisicao = 'Patch';
                estudio.id = idEditarEstudio;
            }

            this.requisicao(tipoDaRequisicao, urlEstudio, estudio);
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