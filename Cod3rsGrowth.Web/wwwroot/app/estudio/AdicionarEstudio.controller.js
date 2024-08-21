sap.ui.define([
    "../BaseController",
    "sap/ui/core/library",
	"sap/m/Dialog",
	"sap/m/Button",
	"sap/m/library",
	"sap/m/Text",
    "sap/m/MessageToast"
], (BaseController, coreLibrary, Dialog, Button, mobileLibrary, Text, MessageToast) => {
    "use strict";

    const nomeEstudioVazio = "";
    const idInputEstudio = "idInputEstudio";
    const idCheckBoxEstaAberto = "idCheckBoxEstaAberto";

    return BaseController.extend("ui5.cod3rsgrowth.app.estudio.AdicionarEstudio", {
        onInit: function () {
        },

        aoClicarSalvarEstudio: function () {
            let estudio = {};
            estudio.nome = this.getView().byId(idInputEstudio).getValue();
            estudio.estaAberto = this.getView().byId(idCheckBoxEstaAberto).getSelected();
            this._aovalidarEntrada(estudio.nome);

            let urlEstudio = '/api/EstudioMusical';
            this._adicionarEstudio(urlEstudio, estudio);
            
            this.getRouter().navTo("appEstudio", {}, true);
        },

        _adicionarEstudio: function (url, estudio) {
            const requestOptions = {method: 'POST', 
                body: JSON.stringify(estudio), 
                headers: {"Content-Type": "application/json"}}

              fetch(url, requestOptions).then(response => response.json()).then(response => console.log(response))
        },

        _aovalidarEntrada: function (estudio) {
            let erro = "Error";
            let sucesso = "None";

            if(estudio === nomeEstudioVazio)
                this.getView().byId(idInputEstudio).setValueState(erro);
            else
                this.getView().byId(idInputEstudio).setValueState(sucesso)
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